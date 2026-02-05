using BlackJackOOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackOOP
{
    internal class RouletteJatek
    {
        private Jatekos2 jatekos;

        public RouletteJatek()
        {
        }

        public void JatekInditasa()
        {
            Console.WriteLine("--- ROULETTE OOP ---");
            Console.Write("Kérlek add meg a neved a belépéshez: ");
            string nev = Console.ReadLine();


            this.jatekos = new Jatekos2(nev, 50000);

            JatekCiklus();
        }


        private void JatekCiklus()
        {
            string valasz = "";
            do
            {
                Console.Clear();
                Console.WriteLine(this.jatekos);
                Console.WriteLine("----------------------------------");


                string tipus = MenupontValasztas();


                int tet = TetBekeres();


                string tipp = TippBekeres(tipus, out int szamTipp);


                Console.WriteLine("\nPörgetés...");
                System.Threading.Thread.Sleep(800);
                Porgetes porgetes = new Porgetes();
                Console.WriteLine(porgetes);


                EredmenyKiertekeles(tipus, tipp, szamTipp, tet, porgetes);


                if (this.jatekos.Egyenleg <= 0)
                {
                    Console.WriteLine("Sajnos elfogyott a pénzed. Game Over.");
                    break;
                }

                Console.Write("\nSzeretnél még játszani? (i/n): ");
                valasz = Console.ReadLine();

            } while (valasz == "i");
        }



        private string MenupontValasztas()
        {
            Console.WriteLine("Mire szeretnél fogadni?");
            Console.WriteLine("1 - Számra (35x)");
            Console.WriteLine("2 - Színre (2x)");
            Console.WriteLine("3 - Páros/Páratlanra (2x)");
            Console.Write("Választásod: ");
            return Console.ReadLine();
        }

        private int TetBekeres()
        {
            int tet = 0;
            bool sikeres = false;
            while (!sikeres)
            {
                Console.Write("Mekkora tétet raksz? ");

                if (int.TryParse(Console.ReadLine(), out tet))
                {
                    sikeres = this.jatekos.TetRakasa(tet);
                }
                else
                {
                    Console.WriteLine("Kérlek számot adj meg!");
                }
            }
            return tet;
        }

        private string TippBekeres(string tipus, out int szamTipp)
        {
            szamTipp = -1;
            string tipp = "";

            switch (tipus)
            {
                case "1":
                    Console.Write("Melyik szám (0-36)? ");
                    int.TryParse(Console.ReadLine(), out szamTipp);
                    break;
                case "2":
                    Console.Write("Melyik szín (Piros/Fekete)? ");
                    tipp = Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Páros vagy Páratlan? ");
                    tipp = Console.ReadLine();
                    break;
            }
            return tipp;
        }

        private void EredmenyKiertekeles(string tipus, string tipp, int szamTipp, int tet, Porgetes p)
        {
            bool nyert = false;
            int szorzo = 0;

            if (tipus == "1" && szamTipp == p.NyeroSzam)
            {
                nyert = true;
                szorzo = 35;
            }
            else if (tipus == "2" && tipp.ToLower() == p.Szin.ToLower())
            {
                nyert = true;
                szorzo = 2;
            }
            else if (tipus == "3" && tipp.ToLower() == p.Paritas.ToLower())
            {
                nyert = true;
                szorzo = 2;
            }

            if (nyert)
            {
                this.jatekos.NyeremenyFeliras(tet * szorzo);
            }
            else
            {
                Console.WriteLine("Sajnos nem nyertél.");
                Console.WriteLine($"Egyenleged: {this.jatekos.Egyenleg} Ft");
            }
        }
    }
}