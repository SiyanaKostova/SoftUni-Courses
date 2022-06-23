using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] command = input.Split(":");

                list = SoftUniCoursePlanning(list, command);
                input = Console.ReadLine();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }

        static List<string> SoftUniCoursePlanning(List<string> list, string[] command)
        {
            string action = command[0];
            switch (action)
            {
                case "Add":
                    list = Add(list, command);
                    break;
                case "Insert":
                    list = Insert(list, command);
                    break;
                case "Remove":
                    list = Remove(list, command);
                    break;
                case "Swap":
                    list = Swap(list, command);
                    break;
                case "Exercise":
                    list = Exercise(list, command);
                    break;
            }

            return list;
        }

        static List<string> Exercise(List<string> list, string[] command)
        {
            string lessonTitle = command[1];

            if (list.Contains(lessonTitle) && !list.Contains(lessonTitle + "-Exercise"))
            {
                int index = list.IndexOf(lessonTitle);
                list.Insert(index + 1, lessonTitle + "-Exercise");
            }
            else if (!list.Contains(lessonTitle))
            {
                list.Add(lessonTitle);
                list.Add(lessonTitle + "-Exercise");
            }

            return list;
        }

        static List<string> Swap(List<string> list, string[] command)
        {
            string firstTitle = command[1];
            string secondTitle = command[2];
            int firstIndex = list.IndexOf(firstTitle);
            int secondIndex = list.IndexOf(secondTitle);

            if (list.Contains(firstTitle) && list.Contains(secondTitle))
            {
                string tempLessonTitle1 = list.ElementAt(firstIndex);
                list[firstIndex] = list[secondIndex];
                list[secondIndex] = tempLessonTitle1;
            }

            if (list.Contains(firstTitle + "-Exercise") && list.Contains(list[firstIndex]))
            {
                firstIndex = list.IndexOf(firstTitle);
                list.Remove(firstTitle + "-Exercise");
                list.Insert(firstIndex + 1, firstTitle + "-Exercise");
            }
            else if (list.Contains(secondTitle + "-Exercise") && list.Contains(list[secondIndex]))
            {
                secondIndex = list.IndexOf(secondTitle);
                list.Remove(secondTitle + "-Exercise");
                list.Insert(secondIndex + 1, secondTitle + "-Exercise");
            }

            return list;
        }

        static List<string> Remove(List<string> list, string[] command)
        {
            string lessonTitle = command[1];

            if (list.Contains(lessonTitle))
            {
                list.Remove(lessonTitle);
            }
            else if (list.Contains(lessonTitle + "-Exercise"))
            {
                list.Remove(lessonTitle + "-Exercise");
            }

            return list;
        }

        static List<string> Insert(List<string> list, string[] command)
        {
            string lessonTitle = command[1];
            int index = int.Parse(command[2]);

            if (index < 0 || index >= list.Count)
            {
                return list;
            }
            else if (!list.Contains(lessonTitle))
            {
                list.Insert(index, lessonTitle);
            }

            return list;
        }

        static List<string> Add(List<string> list, string[] command)
        {
            string lessonTitle = command[1];

            if (!list.Contains(lessonTitle))
            {
                list.Add(lessonTitle);
            }

            return list;
        }
    }
}
