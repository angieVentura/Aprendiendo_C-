using System;
using System.Collections.Generic;
using System.Linq;

namespace ruletaRusa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Revolver revolver = new Revolver();

            Console.WriteLine($"RULETA RUSA");
            Console.Write($"\nIngrese la cantidad de jugadores: ");
            
            int cant = Convert.ToInt32(Console.ReadLine());
            int cantJ = cant > 6 ? 6 : cant;
            List<Jugador> jugadores = Enumerable.Range(1, cantJ).Select(i => new Jugador(i, $"Jugador{i}", true)).ToList();
            Juego juego = new Juego(jugadores, revolver);
            List<string> estado = new List<string>();
            int ronda = 1;
            
            do
            {
                estado = juego.Ronda(cantJ);
                Console.WriteLine($"\nRonda {ronda++}:\n{string.Join("\n", estado)}");
            } while (!juego.FinJuego());

            Console.ReadKey();
        }
    }
}
