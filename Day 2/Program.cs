static int GetDigitFromString(long number, int position) // founf this func online
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
    string[] ranges = fileContents.Split(tokenComma); //splits the file into ranges first

    foreach (string numberRange in ranges)
    {
        string[] twoNums = numberRange.Split(tokenDash); //then splits into individual numbers
        long lowerRangeLong = long.Parse(twoNums[0]); //from string to long
        long upperRangeLong = long.Parse(twoNums[1]);

        for (long i = lowerRangeLong; i <= upperRangeLong; i++)
        {
            string numStr = i.ToString();
            int length = numStr.Length; //gets the length of the int 

            // Only even length numbers can be invalid
            if (length % 2 != 0) continue;

            int half = length / 2;
            bool isInvalid = true;

            for (int j = 0; j < half; j++)
            {
                if (GetDigitFromString(i, j) != GetDigitFromString(i, j + half)) //if digit in first half isnt equal to digit in second half
                {
                    isInvalid = false;
                    break;
                }
            }

            if (isInvalid) //adds it to the total 
            {
                total += i;
            }
        }
    }
    Console.WriteLine($"TOTAL IS: {total} gang");
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}