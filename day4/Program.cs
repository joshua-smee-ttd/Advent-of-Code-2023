// See https://aka.ms/new-console-template for more information

using day4;

string[] lines = File.ReadAllLines("input.txt");

Part2(lines);

void Part1(string[] lines)
{
    int[] scores = lines.Select(s =>
    {
        String input = s.Split(':')[1];
        Console.WriteLine(input);
        Card card = Card.ParseString(input);
        return card.GetPoints();
    }).ToArray();

    int score = scores.Sum();

    Console.WriteLine(score);
}

void Part2(string[] lines)
{
    int[] scores = lines.Select(s =>
    {
        String input = s.Split(':')[1];
        Card card = Card.ParseString(input);
        return card.NumWinning();
    }).ToArray();
    
    Console.WriteLine("[{0}]", string.Join(", ", scores));

    
    int[] gameNumbers = Enumerable.Repeat(1, scores.Length).ToArray();
    
    for (int i = 0; i < scores.Length; i++)
    {
        Console.WriteLine("[{0}]", string.Join(", ", gameNumbers));
        for (int range = i + 1; range <= i + scores[i] && range < scores.Length; range++)
        {
            gameNumbers[range] += gameNumbers[i];
        }
    }
    
   

    int sum = gameNumbers.Sum();
    
    Console.WriteLine(sum);
}