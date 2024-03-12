
using System.Security.Cryptography;

int size = int.Parse(Console.ReadLine());
string carNumber = Console.ReadLine();

string[,] matrix = new string[size, size];

bool isFirstTunnelFound = false;

int firstTunnelRow = 0;
int firstTunnelCol = 0;

int secondTunnelRow = 0;
int secondTunnelCol = 0;

for (int row = 0; row < size; row++)
{
    string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

	for (int col = 0; col < size; col++)
	{
        if (data[col] == "T")
        {
            if (!isFirstTunnelFound)
            {
                firstTunnelRow = row;
                firstTunnelCol = col;
                isFirstTunnelFound = true;
            }
            else
            {
                secondTunnelRow = row;
                secondTunnelCol = col;
            }
        }

		matrix[row, col] = data[col];
	}
}

string command = string.Empty;

int carRow = 0;
int carCol = 0;

int kmPassed = 0;

while ((command = Console.ReadLine()) != "End")
{
    if (command == "left")
    {
        carCol--;
    }
    else if (command == "right")
    {
        carCol++;
    }
    else if (command == "up")
    {
        carRow--;
    }
    else if (command == "down")
    {
        carRow++;
    }

    if (matrix[carRow, carCol] == ".")
    {
        kmPassed += 10;
    }

    else if (matrix[carRow, carCol] == "T")
    {
        kmPassed += 30;
        matrix[carRow, carCol] = ".";

        if (firstTunnelRow == carRow && firstTunnelCol == carCol)
        {
            carRow = secondTunnelRow;
            carCol = secondTunnelCol;
        }
        else 
        {
            carRow = firstTunnelRow;
            carCol = firstTunnelCol;
        }

        matrix[carRow, carCol] = ".";
    }

    else if (matrix[carRow, carCol] == "F")
    {
        kmPassed += 10;
        matrix[carRow, carCol] = "C";

        Console.WriteLine($"Racing car {carNumber} finished the stage!");
        Console.WriteLine($"Distance covered {kmPassed} km.");
        PrintMatrix(matrix);
        return;
    }
}

matrix[carRow, carCol] = "C";

Console.WriteLine($"Racing car {carNumber} DNF.");
Console.WriteLine($"Distance covered {kmPassed} km.");
PrintMatrix(matrix);


static void PrintMatrix<T>(T[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}