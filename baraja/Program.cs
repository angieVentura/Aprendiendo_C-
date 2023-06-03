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

    class Carta
    {
        public int id;
        public Palo palo { get; }
        public bool disponible = true;

        public Carta(int id, Palo palo, bool disponible)
        {
            this.id = id;
            this.palo = palo;
            this.disponible = disponible;
        }

    }

    class Baraja
    {
        public Carta[] cartas;
        Random rand = new Random();

        public Baraja(Carta[] cartas)
        {
            this.cartas = cartas;
        }

        public void Barajar()
        {
            cartas = cartas.OrderBy(c => rand.Next()).ToArray();
        }

        public Carta SiguienteCarta(Carta carta)
        {
            //Func<Carta> Me dieron ganas de probar algo nuevo owo 
            return carta != cartas[cartas.Length - 1] ? ((Func<Carta>)(() => { cartas[Array.IndexOf(cartas, carta) + 1].disponible = false; return cartas[Array.IndexOf(cartas, carta) + 1]; }))() : null;

            /*//Esto es lo mismo
            if (carta != cartas[cartas.Length - 1])
            {
                cartas[Array.IndexOf(cartas, carta) + 1].disponible = false;
                return cartas[Array.IndexOf(cartas, carta) + 1];
            }
            return null;
            */
        }

        public int CartasDisponibles()
        {
            return cartas.Count(c => c.disponible);
        }

        public List<Carta> DarCartas(int cantC)
        {
            return cantC <= CartasDisponibles() ? cartas.Where(c => c.disponible == true).Take(cantC).Select(c => { c.disponible = false; return c; }).ToList() : null;
        }

        public List<Carta> CartasMonton()
        {
            return cartas.Length != CartasDisponibles() ? cartas.Where(c => !c.disponible).ToList() : null;
        }

        public List<Carta> MostrarBaraja()
        {
            return cartas.Where(c => c.disponible).ToList();
        }

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
                        Carta carta = new Carta(contador, palo, true);
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


