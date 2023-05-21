using System;
using System.Linq;

namespace Entregable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            series[0] = new Serie("Game of Thrones", 8, "Drama", "David Benioff");
            series[1] = new Serie("Breaking Bad", "Vince Gilligan");
            series[2] = new Serie("Stranger Things", 4, "Ciencia ficción", "Duffer Brothers");
            series[3] = new Serie("Friends", "David Crane");
            series[4] = new Serie();

            videojuegos[0] = new Videojuego("The Witcher 3: Wild Hunt", 80, "Rol", "CD Projekt Red");
            videojuegos[1] = new Videojuego("Grand Theft Auto V", 60, "Acción", "Rockstar Games");
            videojuegos[2] = new Videojuego("Minecraft", 40, "Aventura", "Mojang Studios");
            videojuegos[3] = new Videojuego("The Legend of Zelda: Breath of the Wild", 120, "Aventura", "Nintendo");
            videojuegos[4] = new Videojuego();

            series[0].Entregar();
            series[2].Entregar();
            videojuegos[3].Entregar();
            videojuegos[1].Entregar();
            videojuegos[2].Entregar();

            Serie[] seriesEntregadas = series.Where(s => s.IsEntregado()).ToArray();
            Videojuego[] vjEntregados = videojuegos.Where(vj => vj.IsEntregado()).ToArray();

            Console.WriteLine($"\nLa cantidad de series entregadas es: {seriesEntregadas.Length}");
            Array.ForEach(seriesEntregadas, serieEntregada => Console.WriteLine($"\n{serieEntregada.Titulo}"));

            Console.WriteLine($"\nLa cantidad de videojuegos entregados es: {vjEntregados.Length}");
            Array.ForEach(vjEntregados, vjEntregado => Console.WriteLine($"\n{vjEntregado.Titulo}"));

            Serie serieMax = series.OrderByDescending(s => s.NumDeTem).FirstOrDefault();
            Videojuego videoMax = videojuegos.OrderByDescending(vj => vj.HorasEstimadas).FirstOrDefault();

            Console.WriteLine($"\nLa serie con más temporadas es: {serieMax.Titulo} con {serieMax.NumDeTem} temporadas.");
            Console.WriteLine($"\nEL videojuego con más horas estimadas es: {videoMax.Titulo} con {videoMax.HorasEstimadas} horas.");

            Console.ReadKey();
        }
    }
}
