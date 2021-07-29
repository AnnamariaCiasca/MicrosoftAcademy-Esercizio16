using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio16
{
    interface IDbRepository<T>
    {
        public List<T> Fetch();
        public List<T> FetchStaticList();
    }
}
