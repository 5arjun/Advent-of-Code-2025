
// ..@@.@@@@.
// @@@.@.@.@@
// @@@@@.@.@@
// @.@@@@..@.
// @@.@@@@.@@
// .@@@@@@@.@
// .@.@.@.@@@
// @.@@@.@@@@
// .@@@@@@@@.
// @.@.@@@.@.
string[] lines = File.ReadAllLines("input.txt");
int rows = lines.Length;  
int cols = lines[0].Length;  
char[,] grid = new char[rows, cols];

for (int r = 0; r < rows; r++)//making 2d array
{
    for (int c = 0; c < cols; c++)
    {
        grid[r, c] = lines[r][c];
    }
}

for(int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write($" value of [{i},{j}]: {grid[i,j]}");
        
        // Check 8 surrounding positions safely
        if (i > 0 && j > 0)           Console.Write($" NW: {grid[i-1,j-1]}");
        if (i > 0)                     Console.Write($" N: {grid[i-1,j]}");
        if (i > 0 && j < cols-1)      Console.Write($" NE: {grid[i-1,j+1]}");
        
        if (j > 0)                     Console.Write($" W: {grid[i,j-1]}");
                                    // Center is always valid: grid[i,j]
        if (j < cols-1)               Console.Write($" E: {grid[i,j+1]}");
        
        if (i < rows-1 && j > 0)      Console.Write($" SW: {grid[i+1,j-1]}");
        if (i < rows-1)               Console.Write($" S: {grid[i+1,j]}");
        if (i < rows-1 && j < cols-1) Console.Write($" SE: {grid[i+1,j+1]}");
        
        Console.WriteLine();
    }
}
