using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //sequence lenght
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] DNA = new int[sequenceLength];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSamples = 0;
            int sample = 0;

            while (input != "Clone them!")
            {
                //current DNA info
                sample++;
                int[] currDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                //current DNA elements
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDNASum = 0;
                bool isCurrDNAbetter = false;
                int count = 0;

                for (int i = 0; i < currDNA.Length; i++)
                {
                    if (currDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }
                    count++;

                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }

                currStartIndex = currEndIndex - currCount + 1;
                currDNASum = currDNA.Sum();

                //check current best DNA
                if (currCount > dnaCount)
                {
                    isCurrDNAbetter = true;
                }
                else if (currCount==dnaCount)
                {
                    if (currStartIndex<dnaStartIndex)
                    {
                        isCurrDNAbetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if (currDNASum > dnaSum)
                        {
                            isCurrDNAbetter = true;
                        }
                    }
                }
                
                if (isCurrDNAbetter)
                {
                    DNA = currDNA;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    dnaSum = currDNASum;
                    dnaSamples = sample;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
