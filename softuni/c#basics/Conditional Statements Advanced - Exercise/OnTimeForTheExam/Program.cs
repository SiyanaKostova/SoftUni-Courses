using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            int difference = 0;
            int hour = 0;
            int minutes = 0;

            examMin += examHour * 60;
            arrivalMin += arrivalHour * 60;

            if (arrivalMin>examMin)
            {
                Console.WriteLine("Late");
                difference = arrivalMin - examMin;
                if (difference<60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");
                }
            }
            else if (arrivalMin<examMin-30)
            {
                Console.WriteLine("Early");
                difference = examMin - arrivalMin;
                if (difference<60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                difference = examMin - arrivalMin;
                Console.WriteLine($"{difference} minutes before the start");
            }

        }
    }
}
