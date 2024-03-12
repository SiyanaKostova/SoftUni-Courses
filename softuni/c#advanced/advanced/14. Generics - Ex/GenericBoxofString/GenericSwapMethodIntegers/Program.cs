

using GenericSwapMethodIntegers;

Box<int> box = new Box<int>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int text = int.Parse(Console.ReadLine());
    box.Add(text);
}

int[] swapIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

box.Swap(swapIndex[0], swapIndex[1]);

Console.WriteLine(box.ToString());