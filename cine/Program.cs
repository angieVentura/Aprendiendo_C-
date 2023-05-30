using System;
using System.Linq;
using System.Threading;

namespace cine
{
    class Pelicula
    {
        public string titulo, director, duracion;
        public int edadMin;

        public Pelicula(string titulo, string director, string duracion, int edadMin)
        {
            this.titulo = titulo;
            this.director = director;
            this.duracion = duracion;
            this.edadMin = edadMin;
        }
    }

    class Espectador
    {
        public string nombre;
        public int edad;
        public double dinero;

        public Espectador(string nombre, int edad, double dinero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dinero = dinero;
        }

    }

    class Asiento
    {
        public string etiqueta;
        public Espectador espectador;
        public int x, y;

        public Asiento(string etiqueta, int x, int y)
        {
            this.etiqueta = etiqueta;
            this.x = x;
            this.y = y;
            espectador = null;
        }

        public void Ocupar(Espectador espectador)
        {
            this.espectador = espectador;
        }

        public bool EstaOcupado()
        {
            return espectador != null;
        }
    }

    class Cine
    {
        public double precio;
        public Pelicula pelicula;
        public Asiento[] asientos;
        public Espectador[] espectadores;
        Random rand = new Random();

        public Cine(double precio, Pelicula pelicula, Asiento[] asientos, Espectador[] espectadores)
        {
            this.precio = precio;
            this.pelicula = pelicula;
            this.asientos = asientos;
            this.espectadores = espectadores;
        }

        public bool Libre()
        {
            return asientos.Any(a => a.espectador == null);
        }

        public bool AlcanzaDinero(Espectador espectador)
        {
            return precio <= espectador.dinero;
        }

        public bool AlcanzaEdad(Espectador espectador)
        {
            return pelicula.edadMin <= espectador.edad;
        }

        public int TomarAsiento(Espectador espectador)
        {
            if (Libre() && AlcanzaDinero(espectador) && AlcanzaEdad(espectador))
            {
                int asiento = rand.Next(0, 72);

                while (asientos[asiento].EstaOcupado())
                {
                    asiento = rand.Next(0, 72);
                }
                asientos[asiento].Ocupar(espectador);
                return asiento;
            }
            return 72;
        }
    }

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
            Asiento[] asientos = new Asiento[72];
            char[] abc = "ABCDEFGHI".ToCharArray();
            string[] nombres = new string[30] { "Juan", "María", "Carlos", "Laura", "Pedro", "Ana", "Luis", "Sofía", "Miguel", "Isabella", "Diego", "Valentina", "Javier", "Lucía", "Alejandro", "Camila", "Andrés", "Valeria", "Ricardo", "Julia", "Fernando", "Gabriela", "Manuel", "Paula", "Sebastián", "Martina", "Daniel", "Emma", "José", "Sara" };

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

            int cantEsp = rand.Next(150, 200);

            Espectador[] espectadores = new Espectador[cantEsp];

            for (int i = 0; i < cantEsp; i++)
            {
                espectadores[i] = new Espectador(nombres[rand.Next(0, 30)], rand.Next(1, 80), Math.Round(rand.NextDouble() * (2500.5 - 2400.5) + 2400.5, 2));
            }

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

            for (int i = 8; i >= 1; i--)
            {
                for (int j = 0; j <= 8; j++)
                {
                    int index = (i - 1) * 9 + j;
                    Mensaje($"{asientos[index].etiqueta}", asientos[index].x, asientos[index].y);
                }
                Console.WriteLine();
            }

            string[] referencia = { $"Pelicula: {pelicula.titulo}", $"Duracion: {pelicula.duracion}", $"Edad minima: {pelicula.edadMin}", $"Precio: {cine.precio}" };
            for (int i = 0; i < referencia.Length; i++)
                Mensaje(referencia[i], 50, 5 + i);

            cantEsp--;
            while (cine.Libre() && cantEsp >= 0)
            {
                string[] referenciaEsp = { $"Nombre: {espectadores[cantEsp].nombre}", $"Edad: {espectadores[cantEsp].edad}", $"Dinero: {espectadores[cantEsp].dinero}" };

                for (int j = 0; j < referenciaEsp.Length; j++)
                    Mensaje(referenciaEsp[j], 6, 20 + j);

                Mensaje($"En fila:{" ".PadLeft(10)}", 6, 15);
                Mensaje($"En fila: {cantEsp}", 6, 15);
                int tomado = cine.TomarAsiento(espectadores[cantEsp]);
                if (tomado < 72)
                {
                    Console.SetCursorPosition(asientos[tomado].x, asientos[tomado].y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{asientos[tomado].etiqueta}");
                }
                cantEsp--;
                Thread.Sleep(100);
            }

            Mensaje( cantEsp < 0 ? "Termino la fila" : "No quedan más entradas", 6, 25);

            Console.ReadKey();
        }
    }
}
