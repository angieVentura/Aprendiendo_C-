using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja
{
    internal class Carta
    {
        public int id;
        public Palo palo { get; }
        public bool disponible = true;

        public Carta(int id, Palo palo, bool disponible)
        {
            this.id = id;
            this.palo = palo;
            this.disponible = disponible;
        }

    }
}
