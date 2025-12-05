
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
int accessibleRolls = 0;

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        //check only rolls of paper
        if (grid[i, j] != '@') continue;

        int neighborCount = 0;

        // Check all 8 surrounding positions if in bounds
        if (i > 0 && j > 0 && grid[i - 1, j - 1] == '@') neighborCount++;         // NW
        if (i > 0 && grid[i - 1, j] == '@') neighborCount++;                       // N
        if (i > 0 && j < cols - 1 && grid[i - 1, j + 1] == '@') neighborCount++;  // NE

        if (j > 0 && grid[i, j - 1] == '@') neighborCount++;                       // W
        if (j < cols - 1 && grid[i, j + 1] == '@') neighborCount++;               // E

        if (i < rows - 1 && j > 0 && grid[i + 1, j - 1] == '@') neighborCount++;  // SW
        if (i < rows - 1 && grid[i + 1, j] == '@') neighborCount++;               // S
        if (i < rows - 1 && j < cols - 1 && grid[i + 1, j + 1] == '@') neighborCount++; // SE

        //accessible if less than 4 neighboring rolls
        if (neighborCount < 4)
        {
            accessibleRolls++;
            grid[i, j] = '.';

            //Console.WriteLine($"Accessible roll at [{i},{j}] with {neighborCount} neighbors");
        }

    }
}

// for (int i = 0; i < rows; i++)
// {
//     for (int j = 0; j < cols; j++)
//     {
//         Console.Write($"{grid[i, j]}");
//     }
//     Console.WriteLine();
// }
Console.WriteLine($"Accessible Rolls: {accessibleRolls}");
