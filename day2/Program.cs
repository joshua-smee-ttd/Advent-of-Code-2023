// See https://aka.ms/new-console-template for more information

using day2;

string[] lines = File.ReadAllLines("input.txt");

part1(lines);
part2(lines);

void part1(string[] lines)
{
    List<Game> games = new List<Game>();

    foreach (string line in lines)
    {
        string[] split = line.Split(':');

        int index = Convert.ToInt32(split[0].Split()[1]);
        Game game = new Game(index);

        String[] revealStrings = split[1].Split(';');
        foreach (var revealString in revealStrings)
        {
            game.reveals.Add(Reveal.ParseString(revealString));
        }

        if (game.valid())
        {
            games.Add(game);
        }
    }

    int result = games.Aggregate(0, (i, game) => i + game.idx);

    Console.WriteLine(result);
}

void part2(string[] lines)
{
    List<Game> games = new List<Game>();

    foreach (string line in lines)
    {
        string[] split = line.Split(':');

        int index = Convert.ToInt32(split[0].Split()[1]);
        Game game = new Game(index);

        String[] revealStrings = split[1].Split(';');
        foreach (var revealString in revealStrings)
        {
            game.reveals.Add(Reveal.ParseString(revealString));
        }

        games.Add(game);
    }

    int result = games.Aggregate(0, (i, game) => i + game.GetPower());

    Console.WriteLine(result);
}