internal class Program
{
    private static void Main(string[] args)
    {
        int[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int rows = coordinates[0];
        int cols = coordinates[1];

        int playerRow = 0;
        int playerCol = 0;

        string[,] playgroundMatrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < cols; col++)
            {
                playgroundMatrix[row, col] = data[col];

                if (playgroundMatrix[row, col] == "B")
                {
                    playerRow = row;
                    playerCol = col;
                    playgroundMatrix[row, col] = "-";
                }
            }
        }

        string command = string.Empty;
        int touchedOpponents = 0;
        int movesMade = 0;

        while (true)
        {
            command = Console.ReadLine();

            if (command == "Finish")
            {
                break;
            }
            if (touchedOpponents == 3)
            {
                break;
            }

            int previousRow = playerRow;
            int previousCol = playerCol;

            switch (command)
            {
                case "up":
                    playerRow--;
                    break;
                case "down":
                    playerRow++;
                    break;
                case "left":
                    playerCol--;
                    break;
                case "right":
                    playerCol++;
                    break;
            }

            if (!IsInside(playerRow, playerCol, rows, cols))
            {
                playerRow = previousRow;
                playerCol = previousCol;
                continue;
            }
            else
            {
                if (playgroundMatrix[playerRow, playerCol] == "-")
                {
                    movesMade++;
                }
                else if (playgroundMatrix[playerRow, playerCol] == "P")
                {
                    touchedOpponents++;
                    movesMade++;
                    playgroundMatrix[playerRow, playerCol] = "-";
                }
                else if (playgroundMatrix[playerRow, playerCol] == "O")
                {
                    playerRow = previousRow;
                    playerCol = previousCol;
                }
            }
        }

        Console.WriteLine("Game over!");
        Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");

        static bool IsInside(int playerRow, int playerCol, int row, int col)
        {
            return playerRow >= 0 && playerRow < row &&
                   playerCol >= 0 && playerCol < col;
        }
    }
}