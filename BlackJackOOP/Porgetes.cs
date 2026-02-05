using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackOOP
{
    internal class Porgetes
    {
        private int nyeroSzam;
        private string szin;
        private string paritas;
        private Random rnd;


        public Porgetes()
        {
            this.rnd = new Random();
            this.nyeroSzam = rnd.Next(0, 37);
            this.szin = SzinMeghatarozas();
            this.paritas = ParitasMeghatarozas();
        }

        public int NyeroSzam { get => nyeroSzam; }
        public string Szin { get => szin; }
        public string Paritas { get => paritas; }

        private string SzinMeghatarozas()
        {
            if (this.nyeroSzam == 0) return "Zöld";

            else if (this.nyeroSzam % 2 == 0) return "Fekete";
            else return "Piros";
        }

        private string ParitasMeghatarozas()
        {
            if (this.nyeroSzam == 0) return "Nulla";
            else if (this.nyeroSzam % 2 == 0) return "Páros";
            else return "Páratlan";
        }


        public override string ToString()
        {
            return $"--- EREDMÉNY: {this.nyeroSzam} ({this.szin}, {this.paritas}) ---";
        }
    }
}
