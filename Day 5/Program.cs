using System.IO;


string filePath = "input.txt";
string[] lines = File.ReadAllLines(filePath);

bool gettingRanges = true;
char tokenDash = '-';
List<(long Min, long Max)> ranges = new List<(long, long)>();
int valid = 0;

foreach (string line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        gettingRanges = false;
        continue;
    }
    if (gettingRanges)
    {
        string[] tokens = line.Split(tokenDash);
        long start = (long)double.Parse(tokens[0]);
        long end = (long)double.Parse(tokens[1]);

        ranges.Add((start, end));

        Console.WriteLine($"{line}");
    }
    else
    {
        long id = (long)double.Parse(line); //food id

        //bool isFresh = false;

        foreach (var range in ranges)//loops thru ranges
        {
            if (id >= range.Min && id <= range.Max)
            {
                //isFresh = true;
                valid++;
                break; // no need to check further ranges
            }
        }

        // now isFresh tells you whether this ID was in any range

    }
}
Console.WriteLine($"Valid total: {valid}");
