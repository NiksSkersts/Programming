using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var naaame = "";
        Console.WriteLine("Current time is : " + myConsole.tagad);

        Console.WriteLine(myConsole.NolasitKaInt());

        myConsole.NomainitBurtuKrasu();
        myConsole.Izvadit("It's like 30 degrees outside and -30 degrees in dorms. NEAT!");

        Console.WriteLine();
        Console.WriteLine("Your name and Surname, please: ");
        myConsole.FormatetVardu(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Length of your overly simple password: ");
        Console.WriteLine(myConsole.IzveidotParoli(Convert.ToInt32(Console.ReadLine())));
        Console.Write("Your pass: ");
        Console.WriteLine(naaame = myConsole.SifretTekstu(Console.ReadLine()));
        Console.Write("Decrypted password: ");
        Console.WriteLine(myConsole.AtsifretTekstu(naaame));

        Console.ReadLine();
        myConsole.NomainitFonaKrasu();
    }
}

public class myConsole
{
    public static string tagad = DateTime.Now.ToString("hh:mm");

    public static int NolasitKaInt()
    {
        Console.Write("Vesels skaitlis: ");
        var vesels_skaitlis = Console.ReadLine();

        var successfullyParsed = int.TryParse(vesels_skaitlis, out var vs);
        if (successfullyParsed == true)
        {
            return vs;
        }
        else
        {
            Console.WriteLine("Convertation Failed");
            return 0;
        }
    }


    public static void Izvadit(string text)
    {
        Console.WriteLine(text);
    }


    public static void NomainitBurtuKrasu()
    {
        var rand = new Random();
        switch (rand.Next(0, 5))
        {
            case 0:
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
                break;
            case 1:
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
                break;
            case 2:
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
                break;
            case 3:
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
                break;
            case 4:
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
                break;
            case 5:
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
                break;
        }
    }

    public static void FormatetVardu(string n_s)
    {
        var hhh = "";
        var x = 0;
        var a = ' ';
        var length = 0;
        for (var i = 0; i < n_s.Length; i++)
        {
            length = i;
            if (n_s[i] == a) x = i;
        }

        hhh = n_s.Substring(0, 1) + "." + n_s.Substring(x, length - x + 1);
        Console.WriteLine(hhh);
    }

    public static string IzveidotParoli(int garums)
    {
        var ran = new Random();
        var pass_gen_string = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        var parole = "";
        for (var i = 0; i < garums; i++)
        {
            var num = ran.Next(0, pass_gen_string.Length);
            parole += pass_gen_string[num];
        }

        return parole;
    }

    public static string SifretTekstu(string teksts)
    {
        var naaame = "";
        var sifrs = teksts.Length - 10;
        for (var i = 0; i < teksts.Length; i++) naaame += Convert.ToChar((int) teksts[i] + sifrs);
        return naaame;
    }

    public static string AtsifretTekstu(string teksts)
    {
        var naaame = "";
        var sifrs = teksts.Length - 10;
        for (var i = 0; i < teksts.Length; i++) naaame += Convert.ToChar((int) teksts[i] - sifrs);
        return naaame;
    }

    public static void NomainitFonaKrasu()
    {
        var ran = new Random();
        switch (ran.Next(0, 4))
        {
            case 0:
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
            }
                break;
            case 1:
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
            }
                break;
            case 2:
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
            }
                break;
            case 3:
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
            }
                break;
            case 4:
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
            }
                break;
        }
    }
}