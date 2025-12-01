
int getDial(int num, string rotation)
{
    char plusMinus = rotation[0];
    int value = int.Parse(rotation.Substring(1));
    Console.WriteLine(value);
    return num;
}
int zeroCount = 0;
int num = 50;




    string filePath = "input.txt"; 

    try
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                getDial(num, line);
            }
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Error: The file '{filePath}' was not found.");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"An I/O error occurred: {ex.Message}");
    }
