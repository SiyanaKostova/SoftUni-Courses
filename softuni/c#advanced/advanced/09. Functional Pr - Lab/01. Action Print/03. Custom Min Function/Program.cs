Func<int[], int> min = numbers => numbers.Min();

int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Console.WriteLine(min(numbers));
