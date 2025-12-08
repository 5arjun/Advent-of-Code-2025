using System.IO;


string filePath = "input.txt";
string[] lines = File.ReadAllLines(filePath);

bool gettingRanges = true;
char tokenDash = '-';
List<(long Min, long Max)> ranges = new List<(long, long)>();

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
}
