using System;
namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Family family = new Family();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] personProps = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person(personProps[0], int.Parse(personProps[1]));

            family.AddMember(person);
        }

        Person oldest = family.GetOldestMember();

        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}