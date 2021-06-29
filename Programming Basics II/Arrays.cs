using System;
using System.Collections.Generic;

namespace Programming_Basics_II
{
    public class Arrays
    {
        private static void Arrays31()
        {
            var array_rand_char = new string[10];
            //init
            var symb = "abcdefghijklmnoprstuvzxyq";
            var r = "";
            //init random
            var rand = new Random();

            //for cycles filling up the array
            for (var i = 0; i < array_rand_char.Length; i++)
            {
                for (var a = 0; a < 10; a++) //get the 10 char string
                    r += symb[rand.Next(symb.Length)];
                //put the string in array and clear it afterwards
                array_rand_char[i] = r;
                r = "";
            }

            //Output
            foreach (var item in array_rand_char) Console.WriteLine(item);
        }

        private static void Arrays33()
        {
            //get input
            Console.WriteLine("Input your name: ");
            //Convert to all-caps
            var name = Console.ReadLine().ToUpper();
            var result = "";
            //make a library of chars and their translation in morse.
            var morse = new Dictionary<string, string>
            {
                {"A", ".-"},
                {"B", "-..."},
                {"C", "-.-."},
                {"D", "-.."},
                {"E", "."},
                {"F", "..-."},
                {"G", "--."},
                {"H", "...."},
                {"I", ".."},
                {"J", ".---"},
                {"K", "-.-"},
                {"L", ".-.."},
                {"M", "--"},
                {"N", "-."},
                {"O", "---"},
                {"P", ".--."},
                {"Q", "--.-"},
                {"R", ".-."},
                {"S", "..."},
                {"T", "-"},
                {"U", "..-"},
                {"V", "...-"},
                {"W", ".--"},
                {"X", "-..-"},
                {"Y", "-.--"},
                {"Z", "--.."},
                {"0", "-----"},
                {"1", ".----"},
                {"2", "..---"},
                {"3", "...--"},
                {"4", "....-"},
                {"5", "....."},
                {"6", "-...."},
                {"7", "--..."},
                {"8", "---.."},
                {"9", "----."}
            };

            //cycle of output; make a string of morse code
            foreach (var item in name)
            {
                result = morse[item.ToString()];

                //Read result and call out approriate action for the char.
                foreach (var c in result)
                {
                    Console.Write(c);
                    //long beep
                    if (c == '-')
                        Console.Beep(1000, 800);
                    //short beep
                    else if (c == '.')
                        Console.Beep(1000, 100);
                    //end of line
                    else
                        System.Threading.Thread.Sleep(100);
                }
            }
        }

