using System;

namespace Programming_Basics_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void Proggresion52()
        {
            int prog_number, result;
            var pg = new progression();
            Console.Write("Pick a number : ");
            prog_number = int.Parse(Console.ReadLine());
            result = pg.sum(prog_number);
            Console.WriteLine("sum of progression {0} is {1}", prog_number, result);
            Console.WriteLine("Kewl Stuff");
            Console.WriteLine("While I am at it. Fuck the Tories. #indyref2 #icecream4scotland");
            Console.ReadLine();
        }

        public static void Progression52()
        {
            Console.Write("Pick a number to start off your progression: ");
            var start = Convert.ToInt32(Console.ReadLine());

            Console.Write("difference between progressions: ");
            var difference = Convert.ToInt32(Console.ReadLine());

            Console.Write("how many times should I do this: ");
            var prog_times = Convert.ToInt32(Console.ReadLine());

            progression(start, difference, prog_times);

            static void progression(int start, int difference, int prog_times)
            {
                for (var i = 1; i <= prog_times; i++)
                {
                    start += difference;
                    Console.WriteLine(start);
                }
            }
        }
    }

    internal class progression
    {
        public int sum(int prog_number)
        {
            if (prog_number != 0)
                return prog_number % 10 + sum(prog_number / 10);
            else
                return 0;
        }
    }
}