using System.Runtime.InteropServices.JavaScript;

namespace day2;

public class Reveal
{

    public static string[] colours = new[] { "red", "green", "blue" };
    
    private Dictionary<String, int> maxColours = new Dictionary<string, int> {
        {"red",12}, {"green",13}, {"blue",14}
    };
    

    public Dictionary<String, int> colourAmounts;

    public Reveal(Dictionary<String, int> colourAmounts)
    {
        this.colourAmounts = colourAmounts;
    }

    public static Reveal ParseString(String inputs)
    {
        string[] seperatedInputs = inputs.Split(',');
        
        
        Dictionary<String, int> dict = new Dictionary<string, int>();
        
        foreach (var seperatedInput in seperatedInputs)
        {
            string trimInput = seperatedInput.Trim();
            string[] numsColour = trimInput.Split(' ');
            
            dict.Add(numsColour[1], Convert.ToInt32(numsColour[0]));
        }
        

        return new Reveal(dict);
    }

    public bool valid()
    {
        foreach(KeyValuePair<string, int> entry in colourAmounts)
        {
            if (maxColours[entry.Key] < entry.Value)
            {
                return false;
            }
        }

        return true;
    }

    public int checkColour(string colour)
    {
        int value = 0;
        
        if (colourAmounts.TryGetValue(colour, out value))
        {
            return value;
        }
        
        return 0;
    }
    
}