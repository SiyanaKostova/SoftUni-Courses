using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Shopping_Listt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceryShoppingList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "Urgent":
                        string itemUrgent = tokens[1];
                        bool isItThereUrgent = false;
                        for (int i = 0; i < groceryShoppingList.Count; i++)
                        {
                            if (groceryShoppingList[i] == itemUrgent)
                            {
                                isItThereUrgent = true;
                                break;
                            }
                        }
                        if (!isItThereUrgent)
                        {
                            groceryShoppingList.Insert(0, itemUrgent);
                        }
                        break;

                    case "Unnecessary":
                        string itemUnnecessary = tokens[1];

                        for (int i = 0; i < groceryShoppingList.Count; i++)
                        {
                            if (groceryShoppingList[i] == itemUnnecessary)
                            {

                                groceryShoppingList.Remove(itemUnnecessary);
                                break;
                            }

                        }
                        break;

                    case "Correct":
                        string oldItem = tokens[1];
                        string newItem = tokens[2];

                        for (int i = 0; i < groceryShoppingList.Count; i++)
                        {
                            if (groceryShoppingList[i] == oldItem)
                            {

                                groceryShoppingList[i] = newItem;
                                break;
                            }

                        }

                        break;

                    case "Rearrange":
                        string itemRearrange = tokens[1];
                        for (int i = 0; i < groceryShoppingList.Count; i++)
                        {
                            if (groceryShoppingList[i] == itemRearrange)
                            {

                                groceryShoppingList.Remove(itemRearrange);
                                groceryShoppingList.Add(itemRearrange);
                                break;
                            }

                        }
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceryShoppingList));
        }
    }
}
