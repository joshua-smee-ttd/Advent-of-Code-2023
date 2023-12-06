namespace day6;

public class Race
{
    public long distance;
    public long time;

    public Race(long distance, long time)
    {
        this.distance = distance;
        this.time = time;
    }

    public long NumBetter()
    {
        long numBetter = 0;
        for (int windup = 0; windup <= time; windup++)
        {
            if (RaceDistance(windup) > distance) numBetter++;
        }
        
        return numBetter;
    }

    private long RaceDistance(long windup)
    {
        return (time - windup) * windup;
    }
    
}