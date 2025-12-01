int getDial(int num, string rotation)
{
    int value = int.Parse(rotation.Substring(1)); 

    // move left or right
    if (rotation[0] == 'L')
        num -= value;
    else
        num += value;

    // wrap between 0..99
    num %= 100;          
    if (num < 0) num += 100;

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
                num = getDial(num, line);
                if (num == 0) zeroCount++; 
                Console.WriteLine(num);
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
