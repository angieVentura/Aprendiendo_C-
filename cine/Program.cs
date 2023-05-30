using System;
using System.Threading;

namespace cine
{
    internal class Program
    {
        static public void Mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(mensaje);
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.CursorVisible = false;
            int cantEsp = rand.Next(150, 200);
            Asiento[] asientos = new Asiento[72];
            Espectador[] espectadores = new Espectador[cantEsp];
            char[] abc = "ABCDEFGHI".ToCharArray();
            string[] nombres = new string[30] { "Juan", "María", "Carlos", "Laura", "Pedro", "Ana", "Luis", "Sofía", "Miguel", "Isabella", "Diego", "Valentina", "Javier", "Lucía", "Alejandro", "Camila", "Andrés", "Valeria", "Ricardo", "Julia", "Fernando", "Gabriela", "Manuel", "Paula", "Sebastián", "Martina", "Daniel", "Emma", "José", "Sara" };
            string[,] peliculas = new string[,]
            {
                { "El Padrino", "Francis Ford Coppola", "2h 55min", "16" },
                { "Pulp Fiction", "Quentin Tarantino", "2h 34min", "18" },
                { "Cadena Perpetua", "Frank Darabont", "2h 22min", "16" },
                { "El Club de la Lucha", "David Fincher", "2h 19min", "18" },
                { "El Gran Dictador", "Charlie Chaplin", "2h 5min", "13" },
                { "La Vida es Bella", "Roberto Benigni", "1h 56min", "13" },
            };
            int item = rand.Next(0, peliculas.GetLength(0));
            Pelicula pelicula = new Pelicula(peliculas[item, 0], peliculas[item, 1], peliculas[item, 2], int.Parse(peliculas[item, 3]));
            Cine cine = new Cine(Math.Round(rand.NextDouble() * (2500.5 - 2400.5) + 2400.5, 2), pelicula, asientos, espectadores);
            string[] referencia = { $"Pelicula: {pelicula.titulo}", $"Duracion: {pelicula.duracion}", $"Edad minima: {pelicula.edadMin}", $"Precio: {cine.precio}" };

            for (int j = 0; j < 8; j++)
            {
                int fila = 8 - j;
                int cada3 = 3;
                for (int i = 0; i < 9; i++)
                {
                    cada3 += 3;
                    int index = j * 9 + i;
                    asientos[index] = new Asiento($"{fila}{abc[i]}", i + cada3, j + 3);
                }
            }

            for (int i = 0; i < cantEsp; i++)
                espectadores[i] = new Espectador(nombres[rand.Next(0, 30)], rand.Next(1, 80), Math.Round(rand.NextDouble() * (2500.5 - 2400.5) + 2400.5, 2));

            for (int i = 8; i >= 1; i--)
            {
                for (int j = 0; j <= 8; j++)
                {
                    int index = (i - 1) * 9 + j;
                    Mensaje($"{asientos[index].etiqueta}", asientos[index].x, asientos[index].y);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < referencia.Length; i++)
                Mensaje(referencia[i], 50, 5 + i);

            cantEsp--;
            while (cine.Libre() && cantEsp >= 0)
            {
                string[] referenciaEsp = { $"En fila: {cantEsp}", $"Nombre: {espectadores[cantEsp].nombre}", $"Edad: {espectadores[cantEsp].edad}", $"Dinero: {espectadores[cantEsp].dinero}" };
                int tomado = cine.TomarAsiento(espectadores[cantEsp]);
                Console.ForegroundColor = ConsoleColor.Red;

                if (tomado < 72)
                {
                    Console.SetCursorPosition(asientos[tomado].x, asientos[tomado].y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{asientos[tomado].etiqueta}");
                }

                for (int j = 0; j < referenciaEsp.Length; j++)
                {
                    Mensaje($"{" ".PadLeft(30)}", 90, 5 + j);
                    Mensaje(referenciaEsp[j], 90, 5 + j);
                }

                cantEsp--;
                Thread.Sleep(100);
            }

            Mensaje(cantEsp < 0 ? "Termino la fila." : "No quedan más entradas.", 6, 17);

            Console.ReadKey();
        }
    }
}
