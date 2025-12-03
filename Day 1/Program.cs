using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SafeDialSolver
{
    static int CountZeroCrossings(List<string> rotations)
    {
        int position = 50;
        int zeroCount = 0;
        
        foreach (string rotation in rotations)
        {
            char direction = rotation[0];
            int distance = int.Parse(rotation.Substring(1));
            
            if (direction == 'R')
            {
                // Rotating right (toward higher numbers)
                // Count how many times we pass through 0
                int crossings = (position + distance) / 100;
                zeroCount += crossings;
                // Update position
                position = (position + distance) % 100;
            }
            else // direction == 'L'
            {
                // Rotating left (toward lower numbers)
                // Count how many times we pass through 0
                int crossings = distance > position ? (distance - position + 99) / 100 : 0;
                zeroCount += crossings;
                // Update position
                position = ((position - distance) % 100 + 100) % 100;
            }
        }
        
        return zeroCount;
    }
    
    static void Main()
    {
        // Example from the puzzle
        var exampleRotations = new List<string>
        {
            "L68", "L30", "R48", "L5", "R60", 
            "L55", "L1", "L99", "R14", "L82"
        };
        
        Console.WriteLine("Example trace:");
        int position = 50;
        int zeroCount = 0;
        Console.WriteLine($"Start: position = {position}");
        
        foreach (string rotation in exampleRotations)
        {
            char direction = rotation[0];
            int distance = int.Parse(rotation.Substring(1));
            
            int crossings;
            if (direction == 'R')
            {
                crossings = (position + distance) / 100;
                position = (position + distance) % 100;
            }
            else
            {
                crossings = distance > position ? (distance - position + 99) / 100 : 0;
                position = ((position - distance) % 100 + 100) % 100;
            }
            
            zeroCount += crossings;
            Console.WriteLine($"{rotation}: position = {position}, crossings = {crossings}, total = {zeroCount}");
        }
        
        Console.WriteLine($"\nExample result: {zeroCount}");
        Console.WriteLine($"Expected: 6\n");
        
        // Read puzzle input from file
        try
        {
            string[] lines = File.ReadAllLines("input.txt");
            var puzzleInput = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
            
            int result = CountZeroCrossings(puzzleInput);
            Console.WriteLine($"Puzzle answer: {result}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: input.txt not found in the current directory.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }
}