using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace juegoAhorcado
{
    internal class Program
    {
        static void mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] palabras = { "script", "cookie", "kernel", "vector", "buffer" };
            List<string> error = new List<string>();
            string palabra = palabras[random.Next(palabras.Length)];
            string adivinada = new string('_', palabra.Length);

            int intento = 6;
            mensaje("Ahorcado", Console.WindowHeight / 2, 3);
            mensaje("".PadLeft(6, '_'), 5, 6);
            for (int i = 0; i <= 2; i++)
                mensaje("|", 5, 7 + i);

            mensaje("|||", 4, 10);
            mensaje($"Progreso: {adivinada}", 4, 12);
            mensaje("Palabras incorrectas:", 4, 14);

            while (intento > 0 && adivinada.Contains('_'))
            {
                bool acierto = false;
                mensaje("".PadLeft(45, ' '), 4, 16);
                mensaje("Ingresa una letra:", 4, 16);
                Console.SetCursorPosition(23, 16);
                string letra = Console.ReadLine();
                if (letra.Length != 1)
                {
                    mensaje("Debes ingresar una única letra.", 4, 20);
                    continue;
                }
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (letra[0] == palabra[i])
                    {
                        adivinada = adivinada.Substring(0, i) + letra + adivinada.Substring(i + 1);
                        acierto = true;
                    }
                }

                if (!acierto)
                {
                    intento--;
                    //no me gusta, pero no se como podria cambiarlo
                    if (intento == 5)
                    {
                        mensaje(" O ", 10, 7);
                    }
                    else if (intento == 4)
                    {
                        mensaje("|", 11, 8);
                    }
                    else if (intento == 3)
                    {
                        mensaje("-", 10, 8);
                    }
                    else if (intento == 2)
                    {
                        mensaje("-", 12, 8);
                    }
                    else if (intento == 1)
                    {
                        mensaje("/", 10, 9);
                    }
                    else if (intento == 0)
                    {
                        mensaje("l", 12, 9);
                    }

                    mensaje("Fallaste ", 4, 18);

                    error.Add(letra);
                    StringBuilder sb = new StringBuilder();
                    foreach (string elemento in error)
                    {
                        sb.Append(elemento + " ");
                    }
                    mensaje(sb.ToString(), 26, 14);
                }
                else
                {
                    mensaje("Acertaste", 4, 18);
                    mensaje(adivinada, 14, 12);
                }

            }

            if (!adivinada.Contains('_'))
            {
                mensaje("¡Felicidades, adivinaste la palabra!", 4, 20);
            }
            else
            {
                mensaje("¡Lo siento, se te acabaron los intentos!", 4, 20);
                mensaje($"La palabra era: {palabra}", 4, 22);
            }
            Console.ReadKey();
        }
    }
}
