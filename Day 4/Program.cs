
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

for (int r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        grid[r, c] = lines[r][c];
    }
}
Console.WriteLine($"{grid[1,1]}");

for(int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.Write($"{grid[i,j]}");


    }
        Console.WriteLine();
}
