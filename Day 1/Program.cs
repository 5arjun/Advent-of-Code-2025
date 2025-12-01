int GetDial(int num, string rotation)
{
    int value = int.Parse(rotation.Substring(1));

    // move left or right
    if (rotation[0] == 'L')
        num -= value;
    else
        num += value;

    // wrap between 0 and 99
    num %= 100;
    if (num < 0) num += 100;

    return num;
}

int zeroCount = 0;        // times landed exactly on 0
int crossedZeroCount = 0; // times passed through 0 (wrapped)
int num = 50;             // starting dial

string filePath = "input.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            int start = num;
            int end = GetDial(num, line);

            // landed exactly on 0
            if (end == 0)
                zeroCount++;

            // crossed 0 (wrapped around)
            char dir = line[0];
            if ((dir == 'R' && end < start) ||   // wrapped past 99 -> 0
                (dir == 'L' && end > start))     // wrapped past 0 -> 99
            {
                crossedZeroCount++;
            }

            num = end; // update current dial
        }
    }

    Console.WriteLine($"Landed on 0: {zeroCount}");
    Console.WriteLine($"Crossed 0: {crossedZeroCount}");
    int total = zeroCount + crossedZeroCount;
    Console.WriteLine($"Total: {total}");
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (IOException ex)
{
    Console.WriteLine($"An I/O error occurred: {ex.Message}");
}
