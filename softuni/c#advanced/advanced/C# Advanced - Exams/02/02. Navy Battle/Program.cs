int size = int.Parse(Console.ReadLine());

string[,] matrix = new string[size, size];

int submarinerRow = 0;
int submarinerCol = 0;


for (int row = 0; row < size; row++)
{
    string data = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = data[col].ToString();
        if (data[col] == 'S')
        {
            matrix[row, col] = "-";
            submarinerRow = row;
            submarinerCol = col;
        }
    }
}

string command = string.Empty;

int mineCounter = 0;
int cruiserCounter = 0;

while (true)
{
    if (mineCounter == 3)
    {
        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarinerRow}, {submarinerCol}]!");
        matrix[submarinerRow, submarinerCol] = "S";
        PrintMatrix(matrix);
        break;
    }
    else if (cruiserCounter == 3)
    {
        Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
        matrix[submarinerRow, submarinerCol] = "S";
        PrintMatrix(matrix);
        break;
    }

    command = Console.ReadLine().ToLower();

    if (command == "left")
    {
        submarinerCol--;
    }
    else if (command == "right")
    {
        submarinerCol++;
    }
    else if (command == "up")
    {
        submarinerRow--;
    }
    else if (command == "down")
    {
        submarinerRow++;
    }

    if (matrix[submarinerRow, submarinerCol] == "*")
    {
        matrix[submarinerRow, submarinerCol] = "-";
        mineCounter++;
    }
    else if (matrix[submarinerRow, submarinerCol] == "C")
    {
        matrix[submarinerRow, submarinerCol] = "-";
        cruiserCounter++;
    }
}

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