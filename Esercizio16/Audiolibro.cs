using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio16
{

    public class AudioLibro : Libro
    {
        public Durata Durata { get; set; }

        public AudioLibro(string titolo, string autore, decimal prezzo, Durata durata)
            : base(titolo, autore, prezzo)
        {
            this.Durata = durata;

        }

        public AudioLibro()
        {

        }

        public override string Print()
        {
            return $"Audiolibro) {base.Print()}, Durata: {Durata.Ore}:{Durata.Minuti}:{Durata.Secondi}";
        }

    }
    public struct Durata
    {
        public int Ore { get; set; }
        public int Minuti { get; set; }
        public int Secondi { get; set; }

        public Durata(int ore, int min, int sec)
        {
            Ore = ore;
            Minuti = min;
            Secondi = sec;
        }
    }
}

