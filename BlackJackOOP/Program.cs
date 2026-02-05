using System.ComponentModel.DataAnnotations;

namespace BlackJackOOP
{
        internal class Program
        {
            static void Roulette()
            {
                RouletteJatek jatek = new RouletteJatek();


                jatek.JatekInditasa();


                Console.WriteLine("\nA program leáll. Nyomj egy gombot...");
                Console.ReadKey();
            }
            static void BlackJack()
            {
                string v = "";
                string valasz = "";
                while (valasz != "n")
                {
                    Pakli pakli = new Pakli();
                    pakli.Keszites();
                    pakli.Keveres();

                    Jatekos jatekos = new Jatekos();
                    Jatekos oszto = new Jatekos();

                    jatekos.LapotKap(pakli.Huz());
                    jatekos.LapotKap(pakli.Huz());
                    oszto.LapotKap(pakli.Huz());
                    oszto.LapotKap(pakli.Huz());

                    Console.WriteLine("JÁTÉKOS:");
                    jatekos.Kiir();

                    while (jatekos.Ertek() < 21)
                    {
                        Console.WriteLine();
                        Console.Write("Húzol? (i/n): ");
                        v = Console.ReadLine();
                        Console.WriteLine();

                        if (v == "i")
                        {

                            jatekos.LapotKap(pakli.Huz());
                            jatekos.Kiir();
                        }
                        else if (v == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Rossz választ adtál meg, próbáld újra!");
                        }
                    }

                    if (jatekos.Ertek() > 21)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Besokalltál! Az Osztó nyert.");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine("\nOSZTÓ:");
                    while (oszto.Ertek() < 17)
                    {
                        oszto.LapotKap(pakli.Huz());
                    }
                    oszto.Kiir();

                    if (oszto.Ertek() > 21 || jatekos.Ertek() > oszto.Ertek())
                        Console.WriteLine("Te nyertél!");
                    else if (jatekos.Ertek() < oszto.Ertek())
                        Console.WriteLine("Az Osztó nyert!");
                    else
                        Console.WriteLine("Döntetlen!");
                    Console.WriteLine();

                    while (valasz != "i" || valasz != "n")
                    {
                        Console.Write("Szeretnél mégegyet játszani?(Igen: i, Nem: n): ");
                        valasz = Console.ReadLine();
                        if (valasz == "i")
                        {
                            Console.WriteLine();
                            break;
                        }
                        else if (valasz == "n")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Köszönjük hogy a Black Jacket választotta.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Rossz választ adott meg próbáld újra!");
                            continue;
                        }
                    }

                }
            }
            static void Main(string[] args)
            {

                Console.WriteLine("Roulette - 1");
                Console.WriteLine("Black Jack - 2");
                Console.Write("Mivel akarsz játszani: ");
                string valasz = Console.ReadLine();
                do
                {
                    if (valasz == "1")
                    {
                        Roulette();
                        return;

                    }
                    else if (valasz == "2")
                    {
                        BlackJack();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Bruthaa 2 számból nem birtal egyetse beutni...");

                    }

                }
                while (valasz != "1" || valasz != "2");
            }
        }
}

