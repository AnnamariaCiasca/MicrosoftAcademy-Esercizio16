using System;
using System.Collections.Generic;
using System.Linq;

namespace Esercizio16
{
   public class LibriCartaceiRepository : IDbRepository<LibroCartaceo>
    {
        public static List<LibroCartaceo> libriCartacei = new List<LibroCartaceo>();
    //    {
    //        new LibroCartaceo("IL NOME DELLA ROSA", "UMBERTO ECO", 15, 20, 550),
    //        new LibroCartaceo("IL PIACERE", "GABRIELE D'ANNUNZIO", 13, 12, 250),
    //        new LibroCartaceo("I PROMESSI SPOSI", "ALESSANDRO MANZONI", 22, 30, 500),
    //};


        public List<LibroCartaceo> Fetch()
        {
            libriCartacei.Add(new LibroCartaceo("IL NOME DELLA ROSA", "UMBERTO ECO", 15, 20, 550));
            libriCartacei.Add(new LibroCartaceo("IL PIACERE", "GABRIELE D'ANNUNZIO", 13, 12, 250));
            libriCartacei.Add(new LibroCartaceo("I PROMESSI SPOSI", "ALESSANDRO MANZONI", 22, 30, 500));

            return libriCartacei;
        }

        public List<LibroCartaceo> FetchStaticList()
        {
            return libriCartacei;
        }

        public static void AggiungiLibroCartaceo()
        {

            LibroCartaceo libroCartaceo = new LibroCartaceo();

            string titolo = "", autore = "";
            int quantita = 0;
            int numeroPagine = 0;


            do
            {
                Console.WriteLine("\nInserisci il titolo");
                titolo = Console.ReadLine().ToUpper();
            
            } while (titolo.Length == 0);


            bool check = GetByTitle(titolo);

            if (check == false)
            {
                libroCartaceo.Titolo = titolo;

                do
                {
                    Console.WriteLine("\nInserisci l'autore: ");
                    libroCartaceo.Autore = Console.ReadLine().ToUpper();
                } while (autore.Length != 0);


                Console.WriteLine("\nInserisci il prezzo: ");
                libroCartaceo.Prezzo = InserisciPrezzo();

                Console.WriteLine("\nInserisci quantità in magazzino: ");
                while (!int.TryParse(Console.ReadLine(), out quantita) || quantita < 1)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }
                libroCartaceo.Quantita = quantita;

                Console.WriteLine("\nInserisci numero di pagine: ");
                while (!int.TryParse(Console.ReadLine(), out numeroPagine) || numeroPagine < 1)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }
                libroCartaceo.NumeroPagine = numeroPagine;



                libriCartacei.Add(libroCartaceo);

            }
            else
            {
                Console.WriteLine("\nEsiste già un libro con questo titolo, aggiunta una nuova copia in magazzino.");
                libroCartaceo.Quantita++;
            }

        }

        internal static void ModificaQuantita()
        {
            LibroCartaceo libroCartaceo = new LibroCartaceo();
            string titolo = "";
            

            do
            {
                Console.WriteLine("\nInserisci il titolo del libro di cui vuoi modificare la quantita");
                titolo = Console.ReadLine().ToUpper();

            } while (titolo.Length == 0);


            bool check = GetByTitle(titolo);

            if (check == true)
            {
                libroCartaceo.Titolo = titolo;

                int qnt = SceltaQuantita();

               UpdateQuantity(titolo, qnt);
          
            }
           else
            {
                Console.WriteLine("\nIl libro non esiste in magazzino.");
            }

        }

        internal static void FiltraPerPrezzo()
        {
            Console.WriteLine("\nScegli il prezzo ");
            decimal prezzoDaFiltrare = InserisciPrezzo();


            List<LibroCartaceo> libriPerPrezzo = new List<LibroCartaceo>();

            foreach (LibroCartaceo libroCartaceo in libriCartacei)
            {
                if (libroCartaceo.Prezzo > prezzoDaFiltrare)
                {
                    libriPerPrezzo.Add(libroCartaceo);
                }
            }

            if (libriPerPrezzo.Count > 0)
            {
                foreach (var libroCartaceo in libriPerPrezzo)
                {
                    Console.WriteLine(libroCartaceo.Print());
                }
            }
            else
            {
                Console.WriteLine($"\nNon sono presenti libri con prezzo maggiore di {prezzoDaFiltrare} euro");
            }
        }

        private static void UpdateQuantity(string titolo, int qnt)
        {
            LibroCartaceo lc = libriCartacei.Where(lc => lc.Titolo == titolo).ToList()[0];
            lc.Quantita = qnt;      
                
                }

        private static int SceltaQuantita()
        {
            int qnt;

            do
            {
                Console.WriteLine("\nInserisci la quantità");
            } while (!int.TryParse(Console.ReadLine(), out qnt) || qnt < 0);

            return qnt;
        }

        private static bool GetByTitle(string titolo)
        {
            int count = libriCartacei.Where(lc => lc.Titolo == titolo).Count();

            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static decimal InserisciPrezzo()
        {
            decimal prezzo;
            while (!decimal.TryParse(Console.ReadLine(), out prezzo) || prezzo < 0)
            {

                Console.WriteLine("\nInserisci un valore valido");

            }
            return prezzo;
        }
    }


}

