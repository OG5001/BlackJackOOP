using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackOOP
{
    internal class Jatekos2
    {
        private string nev;
        private int egyenleg;


        public Jatekos2(string nev, int egyenleg)
        {
            this.nev = nev;
            this.egyenleg = egyenleg;
        }

        public Jatekos2(string nev)
        {
            this.nev = nev;
            this.egyenleg = 10000;
        }


        public string Nev { get => nev; }
        public int Egyenleg { get => egyenleg; set => egyenleg = value; }


        public bool TetRakasa(int tet)
        {
            if (tet <= this.egyenleg && tet > 0)
            {
                this.egyenleg -= tet;
                return true;
            }
            else
            {
                Console.WriteLine("HIBA: Nincs elég fedezet vagy érvénytelen összeg!");
                return false;
            }
        }

        public void NyeremenyFeliras(int osszeg)
        {
            this.egyenleg += osszeg;
            Console.WriteLine($"GRATULÁLOK! Nyereményed: {osszeg} Ft");
        }


        public override string ToString()
        {
            return $"Játékos: {this.nev} | Egyenleg: {this.egyenleg} Ft";
        }
    }
}