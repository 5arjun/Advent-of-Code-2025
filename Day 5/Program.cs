using System.IO;


string filePath = "input.txt";
string[] lines = File.ReadAllLines(filePath);

bool gettingRanges = true;
char tokenDash = '-';
List<(long Min, long Max)> ranges = new List<(long, long)>(); //list to store each pair of ranges
int valid = 0; //tracks how many id's are valid

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

    }
    else
    {
        long id = (long)double.Parse(line); //food id


        foreach (var range in ranges)//loops through ranges
        {
            if (id >= range.Min && id <= range.Max)
            {
                valid++;
                break; // no need to check further ranges
            }
        }
    }
}
Console.WriteLine($"Valid total: {valid}");
