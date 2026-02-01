using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackOOP
{
    internal class Pakli
    {
        private List<(Kartya.Szin, Kartya.Figura)> lapok = new();
        private Random rnd = new();

        public void Keszites()
        {
            lapok.Clear();
            foreach (Kartya.Szin szin in Enum.GetValues(typeof(Kartya.Szin)))
            {
                foreach (Kartya.Figura figura in Enum.GetValues(typeof(Kartya.Figura)))
                {
                    lapok.Add((szin, figura));
                }
            }
        }

        public void Keveres()
        {
            for (int i = 0; i < lapok.Count; i++)
            {
                int j = rnd.Next(lapok.Count);
                (lapok[i], lapok[j]) = (lapok[j], lapok[i]);
            }
        }

        public (Kartya.Szin, Kartya.Figura) Huz()
        {
            var lap = lapok[0];
            lapok.RemoveAt(0);
            return lap;
        }
    }
}
