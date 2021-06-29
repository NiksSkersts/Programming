using System;
using System.Collections.Specialized;

namespace F
{
    internal class task_again
    {
        public static void Main(string[] args)
        {
            var k = new square();
            //init array
            StringArrays(0);
            //make the square
            k.Reg_Square();
            //output the square
            k.Output();
        }

        public static string StringArrays(int x)
        {
            //Collection of all the strings in this work
            //I am starting to like arrays
            var a_lot_of_text = new string[11];
            a_lot_of_text[1] = "Please input X: ";
            a_lot_of_text[2] = "Please input Y: ";
            a_lot_of_text[3] = "Please input colour: ";
            a_lot_of_text[4] = "color: ";
            a_lot_of_text[5] = "x = ";
            a_lot_of_text[6] = "y = ";
            a_lot_of_text[7] = "X";
            a_lot_of_text[8] = "Y";
            a_lot_of_text[9] = "_____________";
            a_lot_of_text[10] = "Line : ";
            a_lot_of_text[0] = "init phase warning:";
            return a_lot_of_text[x];
        }
    }

    public class Punkts
    {
        public int X;
        public int Y;
        public string color;

        public void Reg_Point()
        {
            //get coordinates for "dem" lines.
            Console.Write(task_again.StringArrays(1));
            X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write(task_again.StringArrays(2));
            Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write(task_again.StringArrays(3));
            color = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
        }

        public void Output()
        {
            Console.WriteLine(task_again.StringArrays(5) + X + " " + task_again.StringArrays(6) + Y + " " +
                              task_again.StringArrays(4) + color);
        }
    }

    public class Line
    {
        private Punkts A;
        private Punkts B;
        private string color;

        public void Reg_Line()
        {
            Console.WriteLine(task_again.StringArrays(9) + " " + task_again.StringArrays(7) + " " +
                              task_again.StringArrays(9));
            A = new Punkts();
            A.Reg_Point();
            Console.WriteLine(task_again.StringArrays(9) + " " + task_again.StringArrays(8) + " " +
                              task_again.StringArrays(9));
            B = new Punkts();
            B.Reg_Point();
        }

        public double lenght_of_line()
        {
            double ret = 0;
            var X1 = A.X;
            var Y1 = B.X;
            var X2 = A.Y;
            var Y2 = B.Y;

            ret = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));

            return ret;
        }

        public void Output()
        {
            A.Output();
            B.Output();
            Console.WriteLine("Lenght of the line is " + lenght_of_line());
            Console.WriteLine();
        }
    }

    public class square
    {
        private Line line_one = new();
        private Line line_two = new();
        private Line line_three = new();
        private Line line_four = new();

        public void Reg_Square()
        {
            Console.WriteLine();
            Console.WriteLine(task_again.StringArrays(10) + "1");
            line_one.Reg_Line();
            Console.WriteLine(task_again.StringArrays(10) + "2");
            line_two.Reg_Line();
            Console.WriteLine(task_again.StringArrays(10) + "3");
            line_three.Reg_Line();
            Console.WriteLine(task_again.StringArrays(10) + "4");
            line_four.Reg_Line();
        }

        //get basic meth™ values
        public double Perimeter()
        {
            double ret = 0;
            ret = line_one.lenght_of_line() + line_two.lenght_of_line() + line_three.lenght_of_line() +
                  line_four.lenght_of_line();
            return ret;
        }

        public double square_area()
        {
            double ret = 0;
            if (if_square() == true)
                ret = Math.Sqrt(line_one.lenght_of_line());
            else if (rectangle() == true) ret = line_one.lenght_of_line() * line_two.lenght_of_line();

            return ret;
        }

        public bool rectangle()
        {
            var ret = false;
            if (line_one.lenght_of_line() == line_three.lenght_of_line() &&
                line_two.lenght_of_line() == line_four.lenght_of_line()) ret = true;
            return ret;
        }

        public bool if_square()
        {
            var ret = false;
            if (line_one.lenght_of_line() == line_two.lenght_of_line() &&
                line_one.lenght_of_line() == line_three.lenght_of_line() &&
                line_one.lenght_of_line() == line_four.lenght_of_line()) ret = true;
            return ret;
        }

        public void Output()
        {
            line_one.Output();
            line_two.Output();
            line_three.Output();
            line_four.Output();

            Console.WriteLine("Perimeter: " + Math.Round(Perimeter(), 2));
            Console.WriteLine("Square Area: " + Math.Round(square_area(), 2));
            Console.Write("Inputed object is: ");
            if (if_square() == true)
                Console.Write("orthogonal rectangle");
            else if (rectangle() == true)
                Console.Write("rectangle");
            else
                Console.Write("neither");
        }
    }
}