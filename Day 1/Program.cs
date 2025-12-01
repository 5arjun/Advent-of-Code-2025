int GetDial(int num, string rotation)
{
    int value = int.Parse(rotation.Substring(1));
    if (rotation[0] == 'L') num -= value;
    else num += value;
    num %= 100;
    if (num < 0) num += 100;
    return num;
}

int totalZeroCount = 0;
int num = 50;
string filePath = "input.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            int amount = int.Parse(line.Substring(1));
            char dir = line[0];
            
            int start = num;
            
            // Key: calculate how many times we pass 0 DURING this rotation
            if (dir == 'R')
            {
                // Right: passes 0 when crossing from 99→0
                int distanceToZero = (100 - start) % 100;
                if (amount >= distanceToZero)
                    totalZeroCount++;  // passes 0 at least once
                totalZeroCount += amount / 100;  // full circles
            }
            else  // 'L'
            {
                // Left: passes 0 when crossing from 0→99  
                if (amount >= start)
                    totalZeroCount++;  // passes 0 at least once
                totalZeroCount += amount / 100;  // full circles
            }
            
            num = GetDial(num, line);
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
