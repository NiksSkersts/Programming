using System;
using System.Linq;

namespace task_app
{
    internal class Tasks
    {
        //start of code
        private static void Main()
        {
            //Note to myself: Update the code to make this look more like an app.
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("Please choose one task!");
            Console.WriteLine("1. Arrays");
            Console.WriteLine("2. Symbols");
            Console.WriteLine("3. Training");
            Console.WriteLine("4. Data Types");
            var menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.Clear();
                Console.WriteLine("1. String Array");
                Console.WriteLine("2. Int Array");
                Console.WriteLine("3. Array");
                var submenu = Convert.ToInt32(Console.ReadLine());
                if (submenu == 1) StringArray();
                if (submenu == 2) IntArray();
                if (submenu == 3) CArray();
                Main();
            }

            if (menu == 2)
            {
                Console.Clear();
                Console.WriteLine("1. Symbols");
                Console.WriteLine("2. Symbols 2 ");
                var submenu = Convert.ToInt32(Console.ReadLine());
                if (submenu == 1) Symbols();

                if (submenu == 2) Symbols2();
                Main();
            }

            if (menu == 3)
            {
                Console.Clear();
                Console.WriteLine("1. atk_1");
                Console.WriteLine("2. atk_2");
                var submenu = Convert.ToInt32(Console.ReadLine());
                if (submenu == 1) atk_1();
                if (submenu == 2) atk_2();
                Main();
            }

            if (menu == 4)
            {
                Console.Clear();
                Console.WriteLine("1. Decimal and Double");
                Console.WriteLine("2. Char");
                Console.WriteLine("3. Bool");
                Console.WriteLine("4. Int");
                Console.WriteLine("5. Data Type Values");
                Console.WriteLine("6. Data Type Symmetric");
                var submenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (submenu == 1) Data_Types_Decimal_Double();
                if (submenu == 2) Data_Types_Char();
                if (submenu == 3) Data_Types_Bool();
                if (submenu == 4) Data_Types_Int();
                if (submenu == 5) Data_Types_Values();
                if (submenu == 6) Data_Types_Sym();
                Main();
            }

            if (menu == 5)
            {
                Console.Clear();
                Console.WriteLine("1. Random String Array");
                var submenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (submenu == 1) ForEachCycle();
                Main();
            }
        }

