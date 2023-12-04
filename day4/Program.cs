// See https://aka.ms/new-console-template for more information

using day4;

string[] lines = File.ReadAllLines("input.txt");

int[] scores = lines.Select(s =>
{
    String input = s.Split(':')[1];
    Console.WriteLine(input);
    Card card = Card.ParseString(input);
    return card.GetPoints();
}).ToArray();

int score = scores.Sum();

Console.WriteLine(score);