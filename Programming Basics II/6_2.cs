using System;

namespace Prakse
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var k = new Cetrsturis();
            k.Registret();
            k.Izvadit();
        }
    }

    public class Punkts
    {
        public int X;
        public int Y;
        public string Krasa;

        public void Registret()
        {
            Console.WriteLine("Ievadiet X vertibu");
            X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ievadiet Y vertibu");
            Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ievadiet Krasu");
            Krasa = Convert.ToString(Console.ReadLine());
        }

        public void Izvadit()
        {
            Console.WriteLine("x= " + X + "y= " + Y + "Krasa: " + Krasa);
        }
    }

    public class Linija
    {
        private Punkts A;
        private Punkts B;
        private string Krasa;

        public void Registret()
        {
            Console.WriteLine("-----X------");
            A = new Punkts();
            A.Registret();
            Console.WriteLine("-----Y------");
            B = new Punkts();
            B.Registret();
        }

        public double Garums()
        {
            double ret = 0;
            var X1 = A.X;
            var Y1 = B.X;
            var X2 = A.Y;
            var Y2 = B.Y;

            ret = Math.Sqrt(Y1 - X1 + (Y2 - X2));

            return ret;
        }

        public void Izvadit()
        {
            A.Izvadit();
            B.Izvadit();
            Console.WriteLine(Garums());
            Console.WriteLine(Krasa);
        }
    }

    public class Cetrsturis
    {
        private Linija Linija1 = new();
        private Linija Linija2 = new();
        private Linija Linija3 = new();
        private Linija Linija4 = new();

        public void Registret()
        {
            Linija1.Registret();
            Linija2.Registret();
            Linija3.Registret();
            Linija4.Registret();
        }

        public double Perimetrs()
        {
            double ret = 0;
            ret = Linija1.Garums() + Linija2.Garums() + Linija3.Garums() + Linija4.Garums();
            return ret;
        }

        public bool IrTaisnsturis()
        {
            var ret = false;
            if (Linija1.Garums() == Linija3.Garums() && Linija2.Garums() == Linija4.Garums()) ret = true;
            return ret;
        }

        public bool IrKvadrats()
        {
            var ret = false;
            if (Linija1.Garums() == Linija2.Garums() && Linija1.Garums() == Linija3.Garums() &&
                Linija1.Garums() == Linija4.Garums()) ret = true;
            return ret;
        }

        public double Laukums()
        {
            double ret = 0;
            if (IrKvadrats() == true)
                ret = Math.Sqrt(Linija1.Garums());
            else if (IrTaisnsturis() == true) ret = Linija1.Garums() * Linija2.Garums();

            return ret;
        }

        public void Izvadit()
        {
            Linija1.Izvadit();
            Linija2.Izvadit();
            Linija3.Izvadit();
            Linija4.Izvadit();

            Console.WriteLine("Perimetrs: " + Perimetrs());
            Console.WriteLine("Laukums: " + Laukums());
            if (IrKvadrats() == true)
                Console.WriteLine("Četrstūris ir kvadrats");
            else if (IrTaisnsturis() == true)
                Console.WriteLine("Četrstūris ir taisnstūris");
            else
                Console.WriteLine("Nav ne kvadrats ne taisnsturis");
        }
    }
}