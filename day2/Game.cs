namespace day2;

public class Game
{
    public int idx;
    public List<Reveal> reveals;


    public Game(int idx)
    {
        this.idx = idx;
        this.reveals = new List<Reveal>();
    }

    public bool valid()
    {
        return reveals.Aggregate(true, ((b, reveal) => b && reveal.valid()));
    }


    public int GetPower()
    {
        return Reveal.colours.Aggregate(1, ((i, colour) =>
        i * HighestOfColour(colour)
        ));
    }

    private int HighestOfColour(string colour)
    {
        int val = reveals.Aggregate(0, (i1, reveal) => reveal.checkColour(colour) > i1 ?  reveal.checkColour(colour) : i1);

        Console.WriteLine(val);
        Console.WriteLine(colour);
        
        return val;
    }
}

