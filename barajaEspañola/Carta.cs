using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barajaEspañola
{
    internal class Carta<T>
    {
        public string id;
        public T palo { get; }
        public bool disponible = true;

        public Carta(string id, T palo, bool disponible)
        {
            this.id = id;
            this.palo = palo;
            this.disponible = disponible;
        }
    }
}
