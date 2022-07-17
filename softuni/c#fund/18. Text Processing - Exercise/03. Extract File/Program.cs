using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split("\\", StringSplitOptions.RemoveEmptyEntries);
            string[] path = input[input.Length - 1].Split('.');

            string fileName = path[0];
            string fileExtension = path[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
