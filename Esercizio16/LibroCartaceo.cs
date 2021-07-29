using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio16
{
    public class LibroCartaceo : Libro
    {
        public int Quantita { get; set; }  //quantità dei libri in magazzino
        public int NumeroPagine { get; set; }
        

        public LibroCartaceo(string titolo, string autore, decimal prezzo, int quantita, int numeroPagine)
            : base(titolo, autore, prezzo)
        {
            this.Quantita = quantita;
            this.NumeroPagine = numeroPagine;
    
            
        }

        public LibroCartaceo()
        {

        }


        public override string Print()
        {
            return $"LibroCartaceo) {base.Print()}, Numero di Pagine: {NumeroPagine}, Quantità in magazzino: {Quantita}";
        }
    }
}
