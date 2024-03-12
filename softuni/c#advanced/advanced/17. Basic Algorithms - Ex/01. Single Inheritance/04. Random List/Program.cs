namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("hi");
            list.Add("hello");
            list.Add("hello again");
            Console.WriteLine(list.RandomString());
        }
    }
}