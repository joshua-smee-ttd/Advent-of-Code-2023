namespace day4;

public class Card
{
    public int[] winning;
    public int[] numbers;

    public Card(int[] winning, int[] numbers)
    {
        this.winning = winning;
        this.numbers = numbers;
    }

    public static Card ParseString(String input)
    {
        string[] parts = input.Split('|');

        return new Card(ParseList(parts[0]), ParseList(parts[1]));
    }

    private static int[] ParseList(String input)
    {
        input = input.Trim();
        string[] numbers = input.Split(' ').Where(s => s != "" ).ToArray();
        
        return numbers.Select(s => Int32.Parse(s.Trim())).ToArray();
    }

    public int GetPoints()
    {
        var numWinning = NumWinning();
                
        if (numWinning == 0)
        {
            return 0;
        }

        return (int)Math.Pow(2, numWinning - 1);
    }

    public int NumWinning()
    {
        return numbers.Count(i => winning.Contains(i));
    }
}