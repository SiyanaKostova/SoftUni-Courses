Func<int, int, List<int>> generateRange = (start, end) =>
{
    List<int> range = new List<int>();

	for (int i = start; i <= end; i++)
	{
		range.Add(i);
	}

	return range;	
};

Predicate<int> match;

int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
string typeOfNumber = Console.ReadLine();

List<int> numbers = generateRange(range[0], range[1]);

if (typeOfNumber == "even")
{
	match = number => number % 2 == 0;
}
else
{
    match = number => number % 2 != 0;
}

foreach (var item in numbers)
{
	if (match(item))
	{
		Console.Write($"{item} ");
	}
}
