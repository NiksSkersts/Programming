using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

//1 uzd
// Ref un out tiek izmantoti, lai nodotu argumentus metodei vai funkcijai.
// Ref nodod atsauci uz vērtību un var izmainīt oriģināl vērtību. Out arī nodod atsauci, bet neatļauj mainīt oriģinālvērtību
// Ref parametrs vai arguments ir jādeklarē (initialize), Out param vai arg nav obligāti jādeklarē.
// ref vērtība ir jādeklarē. Out nav obligāti jādeklarē, bet ir noderīgi, kad jānodod vairākas vērtības.
// ref dati var tikt nodoti abējādi. Out tikai vienā virzienā
namespace _9_uzd
{
    internal class Program
    {
        private static void Main()
        {
            var one = new Calc();
            Console.Write("Input sk: ");
            var sk = Console.ReadLine();
            int.TryParse(sk, out var sk1);

            Console.Write("Input x: ");
            var x = Console.ReadLine();
            int.TryParse(x, out var x1);

            Console.Write("Input y: ");
            var y = Console.ReadLine();
            int.TryParse(y, out var y1);

            one.Cubed(ref sk1);
            Console.WriteLine("SK squared by 3: " + sk1);

            one.Multiply(ref x1, ref y1);
            Console.WriteLine("x * y = " + x1);
        }
    }

    internal class Calc
    {
        public void Cubed(ref int x)
        {
            x = (int) Math.Pow(x, 3);
        }

        public void Multiply(ref int x, ref int y)
        {
            x = y * x;
        }
    }
}

//2 uzd
namespace _9_1_uzd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Input x: ");
            var x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input y: ");
            var y = Convert.ToInt32(Console.ReadLine());

            Math.Min(x, y);
            Math.Max(x, y);
            //Params ņem vērā mainīgo arg skaitu.
            MansMath.Min(6, 2, 9, 5, 1, 3, 6, 6, 65, 26, 5, 262, 65, 26, 2);
            MansMath.Max(9, 1, 54, 4, 15, 5, 15, 85, 45, 1, 54, 51);
        }
    }

    internal class Math
    {
        public static void Min(int x, int y)
        {
            if (x < y)
                Console.WriteLine("Min: X: " + x);
            else
                Console.WriteLine("Min Y: " + y);
        }

        public static void Max(int x, int y)
        {
            if (x > y)
                Console.WriteLine("Max X: " + x);
            else
                Console.WriteLine("Max Y: " + y);
        }
    }

    internal class MansMath
    {
        public static void Min(params int[] x)
        {
            Console.WriteLine("Min V2 X: " + x.Min());
        }

        public static void Max(params int[] x)
        {
            Console.WriteLine("Max V2 Y: " + x.Max());
        }
    }
}