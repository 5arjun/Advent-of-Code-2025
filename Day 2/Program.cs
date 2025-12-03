

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
        foreach(string number in twoNums)
        {
            Console.WriteLine($"{number} is a part of {string.Join("-", twoNums)}");
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