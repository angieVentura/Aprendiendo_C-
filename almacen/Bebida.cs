using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen
{
    internal class Bebida
    {
        public int id;
        public string nombre, marca;
        public double litros, precio;

        public Bebida(int id, string nombre, string marca, double litros, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.marca = marca;
            this.litros = litros;
            this.precio = precio;
        }
    }
}
