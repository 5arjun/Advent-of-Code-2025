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
int totalZeroCount = 0;   // total times landed on OR crossed 0
int num = 50;

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
            int amount = int.Parse(line.Substring(1));
            char dir = line[0];

            // count passes DURING rotation
            int passesDuring = amount / 100;  // full circles passing 0

            // add if landed exactly on 0
            if (end == 0)
                passesDuring++;

            // total for this move
            totalZeroCount += passesDuring;

            num = end;

        }
    }

    Console.WriteLine(totalZeroCount);
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (IOException ex)
{
    Console.WriteLine($"An I/O error occurred: {ex.Message}");
}
