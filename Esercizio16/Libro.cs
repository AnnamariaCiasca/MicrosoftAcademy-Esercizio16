using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio16
{
   
   public abstract class Libro
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public decimal Prezzo { get; set; }


        public Libro(string titolo, string autore, decimal prezzo)
        {
            this.Titolo = titolo;
            this.Autore = autore;
            this.Prezzo = prezzo;
       
        }

        public Libro()
        {

        }

        public virtual string Print()
        {
            return $"Titolo: {Titolo}, Autore: {Autore}, Prezzo: {Prezzo} euro";
        }
    }
}