        private static void StringArray()
        {
            var stringy = "";
            Console.Clear();
            Console.WriteLine("String Arrays!");
            int i, b;
            b = 1;
            var FirstMassive = new string[11];
            for (i = 1; i <= 10; i++)
            {
                Console.Write("Input massive {0} value {1} : ", b, i);
                FirstMassive[i] = Console.ReadLine();
                stringy = stringy + FirstMassive[i];
            }

            for (i = 1; i <= 10; i++) Console.WriteLine("Input massive {0} value {1} is {2}", b, i, FirstMassive[i]);
            Console.WriteLine();
            Console.WriteLine("All Symbols in one line := {0}", stringy);
            Console.WriteLine();
            Console.WriteLine("Sounds like a solid YAY for me!");
            Console.WriteLine("TASK 2");
            int value1, value2, formassive2, formassive3, mass = 0, massive1 = 0, massive2 = 0;
            var m = "";
            Console.Write("Input the size of first massive: ");
            value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the size of second massive: ");
            value2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            var SecondMassive = new string[value1];
            var ThirdMassive = new string[value2];
            for (formassive2 = 0; formassive2 != SecondMassive.Length; formassive2++)
            {
                Console.Write("Input massive{0} value {1}: ", mass + 1, formassive2);
                SecondMassive[massive1] = Console.ReadLine();
                massive1++;
            }

            for (formassive3 = 0; formassive3 != ThirdMassive.Length; formassive3++)
            {
                Console.Write("Input massive{0} value {1}: ", mass + 2, formassive3);
                ThirdMassive[massive2] = Console.ReadLine();
                massive2++;
            }

            foreach (var item in SecondMassive)
            {
                var a = 0;
                Console.WriteLine("Massive {0} value {1} is {2}", mass + 1, a++,
                    item.ToString());
            }

            foreach (var item in ThirdMassive)
            {
                var a = 0;
                Console.WriteLine("Massive {0} value {1} is {2}", mass + 2, a++,
                    item.ToString());
            }

            Console.WriteLine();
            Console.Write("All values in one line: ");
            for (var p = 0; p < Math.Max(value1, value2); p++)
            {
                if (p < value1) m = m + SecondMassive[p];
                if (p < value2) m = m + ThirdMassive[p];
            }

            Console.WriteLine("Merged 1st and 2nd array values : " + m);

            Console.ReadLine();
            Console.WriteLine("Task 3");
            int value3, value4, firstfor, secondfor, arr = 0;
            Console.Write("Input the size of first array: ");
            value3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the size of second array: ");
            value4 = Convert.ToInt32(Console.ReadLine());
            var ThirdArray = new string[value3];
            var FourthArray = new string[value4];
            var sum1 = "";
            var sum2 = "";
            var sum3 = "";
            for (firstfor = 0; firstfor < ThirdArray.Length; firstfor++)
            {
                Console.Write("Input array {0} value {1}: ", arr + 1, firstfor);
                ThirdArray[firstfor] = Console.ReadLine();
            }

            for (secondfor = 0; secondfor < FourthArray.Length; secondfor++)
            {
                Console.Write("Input array {0} value {1}: ", arr + 2, secondfor);
                FourthArray[secondfor] = Console.ReadLine();
            }

            for (var u = 0; u < ThirdArray.Length; u++)
                Console.WriteLine("Massive {0} value {1} is {2}", arr + 1, u, ThirdArray[u]);
            for (var u = 0; u < FourthArray.Length; u++)
                Console.WriteLine("Massive {0} value {1} is {2}", arr + 2, u, FourthArray[u]);
            for (var u = 0; u < ThirdArray.Length / 2; u++) sum1 = sum1 + ThirdArray[u];
            for (var u = ThirdArray.Length / 2; u < ThirdArray.Length; u++) sum2 = sum2 + ThirdArray[u];
            for (var u = 0; u < FourthArray.Length; u++) sum3 = sum3 + FourthArray[u];
            Console.WriteLine(sum1 + sum3 + sum2);
            Console.ReadLine();
            Main();
        }

