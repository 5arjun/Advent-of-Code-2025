static int GetDigitFromString(long number, int position) // Updated to long
{
    // Position is 0-based, where 0 is the leftmost digit.
    // Example: GetDigitFromString(12345, 0) returns 1, GetDigitFromString(12345, 2) returns 3.

    string numberString = number.ToString();
    if (position < 0 || position >= numberString.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range for the given number.");
    }
        // Convert the character at the specified position back to an integer.

    return int.Parse(numberString[position].ToString());
}

string filePath = "input.txt";
long total = 0;
try
{
    string fileContents = File.ReadAllText(filePath);
    char tokenComma = ',';
    char tokenDash = '-';
    string[] ranges = fileContents.Split(tokenComma);

    foreach (string numberRange in ranges)
    {
        string[] twoNums = numberRange.Split(tokenDash);

        if (twoNums[0].TrimStart('0').Length % 2 != 0 && twoNums[1].TrimStart('0').Length % 2 != 0)
        {
            //Console.WriteLine($"Both ranges has odd number of digits ({twoNums[0]}-{twoNums[1]})... skipping");
            continue;
        }

        long lowerRangeLong = long.Parse(twoNums[0]);  
        long upperRangeLong = long.Parse(twoNums[1]);  
        
        for (long i = lowerRangeLong; i <= upperRangeLong; i++)  
        {
            int symmetryCount = 0;
            string numStr = i.ToString();  
            int length = numStr.Length;
            int half = length / 2;
            
            for (int j = 0; j < half; j++)
            {
                if (GetDigitFromString(i, j) == GetDigitFromString(i, j + half))
                {
                    symmetryCount++;
                }
                if (symmetryCount == half)  
                {
                    //Console.WriteLine($"{i} has sequence repeated twice gangy");
                    total += i;
                    break;  
                }
            }
        }
    }
    Console.WriteLine($"TOTAL IS: {total}");
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}