


using System.Net.Mime;
Part1();
Part2();

void Part1()
{
    try
    {
        int sum = 0;
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader("input.txt");
        //Read the first line of text
        string? line = sr.ReadLine();
        //Continue to read until you reach end of file
        while (line != null)
        {
            int? firstNum = null;
            int? lastNum = null;

            foreach (char c in line)
            {
                if (Char.IsNumber(c))
                {
                    int val = c - '0';
                
                    firstNum ??= val;
                    lastNum = val;
                }
            }
        

            sum += (firstNum ?? 0) * 10 + (lastNum ?? 0);
        
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
    
        Console.WriteLine(sum);
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
}

void Part2()
{
    try
    {
        IDictionary<string, int> numberNames = new Dictionary<string, int>();
        numberNames.Add("one", 1);
        numberNames.Add("two", 2);
        numberNames.Add("three", 3);
        numberNames.Add("four", 4);
        numberNames.Add("five", 5);
        numberNames.Add("six", 6);
        numberNames.Add("seven", 7);
        numberNames.Add("eight", 8);
        numberNames.Add("nine", 9);
        
        int sum = 0;
        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader("input.txt");
        //Read the first line of text
        string? line = sr.ReadLine();
        //Continue to read until you reach end of file
        while (line != null)
        {
            int? firstNum = null;
            int? lastNum = null;

            int i = 0;
            while (i < line.Length)
            {
                int? val = null;
                if (Char.IsNumber(line[i]))
                {
                    val = line[i] - '0';
                
                    firstNum ??= val;
                    lastNum = val;
                }
                else
                {
                    val = CheckVal(line, i, numberNames);
                }

                if (val != null)
                {
                    firstNum ??= val;
                    lastNum = val;
                }
                
                i++;
            }

            sum += (firstNum ?? 0) * 10 + (lastNum ?? 0);
        
            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
    
        Console.WriteLine(sum);
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
}

int? CheckVal(string s, int idx, IDictionary<string, int> numberNames)
{
    for (int length = 3; length <= 5 && idx + length <= s.Length; length++)
    {
        string subString = s.Substring(idx, length);
        if (numberNames.TryGetValue(subString, out var val))
        {
            return val;
        }
    }

    return null;
}
