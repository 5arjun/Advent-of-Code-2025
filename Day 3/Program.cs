string filePath = "input.txt";


try
{
    string fileContents = File.ReadAllText(filePath);
    // Console.WriteLine($"{fileContents}");
    string[] banks = fileContents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string bank in banks)
    {
        //Console.WriteLine($"{bank}");
        char[] bankArray = bank.ToCharArray();
        Console.WriteLine($"{bankArray[0]}");

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