        private static void Arrays32()
        {
            //init random
            var rand = new Random();
            //random from 3-7
            var arr_len = rand.Next(3, 7);
            //init array
            //myArray is a very plain name
            var myArray = new int[arr_len][];
            for (var i = 0; i < myArray.Length; i++)
            {
                // init array columns. length + 1
                myArray[i] = new int[myArray.Length + i];
                //fill up the array; values 1 to 10
                for (var j = 0; j < myArray[i].Length; j++) myArray[i][j] = rand.Next(1, 10);
            }

            Console.WriteLine("Cool dude club, For Cycle");
            // output with for cycle
            for (var i = 0; i < myArray.Length; i++)
            {
                //get row
                for (var j = 0; j < myArray[i].Length; j++)
                    //output values of that row
                    Console.Write(myArray[i][j] + "\t");
                Console.Write("Row " + i + "  length = " + myArray[i].Length);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Time for ForEach");
            Console.WriteLine();

            //output with foreach
            int count = 0, count1 = 0;
            foreach (var s in myArray)
            {
                foreach (var c in s)
                {
                    Console.Write(c + "\t");
                    count1++;
                }

                Console.WriteLine(" Row " + count + " lenght = " + count1);
                count++;
                count1 = 0;
            }
        }

        private static void Arrays41()
        {
            //init random
            var rand = new Random();

            //init arrays
            var array_one = new double[10];
            var array_two = new double[10];
            for (var i = 0; i < array_one.Length; i++) array_one[i] = rand.Next(1, 10);
            for (var i = 0; i < array_two.Length; i++) array_two[i] = rand.Next(1, 10);

            int menu;
            do
            {
                //output arrays
                foreach (int i in array_two) Console.Write(i + " ");
                Console.WriteLine("");
                foreach (int i in array_one) Console.Write(i + " ");
                Console.WriteLine("");

                Console.Write("Menu ");
                Console.WriteLine("");
                Console.WriteLine("1-Sum");
                Console.WriteLine("2-Subtract");
                Console.WriteLine("3-Multiply");
                Console.WriteLine("4-Divide");
                Console.WriteLine("5-AVG");
                Console.WriteLine("0-Exit");
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        sum(array_one, array_two);
                        break;
                    case 2:
                        subt(array_one, array_two);
                        break;
                    case 3:
                        mult(array_one, array_two);
                        break;
                    case 4:
                        div(array_one, array_two);
                        break;
                    case 5:
                        avg(array_one, array_two);
                        break;
                }

                Console.Clear();
            } while (menu != 0);

            static void avg(double[] array_one, double[] array_two)
            {
                double avg = 0;
                for (var i = 0; i < array_one.Length; i++) avg += array_one[i];
                avg = avg / 10;
                Console.WriteLine("AVG in array one: " + avg);

                double avg_two = 0;
                for (var i = 0; i < array_two.Length; i++) avg_two += array_two[i];
                avg_two = avg_two / 10;
                Console.WriteLine("AVG in array two: " + avg_two);
                if (avg > avg_two)
                {
                    double a = 0;
                    a = avg - avg_two;
                    Console.WriteLine($"first array is bigger than second one by {a}");
                }

                else if (avg_two > avg)
                {
                    double b = 0;
                    b = avg_two - avg;
                    Console.WriteLine($"second array is bigger than first one by {b}");
                }

                Console.ReadLine();
            }

            static void div(double[] array_one, double[] array_two)
            {
                var div = new double[array_one.Length];

                for (var i = 0; i < array_one.Length; i++) div[i] = array_two[i] / array_one[i];
                Console.WriteLine();

                foreach (int i in div) Console.Write(i + " ");
                Console.ReadLine();
            }

            static void mult(double[] array_one, double[] array_two)
            {
                var mult = new double[array_one.Length];

                for (var i = 0; i < array_one.Length; i++) mult[i] = array_two[i] * array_one[i];
                Console.WriteLine();

                foreach (int i in mult) Console.Write(i + " ");
                Console.ReadLine();
            }

            static void subt(double[] array_one, double[] array_two)
            {
                var subt = new double[array_one.Length];

                for (var i = 0; i < array_one.Length; i++) subt[i] = array_two[i] - array_one[i];
                Console.WriteLine();

                foreach (int i in subt) Console.Write(i + " ");
                Console.ReadLine();
            }

            static void sum(double[] array_one, double[] array_two)
            {
                var sum = new double[array_one.Length];

                for (var i = 0; i < array_one.Length; i++) sum[i] = array_two[i] + array_one[i];
                Console.WriteLine();

                foreach (int i in sum) Console.Write(i + " ");
                Console.ReadLine();
            }

            Environment.Exit(5);
        }

        private static void Arrays42()
        {
            static void InitArray(int[,] array)
            {
                var rand = new Random();
                for (var i = 0; i < array.GetLength(0); i++)
                for (var j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rand.Next(1, 10);
            }

            static void PrintArray(int[,] array)
            {
                for (var i = 0; i < array.GetLength(0); i++)
                {
                    for (var j = 0; j < array.GetLength(1); j++) Console.Write(array[i, j] + " ");
                    Console.WriteLine();
                }
            }

            static int MINArray(int[,] array)
            {
                var min = array[0, 0];
                for (var i = 0; i < array.GetLength(0); i++)
                for (var k = 0; k < array.GetLength(1); k++)
                    if (array[i, k] < min)
                        min = array[i, k];
                Console.WriteLine("min value = " + min);
                return 0;
            }

            static int MAXArray(int[,] array)
            {
                var max = array[0, 0];
                for (var i = 0; i < array.GetLength(0); i++)
                for (var k = 0; k < array.GetLength(1); k++)
                    if (array[i, k] > max)
                        max = array[i, k];
                Console.WriteLine("max value = " + max);
                return 0;
            }


            static void search(int[,] array, int search_option)
            {
                var times_default = 0;
                foreach (var c in array)
                    if (c == search_option)
                        times_default++;
                Console.WriteLine($"Int can be found in Array {times_default} times");
            }

            static void Main(string[] args)
            {
                Console.Write("Array row count : ");
                var array_rows = Convert.ToInt32(Console.ReadLine());
                Console.Write("Array Column count: ");
                var array_columns = Convert.ToInt32(Console.ReadLine());
                var array = new int[array_rows, array_columns];
                InitArray(array);
                PrintArray(array);
                MINArray(array);
                MAXArray(array);
                Console.Write("Search : ");
                var search_option = Convert.ToInt32(Console.ReadLine());
                search(array, search_option);
            }
        }
    }
}