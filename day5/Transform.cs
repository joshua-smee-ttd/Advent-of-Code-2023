namespace day5;

public class Transform
{
    public List<Map> maps = new List<Map>();


    public long MapInt(long input)
    {
        foreach (var map in maps)
        {
            long output = map.MapInt(input);

            if (output != input)
            {
                return output;
            }
        }

        return input;
    }
}