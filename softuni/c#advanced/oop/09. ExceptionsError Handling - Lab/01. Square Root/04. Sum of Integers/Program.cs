public class Program
{
    private static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split();
        int sum = 0;

        foreach (string element in elements)
        {
            try
            {
                int num = int.Parse(element);
                sum += num;
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"The element '{element}' is in wrong format!");
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The element '{element}' is out of range!");
                Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
            }
        }

        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}