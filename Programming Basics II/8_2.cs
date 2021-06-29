using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _8_uzd_it19055
{
    //vērtību tipiem vienmēr ir vērtība, kamēr atsauču tips norāda uz vērtību
    //struct vērtības uzglabā stack (statiska atmiņa, kura tiek uzglabāta pa tiešo atmiņā un iedalīta kad programma tiek compiled)
    //klase uzglabā heap atmiņā (dinamiska atmiņa, kura tiek piešķirta, kamēr app darbojas.)

    //struck izmanto mazām vērtībām un mazās programmās.
    //struck ir ierobežots funkciju skaits, tai skaitā struct nevar mantot no citām struct vai klasēm
    //Struct, katram variable ir sava datu kopija, kamēr klase norāda uz vienu un to pašu variable.
    internal struct Struktura
    {
        public int qq;
    }

    internal class Klase
    {
        public int ww;
    }

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("klase");
            //testējam klasi. klase ir atsauču tips
            var x = new Klase();
            var y = new Klase();
            x.ww = 1;
            y.ww = 2;
            Console.WriteLine(x.ww);
            Console.WriteLine(y.ww);
            // tiek deklarēti skaitļi

            y = x;
            x.ww = 111;
            Console.WriteLine(x.ww);
            Console.WriteLine(y.ww);
            //abas vērtības ir '111', jo darbs notiek ar oriģinālajām vērtībām. Klase norāda, nevis pārkopē


            Console.WriteLine("Struktūra");
            //tas pats piemērs kas klasei, tikai ar struct
            Struktura val_1;
            Struktura val_2;
            //struktūra nav jādeklarē kā 'new'. struct ir vērtību tips
            val_1.qq = 1;
            val_2.qq = 2;
            Console.WriteLine(val_1.qq);
            Console.WriteLine(val_2.qq);
            val_1 = val_2;
            val_2.qq = 111;
            Console.WriteLine(val_1.qq);
            Console.WriteLine(val_2.qq);
            //tikai val_1 tika izvadīta kā 111, jo katrai izsauktajai vērtībai ir savi dati. RIP atmiņa
        }
    }
}