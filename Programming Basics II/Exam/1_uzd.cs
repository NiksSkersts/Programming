using System;


namespace raftypoile

{
    internal class Program

    {
        public static void Main()

        {
            Console.WriteLine("Input the size of the array");

            var array_size = Convert.ToInt32(Console.ReadLine());

            var array = new int[array_size, array_size];

            var array_two = new int[array_size, array_size];


            InitArr(array);

            InitArr(array_two);

            PrintArr(array, array_two);

            Console.WriteLine("****** SUM FUNKCIJA *******");

            Sum(array, array_two);
        }

        public static void InitArr(int[,] array)

        {
            var rand = new Random();

            for (var i = 0; i < array.GetLength(0); i++)

            for (var z = 0; z < array.GetLength(1); z++)
                array[z, i] = rand.Next(0, 9);
        }

        public static void PrintArr(int[,] array, int[,] array_two)

        {
            for (var i = 0; i < array_two.GetLength(0); i++)

            {
                for (var z = 0; z < array_two.GetLength(1); z++)

                {
                    Console.Write(array[i, z]);

                    Console.Write(" ");
                }

                Console.Write("\t");

                for (var x = 0; x < array_two.GetLength(1); x++)

                {
                    Console.Write(" ");

                    Console.Write(array_two[i, x]);
                }

                Console.WriteLine();
            }
        }

        public static void Sum(int[,] array, int[,] array_two)

        {
            for (var i = 0; i < array_two.GetLength(0); i++)

            {
                for (var z = 0; z < array_two.GetLength(1); z++)

                {
                    Console.Write(array[i, z] + array_two[i, z]);

                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}