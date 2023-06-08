using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleados
{
    internal class Comercial : Empleado
    {
        public double comision;

        public Comercial(string nombre, int edad, double salario, double comision) : base(nombre, edad, salario)
        {
            this.comision = comision;
        }

        protected double SetComision
        {
            set { comision = value; }
        }

        public double GetComision
        {
            get { return comision; }
        }

        public override void Plus()
        {
            if (edad > 30 && comision > 200) salario += PLUS;
        }

        public override string Mostrar()
        {
            return $"Comercial: {nombre}, Edad: {edad}, Salario: {salario}, Comision: {comision}";
        }

    }
}
