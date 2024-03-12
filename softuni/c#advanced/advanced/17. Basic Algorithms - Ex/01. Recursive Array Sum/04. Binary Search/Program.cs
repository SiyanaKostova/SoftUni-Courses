﻿int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int element = int.Parse(Console.ReadLine());

Console.WriteLine(BinarySearch(array, 0, array.Length - 1, element));

static int BinarySearch(int[] array, int start, int end, int element)
{
	if (start > end)
	{
		return -1;
	}

    int middle = (start + end) / 2;

	if (array[middle] == element)
	{
		return middle;
	}
	if (element < array[middle])
	{
		return BinarySearch(array, start, middle - 1, element);
	}
	else
	{
        return BinarySearch(array, middle + 1, end, element);
    }
}