using System;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial field size
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugsField = new int[fieldSize];
            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currIndex = int.Parse(occupiedIndexes[i]);
                if (currIndex >= 0 && currIndex < fieldSize)
                {
                    ladyBugsField[currIndex] = 1;
                }
            }

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                bool isFirst = true;
                int currIndex = int.Parse(commands[0]);
                while (currIndex >= 0 && currIndex < fieldSize && ladyBugsField[currIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugsField[currIndex] = 0;
                        isFirst = false;
                    }

                    string direction = commands[1];
                    int flightLength = int.Parse(commands[2]);
                    if (direction == "left")
                    {
                        currIndex -= flightLength;
                        if (currIndex >= 0 && currIndex < fieldSize)
                        {
                            if (ladyBugsField[currIndex] == 0)
                            {
                                ladyBugsField[currIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currIndex += flightLength;
                        if (currIndex >= 0 && currIndex < fieldSize)
                        {
                            if (ladyBugsField[currIndex] == 0)
                            {
                                ladyBugsField[currIndex] = 1;
                                break;
                            }
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", ladyBugsField));
        }
    }
}
