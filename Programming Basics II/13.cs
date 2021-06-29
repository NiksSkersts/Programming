namespace there_once_was_an_elf_named_jerry_the_pooh
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var uni_kursi = new Kurss[1];
            for (var i = 0; i < uni_kursi.Length; i++)
            {
                uni_kursi[i] = new Kurss();
                uni_kursi[i].ReadData();
            }

            PrintArray(uni_kursi);
            PrintArrayToFile(uni_kursi);
            PrintArray(ReadArrayFromFile());
        }

        public static void PrintArray(Kurss[] kurss)
        {
            for (var i = 0; i < kurss.Length; i++) kurss[i].PrintData();
        }

        public static void PrintArrayToFile(Kurss[] kurss)
        {
            var sep = ";";
            FileStream data = new FileStream(@"C:\tmp\prog_d.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter just_write = new StreamWriter(data);
            var texy = new string[5];
            for (var i = 0; i < kurss.Length; i++)
            {
                texy[0] = kurss[i].nosaukums;
                texy[1] = Convert.ToString(kurss[i].cp);
                texy[2] = Convert.ToString(kurss[i].obligatory);
                texy[3] = kurss[i].lektors;
                texy[4] = Convert.ToString(kurss[i].gala_referats);
                for (var j = 0; j < 5; j++)
                {
                    var text = texy[j] + sep;
                    just_write.WriteLine(text);
                }
            }

            just_write.Close();
            data.Close();
        }

        public static Kurss[] ReadArrayFromFile()
        {
            var tmp = new string[5];
            var str = "";
            foreach (String line in File.ReadAllLines(@"C:\tmp\prog_d.txt")) str = str + line;
            tmp = str.Split(';');
            for (var i = 0; i < tmp.Length; i++) Console.WriteLine(tmp[i]);
            //10hrs later. https://stackoverflow.com/questions/31720435/cannot-implement-type-with-a-collection-initializer-because-it-does-not-implemen
            var kurss = new Kurss[]
            {
                new()
                {
                    nosaukums = tmp[0],
                    cp = Convert.ToInt32(tmp[1]),
                    obligatory = Convert.ToBoolean(tmp[2]),
                    lektors = tmp[3],
                    gala_referats = Convert.ToBoolean(tmp[4])
                }
            };
            return kurss;
        }
    }

    internal class Kurss
    {
        public string nosaukums;
        public int cp;
        public bool obligatory;
        public string lektors;
        public bool gala_referats;

        public void ReadData()
        {
            Console.Write("Kursa Nosaukums: ");
            nosaukums = Console.ReadLine();
            Console.Write("Kursa Kredītpunkti: ");
            cp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vai Kurss ir obligāts? (true or false): ");
            obligatory = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Kursa Lektors: ");
            lektors = Console.ReadLine();
            Console.Write("Vai Kursā ir jāraksta referāts (true or false): ");
            gala_referats = Convert.ToBoolean(Console.ReadLine());
        }

        public void PrintData()
        {
            Console.WriteLine(nosaukums);
            Console.WriteLine(cp);
            Console.WriteLine(obligatory);
            Console.WriteLine(lektors);
            Console.WriteLine(gala_referats);
            Console.WriteLine("Print End");
            Console.WriteLine();
        }
    }
}

//uzd2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Tracing;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.Design;

namespace there_once_was_an_elf_named_jerry_the_pooh
{
    internal class uzd_2
    {
        private static void Main(string[] args)
        {
            var sk1 = 20;
            var sk2 = 0;
            try
            {
                Console.WriteLine(sk1 / sk2);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by 0", sk1);
            }


            try
            {
                var y = true;
                var d = Convert.ToChar(y);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Nope, nepareiza konv.");
            }


            try
            {
                using (var reader = new StreamReader("dati.txt"))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException eksdee)
            {
                Console.WriteLine(eksdee);
            }


            var ind = new int[4];
            index(ind, 10);

            int index(int[] array, int index)
            {
                try
                {
                    return array[index];
                }
                catch (IndexOutOfRangeException abc)
                {
                    Console.WriteLine(abc.Message);
                    throw new ArgumentOutOfRangeException("ārpus robežas, ggwp");
                }
            }

            Console.WriteLine();
        }
    }
}