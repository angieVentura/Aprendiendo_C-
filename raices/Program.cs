using System;

namespace raices
{
    class Raices
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

    internal class Program
    {
        static public void Mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }
        static public string Read(string mensaje, int x, int y, int x2)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
            Console.SetCursorPosition(x2, y);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            char[] letras = {'a', 'b', 'c'};
            int yPos = 0;

            Mensaje("Calculadora de ecuaciones de segundo grado", Console.WindowWidth / 3, 3);
            Mensaje("Ingrese el valor de cada termino:", Console.WindowWidth / 3, 6);

            for (int i = 0; i < letras.Length; i++)
            {
                yPos += 3;
                Mensaje("╔════════════════════════════════════════╗", Console.WindowWidth / 3, 6 + yPos);
                Mensaje($"║  {letras[i]}:    {" ".PadLeft(32,' ')}║", Console.WindowWidth / 3, 7 + yPos);
                Mensaje("╚════════════════════════════════════════╝", Console.WindowWidth / 3, 8 + yPos);
            }

            double a = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 10, Console.WindowWidth / 3 + 6));
            double b = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 13, Console.WindowWidth / 3 + 6));
            double c = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 16, Console.WindowWidth / 3 + 6));

            Raices raices = new Raices(a, b, c);

            Mensaje($"Resultado: {raices.Calcular()}", Console.WindowWidth / 3 , 19);

            Console.ReadKey();

        }
    }
}
