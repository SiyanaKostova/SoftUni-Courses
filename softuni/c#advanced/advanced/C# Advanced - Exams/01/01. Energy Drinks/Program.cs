
const int maxMilligramsForNight = 300;

int caffeine = 0;

List<int> firstInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
Stack<int> milligramsCaffeinе = new Stack<int>(firstInput);

List<int> secondInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
Queue<int> energyDrinks = new Queue<int>(secondInput);



while (milligramsCaffeinе.Any() && energyDrinks.Any())
{
    int caffeineInLastDrink = milligramsCaffeinе.Peek() * energyDrinks.Peek();

	if ((caffeine + caffeineInLastDrink) <= 300)
	{
		milligramsCaffeinе.Pop();
		energyDrinks.Dequeue();
		caffeine += caffeineInLastDrink;
	}
	else
	{
		milligramsCaffeinе.Pop();
		int currentDrink = energyDrinks.Dequeue();
		energyDrinks.Enqueue(currentDrink);

		if (caffeine >= 30)
		{
			caffeine -= 30;
		}
	}
}

if (energyDrinks.Any())
{
	Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
}
else
{
	Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {caffeine} mg caffeine.");