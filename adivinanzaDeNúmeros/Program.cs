using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adivinanzaDeNúmeros
{
    //3. Crear un programa que simule un juego de adivinanza de números, en el que el usuario debe adivinar un número generado aleatoriamente por el programa.
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int num = 4; //random.Next(10);
            bool estado = true;
            int cont = 4;
            int numUs;
            bool numE = true;

            Console.WriteLine("Adivina el número");
            Console.WriteLine("\nIngresa un número");
            numE = int.TryParse(Console.ReadLine(), out numUs);
            if (!numE) Environment.Exit(0); 
            if(num == numUs ) estado= false;

            while (estado)
            {
                cont--;
                if(cont == 0)
                {
                    Console.WriteLine("Perdiste :(");
                    Console.ReadKey();
                    Environment.Exit(0);    
                }
                Console.WriteLine($"Incorrecto, cantidad de intentos restante: {cont}");
                numE = int.TryParse(Console.ReadLine(), out numUs);
                if (!numE) Environment.Exit(0);
                if (num == numUs) estado = false;
            }

            Console.WriteLine("Ganaste! :D");
            Console.ReadKey();
        }
    }
}