using System;
using System.Globalization;
using System.IO;

int zeroCount = 0;
int num = 50;

int getDial(int num, string rotation)
{
    
    return num;
}

public class StreamReaderExample
{
    public static void Main(string[] args)
    {
        string filePath = "input.txt"; // Replace with your file path

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Console.WriteLine("yuh");

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
    }
}