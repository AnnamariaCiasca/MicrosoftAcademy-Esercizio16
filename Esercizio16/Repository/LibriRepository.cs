using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio16
{
    class LibriRepository : IDbRepository<Libro>
    {
        static List<Libro> libri = new List<Libro>();

        LibriCartaceiRepository lcr = new LibriCartaceiRepository();
        AudiolibriRepository ar = new AudiolibriRepository();

        public List<Libro> Fetch()
        {
            List<LibroCartaceo> libriCartacei = lcr.FetchStaticList();
            List<AudioLibro> audiolibri = ar.FetchStaticList();

            libri.AddRange(libriCartacei);
            libri.AddRange(audiolibri);

            return libri;
        }

        public List<Libro> FetchStaticList()
        {
            return libri;
        }
    }
}
