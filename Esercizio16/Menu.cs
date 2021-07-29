using System;
using System.Collections.Generic;

namespace Esercizio16
{
    public class Menu
    {
        public static void Start()
        {
            char continua;

            LibriCartaceiRepository lcr = new LibriCartaceiRepository();
            AudiolibriRepository ar = new AudiolibriRepository();
            LibriRepository lr = new LibriRepository();


            do
            {
                int scelta = 0;

                Console.WriteLine("***********************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digita 1 per Visualizzare tutti i libri");
                Console.WriteLine("Digita 2 per Visualizzare tutti i libri cartacei");
                Console.WriteLine("Digita 3 per Visualizzare tutti gli audiolibri");
                Console.WriteLine("Digita 4 per Aggiungere un nuovo audiolibro");
                Console.WriteLine("Digita 5 per Aggiungere un nuovo libro cartaceo");
                Console.WriteLine("Digita 6 per modificare la quantità in magazzino di un libro cartaceo");
                Console.WriteLine("Digita 7 per visualizzare gli audiolibri di durata minore uguale a quella inserita");
                Console.WriteLine("Digita 8 per visualizzare i libri cartacei di prezzo maggiore di quello inserito");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("***********************************************");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 8)
                {
                    Console.WriteLine("Inserire valore corretto!");
                }

                switch (scelta)
                {
                    case 1:
                        List<Libro> libri = lr.Fetch();

                        foreach (var libro in libri)
                        {
                            Console.WriteLine(libro.Print());
                        }
                        break;



                    case 2:
                        List<LibroCartaceo> libriCartacei = lcr.Fetch();

                        foreach (var libroCartaceo in libriCartacei)
                        {
                            Console.WriteLine(libroCartaceo.Print());
                        }
                        break;


                    case 3:

                        List<AudioLibro> audiolibri = ar.Fetch();

                        foreach (var audiolibro in audiolibri)
                        {
                            Console.WriteLine(audiolibro.Print());
                        }
                        break;

                    case 4:

                        
                        AudiolibriRepository.AggiungiAudioLibro();

                        break;

                    case 5:
                       
                        LibriCartaceiRepository.AggiungiLibroCartaceo();

                        break;
                   
                    case 6:
                        LibriCartaceiRepository.ModificaQuantita();
                        break;

                    case 7:
                        AudiolibriRepository.FiltraPerDurata();
                        break;

                    case 8:
                        LibriCartaceiRepository.FiltraPerPrezzo();
                        break;

                    default:
                        break;

                }





                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nVuoi continuare? Se sì, digita s");
                continua = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");


            } while (continua == 's' || continua == 'S');
        }
    }
}
