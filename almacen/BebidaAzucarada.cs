using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen
{
    internal class BebidaAzucarada : Bebida
    {
        public double porcentajeAzucar;
        public bool promocion;

        public BebidaAzucarada(int id, string nombre, string marca, double litros, double precio, double porcentajeAzucar, bool promocion) : base(id, nombre, marca, litros, precio)
        {
            this.porcentajeAzucar = porcentajeAzucar;
            this.promocion = promocion;
        }

        public double Descuento()
        {
            return promocion ? precio * 0.9 : precio;
        }
    }
}
