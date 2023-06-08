using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productos
{
    internal class Producto
    {
        public string nombre;
        public double precio;

        public Producto(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public virtual string ToString()
        {
            return $"nombre: {nombre}, precio: {precio}";
        }

        public virtual double Calcular(int productos)
        {
            return productos * precio;
        }

    }
}
