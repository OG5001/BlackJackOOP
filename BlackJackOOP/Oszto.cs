using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJackOOP
{
    internal class Oszto
    {
        private List<(Kartya.Szin, Kartya.Figura)> Kez { get; } = new();

        public void LapotKap((Kartya.Szin, Kartya.Figura) lap)
        {
            Kez.Add(lap);
        }

        public int Ertek()
        {
            int osszeg = 0;
            int aszok = 0;

            foreach (var lap in Kez)
            {
                osszeg += (int)lap.Item2;
                if (lap.Item2 == Kartya.Figura.ASZ)
                    aszok++;
            }

            while (osszeg > 21 && aszok > 0)
            {
                osszeg -= 10;
                aszok--;
            }

            return osszeg;
        }

        public void Kiir()
        {
            foreach (var lap in Kez)
                Console.WriteLine($"{lap.Item1} - {lap.Item2}");

            Console.WriteLine($"Érték: {Ertek()}");
        }
    }
}
