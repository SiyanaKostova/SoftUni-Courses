Action<string[]> print = name => Console.WriteLine(string.Join(Environment.NewLine, name));
string[] input = Console.ReadLine().Split();
print(input);