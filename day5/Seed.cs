namespace day5;

public class Seed
{
    public long start;
    public long range;
    public bool changed;


    public Seed(long start, long range, bool changed = false)
    {
        this.start = start;
        this.range = range;
        this.changed = changed;
    }

    public List<Seed> Split(Map map)
    {
        if (map.source > start + range - 1 || map.source + map.range - 1 < start)
        {
            Console.WriteLine("TESTING");
            return new List<Seed>() { this };
        }

        Console.WriteLine("HERE");
        
        changed = true;

        List<Seed> returnList = new List<Seed>{this};
        
        if (map.source > start)
        {
            Seed startSeed = new Seed(start, map.source - start);
            returnList.Add(startSeed);
            start = map.source;
            range -= startSeed.range;
        }

        if (map.source + map.range < start + range)
        {
            Seed endSeed = new Seed(map.source + map.range, start + range - map.source - map.range);
            returnList.Add(endSeed);
            range -= endSeed.range;
        }

        start = map.destination + (start - map.source);

        return returnList;
    }
}