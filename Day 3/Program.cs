string filePath = "input.txt";

try
{
    string fileContents = File.ReadAllText(filePath);
    string[] banks = fileContents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    int total = 0; //tracks total jolts


    foreach (string bank in banks)
    {
        //converting from string to char array to int array lol 
        char[] bankCharArray = bank.ToCharArray();
        int[] bankIntArray = Array.ConvertAll(bankCharArray, c => (int)Char.GetNumericValue(c));

        int length = bankIntArray.Length;
        int largest = 0;
        int bestTensDigit = 0;
        for (int i = 0; i < length; i++) //loop for *10 number
        {
            if (bankIntArray[i] > bestTensDigit)
            {
                bestTensDigit = bankIntArray[i];
            }

            int sum = bestTensDigit * 10 + bankIntArray[i];
            if (sum > largest) largest = sum;

            if (largest == 99)
            {
                break; //breaks since 99 is the highest poss joltage
            }

        }
        Console.WriteLine($"largest of bank {bank}= {largest}");
        total += largest;
    }
    Console.WriteLine($"TOTAL = {total}");

}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

//total should be 17343