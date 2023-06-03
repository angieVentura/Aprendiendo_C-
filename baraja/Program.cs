using System;
using System.Collections.Generic;
using System.Linq;

namespace baraja
{
    public enum Palo
    {
        Espadas,
        Bastos,
        Oros,
        Copas
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            Carta[] cartas = new Carta[40];
            int contador = 1;
            for (int i = 0; i < 4; i++)
            {
                Palo palo = (Palo)i;
                for (int j = 1; j <= 12; j++)
                {
                    if (j != 8 && j != 9)
                    {
                        Carta carta = new Carta(j, palo, true);
                        cartas[contador - 1] = carta;
                        contador++;
                    }
                }
            }

            Baraja baraja = new Baraja(cartas);
            baraja.Barajar();
            List<Carta> cartasRepartidas = baraja.DarCartas(5);
            Console.WriteLine("Cartas disponibles: " + baraja.CartasDisponibles());
            List<Carta> cartasMonton = baraja.CartasMonton();
            List<Carta> cartasBaraja = baraja.MostrarBaraja();

            Console.WriteLine("Cartas repartidas:");
            foreach (Carta carta in cartasRepartidas)
            {
                Console.WriteLine($"Número: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("Cartas en el montón:");
            foreach (Carta carta in cartasMonton)
            {
                Console.WriteLine($"Número: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("Cartas en la baraja:");
            foreach (Carta carta in cartasBaraja)
            {
                Console.WriteLine($"Número: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.ReadKey();

        }
    }
}


