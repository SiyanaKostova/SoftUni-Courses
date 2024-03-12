public class Program
{
    private static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int countOfExceptions = 0;

        while (countOfExceptions < 3)
        {
            try
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[0];

                if (command == "Replace")
                {
                    int index = int.Parse(input[1]);
                    int element = int.Parse(input[2]);
                    arr[index] = element;
                }
                else if (command == "Print")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    if (startIndex < 0 || endIndex >= arr.Length || startIndex > endIndex)
                    {
                        Console.WriteLine("The index does not exist!");
                        countOfExceptions++;
                        continue;
                    }

                    string result = string.Join(", ", arr.Skip(startIndex).Take(endIndex - startIndex + 1));
                    Console.WriteLine(result);
                }
                else if (command == "Show")
                {
                    int index = int.Parse(input[1]);
                    if (index < 0 || index >= arr.Length)
                    {
                        Console.WriteLine("The index does not exist!");
                        countOfExceptions++;
                        continue;
                    }
                    Console.WriteLine(arr[index]);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
                countOfExceptions++;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
                countOfExceptions++;
            }
        }
        Console.WriteLine(string.Join(", ", arr));
    }
}