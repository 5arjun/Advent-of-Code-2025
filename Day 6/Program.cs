// See https://aka.ms/new-console-template for more information
string[] lines = File.ReadAllLines("input.txt");
int rows = lines.Length - 1; 
int cols = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

int[,] numbers = new int[rows, cols]; //2d array of just numbers
string[] operators = new string[cols];// array of operators

for (int i = 0; i < rows; i++)
{
    string[] parts = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j < cols; j++)
    {
        numbers[i, j] = int.Parse(parts[j]);
    }
}

// Parse operators
string[] opParts = lines[rows].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
for (int j = 0; j < cols; j++)
{
    operators[j] = opParts[j];
}

for(int j = 0; j < cols; j++)
{
    
}