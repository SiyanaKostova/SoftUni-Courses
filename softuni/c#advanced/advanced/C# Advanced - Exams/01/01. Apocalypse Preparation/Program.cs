using System;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Queue<int> textiles = new Queue<int>(first);

            List<int> second = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> medicaments = new Stack<int>(second);

            Dictionary<string, int> collection = new Dictionary<string, int>
            {
                {"Patch", 30 },
                {"Bandage", 40 },
                {"MedKit", 100 },
            };

            Dictionary<string, int> healingItemsMade = new Dictionary<string, int>();

            while (textiles.Any() && medicaments.Any())
            {
                int leftKid = 0;
                int currTextile = textiles.Peek();
                int currMedicament = medicaments.Peek();
                int healingItem = currMedicament + currTextile;

                bool isThere = false;

                foreach (var element in collection)
                {
                    if (element.Value == healingItem)
                    {
                        isThere = true;

                        if (!healingItemsMade.ContainsKey(element.Key))
                        {
                            healingItemsMade.Add(element.Key, 1);
                        }
                        else
                        {
                            healingItemsMade[element.Key]++;
                        }

                        medicaments.Pop();
                        textiles.Dequeue();
                        break;
                    }
                }

                if (!isThere)
                {
                    if (healingItem > 100)
                    {
                        if (!healingItemsMade.ContainsKey("MedKit"))
                        {
                            healingItemsMade.Add("MedKit", 1);
                        }
                        else
                        {
                            healingItemsMade["MedKit"]++;
                        }

                        leftKid = healingItem - 100;
                        medicaments.Pop();
                    }

                    textiles.Dequeue();

                    if (leftKid > 0)
                    {
                        int medToAdd = medicaments.Peek() + leftKid;
                        int prevMed = medicaments.Peek();

                        bool isFound = false;
                        Stack<int> currStack = new Stack<int>();

                        while (medicaments.Count > 0)
                        {
                            var value = medicaments.Pop();
                            if (medToAdd == value + leftKid && isFound == false)
                            {
                                isFound = true;
                                currStack.Push(medToAdd);

                            }
                            else
                            {
                                currStack.Push(value);
                            }
                        }

                        while (currStack.Count > 0)
                        {
                            medicaments.Push(currStack.Pop());
                        }
                    }
                    else
                    {
                        int meds = medicaments.Peek() + 10;
                        int prevMeds = medicaments.Peek();
                        bool isMedFound = false;

                        Stack<int> tempMedStack = new Stack<int>();
                        while (medicaments.Count > 0)
                        {
                            var value = medicaments.Pop();
                            if (meds == value + 10 && isMedFound == false)
                            {
                                isMedFound = true;
                                tempMedStack.Push(meds);
                            }
                            else
                            {
                                tempMedStack.Push(value);
                            }
                        }

                        while (tempMedStack.Count > 0)
                        {
                            medicaments.Push(tempMedStack.Pop());
                        }
                    }
                }
            }

            if ((!textiles.Any()) && (!medicaments.Any()))
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!medicaments.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }


            if (healingItemsMade.Any())
            {
                var sortedHealingItems = healingItemsMade.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

                foreach (var item in sortedHealingItems)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}