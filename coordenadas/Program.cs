using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coordenadas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese las coordenadas del primer punto:");
            Console.WriteLine("Coordenada X: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Coordenada Y: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese las coordenadas del segundo punto:");
            Console.WriteLine("Coordenada X: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Coordenada Y: ");
            double y2 = double.Parse(Console.ReadLine());

            double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine($"La distancia entre los puntos ({x1},{y1}) y ({x2},{y2}) es {distancia}");
            Console.ReadLine();
        }
    }
}
