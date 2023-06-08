using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productos
{
    internal class Perecedero : Producto
    {
        public int diasCaducar;

        public Perecedero(string nombre, double precio, int diasCaducar) : base(nombre, precio)
        {
            this.diasCaducar = diasCaducar;
        }

        public int DiasCaducar
        {
            get { return diasCaducar; }
            set { diasCaducar = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, días a caducar: {diasCaducar}";
        }

        public override double Calcular(int productos)
        {
            double precioFinal = base.Calcular(productos);

            switch (diasCaducar)
            {
                case 1:
                    precioFinal /= 4;
                    break;
                case 2:
                    precioFinal /= 3;
                    break;
                case 3:
                    precioFinal /= 2;
                    break;
            }

            return precioFinal;
        }
    }
}
