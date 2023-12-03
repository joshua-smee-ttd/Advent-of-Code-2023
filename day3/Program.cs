// See https://aka.ms/new-console-template for more information

string[] lines = File.ReadAllLines("input.txt");

// Part1(lines);

Part2(lines);

void Part1(string[] strings)
{
    int sum = 0;

    int currNum = 0;
    bool part = false;

    for (int y = 0; y < strings.Length; y++)
    {
        for (int x = 0; x < strings[0].Length; x++)
        {
            if (Char.IsDigit(strings[y][x]))
            {
                currNum = currNum * 10 + (strings[y][x] - '0');


                for (int xChange = -1; xChange <= 1; xChange++)
                {
                    for (int yChange = -1; yChange <= 1; yChange++)
                    {
                        if (x + xChange >= strings[0].Length || x + xChange < 0)
                        {
                            continue;
                        }

                        if (y + yChange >= strings.Length || y + yChange < 0)
                        {
                            continue;
                        }

                        if (!Char.IsDigit(strings[y + yChange][x + xChange]) &&
                            strings[y + yChange][x + xChange] != '.')
                        {
                            part = true;
                        }
                    }
                }
            }
            else
            {
                if (part)
                {
                    sum += currNum;
                }

                currNum = 0;
                part = false;
            }
        }
    }

    Console.WriteLine(sum);
}

void Part2(string[] strings)
{
    long sum = 0;

    int?[,] nums = new int?[strings.Length,strings[0].Length];

    for (int y = 0; y < strings.Length; y++)
    {
        int? num = null;
        int startIdx = 0;
        for (int x = 0; x < strings[0].Length; x++)
        {
            if (Char.IsDigit(strings[y][x]))
            {
                if (num == null)
                {
                    num = strings[y][x] - '0';
                    startIdx = x;
                }
                else
                {
                    num = num * 10 + strings[y][x] - '0';
                }
            }
            else
            {
                if (num != null)
                {
                    for (int xCurr = startIdx; xCurr < x; xCurr++)
                    {
                        nums[y, xCurr] = num;
                    }
                }

                nums[y, x] = null;
                num = null;
            }
        }
        if (num != null)
        {
            for (int xCurr = startIdx; xCurr < strings[0].Length; xCurr++)
            {
                nums[y, xCurr] = num;
            }
        }
    }

    for (int y = 0; y < strings.Length; y++)
    {
        for (int x = 0; x < strings[0].Length; x++)
        {
            if (strings[y][x] != '*') continue;
            
            List<int> numbers = new List<int>();
            for (int yChange = -1; yChange <= 1; yChange++)
            {
                bool inNum = false;
                for (int xChange = -1; xChange <= 1; xChange++) 
                {
                    if (x + xChange >= strings[0].Length || x + xChange < 0)
                    {
                        continue;
                    }
    
                    if (y + yChange >= strings.Length || y + yChange < 0)
                    {
                        continue;
                    }

                    if (nums[y + yChange, x + xChange] != null )
                    {
                        if (inNum) continue;
                        
                        numbers.Add((int)nums[y + yChange, x + xChange]!);
                        inNum = true;
                    }
                    else
                    {
                        inNum = false;
                    }
                }
            }
            
            if (numbers.Count != 2) continue;

            sum += numbers[0] * numbers[1];
        }
    }
    
    Console.WriteLine(sum);
}