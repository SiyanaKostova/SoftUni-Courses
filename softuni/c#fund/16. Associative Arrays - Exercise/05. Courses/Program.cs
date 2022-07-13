using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!courseInfo.ContainsKey(courseName))
                {
                    courseInfo[courseName] = new List<string>();
                }
                courseInfo[courseName].Add(studentName);

                command = Console.ReadLine();
            }
            foreach (var course in courseInfo)
            {
                string courseName = course.Key;
                var students = course.Value;

                Console.WriteLine($"{courseName}: {students.Count}");

                foreach (var student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
