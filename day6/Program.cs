using day6;

string[] lines = File.ReadAllLines("input.txt");

long[] times = lines[0].Split(":")[1].Split(" ").Where(s => s != "").Select(long.Parse).ToArray();
long[] distances = lines[1].Split(":")[1].Split(" ").Where(s => s != "").Select(long.Parse).ToArray();

List<Race> races = new List<Race>();

for (var i = 0; i < times.Length; i++)
{
    races.Add(new Race(distances[i], times[i]));
}

long start = 1;
long output = races.Aggregate(start, (i, race) => i * race.NumBetter());

Console.WriteLine(output);