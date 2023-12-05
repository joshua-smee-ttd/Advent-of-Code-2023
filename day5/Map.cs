namespace day5;

public class Map
{
    public long source;
    public long destination;
    public long range;

    public Map(long source, long destination, long range)
    {
        this.source = source;
        this.destination = destination;
        this.range = range;
        
    }

    public static Map ParseString(String input)
    {
        long[] intInput = input.Split(' ').Select(s => long.Parse(s.Trim())).ToArray();
        

        return new Map(intInput[1], intInput[0], intInput[2]);
    }
    
    public long MapInt(long input)
    {
        
        if (input >= source && input < source + range)
        {
            return destination + (input - source);
        }

        return input;
    }
}