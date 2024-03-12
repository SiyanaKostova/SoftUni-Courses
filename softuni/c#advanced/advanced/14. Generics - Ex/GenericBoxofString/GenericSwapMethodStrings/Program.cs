

using GenericSwapMethodStrings;

Box<string> box = new Box<string>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string text = Console.ReadLine();
    box.Add(text);
}

int[] swapIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

box.Swap(swapIndex[0], swapIndex[1]);

Console.WriteLine(box.ToString());