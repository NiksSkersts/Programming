using System;

namespace get_set
{
    // https://www.w3schools.com/cs/cs_properties.asp
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = new Darbinieks();

            Console.Write("Input a name: ");
            test.vards2 = Console.ReadLine();
            Console.WriteLine("Name: " + test.vards2);

            Console.Write("Input a surname: ");
            test.uzvards2 = Console.ReadLine();
            Console.WriteLine("Surname: ");
            Console.Write("Input DoB: ");
            test.dzimsanas_gads_2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Age: " + test.vecums);
        }

        private class Darbinieks
        {
            private int date = DateTime.Now.Year;
            private string vards;

            public string vards2
            {
                get => vards;
                set
                {
                    if (value.Length <= 20)
                        vards = value;
                    else
                        vards = "nedefinets :(";
                }
            }

            private string uzvards;

            public string uzvards2
            {
                get => uzvards;
                set
                {
                    if (vards == null)
                        Console.WriteLine("vards nav definets");
                    else
                        uzvards = value;
                }
            }

            private int dzimsana_gads;

            public int dzimsanas_gads_2
            {
                get => dzimsana_gads;
                set => dzimsana_gads = value;
            }

            public int vecums
            {
                get => date - dzimsana_gads;
                set { ; }
            }
        }
    }
}

// 2 uzd

using System;

namespace get_set
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/destructors
    // My destructors are mean and aren't being called :(
    public class Pirmais
    {
        public Pirmais()
        {
            Console.WriteLine("Tiek izveidots Pirmais objekts");
        }

        ~Pirmais()
        {
            Console.WriteLine("Pirmais objekts tiek iznicinats");
        }
    }

    public class Otrais : Pirmais
    {
        public Otrais()
        {
            Console.WriteLine("Tiek izveidots Otrais objekts");
        }

        ~Otrais()
        {
            Console.WriteLine("Otrais objekts tiek iznicinats");
        }
    }

    public class Tresais : Otrais
    {
        public Tresais()
        {
            Console.WriteLine("Tiek izveidots Tresais objekts");
        }

        ~Tresais()
        {
            Console.WriteLine("Tresais objekts tiek iznicinats");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var Test = new Tresais();
        }
    }
}

//3

namespace get_set
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Test = new Konstruktors();
            var Test1 = new Konstruktors(454641);
            var Test2 = new Konstruktors(5.84);
            var Test3 = new Konstruktors("random");
        }
    }

    internal class Konstruktors
    {
        public Konstruktors()
        {
            Console.WriteLine("Default konstruktors");
        }

        public Konstruktors(int i)
        {
            Console.WriteLine("int tipa param.: " + i);
        }

        public Konstruktors(double d)
        {
            Console.WriteLine("double tipa param.: " + d);
        }

        public Konstruktors(string s)
        {
            Console.WriteLine("string tipa param.: " + s);
        }
    }
}