
using GenericBoxofInteger;

Box<int> box = new Box<int>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int number = int.Parse(Console.ReadLine());
    box.Add(number);
}

Console.WriteLine(box.ToString());