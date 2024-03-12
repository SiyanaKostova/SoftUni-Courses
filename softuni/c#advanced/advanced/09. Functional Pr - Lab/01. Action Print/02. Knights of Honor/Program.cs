Action<string[], string> print = (names, title) =>
{
	foreach (var name in names)
	{
		Console.WriteLine($"{title} {name}");
	}
};
string[] input = Console.ReadLine().Split();
print(input, "Sir");