using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temperatura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la temperatura en grados Celsius:");
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 9 / 5) + 32;

            Console.WriteLine($"La temperatura {celsius}°C es equivalente a {fahrenheit}°F");
            Console.ReadKey();
        }
    }
}
