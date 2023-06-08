using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleados
{
    internal class Empleado
    {
        protected string nombre;
        protected int edad;
        protected double salario;
        protected const double PLUS = 300;

        protected Empleado(string nombre, int edad, double salario)
        {
            this.edad = edad;
            this.salario = salario;
            this.nombre = nombre;
        }

        protected string SetNombre
        {
            set { nombre = value; }
        }

        public string GetNombre
        {
            get { return nombre; }
        }

        public int SetEdad
        {
            set { edad = value; }
        }

        public int GetEdad
        {
            get { return edad; }
        }

        public double SetSalario
        {
            set { salario = value; }
        }

        public double GetSalario
        {
            get { return salario; }
        }

        public virtual void Plus()
        {
        }

        public virtual string Mostrar()
        {
            return null;
        }

    }
}
