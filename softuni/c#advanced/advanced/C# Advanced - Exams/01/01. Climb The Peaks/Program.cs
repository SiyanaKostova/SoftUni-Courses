List<int> firstInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
Stack<int> dailyFood = new Stack<int>(firstInput);

List<int> secondInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
Queue<int> dailyStamina = new Queue<int>(secondInput);

Dictionary<string, int> peaks = new Dictionary<string, int>
{
    {"Vihren",80 },
    {"Kutelo",90 },
    {"Banski Suhodol",100 },
    {"Polezhan",60 },
    {"Kamenitza",70 },
};

List<string> peaksConcuered = new List<string>();

Queue<string> peaksName = new Queue<string>();
peaksName.Enqueue("Vihren");
peaksName.Enqueue("Kutelo");
peaksName.Enqueue("Banski Suhodol");
peaksName.Enqueue("Polezhan");
peaksName.Enqueue("Kamenitza");

while (dailyFood.Any() && dailyStamina.Any() && peaksName.Any())
{
    int portion = dailyFood.Peek();
    int stamina = dailyStamina.Peek();
    int currCounter = portion + stamina;

    if (currCounter >= peaks[peaksName.Peek()])
    {
        peaksConcuered.Add(peaksName.Dequeue());
        dailyStamina.Dequeue();
        dailyFood.Pop();
    }
    else
    {
        dailyStamina.Dequeue();
        dailyFood.Pop();
    }

}
if (!peaksName.Any())
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (peaksConcuered.Count > 0)
{
    Console.WriteLine("Conquered peaks:");
    foreach (var item in peaksConcuered)
    {
        Console.WriteLine(item);
    }
}