        private static void IntArray()
        {
            var sum = 1;
            var array1 = new int[10];
            for (var firstfor = 0; firstfor < array1.Length; firstfor++)
            {
                Console.Write("Input array value {0}: ", firstfor);
                array1[firstfor] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("");
            for (var firstfor = 0; firstfor < array1.Length; firstfor++)
                Console.WriteLine("Array1[{0}] = {1}: ", firstfor, array1[firstfor]);
            Console.WriteLine();
            for (var firstfor = 0; firstfor < array1.Length; firstfor++)
            {
                sum = sum * array1[firstfor];
                Console.WriteLine("Mult_[{0}] = {1}: ", firstfor, sum);
            }

            Console.WriteLine("Task 2");
            Console.ReadLine();
            Console.Clear();

            var array2 = new char[20];
            char a;
            var times = 0;
            string cs;
            var random = new Random();
            for (var secondfor = 0; secondfor < array2.Length; secondfor++)
                array2[secondfor] = Convert.ToChar(random.Next(48, 126));
            Console.WriteLine();
            for (var secondfor = 0; secondfor < array2.Length; secondfor++)
                Console.WriteLine("Array[{0}] = {1}", secondfor, array2[secondfor]);
            Console.WriteLine();
            Console.Write("Input a character: ");

            a = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            for (var secondfor = 0; secondfor < array2.Length; secondfor++)
                if (array2[secondfor] == a)
                    times++;
            if (times > 1)
                cs = "times";
            else
                cs = "time";
            Console.WriteLine("Symbol {0} was found in array {1} {2}", a, times, cs);

            Console.WriteLine();

            for (var secondfor = 0; secondfor < array2.Length; secondfor++)
                if (array2[secondfor] != a)
                    Console.WriteLine("Array{0} = {1}", secondfor, array2[secondfor]);
            Console.WriteLine("Task 3");
            Console.ReadLine();
            Console.Clear();
            int min, max;
            var array3 = new int[10];
            for (var secondfor = 0; secondfor < array3.Length; secondfor++)
                array3[secondfor] = Convert.ToInt32(random.Next(1, 20));
            for (var secondfor = 0; secondfor < array3.Length; secondfor++)
                Console.WriteLine("Array[{0}] = {1}", secondfor, array3[secondfor]);
            max = array3.Max();
            min = array3.Min();
            Console.WriteLine("Max value = " + max);
            Console.WriteLine("Min value = " + min);

            Console.WriteLine("Task 4");
            Console.ReadLine();
            Console.Clear();

            var array4 = new int[10];
            for (var secondfor = 0; secondfor < array4.Length; secondfor++)
                array4[secondfor] = Convert.ToInt32(random.Next(1, 20));
            for (var secondfor = 0; secondfor < array4.Length; secondfor++)
                Console.WriteLine("Array[{0}] = {1}", secondfor, array4[secondfor]);
            Console.WriteLine();
            for (var secondfor = array4.Length - 1; secondfor != -1; secondfor--)
                Console.WriteLine("Array[{0}] = {1}", secondfor, array4[secondfor]);
            Console.ReadLine();
            Main();
        }

        private static void CArray()
        {
            Console.Clear();
            int value1, value2;
            Console.WriteLine("Define the sizes for arrays");
            Console.Write("First Array: ");
            value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Second Array: ");
            value2 = Convert.ToInt32(Console.ReadLine());
            var random = new Random();
            var BigArray = new int[value1];
            var BigArray2 = new int[value2];
            for (var thirdfor = 0; thirdfor < BigArray.Length; thirdfor++)
                BigArray[thirdfor] = Convert.ToInt32(random.Next(10, 100));
            for (var thirdfor = 0; thirdfor < BigArray2.Length; thirdfor++)
                BigArray2[thirdfor] = Convert.ToInt32(random.Next(10, 100));
            {
                if (Math.Max(BigArray.Length, BigArray2.Length) == BigArray2.Length)
                {
                    Console.WriteLine("Pirmais Otrais");
                    for (var i = 0; i < Math.Max(BigArray.Length, BigArray2.Length); i++)
                    {
                        if (i < BigArray.Length) Console.Write(+BigArray[i]);
                        else Console.Write("  ");

                        Console.Write("     ");

                        if (i < BigArray2.Length) Console.Write(+BigArray2[i]);

                        Console.WriteLine();
                    }
                }

                if (Math.Max(BigArray.Length, BigArray2.Length) == BigArray.Length)
                {
                    Console.WriteLine("Otrais Pirmais");
                    for (var i = 0; i < Math.Max(BigArray.Length, BigArray2.Length); i++)
                    {
                        if (i < BigArray2.Length) Console.Write(+BigArray2[i]);
                        else Console.Write("  ");

                        Console.Write("     ");

                        if (i < BigArray.Length) Console.Write(+BigArray[i]);

                        Console.WriteLine();
                    }
                }

                //Last Checks
                if (BigArray.Min() < BigArray2.Min())
                    Console.WriteLine("Smallest number is in first array. Value : {0}", BigArray.Min());
                else if (BigArray.Min() > BigArray2.Min())
                    Console.WriteLine("Smallest number is in second array. Value : {0}", BigArray2.Min());
                else
                    Console.WriteLine("Smallest number is in first and second array. Value : {0}", BigArray.Min());
                //Largest
                if (BigArray.Max() < BigArray2.Max())
                    Console.WriteLine("Largest number is in first array. Value : {0}", BigArray.Max());
                else if (BigArray.Max() > BigArray2.Max())
                    Console.WriteLine("Largest number is in second array. Value : {0}", BigArray2.Max());
                else
                    Console.WriteLine("Largest number is in first and second array. Value : {0}", BigArray.Max());
                Console.ReadLine();
                Main();
            }
        }

        private static void Symbols()
        {
            Console.Clear();
            Console.WriteLine("Task: Symbols - 1 ");
            Console.WriteLine("Input random symbols or characters. DON'T crash this thing please!");
            var stringline = Convert.ToString(Console.ReadLine());
            char y;
            var sum = 0;
            for (var i = 0; i < stringline.Length; i++)
            {
                Console.WriteLine(stringline[i] + "=" + (int) stringline[i]);
                sum = sum + (int) stringline[i];
            }

            Console.WriteLine("Sum of Code = " + sum);
            Console.Write("Input a symbol please: ");
            y = Convert.ToChar(Console.ReadLine());

            sum = 0;

            for (var i = 0; i < stringline.Length; i++)
                if (stringline[i] == y)
                    sum++;

            Console.WriteLine("Symbol is found in string " + sum + " times ");

            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("Next?");
            Console.ReadLine();
            Console.Clear();

            string firstS, secondS;

            Console.Write("Input first line of symbols: ");
            firstS = Console.ReadLine();
            Console.Write("Input second line of symbols: ");
            secondS = Console.ReadLine();
            string z1 = null, z2 = null;
            const string number = "0123456789";

            for (var i = 0; i < firstS.Length; i++)
                if (number.Contains(firstS[i]))
                    z1 = z1 + '*';
                else
                    z1 = z1 + firstS[i];
            for (var i = 0; i < secondS.Length; i++)
                if ('a' <= secondS[i] && secondS[i] <= 'z')
                    z2 = z2 + (char) ((int) secondS[i] - ((int) 'a' - (int) 'A'));
                else
                    z2 = z2 + secondS[i];

            Console.WriteLine("First symbol line: " + z1);
            Console.WriteLine("Second symbol line: " + z2);

            Console.WriteLine("Length of first symbol line: " + z1.Length);
            Console.WriteLine("Length of second symbol line: " + z2.Length);

            string z3 = null;

            for (var i = 0; i < secondS.Length; i++)
                if (i == (int) (secondS.Length / 2))
                    z3 = z3 + firstS;
                else
                    z3 = z3 + secondS[i];

            Console.WriteLine("Behold! The Result is: " + z3);

            string z4;
            int xTimes;
            Console.Write("Input the third symbol line: ");
            z4 = Console.ReadLine();

            for (var i = 0; i < z4.Length; i++)
            {
                xTimes = 0;
                for (var j = 0; j < z3.Length; j++)
                    if (z3[j] == z4[i])
                        xTimes++;
                Console.WriteLine(z4[i] + " Symbol is seen = " + xTimes + " times");
            }

            Console.WriteLine("Finally!");
            Console.ReadLine();
            Main();
        }

        private static void Symbols2()
        {
            Console.Clear();
            Console.WriteLine("Task 1");
            var ham = new int[10];
            int x = 10, y = 10;
            int[,] array01;
            var sum = 0;
            var rng = new Random();
            array01 = new int[x, y];

            for (var i = 0; i < x; i++)
            for (var j = 0; j < y; j++)
                array01[i, j] = rng.Next(10);
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++) Console.Write(array01[i, j] + "\t");
                Console.WriteLine("\n");
            }

