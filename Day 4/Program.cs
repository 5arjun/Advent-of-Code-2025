string filePath = "input.txt";

try
{
    string fileContents = File.ReadAllText(filePath);
    Console.WriteLine($"{fileContents}");
}

catch (FileNotFoundException)
{
    Console.WriteLine($"Error: The file '{filePath}' was not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}