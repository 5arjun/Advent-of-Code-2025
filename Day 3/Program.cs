string filePath = "input.txt";


try
{
    string fileContents = File.ReadAllText(filePath);
    // Console.WriteLine($"{fileContents}");
    string[] banks = fileContents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string bank in banks)
    {
        char[] bankCharArray = bank.ToCharArray();
        int[] bankIntArray = Array.ConvertAll(bankCharArray, c => (int)Char.GetNumericValue(c));

        int length = bankIntArray.Length;
        int largest = 0;

        for (int i = 0; i < length; i++)
        {
            int j = length - 1;
            while (i < j)
            {
                int sum = bankIntArray[i] * 10 + bankIntArray[j];
                if (sum > largest) largest = sum;
                j--;
            }
        }
        Console.WriteLine($"largest of bank {bank}= {largest}");
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