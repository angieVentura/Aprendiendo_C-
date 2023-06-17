using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen
{
    internal class AguaMineral : Bebida
    {
        public string origen;

        public AguaMineral(int id, string nombre, string marca, double litros, double precio, string origen) : base(id, nombre, marca, litros, precio)
        {
            this.origen = origen;
        }
    }
}
