// L'utente può decide se stampare a video tutti i libri cartecei, tutti gli audiolibri o tutti i libri
// Vorrà stampare tutte le proprietà
// Nel caso scelga di stampare tutti i libri, oltre alle proprietà stampare se è audiol o libro cart

// Un utente può decidere di inserire un nuovo audiolibro
//Un utente può decidere di inserire un nuovo libro cartaceo, se il libro esiste già, ne aumenta la quantità
//un utente può modificare la quantità in magazzino di un libro cartaceo

//data una durata visualizzare gli audiolibri con durata <= della durata inserita
// data un prezzo visualizzare i libri cartacei con prezzo > del prezzo inserito



using System;

namespace Esercizio16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gestore della libreria\n");
            Menu.Start();

        }
    }
}
