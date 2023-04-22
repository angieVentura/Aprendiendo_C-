using System;
using System.Collections.Generic;

namespace númerosPrimos
{
    internal class Program
    {
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<int> numerosPrimos = new List<int>();
            Console.WriteLine("Ingrese un número para generar una lista de números primos: ");
            int numeroMaximo = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= numeroMaximo; i++)
            {
                if (EsPrimo(i)) numerosPrimos.Add(i);
            }

            Console.WriteLine($"Los números primos hasta {numeroMaximo} son: ");
            foreach (int primo in numerosPrimos)
            {
                Console.Write("{0} ", primo);
            }
            Console.ReadKey();
        }
    }
}
