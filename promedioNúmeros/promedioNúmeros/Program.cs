using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promedioNúmeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            /* Crear un programa que calcule el promedio de un conjunto de números ingresados por el usuario.*/

            Console.WriteLine("Ingrese la cantidad de números a promediar:");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            int contador = 0;
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Ingrese el número {i} a sumar");
                contador += Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"El promedio de los número ingresados es {contador / cantidad}");

            Console.ReadKey();
        }
    }

}
