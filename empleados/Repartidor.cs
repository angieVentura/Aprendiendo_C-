using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleados
{
    internal class Repartidor : Empleado
    {
        public string zona;

        public Repartidor(string nombre, int edad, double salario, string zona) : base(nombre, edad, salario)
        {
            this.zona = zona;
        }

        protected string SetZona
        {
            set { zona = value; }
        }

        public string GetZona
        {
            get { return zona; }
        }

        public override void Plus()
        {
            if (edad > 25 && zona == "zona 3") salario += PLUS;
        }

        public override string Mostrar()
        {
            return $"Repartidor: {nombre}, Edad: {edad}, Salario: {salario}, Zona: {zona}";
        }
    }
}
