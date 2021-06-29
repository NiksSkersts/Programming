using System;

namespace there_once_was_an_elf_named_jerry_the_pooh
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Distilled_Avocado = new Veikals();
            //Distilled Avocados exist. I checked. #koju_adventures
            Distilled_Avocado.Registret();
            Distilled_Avocado.Izvadit();
            Distilled_Avocado.Veikala_Tips();
            Distilled_Avocado.arpus_termina();
            Distilled_Avocado.bistami();
        }
    }

    public class Prece
    {
        public string preces_nosaukums;
        public double iepirkuma_cena;

        public void Izvadit()
        {
            Console.WriteLine(preces_nosaukums);
            Console.WriteLine(iepirkuma_cena);
        }
    }

    internal class Partikas_prece : Prece
    {
        public DateTime deriguma_termins;
        public bool alergisks;
        public string mervieniba;
        public double pardosanas_cena;

        public void Registret()
        {
            Console.Write("Ievadiet Pārtikas Preces Nosaukumu: ");
            preces_nosaukums = Console.ReadLine();
            Console.Write("Ievadied Iepirkuma Cenu: ");
            iepirkuma_cena = Convert.ToDouble(Console.ReadLine());
            Console.Write("ievadiet Deriguma terminu: ");
            deriguma_termins = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Vai prece Ir alergiska (true or false): ");
            alergisks = Convert.ToBoolean(Console.ReadLine());
            Console.Write("ievadiet Mervienibu:");
            mervieniba = Console.ReadLine();

            pardosanas_cena = iepirkuma_cena * 0.3 + iepirkuma_cena;
            //Ārā Covid, normāli jāuzskrūvē cenas. ~ #Rimi un #Maxima be like. "Varētu piemest vēl +20%."
        }

        public new void Izvadit()
        {
            Console.WriteLine();
            Console.WriteLine(preces_nosaukums);
            Console.WriteLine(iepirkuma_cena);
            Console.WriteLine(deriguma_termins);
            Console.WriteLine(alergisks);
            Console.WriteLine(mervieniba);
            Console.WriteLine(pardosanas_cena);
            Console.WriteLine();
        }
    }

    internal class Saimniecibas_Prece : Prece
    {
        public string materials;
        public bool bistams;
        public double pardosanas_cena;

        public void Registret()
        {
            Console.Write("ievadiet Saimniecības Preces Nosaukumu: ");
            preces_nosaukums = Console.ReadLine();
            Console.Write("ievadiet Iepirkšanas Cenu: ");
            iepirkuma_cena = Convert.ToDouble(Console.ReadLine());
            Console.Write("Materiālu sastāvs precei: ");
            materials = Console.ReadLine();
            Console.Write("Bīstamība: (true or false) ");
            bistams = Convert.ToBoolean(Console.ReadLine());
            pardosanas_cena = iepirkuma_cena * 0.5 + iepirkuma_cena;
        }

        public new void Izvadit()
        {
            Console.WriteLine();
            Console.WriteLine(preces_nosaukums);
            Console.WriteLine(iepirkuma_cena);
            Console.WriteLine(materials);
            Console.WriteLine(bistams);
            Console.WriteLine(pardosanas_cena);
            Console.WriteLine();
        }
    }

    internal class Veikals
    {
        private string nosaukums;
        private int p_precu_skaits;
        private int s_precu_skaits;
        private Partikas_prece[] Partikas_Preces;
        private Saimniecibas_Prece[] Saimniecibas_preces;

        public void Registret()
        {
            Console.Write("Ievadiet Veikala Nosaukumu: ");
            nosaukums = Console.ReadLine();
            Console.Write("Partikas precu skaitu: ");
            p_precu_skaits = Convert.ToInt32(Console.ReadLine());
            Console.Write("Saimniecibas precu skaits: ");
            s_precu_skaits = Convert.ToInt32(Console.ReadLine());
            Partikas_Preces = new Partikas_prece[p_precu_skaits];
            Saimniecibas_preces = new Saimniecibas_Prece[s_precu_skaits];
            for (var i = 0; i < p_precu_skaits; i++)
            {
                Partikas_Preces[i] = new Partikas_prece();
                Partikas_Preces[i].Registret();
            }

            for (var i = 0; i < s_precu_skaits; i++)
            {
                Saimniecibas_preces[i] = new Saimniecibas_Prece();
                Saimniecibas_preces[i].Registret();
            }
        }

        public void Izvadit()
        {
            Console.WriteLine();
            Console.WriteLine("Veikala nosaukums: " + nosaukums);
            Console.WriteLine("Partikas precu skaits: " + p_precu_skaits);
            Console.WriteLine("Saimniecibas precu skaits: " + s_precu_skaits);

            for (var i = 0; i < p_precu_skaits; i++) Partikas_Preces[i].Izvadit();
            for (var i = 0; i < s_precu_skaits; i++) Saimniecibas_preces[i].Izvadit();
            Console.WriteLine();
        }

        public void Veikala_Tips()
        {
            if (p_precu_skaits > 0 && s_precu_skaits > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Lielveikals");
                Console.WriteLine();
            }

            if (p_precu_skaits > 0 && s_precu_skaits == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pārtikas veikals");
                Console.WriteLine();
            }

            if (p_precu_skaits == 0 && s_precu_skaits > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Saimniecības veikals");
                Console.WriteLine();
            }
        }

        public void arpus_termina()
        {
            var today = DateTime.Today;

            for (var i = 0; i < p_precu_skaits; i++)
                if (Partikas_Preces[i].deriguma_termins <= today)
                {
                    Console.WriteLine("Best Before termiņš iztecējis vai iztek šodien:");
                    Partikas_Preces[i].Izvadit();
                    Console.WriteLine();
                }
        }

        public void bistami()
        {
            for (var i = 0; i < s_precu_skaits; i++)
                if (Saimniecibas_preces[i].bistams == true)
                {
                    Console.WriteLine("Augsta Riska Prece!");
                    Saimniecibas_preces[i].Izvadit();
                    Console.WriteLine();
                }
        }
    }
}