using System;

namespace Programming_Basics_I
{
    public class Classes

    {
        public static int line = 0;

        public static void Main()

        {
            var uzdevums = new Analitical_Math_Homework[0];

            for (var i = 0; i < uzdevums.Length; i++)

            {
                uzdevums[i] = new Analitical_Math_Homework();

                uzdevums[i].Registret();

                uzdevums[i].Izvadit();
            }

            var cels = "var7.txt";

            for (var i = 0; i < 4; i++)

            {
                Izvadit_visu(Nolasit_visu(cels));
                line++;
            }
        }

        public static Analitical_Math_Homework[] Nolasit_visu(string cels)

        {
            var counter = 0;

            var tmp_words = new string[5];

            var tmp = new string[4];

            foreach (string line in File.ReadAllLines(cels))

            {
                tmp[counter] = line;

                counter++;
            }

            for (var i = 0; i < tmp.GetLength(0); i++) tmp_words = tmp[line].Split(';');


            var uzdevumi = new Analitical_Math_Homework[]
            {
                new()
                {
                    nr = Convert.ToInt32(tmp_words[0]),

                    forma = tmp_words[1],

                    atzime = Convert.ToInt32(tmp_words[2]),

                    parametrs = tmp_words[3],

                    vertiba = Convert.ToInt32(tmp_words[4]),

                    termins = Convert.ToBoolean(tmp_words[5])
                }
            };


            Console.WriteLine("Vai viss ir pareizi?");
            var re_do = Convert.ToBoolean(Console.ReadLine());
            if (re_do != true)
            {
                Console.WriteLine("kuru vērtību pēc kārtas labot?");
                var labojums = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Jaunā vērtība");
                var n_val = Console.ReadLine();
                switch (labojums)
                {
                    case 1:
                        uzdevumi[line].nr = Convert.ToInt32(n_val);
                        break;

                    case 2:
                        uzdevumi[line].forma = n_val;
                        break;
                    case 3:
                        uzdevumi[line].atzime = Convert.ToInt32(n_val);
                        break;
                    case 4:
                        uzdevumi[line].parametrs = n_val;
                        break;
                    case 5:
                        uzdevumi[line].vertiba = Convert.ToInt32(n_val);
                        break;
                    case 6:
                        uzdevumi[line].termins = Convert.ToBoolean(n_val);
                        break;
                }
            }

            return uzdevumi;
        }

        public static void Izvadit_visu(Analitical_Math_Homework[] uzdevums)

        {
            for (var i = 0; i < uzdevums.Length; i++) uzdevums[i].Izvadit();
        }
    }

    internal class Analitical_Math_Homework

    {
        public int nr;

        public string forma;

        public int atzime;

        public string parametrs;

        public int vertiba;

        public bool termins;

        public void Registret()

        {
            Console.Write("Skolēna kārtas nr ");

            nr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Uzdotā Ģeometriskā forma ");

            forma = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Mājasdarba Atzīme ");

            atzime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Galvenais parametrs ");

            parametrs = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Galvenā parametra vērtība ");

            vertiba = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Iesniegts Laicīgi? (true or false) ");

            termins = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine();
        }

        public void Izvadit()

        {
            Console.WriteLine("Skolēna kārtas numurs {0}", nr);

            Console.WriteLine("Skolēnam uzdotā ģeometriskā forma {0}", forma);

            Console.WriteLine("Skolēna atzīme {0}", atzime);

            Console.WriteLine("Skolēna galvenais parametrs {0}", parametrs);

            Console.WriteLine("Skolēna parametra vērtība {0}", vertiba);

            Console.WriteLine("Skolēna iekļāvās termiņā {0}", termins);

            Console.WriteLine();
        }
    }
}