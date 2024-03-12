int number = int.Parse(Console.ReadLine());

Console.WriteLine(Factorial(number));

static long Factorial(int number)
{
	if (number == 0)
	{
		return 1;
	}
	return number * Factorial(number - 1);
}