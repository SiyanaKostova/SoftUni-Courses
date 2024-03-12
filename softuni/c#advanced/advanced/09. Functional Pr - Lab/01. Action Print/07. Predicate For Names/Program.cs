Func<List<string>, int, List<string>> filterByLenght = (names, lenght) =>
{
    List<string> result = new List<string>();

    foreach (var name in names)
    {
        if (name.Length <= lenght)
        {
            result.Add(name);
        }
    }

    return result;
};

int lenghtOfName = int.Parse(Console.ReadLine());
List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

names = filterByLenght(names, lenghtOfName);
Console.WriteLine(string.Join(Environment.NewLine, names));