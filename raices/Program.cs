﻿using System;

namespace raices
{
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
            char[] letras = { 'a', 'b', 'c' };
            int yPos = 0;

            Mensaje("Calculadora de ecuaciones de segundo grado", Console.WindowWidth / 3, 3);
            Mensaje("Ingrese el valor de cada termino:", Console.WindowWidth / 3, 6);

            for (int i = 0; i < letras.Length; i++)
            {
                yPos += 3;
                Mensaje("╔════════════════════════════════════════╗", Console.WindowWidth / 3, 6 + yPos);
                Mensaje($"║  {letras[i]}:    {" ".PadLeft(32, ' ')}║", Console.WindowWidth / 3, 7 + yPos);
                Mensaje("╚════════════════════════════════════════╝", Console.WindowWidth / 3, 8 + yPos);
            }

            double a = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 10, Console.WindowWidth / 3 + 6));
            double b = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 13, Console.WindowWidth / 3 + 6));
            double c = Convert.ToDouble(Read("", Console.WindowWidth / 3 + 6, 16, Console.WindowWidth / 3 + 6));

            Raices raices = new Raices(a, b, c);

            Mensaje($"Resultado: {raices.Calcular()}", Console.WindowWidth / 3, 19);

            Console.ReadKey();

        }
    }
}


