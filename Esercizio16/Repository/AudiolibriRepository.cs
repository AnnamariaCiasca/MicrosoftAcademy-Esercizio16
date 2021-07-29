using System;
using System.Collections.Generic;
using System.Linq;

namespace Esercizio16
{
   public class AudiolibriRepository : IDbRepository<AudioLibro>
    {
        static List<AudioLibro> audiolibri = new List<AudioLibro>();
        //{

        //  new AudioLibro("LA DIVINA COMMEDIA", "DANTE ALIGHIERI", 20, new TimeSpan(3, 20, 0)),
        //  new AudioLibro("L'ILIADE", "OMERO", 33, new TimeSpan(4, 45, 0)),
        //  new AudioLibro("VENUTO AL MONDO", "MARGARET MAZZANTINI", 18, new TimeSpan(2, 30, 0)),
        //};


        public List<AudioLibro> Fetch()
        {
            audiolibri.Add(new AudioLibro("LA DIVINA COMMEDIA", "DANTE ALIGHIERI", 20, new Durata(3, 20, 0)));
            audiolibri.Add(new AudioLibro("L'ILIADE", "OMERO", 33, new Durata(4, 45, 0)));
            audiolibri.Add(new AudioLibro("VENUTO AL MONDO", "MARGARET MAZZANTINI", 18, new Durata(2, 30, 0)));

            return audiolibri;
        }

        public List<AudioLibro> FetchStaticList()
        {
            return audiolibri;
        }

        public static void AggiungiAudioLibro()
        {

            AudioLibro audiolibro = new AudioLibro();

            string titolo, autore = "";
            TimeSpan durata;

            do
            {
                Console.WriteLine("\nInserisci il titolo");
                titolo = Console.ReadLine().ToUpper();
               
            } while (titolo.Length == 0);


            bool  check = GetByTitle(titolo);

            if (check == false)
            {
                audiolibro.Titolo = titolo;

                do
                {
                    Console.WriteLine("\nInserisci l'autore: ");
                    audiolibro.Autore = Console.ReadLine().ToUpper();
                } while (autore.Length != 0);


                Console.WriteLine("\nInserisci il prezzo: ");
                audiolibro.Prezzo = InserisciPrezzo();

                Durata d= new Durata();
                int ore;
                do
                {
                    Console.WriteLine("\nInserisci le ore di durata dell'audiolibro");
                } while (!int.TryParse(Console.ReadLine(), out ore));
                d.Ore = ore;

                int min;
                do
                {
                    Console.WriteLine("\nInserisci i minuti");
                } while (!int.TryParse(Console.ReadLine(), out min));
                d.Minuti = min;

                int sec;
                do
                {
                    Console.WriteLine("\nInserisci i secondi");
                } while (!int.TryParse(Console.ReadLine(), out sec));
              
                d.Secondi = sec;

                audiolibro.Durata = d;

                audiolibri.Add(audiolibro);

            }
            else
            {
                Console.WriteLine("\nEsiste già un libro con questo titolo");
            }

        }

        private static bool GetByTitle(string titolo)
        {
            int count = audiolibri.Where(al => al.Titolo == titolo).Count();

            if(count == 0)
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

        internal static void FiltraPerDurata()
        {
            Console.WriteLine("\nScegli la durata: ");

            Durata d = new Durata();
            int ore;
            do
            {
                Console.WriteLine("\nInserisci le ore di durata dell'audiolibro");
            } while (!int.TryParse(Console.ReadLine(), out ore));
            d.Ore = ore;

            int min;
            do
            {
                Console.WriteLine("\nInserisci i minuti");
            } while (!int.TryParse(Console.ReadLine(), out min));
            d.Minuti = min;

            int sec;
            do
            {
                Console.WriteLine("\nInserisci i secondi");
            } while (!int.TryParse(Console.ReadLine(), out sec));

            d.Secondi = sec;

            List<AudioLibro> libriPerDurata = new List<AudioLibro>();

            foreach (AudioLibro audiolibro in audiolibri)
            {
                if (audiolibro.Durata.Ore <= d.Ore)
                {
                    if (audiolibro.Durata.Minuti <= d.Minuti)
                    {
                        if (audiolibro.Durata.Secondi <= d.Secondi)
                        {

                            libriPerDurata.Add(audiolibro);
                        }
                    }
                }
            }

            if (libriPerDurata.Count > 0)
            {
                foreach (var audiolibro in libriPerDurata)
                {
                    Console.WriteLine(audiolibro.Print());
                }
            }
            else
            {
                Console.WriteLine($"\nNon sono presenti libri di durata inferiore a {d.Ore}:{d.Ore}:{d.Secondi}");
            }
        }

    }
}