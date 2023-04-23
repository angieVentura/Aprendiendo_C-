using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace númeroMayorMenor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una serie de números separados por comas: ");
            string numerosString = Console.ReadLine();
            string[] numerosArray = numerosString.Split(',');
            int[] numeros = Array.ConvertAll(numerosArray, int.Parse);

            int maximo = numeros[0];
            int minimo = numeros[0];
            for (int i = 1; i < numeros.Length; i++)
            {
                if (numeros[i] > maximo)  maximo = numeros[i];             
                if (numeros[i] < minimo) minimo = numeros[i];
            }

            Console.WriteLine("El número más grande es: " + maximo);
            Console.WriteLine("El número más pequeño es: " + minimo);
            
            Console.ReadKey();
        }
    }
}
