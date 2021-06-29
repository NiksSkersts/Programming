using System;
using System.Threading;

namespace Programming_Basics_I
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private void FirstTask()
        {
            Console.WriteLine("OMG, what a beautiful world!");
            //           Console.ReadLine();
            Console.WriteLine("YASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            //            Console.Write("dunnnn");
            var a = 1;
            var b = 3;
            b = a + 9;
            var c = a + b;
            Console.Write(b);
            Console.Write("/");
            Console.Write(c);
            // I AM NOT TRYING TO DIVIDE b with c!
            Console.WriteLine("");
            Console.WriteLine("Write smth in. eksdee");
            Console.ReadLine();
            if (b > c) ;
            {
                Console.WriteLine("PFFFFFFFFFFFFFF");
            }
        }

        private void SecondTask()
        {
            //BASIC MATH***
            var firstOne = 6;
            var secondOne = 4;
            var a = 3.4;
            double b = 5;
            double c;

            c = firstOne + secondOne;
            c = firstOne * secondOne;
            c = firstOne / secondOne;

            Console.Write(c);
            Console.Write("/");
            Console.Write(c);
            Console.ReadLine();

            //SLIGHTLY ADVANCED MATH***


            double H = 9;
            double R = 3;
            var pi = 3.14159265359;
            double sanuMalas;
            double rinkaLaukums;
            double pilnaisLaukums;
            var V = pi * (R * R) * H;


            sanuMalas = 2 * pi * R * H;
            rinkaLaukums = pi * (R * R);
            pilnaisLaukums = 2 * rinkaLaukums + sanuMalas;

            Console.WriteLine("Cilindra laukums =" + pilnaisLaukums);
            Console.WriteLine("Cilindra tilpums =" + V);
            Console.ReadLine();
        }

        private void ThirdTask()
        {
            //2.uzd
            var R = 2.4;
            var pi = 3.14159265359;
            double RLG;
            double RL;
            double LL;
            double LT;

            RL = pi * (R * R);
            RLG = 2 * pi * R;
            LL = 4 * pi * (R * R);
            LT = 4 * pi * (R * R * R) / 3;
            Console.WriteLine("2.UZD");
            Console.WriteLine("Rādiuss =" + R);
            Console.WriteLine("Rinķa līnijas garums =" + RLG);
            Console.WriteLine("Rinķa laukums =" + RL);
            Console.WriteLine("Lodes Laukums =" + LL);
            Console.WriteLine("Lodes tilpums =" + LT);
            Console.ReadLine();
            Console.WriteLine("");

            //1.uzd

            double A = 5;
            double B = 4;
            double C;
            double D;
            double E;
            double F;

            C = A * B;
            D = A - B;
            E = A + B;
            F = A / B;
            Console.WriteLine("1.UZD");
            Console.WriteLine("");
            Console.WriteLine("Reizinājums =" + C);
            Console.WriteLine("Atņemšana =" + D);
            Console.WriteLine("Summa =" + E);
            Console.WriteLine("Dalīšana =" + F);
        }

        private void FourthTask()
        {
            //double b = 65;
            Console.WriteLine("Please write a number! Pretty please??? *puppy eyes*");
            //double a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}\t{1}", a, b);
            //Console.WriteLine("{0}\n{1}", a, b);
            //double c = Math.Pow(2,4);
            //Console.WriteLine(c);

            Console.WriteLine("Please write the first number!");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please write the second number!");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Attaboy!");
            Console.WriteLine("");

            var plus = a + b;
            var minus = a - b;
            var subtract = a * b;
            var divide = a / b;
            double percent = (int) a % (int) b;
            var fraction = a / b;
            var squared1 = Math.Pow(a, 2);
            var squared2 = Math.Pow(b, 2);
            //+
            Console.Write("The sum of {0} and {1} is ", a, b);
            Console.Write(plus);
            Console.WriteLine("");
            Console.WriteLine("");
            //-
            Console.Write("The difference between {0} and {1} is ", a, b);
            Console.Write(minus);
            Console.WriteLine("");
            Console.WriteLine("");
            //*
            Console.Write("Sum of subtraction between {0} and {1} is ", a, b);
            Console.Write(subtract);
            Console.WriteLine("");
            Console.WriteLine("");
            // "/"
            Console.Write("a/b = ");
            Console.Write(Convert.ToInt32(divide));
            Console.WriteLine("");
            Console.WriteLine("");
            // %
            Console.Write("a%b = ");
            Console.Write(percent);
            Console.WriteLine("");
            Console.WriteLine("");
            //fraction
            Console.Write("fraction is ");
            Console.Write(fraction);
            Console.WriteLine("");
            Console.WriteLine("");
            //squared
            Console.Write("a plus b squared is ");
            Console.Write(squared1 + squared2);
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("End of Task 1, proceed with task 2? Y or N");
            var t2 = Console.ReadLine();
            if (t2 == "y")
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t" + "\t" + "\t" + "Multiplication Table" + "\t");
                Console.WriteLine("____________________________________________________________________________");
                Console.WriteLine("|" + 1 * 1 + "\t" + 1 * 2 + "\t" + 1 * 3 + "\t" + 1 * 4 + "\t" + 1 * 5 + "\t" +
                                  1 * 6 + "\t" + 1 * 7 + "\t" + 1 * 8 + "\t" + 1 * 9 + "\t" + 1 * 10 + " |");
                Console.WriteLine("|" + 2 * 1 + "\t" + 2 * 2 + "\t" + 2 * 3 + "\t" + 2 * 4 + "\t" + 2 * 5 + "\t" +
                                  2 * 6 + "\t" + 2 * 7 + "\t" + 2 * 8 + "\t" + 2 * 9 + "\t" + 2 * 10 + " |");
                Console.WriteLine("|" + 3 * 1 + "\t" + 3 * 2 + "\t" + 3 * 3 + "\t" + 3 * 4 + "\t" + 3 * 5 + "\t" +
                                  3 * 6 + "\t" + 3 * 7 + "\t" + 3 * 8 + "\t" + 3 * 9 + "\t" + 3 * 10 + " |");
                Console.WriteLine("|" + 4 * 1 + "\t" + 4 * 2 + "\t" + 4 * 3 + "\t" + 4 * 4 + "\t" + 4 * 5 + "\t" +
                                  4 * 6 + "\t" + 4 * 7 + "\t" + 4 * 8 + "\t" + 4 * 9 + "\t" + 4 * 10 + " |");
                Console.WriteLine("|" + 5 * 1 + "\t" + 5 * 2 + "\t" + 5 * 3 + "\t" + 5 * 4 + "\t" + 5 * 5 + "\t" +
                                  5 * 6 + "\t" + 5 * 7 + "\t" + 5 * 8 + "\t" + 5 * 9 + "\t" + 5 * 10 + " |");
                Console.WriteLine("|" + 6 * 1 + "\t" + 6 * 2 + "\t" + 6 * 3 + "\t" + 6 * 4 + "\t" + 6 * 5 + "\t" +
                                  6 * 6 + "\t" + 6 * 7 + "\t" + 6 * 8 + "\t" + 6 * 9 + "\t" + 6 * 10 + " |");
                Console.WriteLine("|" + 7 * 1 + "\t" + 7 * 2 + "\t" + 7 * 3 + "\t" + 7 * 4 + "\t" + 7 * 5 + "\t" +
                                  7 * 6 + "\t" + 7 * 7 + "\t" + 7 * 8 + "\t" + 7 * 9 + "\t" + 7 * 10 + " |");
                Console.WriteLine("|" + 8 * 1 + "\t" + 8 * 2 + "\t" + 8 * 3 + "\t" + 8 * 4 + "\t" + 8 * 5 + "\t" +
                                  8 * 6 + "\t" + 8 * 7 + "\t" + 8 * 8 + "\t" + 8 * 9 + "\t" + 8 * 10 + " |");
                Console.WriteLine("|" + 9 * 1 + "\t" + 9 * 2 + "\t" + 9 * 3 + "\t" + 9 * 4 + "\t" + 9 * 5 + "\t" +
                                  9 * 6 + "\t" + 9 * 7 + "\t" + 9 * 8 + "\t" + 9 * 9 + "\t" + 9 * 10 + " |");
                Console.WriteLine("|" + 10 * 1 + "\t" + 10 * 2 + "\t" + 10 * 3 + "\t" + 10 * 4 + "\t" + 10 * 5 + "\t" +
                                  10 * 6 + "\t" + 10 * 7 + "\t" + 10 * 8 + "\t" + 10 * 9 + "\t" + 10 * 10 + "|");
                Console.WriteLine("____________________________________________________________________________");

                Console.WriteLine("Press any button to continue :)");
                Console.WriteLine("");
                Console.WriteLine("");
                var t3 = Console.ReadLine();
                if (t3 == "")
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Have a nice day!");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("OH WELL!!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("Self-destruct sequence initiated");
                Console.WriteLine("#StarTrekReferences");
                Thread.Sleep(TimeSpan.FromSeconds(4));
                Environment.Exit(0);
            }
        }

        private void FifthTask()
        {
            Console.Write("Input a: ");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Increment result is " + a++);
            Console.WriteLine("Increment result is " + a++);
            Console.WriteLine("Increment result is " + a++);
            Console.WriteLine("Increment result is " + a++);
            Console.WriteLine("Increment result is " + a++);
            Console.Write("Input b: ");
            var b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Increment result is " + b--);
            Console.WriteLine("Increment result is " + b--);
            Console.WriteLine("Increment result is " + b--);
            Console.WriteLine("Increment result is " + b--);
            Console.WriteLine("Increment result is " + b--);
            Console.WriteLine("Thank you for your cooperation Human!");
            Console.WriteLine("Off to the next task!");
            Console.WriteLine();
            Console.WriteLine("Task 2");
            Console.WriteLine();
            Console.Write("Input your name, Human: ");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Now input your surname: ");
            var surname = Console.ReadLine();
            var NM = name + " " + surname + "!";
            Console.Write("Welcome to Planet Earth: " + NM);
            Console.WriteLine("");
            Console.WriteLine("Last But not least, well it's the last one. Pardon!");
            Console.WriteLine("");
            Console.WriteLine("Let's make something cool!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Voila!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("****    **  ******** ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("** **   **  ***      ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("**  **  **     ***   ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("**   ** **        ***");
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**    ****  ******** ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Cool, right?");
        }

        private void Something()
        {
            double a;
            double c;
            string b;
            Console.WriteLine("Please input a number!");
            a = Convert.ToInt32(Console.ReadLine());
            c = a / 2;
            if ((int) c == c) Console.WriteLine("Skaitlis " + "" + a + " ir pāra skaitlis", a);
            else Console.WriteLine("Skaitlis " + +a + " ir nepāra skaitlis", a);

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            double x;
            double y;
            Console.WriteLine("Please input x");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please input y");
            y = Convert.ToDouble(Console.ReadLine());
            if (y != 0) Console.WriteLine("Result is " + x / y);
            else Console.WriteLine("Division by 0");

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            var pass = "HALLO";
            Console.WriteLine("Side note: Predefined Password is " + pass);
            Console.WriteLine("Input your username");
            var teksts = Console.ReadLine();
            Console.WriteLine("Input your password");
            var password = Console.ReadLine();

            if (password.Length == 5)
            {
                if (password == pass)
                    Console.WriteLine("Password is correct!");

                else
                    Console.WriteLine("Password is incorrect...");
            }
            else
            {
                Console.WriteLine("Password must contain atleast 5 characters!");
            }

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();
            Console.WriteLine("Formulu saraksts:");
            Console.WriteLine("1 - Kvadrāta perimetra formula");
            Console.WriteLine("2 - Kvadrāta laukuma formula");
            Console.WriteLine("3 - Kvadrāta diognāles formula");
            Console.WriteLine("Ievadiet Kvadrāta malas garumu:");
            var Mala = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Izvēlieties formulu!");
            var choice = Convert.ToInt32(Console.ReadLine());
            double p;
            switch (choice)
            {
                case 1:
                    p = Mala * 4;
                    Console.WriteLine("Kvadrāta perimetrs ir " + p);
                    break;
                case 2:
                    p = Mala ^ 2;
                    Console.WriteLine("Kvadrāta laukums ir " + p);
                    break;
                case 3:
                    p = Math.Sqrt(2) * Mala;
                    Console.WriteLine("Kvadrāta diagonāle ir " + p);
                    break;
                default:
                    Console.WriteLine("Tādas darbības nav!!!");
                    break;
            }
        }

        private void Cycles()
        {
            var b = true;
            do
            {
                Console.WriteLine("Type a number from one to ten.");
                Console.WriteLine("Pick either 1 or 5 to exit this thing!");
                var a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("One");
                        b = false;
                        break;
                    case 2:
                        Console.WriteLine("Two");
                        break;
                    case 3:
                        Console.WriteLine("Three");
                        break;
                    case 4:
                        Console.WriteLine("Four");
                        break;
                    case 5:
                        Console.WriteLine("Five");
                        b = false;
                        break;
                    case 6:
                        Console.WriteLine("Six");
                        break;
                    case 7:
                        Console.WriteLine("Seven");
                        break;
                    case 8:
                        Console.WriteLine("Eight");
                        break;
                    case 9:
                        Console.WriteLine("Nine");
                        break;
                    case 10:
                        Console.WriteLine("Ten");
                        break;
                }
            } while (b == true);

            Console.WriteLine("Terminated :((");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Next");

            Console.WriteLine("How many times should I check?");
            var check = Convert.ToInt32(Console.ReadLine());
            double sum;
            double divider = 3;
            for (var end = check; end != 0; end--)
            {
                Console.WriteLine("Please enter a number!");
                var number = Convert.ToDouble(Console.ReadLine());
                sum = number % divider;
                if (sum == 0)
                    Console.WriteLine("Number {0} can be divided by {1}", number, divider);
                else
                    Console.WriteLine("Number {0} can't be divided by {1}", number, divider);
            }

            Console.WriteLine("Terminated :((");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Next");

            Console.WriteLine("Ievadiet Platumu");
            var x = Convert.ToInt32(Console.ReadLine());
            var i = 1;
            while (i <= x)
            {
                Console.WriteLine("");
                var k = 15;
                var h = 1;
                while (k > i)
                {
                    Console.Write(" ");
                    k--;
                }

                while (h <= i)
                {
                    Console.Write("**");
                    h++;
                }

                i++;
            }

            Console.ReadLine();
        }

        private void For()
        {
            int i, number, fact, factorial;
            Console.Write("Enter the Number: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("Input factorial: ");
            factorial = int.Parse(Console.ReadLine());
            Console.WriteLine();
            fact = number;
            for (i = 1; i != factorial + 1; i++)
            {
                fact = fact * i;
                Console.WriteLine("{0}*{1} = {2}", i, fact, fact);
            }

            Console.WriteLine();
            Console.WriteLine("proceed to next task?");
            Console.WriteLine("No choice really.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Task two");

            int a;
            Console.Write("Enter the amount you're gonna deposit: ");
            var deposit = Convert.ToDouble(Console.ReadLine());
            Console.Write("For how long? ");
            var years = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the percentage: ");
            var percentage = Convert.ToDouble(Console.ReadLine());
            for (a = 0; a != years; a++)
            {
                deposit = deposit * percentage + deposit;
                Console.WriteLine("In year {0}, your deposit will be {1}", a + 1, Math.Round(deposit, 2));
            }

            Console.WriteLine();
            Console.WriteLine("proceed to next task?");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Task three");

            Console.Write("   ");
            for (var n = 1; n < 10; n++) Console.Write(n + "\t");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            for (var n = 1; n < 10; n++)
            {
                Console.Write(i + " |");
                for (var j = 1; j < 10; j++) Console.Write(n * j + "\t");
                Console.WriteLine();
            }
        }

        private void IF()
        {
            double a;
            double c;
            string b;
            Console.WriteLine("Please input a number!");
            a = Convert.ToInt32(Console.ReadLine());
            c = a / 2;
            if ((int) c == c) Console.WriteLine("Skaitlis " + "" + a + " ir pāra skaitlis", a);
            else Console.WriteLine("Skaitlis " + +a + " ir nepāra skaitlis", a);

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            double x;
            double y;
            Console.WriteLine("Please input x");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please input y");
            y = Convert.ToDouble(Console.ReadLine());
            if (y != 0) Console.WriteLine("Result is " + x / y);
            else Console.WriteLine("Division by 0");

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            var pass = "HALLO";
            Console.WriteLine("Side note: Predefined Password is " + pass);
            Console.WriteLine("Input your username");
            var teksts = Console.ReadLine();
            Console.WriteLine("Input your password");
            var password = Console.ReadLine();

            if (password.Length == 5)
            {
                if (password == pass)
                    Console.WriteLine("Password is correct!");

                else
                    Console.WriteLine("Password is incorrect...");
            }
            else
            {
                Console.WriteLine("Password must contain atleast 5 characters!");
            }

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();
            Console.WriteLine("Formulu saraksts:");
            Console.WriteLine("1 - Kvadrāta perimetra formula");
            Console.WriteLine("2 - Kvadrāta laukuma formula");
            Console.WriteLine("3 - Kvadrāta diognāles formula");
            Console.WriteLine("Ievadiet Kvadrāta malas garumu:");
            var Mala = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Izvēlieties formulu!");
            var choice = Convert.ToInt32(Console.ReadLine());
            double p;
            switch (choice)
            {
                case 1:
                    p = Mala * 4;
                    Console.WriteLine("Kvadrāta perimetrs ir " + p);
                    break;
                case 2:
                    p = Mala ^ 2;
                    Console.WriteLine("Kvadrāta laukums ir " + p);
                    break;
                case 3:
                    p = Math.Sqrt(2) * Mala;
                    Console.WriteLine("Kvadrāta diagonāle ir " + p);
                    break;
                default:
                    Console.WriteLine("Tādas darbības nav!!!");
                    break;
            }
        }

        private void While()
        {
            double a;
            double c;
            string b;
            Console.WriteLine("Please input a number!");
            a = Convert.ToInt32(Console.ReadLine());
            c = a / 2;
            if ((int) c == c) Console.WriteLine("Skaitlis " + "" + a + " ir pāra skaitlis", a);
            else Console.WriteLine("Skaitlis " + +a + " ir nepāra skaitlis", a);

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            double x;
            double y;
            Console.WriteLine("Please input x");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please input y");
            y = Convert.ToDouble(Console.ReadLine());
            if (y != 0) Console.WriteLine("Result is " + x / y);
            else Console.WriteLine("Division by 0");

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();

            var pass = "HALLO";
            Console.WriteLine("Side note: Predefined Password is " + pass);
            Console.WriteLine("Input your username");
            var teksts = Console.ReadLine();
            Console.WriteLine("Input your password");
            var password = Console.ReadLine();

            if (password.Length == 5)
            {
                if (password == pass)
                    Console.WriteLine("Password is correct!");

                else
                    Console.WriteLine("Password is incorrect...");
            }
            else
            {
                Console.WriteLine("Password must contain atleast 5 characters!");
            }

            //next
            Console.WriteLine("Next Task");
            b = Convert.ToString(Console.ReadLine());
            if (b == "y" || b == "Y") Console.Clear();
            Console.WriteLine("Formulu saraksts:");
            Console.WriteLine("1 - Kvadrāta perimetra formula");
            Console.WriteLine("2 - Kvadrāta laukuma formula");
            Console.WriteLine("3 - Kvadrāta diognāles formula");
            Console.WriteLine("Ievadiet Kvadrāta malas garumu:");
            var Mala = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Izvēlieties formulu!");
            var choice = Convert.ToInt32(Console.ReadLine());
            double p;
            switch (choice)
            {
                case 1:
                    p = Mala * 4;
                    Console.WriteLine("Kvadrāta perimetrs ir " + p);
                    break;
                case 2:
                    p = Mala ^ 2;
                    Console.WriteLine("Kvadrāta laukums ir " + p);
                    break;
                case 3:
                    p = Math.Sqrt(2) * Mala;
                    Console.WriteLine("Kvadrāta diagonāle ir " + p);
                    break;
                default:
                    Console.WriteLine("Tādas darbības nav!!!");
                    break;
            }
        }

        private void KDI()
        {
            int i;
            double sum = 0;
            Console.Write("Input number n : ");
            var n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input {0} whole numbers:", n);
            for (i = 0; i != n; i++)
            {
                Console.Write("whole number[{0}] : ", i);
                var number = Convert.ToInt32(Console.ReadLine());
                double mult = number % 2;
                if (mult == 0)
                {
                    Console.WriteLine("Para skaitlis");
                    sum += number;
                }
                else
                {
                    Console.WriteLine("nepara skaitlis");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Sum is = {0}", sum);
            Console.WriteLine("TASK 2");
            Console.ReadLine();
            Console.Clear();
            var izvelne1 = "I";
            var izvelne2 = "T";
            var izvelne3 = "F";
            var izvelne4 = "ITF";
            var izvelne5 = "Iziet";

            var izvelne = false;
            do
            {
                Console.WriteLine(izvelne1);
                Console.WriteLine(izvelne2);
                Console.WriteLine(izvelne3);
                Console.WriteLine(izvelne4);
                Console.WriteLine(izvelne5);
                Console.WriteLine("");
                Console.WriteLine("pick an option (uppercase!)");
                var option = Console.ReadLine();

                switch (option)
                {
                    default:
                        Console.WriteLine("No such option!!!");
                        break;
                    case "I":
                        Console.WriteLine("punkts I = " + izvelne1);
                        break;
                    case "T":
                        Console.WriteLine("punkts T = " + izvelne2);
                        break;
                    case "F":
                        Console.WriteLine("punkts F = " + izvelne3);
                        break;
                    case "ITF":
                        Console.WriteLine("punkts ITF = " + izvelne1 + izvelne2 + izvelne3);
                        break;
                    case "Iziet":
                        izvelne = true;
                        break;
                }
            } while (izvelne == false);
        }

        private void KDII()
        {
            //1.uzdevums
            /*
            Console.Write("Ievadiet skaitli:");
            int n = Convert.ToInt32(Console.ReadLine());
            string l = Convert.ToString(n);

            
            switch (l.Length)
            {

                case 1: Console.WriteLine("Skaitlis ir viencipara");
                break;
                case 2: Console.WriteLine("Skaitlis ir divciparu");
                    break;
                case 3: Console.WriteLine("Skaitlis ir trisciparu");
                    break;
                default: Console.WriteLine("Ievaditajam skaitlim ir vairak par 3 cipariem");
                    break;
                                       
            }
            */

            //2.uzdevums

            Console.Write("Ievadiet tekstu: ");
            var a = Console.ReadLine();
            Console.WriteLine("Teksta garums ir {0} simboli", a.Length);
            var i = 0;
            while (a.Length > i)
            {
                Console.Write("*");
                i++;
            }

            Console.WriteLine();
        }
    }
}