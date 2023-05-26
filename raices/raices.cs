using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raices
{
    internal class Raices
    {
        private double a, b, c;

        public Raices(double a, double b, double c)
        {

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetDiscriminante()
        {
            return (b * b) - (4 * a * c);
        }

        public bool TieneRaices()
        {
            return GetDiscriminante() > 0;
        }

        public bool TieneRaiz()
        {
            return GetDiscriminante() == 0;
        }

        public double[] ObtenerRaices()
        {
            return new double[] { (-b + Math.Sqrt(GetDiscriminante())) / (2 * a), (-b - Math.Sqrt(GetDiscriminante())) / (2 * a) };
        }

        public double ObtenerRaiz()
        {
            return (-b + Math.Sqrt(GetDiscriminante())) / (2 * a);
        }

        public string Calcular()
        {
            return TieneRaices() ? $"Las raíces son X1: {ObtenerRaices()[0]} y X2: {ObtenerRaices()[1]}"
                   : TieneRaiz() ? $"La raíz es X1: {ObtenerRaiz()}"
                   : "La ecuación no tiene raíces reales.";
        }
    }
}