            Console.WriteLine("");
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++) ham[i] = ham[i] + array01[i, j];
                Console.WriteLine($"Sum of line {i} is: {ham[i]}");
            }

            Console.WriteLine();
            for (var i = 0; i < 10; i++) sum = sum + ham[i];
            Console.WriteLine($"Sum of array: {sum}");
            Console.WriteLine();
            Console.WriteLine("Task 2");
            Console.WriteLine();


            var Min = 10;
            var Max = 0;
            var min1 = 9;
            var max1 = 0;
            int min2;
            int max2;
            int[,] array02;
            array02 = new int[x, y];

            for (var e = 0; e < x; e++)
            for (var j = 0; j < y; j++)
                array02[e, j] = rng.Next(10);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++) Console.Write(array02[i, j] + "\t");
                Console.WriteLine("\n");
            }

            Console.WriteLine("");


            for (var i = 0; i < 10; i++)
            {
                min2 = Min;
                max2 = Max;
                for (var j = 0; j < 10; j++)
                {
                    if (Min > array02[i, j]) Min = array02[i, j];
                    if (Max < array02[i, j]) Max = array02[i, j];
                }

                if (min2 > Min) min1 = Min;
                if (max2 < Max) max1 = Max;
                Console.WriteLine($"Row {i} max value is: {Max} , min value: {Min} ");
            }

            Console.WriteLine($"whole array max value is {max1} , whole array min value is {min1}");

            Console.WriteLine("Task 3 ");

            int[,] array03;
            array03 = new int[x, y];
            for (var i = 0; i < x; i++)
            for (var j = 0; j < y; j++)
                array03[i, j] = rng.Next(10);
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++) Console.Write(array03[i, j] + "\t");
                Console.WriteLine();
            }

            Console.WriteLine("");
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++) Console.Write(array03[j, i] + "\t");
                Console.WriteLine();
            }


            Console.WriteLine("Task 4 ");
            int[,] array04;
            var g = -1;
            array04 = new int[x, y];

            for (var i = 0; i < x; i++)
            for (var j = 0; j < y; j++)
                array04[i, j] = rng.Next(0, 10);
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++) Console.Write(array04[i, j] + "\t");
                Console.WriteLine();
            }

            Console.WriteLine("");
            for (var i = 0; i < x; i++)
            {
                g = g + 2;
                for (var j = 0; j < y; j++)
                {
                    if (i + j >= g) array04[i, j] = 0;
                    Console.Write(array04[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
            Main();
        }

        private static void atk_1()
        {
            var rand = new Random();
            var game = rand.Next(0, 100);
            Console.WriteLine(game);
            var game_on = true;
            var count_times = 0;
            while (game_on == true)
            {
                Console.WriteLine("Pick a value from 0 to 100");
                var player_1 = Convert.ToInt32(Console.ReadLine());
                if (player_1 > game) Console.WriteLine("Value is lower");
                if (player_1 < game) Console.WriteLine("Value is higher");
                if (player_1 == game)
                {
                    Console.WriteLine("Congratz You did it");
                    Console.WriteLine("Answer was :" + game);
                    Console.WriteLine("Here's how long it took you: " + count_times);
                    Console.WriteLine("Bye, Come Again!");
                    game_on = false;
                }

                count_times++;
            }

            Environment.Exit(5);
        }

        private static void atk_2()
        {
            //THIS SHIT TOOK ME WHOLE NIGHT! AGH!
            //I have to set up GoFundMe eksdee

            //Let's get that word
            Console.WriteLine("Choose a word, please :)");
            var result = Console.ReadLine();
            Console.WriteLine();

            //init
            var low_line = '_';
            var minus = '-';
            var plus = '+';
            char player_guess;
            var game_on = true;
            var tries = 0;
            var victory_condition = 0;

            //split the word
            var lenght = result.Length;
            var split_result = new char[lenght];
            split_result = result.ToCharArray();
            //Array for checking results
            var game_in_progress = new char[lenght];
            for (var i = 0; i < result.Length; i++) game_in_progress[i] = minus;

            //exec
            while (game_on == true)
            {
                for (var i = 0; i < result.Length; i++)
                {
                    if (game_in_progress[i] == minus) Console.Write("{0} ", low_line);
                    if (game_in_progress[i] == plus)
                    {
                        Console.Write(split_result[i]);
                        victory_condition++;

                        if (victory_condition == result.Length)
                        {
                            Console.WriteLine();
                            Console.WriteLine("You won the game in {0} tries", tries);
                            game_on = false;
                            Environment.Exit(5);
                        }
                    }
                }

                Console.WriteLine();
                Console.Write("Enter a letter: ");
                player_guess = Convert.ToChar(Console.ReadLine());
                for (var j = 0; j < result.Length; j++)
                    if (player_guess == split_result[j])
                        game_in_progress[j] = plus;
                victory_condition = 0;
                tries++;
            }
        }

        private static void Data_Types_Decimal_Double()
        {
            //init
            var random = new Random();
            double new_decimal_comma, new_decimal, new_discount_comma, new_discount;
            decimal new_deci, total, new_disc;
            var stringBase = new string[4];
            stringBase[0] = "Your discount = ";
            stringBase[1] = "New Price = ";
            stringBase[2] = "Old Price = ";
            stringBase[3] = "Press any button to continue";

            //Get a decimal
            new_decimal_comma = random.NextDouble();
            new_decimal = random.Next(1, 100);
            new_deci = Convert.ToDecimal(new_decimal + new_decimal_comma);

            //get dat discount
            new_discount_comma = random.NextDouble();
            new_discount = random.Next(1, Convert.ToInt32(new_decimal));
            new_disc = Convert.ToDecimal(new_discount + new_discount_comma);

            //output
            total = new_deci - new_disc;
            Console.WriteLine(stringBase[2] + Math.Round(new_deci, 2));
            Console.WriteLine(stringBase[0] + Math.Round(new_disc, 2));
            Console.WriteLine(stringBase[1] + Math.Round(total, 2));

            Console.WriteLine(stringBase[3]);
            Console.ReadLine();
            Main();
        }

        private static void Data_Types_Int()
        {
            //get Length for array
            Console.WriteLine("Input Array Lenght");
            var IntBaseLength = Convert.ToInt32(Console.ReadLine());
            var total = 0;

            var intBase = new int[IntBaseLength];

            for (var i = 0; i < intBase.Length; i++)
            {
                Console.WriteLine("Input Value " + i);
                intBase[i] = Convert.ToInt32(Console.ReadLine());
                total += intBase[i];
            }

            Console.WriteLine("Total = " + total);
            Console.ReadLine();
            Main();
        }

        private static void Data_Types_Char()
        {
            char[] chars = {'A', 'B', 'C', 'D', 'E', 'F', 'G', '0', '1'};
            var random = new Random();
            var character_random = random.Next(0, chars.Length);
            Console.Clear();
            Console.WriteLine("Random Char of the Day is ...... " + chars[character_random]);
            var char_temp_storage = new char[5];
            Console.WriteLine();

            Console.WriteLine("Keep inputting a single character until cows come home. (5)");
            for (var i = 0; i < 4; i++) char_temp_storage[i] = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Time for a miracle!");
            Console.WriteLine();
            for (var i = 4; i >= 0; i--) Console.WriteLine(char_temp_storage[i]);
            Console.ReadLine();
            Main();
        }

        private static void Data_Types_Bool()
        {
            var truth_count = 0;
            var gamemode = true;
            var opinion_poll = new bool[5];
            var Questions = new string[5];
            Questions[0] = "Do you believe in our lord and saviour Cheesus";
            Questions[1] = "Do you like Cheese?";
            Questions[2] = "Do you believe WW2 would have been avoided if Cheese was cheap?";
            Questions[3] = "Do you find that cheese prices are silly atm?";
            Questions[4] = "Cheese = Food = YUM?";
            Console.WriteLine("All the info provided here will be used against you, do you agree?");
            Console.ReadLine();
            Console.WriteLine("*pretends to read the inputted text*");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            while (gamemode == true)
            {
                for (var i = 0; i < opinion_poll.Length; i++)
                {
                    Console.WriteLine("input Y or N");
                    Console.WriteLine(Questions[i]);
                    var x = Convert.ToChar(Console.ReadLine());
                    if (x == 'y')
                    {
                        opinion_poll[i] = true;
                        truth_count++;
                    }

                    if (x == 'n') opinion_poll[i] = true;
                }

                if (truth_count > 3)
                    Console.WriteLine("Good boy!");
                else
                    Console.WriteLine("WHAT THE CHEESE!!!!");
                Console.WriteLine("Continue?");
                var end_game = Convert.ToChar(Console.ReadLine());
                if (end_game == 'n')
                {
                    gamemode = false;
                    Console.WriteLine("Have a Snack, Have a poro snacc");
                    Console.ReadLine();
                    Main();
                }
            }
        }

        private static void Data_Types_Values()
        {
            Console.Clear();
            //init
            Console.WriteLine("Please, choose one of the options below:");
            var Data_Types_Values_Array = new string[11];
            Data_Types_Values_Array[0] = "int";
            Data_Types_Values_Array[1] = "char";
            Data_Types_Values_Array[2] = "decimal";
            Data_Types_Values_Array[3] = "double";
            Data_Types_Values_Array[4] = "short";
            Data_Types_Values_Array[5] = "float";
            Data_Types_Values_Array[6] = "byte";
            Data_Types_Values_Array[7] = "sbyte";
            Data_Types_Values_Array[8] = "long";
            Data_Types_Values_Array[9] = "ulong";
            Data_Types_Values_Array[10] = "uint";
            var DTV_start = "Max and Min Value";
            //List
            for (var i = 0; i < Data_Types_Values_Array.Length; i++)
                Console.WriteLine($"{i}. {Data_Types_Values_Array[i]} {DTV_start}");

            //inti string
            var Data_Types_Menu = Convert.ToInt32(Console.ReadLine());
            var console_out_max = "Max value is ";
            var console_out_min = "Min value is ";
            //workaround for multiple type var
            var valueMax = new object { };
            var valueMin = new object { };

            //assign value
            if (Data_Types_Menu < Data_Types_Values_Array.Length + 1)
            {
                if (Data_Types_Menu == 0)
                {
                    valueMax = int.MaxValue;
                    valueMin = int.MinValue;
                }

                if (Data_Types_Menu == 1)
                {
                    valueMax = char.MaxValue;
                    valueMin = char.MinValue;
                }

                if (Data_Types_Menu == 2)
                {
                    valueMax = decimal.MaxValue;
                    valueMin = decimal.MinValue;
                }

                if (Data_Types_Menu == 3)
                {
                    valueMax = double.MaxValue;
                    valueMin = double.MinValue;
                }

                if (Data_Types_Menu == 4)
                {
                    valueMax = short.MaxValue;
                    valueMin = short.MinValue;
                }

                if (Data_Types_Menu == 5)
                {
                    valueMax = float.MaxValue;
                    valueMin = float.MinValue;
                }

                if (Data_Types_Menu == 6)
                {
                    valueMax = byte.MaxValue;
                    valueMin = byte.MinValue;
                }

                if (Data_Types_Menu == 7)
                {
                    valueMax = sbyte.MaxValue;
                    valueMin = sbyte.MinValue;
                }

                if (Data_Types_Menu == 8)
                {
                    valueMax = long.MaxValue;
                    valueMin = long.MinValue;
                }

                if (Data_Types_Menu == 9)
                {
                    valueMax = ulong.MaxValue;
                    valueMin = ulong.MinValue;
                }

                if (Data_Types_Menu == 10)
                {
                    valueMax = uint.MaxValue;
                    valueMin = uint.MinValue;
                }
            }
            else
            {
                valueMax = 0;
            }

            ;

            //output
            Console.WriteLine($"{Data_Types_Values_Array[Data_Types_Menu]} {console_out_max} {valueMax}");
            Console.WriteLine($"{Data_Types_Values_Array[Data_Types_Menu]} {console_out_min} {valueMin}");

            //loop
            Console.WriteLine("Return to menu? y or n");
            var return_to_menu = Console.ReadLine();
            if (return_to_menu == "y")
                Main();
            else
                Data_Types_Values();
        }

        private static void Data_Types_Sym()
        {
            Console.WriteLine("Input a String or Character Line, Danke! <3");
            //Init
            var string_sym_line_input = Console.ReadLine();
            var string_sym_part_one = "";
            var string_sym_part_two = "";
            var string_sym = new char[string_sym_line_input.Length];
            string_sym = string_sym_line_input.ToCharArray();
            for (var i = string_sym_line_input.Length - 1; i >= string_sym_line_input.Length / 2; i--)
                string_sym_part_one = Convert.ToString(string_sym[i]);
            for (var i = 0; i < string_sym_line_input.Length / 2; i++)
                string_sym_part_two = Convert.ToString(string_sym[i]);

            if (string_sym_part_one == string_sym_part_two)
                Console.WriteLine("Is symmetrical");
            else
                Console.WriteLine("Not even remotely symmetrical");
            Console.ReadKey();
            Main();
        }

        private static void ForEachCycle()
        {
            var rand = new Random();
            var rand_string_line = "";
            var string_massive = new string[10];
            var randomChar = (char) rand.Next('a', 'z');

            for (var i = 0; i < string_massive.Length; i++)
            {
                for (var j = 0; j <= 3; j++) rand_string_line = rand_string_line + randomChar;
                string_massive[i] = rand_string_line;
                Console.WriteLine(string_massive[i]);
            }

            Console.ReadLine();
        }
    }
}