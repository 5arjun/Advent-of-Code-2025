static int GetDigitFromString(int number, int position)
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
try
{
    string fileContents = File.ReadAllText(filePath);
    //Console.WriteLine("File contents:\n" + fileContents);

    char tokenComma = ',';
    char tokenDash = '-';
    string[] ranges = fileContents.Split(tokenComma);

    foreach (string numberRange in ranges)
    {
        //Console.WriteLine(numberRange);
        string[] twoNums = numberRange.Split(tokenDash);

        if (twoNums[0].TrimStart('0').Length % 2 != 0 && twoNums[1].TrimStart('0').Length % 2 != 0)
        {
            Console.WriteLine($"Both ranges has odd number of digits ({twoNums[0]}-{twoNums[1]})");
            continue;
        }

        int lowerRangeInt = int.Parse(twoNums[0]);
        int upperRangeInt = int.Parse(twoNums[1]);
        for (int i = lowerRangeInt; i <= upperRangeInt; i++)
        {
            for (int j = 0; j < i.ToString().Length / 2; j++)
            {
                if (GetDigitFromString(i, j) == GetDigitFromString(i, j + i.ToString().Length / 2))
                {

                    Console.WriteLine($"{i}: digit at {j} is the same gang");
                }

            }
        }

        foreach (string number in twoNums)
        {
            //Console.WriteLine($"{number} is a part of {string.Join("-", twoNums)}");
        }

    }

}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}