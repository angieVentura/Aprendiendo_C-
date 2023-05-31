using System;
using System.Collections.Generic;
using System.Linq;

namespace apuesta
{
    internal class Program
    {
        static public Random rand = new Random();
        static public string[] Resultados(int cantPart)
        {

            string[] resultados = { "Empate", "Local", "Foraneo" };
            string[] apuesta = new string[cantPart];
            for (int i = 0; i < apuesta.Length; i++)
                apuesta[i] = resultados[rand.Next(0, 3)];

            return apuesta;
        }

        static void Main(string[] args)
        {
            int cantPart = rand.Next(2, 10), montoMin = 1, minAciertos = 2, pozoAc = 0, cantRes = rand.Next(2, 4), jornadas = 1;
            string[] nombres = new string[10] { "Juan", "María", "Pedro", "Ana", "Luis", "Laura", "Carlos", "Sofía", "Miguel", "Elena" };
            Apuesta apuesta = new Apuesta(montoMin, minAciertos, pozoAc, cantPart, Resultados(cantRes));
            List<Jugador> postulantes = new List<Jugador>();
            Jugador ganador = null;
            while (ganador == null)
            {
                Console.WriteLine($"\nJornada: {jornadas++}");
                for (int i = 0; i < cantPart; i++)
                    postulantes.Add(new Jugador(nombres[rand.Next(0, nombres.Length)], rand.Next(0, 5), 0, Resultados(cantRes)));

                List<Jugador> jugadores = postulantes.Where(j => j.PuedeParticipar() == true ).ToList();

                //Primero que haga 2 victorias = ganador
                for (int i = 0; i < jugadores.Count; i++)
                {
                    if (!jugadores.Any(j => j.victorias >= minAciertos))
                    {
                        jugadores[i].Apostar(montoMin);
                        pozoAc += montoMin;
                        for (int j = 0; j < apuesta.resultado.Length; j++)
                        {
                            if (apuesta.resultado[j] == jugadores[i].respuesta[j]) jugadores[i].IncrementarVictorias();
                        }
                    }
                }

                ganador = jugadores.Find(j => j.victorias == minAciertos);
                if (ganador != null) ganador.dinero += pozoAc;

                for (int i = 0; i < jugadores.Count; i++)
                {
                    Console.WriteLine(jugadores[i].MostrarResultados());
                }
                Console.WriteLine(ganador != null ? $"\nJugador que cumplio primero la cantidad de victorias: {ganador.nombre}" : $"\nNingun jugador gano, pozo acumulado: {pozoAc}");
                Console.WriteLine($"Cantidad de jugadores:{jugadores.Count}");
                Console.WriteLine($"Cantidad de partidos:{apuesta.resultado.Length}");
            }
            
            Console.ReadKey();
        }
    }
}
