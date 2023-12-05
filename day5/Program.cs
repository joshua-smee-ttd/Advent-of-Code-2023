
using day5;

string[] lines = File.ReadAllLines("input.txt");

long[] seedInputs = lines[0].Split(':')[1].Trim().Split(' ').Select(long.Parse).ToArray();

List<Seed> currSeeds = new List<Seed>();

for (var i = 0; i < seedInputs.Length; i+=2)
{
    currSeeds.Add(new Seed(seedInputs[i], seedInputs[i + 1]));
}

List<Transform> transforms = new List<Transform>();

Transform? currTransform = null;

for (var i = 2; i < lines.Length; i++)
{
    if (lines[i].Contains(':'))
    {
        currTransform = new Transform();
        transforms.Add(currTransform);
        
    } else if (lines[i] != "")
    {
        Map currMap = Map.ParseString(lines[i]);
        
        currTransform?.maps.Add(currMap);
    }
}

foreach (var transform in transforms)
{
    List<Seed> newSeeds = new List<Seed>();

    foreach (var currSeedSet in currSeeds)
    {
        List<Seed> seedOutcome = transform.maps.Aggregate(new List<Seed>() { currSeedSet }, (seedList, map) =>
        {
            List<Seed> newSeedList = new List<Seed>();
            newSeedList.AddRange(seedList.Where(seed => seed.changed));
            
            foreach (var seed in seedList.Where(seed => !seed.changed))
            {
                newSeedList.AddRange(seed.Split(map));
            }

            return newSeedList;
        });

        newSeeds.AddRange(seedOutcome);
    }

    foreach (var newSeed in newSeeds)
    {
        newSeed.changed = false;
    }
    
    currSeeds = newSeeds;
}

// Console.WriteLine("FINAL");
// foreach (var currSeed in currSeeds)
// {
//     Console.WriteLine(String.Format("{0} {1}", currSeed.start, currSeed.range));
// }
Console.WriteLine("RESULT");
Console.WriteLine(currSeeds.Where(seed => seed.start != 0).Min(seed => seed.start));



