using System;
using System.Collections.Generic;
using System.Linq;

namespace barajaEspañola
{
    public enum PalosBarEspañola
    {
        Espadas,
        Bastos,
        Oros,
        Copas
    }

    public enum PalosBarFrancesa
    {
        Diamantes,
        Picas,
        Corazones,
        Treboles
    }

    class Carta<T>
    {
        public string id;
        public T palo { get; }
        public bool disponible = true;

        public Carta(string id, T palo, bool disponible)
        {
            this.id = id;
            this.palo = palo;
            this.disponible = disponible;
        }
    }

    abstract class Baraja<T, P>
    {
        protected Carta<P>[] cartas;
        public int totalCartas, cartasPorPalo;
        Random rand = new Random();

        protected Baraja(int totalCartas, int cartasPorPalo)
        {
            this.totalCartas = totalCartas;
            this.cartasPorPalo = cartasPorPalo;
            cartas = new Carta<P>[totalCartas];
        }

        public abstract void CrearBaraja();

        public void Barajar()
        {
            cartas = cartas.OrderBy(c => rand.Next()).ToArray();
        }

        public Carta<P> SiguienteCarta(Carta<P> carta)
        {
            return carta != cartas[cartas.Length - 1] ? ((Func<Carta<P>>)(() => { cartas[Array.IndexOf(cartas, carta) + 1].disponible = false; return cartas[Array.IndexOf(cartas, carta) + 1]; }))() : null;
        }

        public int CartasDisponibles()
        {
            return cartas.Count(c => c.disponible);
        }

        public List<Carta<P>> DarCartas(int cantC)
        {
            return cantC <= CartasDisponibles() ? cartas.Where(c => c.disponible == true).Take(cantC).Select(c => { c.disponible = false; return c; }).ToList() : null;
        }

        public List<Carta<P>> CartasMonton()
        {
            return cartas.Length != CartasDisponibles() ? cartas.Where(c => !c.disponible).ToList() : null;
        }

        public List<Carta<P>> MostrarBaraja()
        {
            return cartas.Where(c => c.disponible).ToList();
        }
    }

    internal class BarajaEspañola : Baraja<Carta<PalosBarEspañola>, PalosBarEspañola>
    {
        private bool incluirOchoNueve;

        public BarajaEspañola(bool incluirOchoNueve) : base(incluirOchoNueve ? 48 : 40, 10)
        {
            this.incluirOchoNueve = incluirOchoNueve;
        }

        public override void CrearBaraja()
        {
            int contador = 1;
            foreach (PalosBarEspañola palo in Enum.GetValues(typeof(PalosBarEspañola)))
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (incluirOchoNueve || (j != 8 && j != 9))
                    {
                        string nombreCarta = GetNombreCarta(j);
                        Carta<PalosBarEspañola> carta = new Carta<PalosBarEspañola>(nombreCarta, palo, true);
                        cartas[contador - 1] = carta;
                        contador++;
                    }
                }
            }
        }

        private string GetNombreCarta(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "As";
                case 10:
                    return "Sota";
                case 11:
                    return "Caballo";
                case 12:
                    return "Rey";
                default:
                    return numero.ToString();
            }
        }
    }

    internal class BarajaFrancesa : Baraja<Carta<PalosBarFrancesa>, PalosBarFrancesa>
    {
        public BarajaFrancesa() : base(52, 13)
        {
        }

        public override void CrearBaraja()
        {
            int contador = 1;
            foreach (PalosBarFrancesa palo in Enum.GetValues(typeof(PalosBarFrancesa)))
            {
                for (int j = 1; j <= 13; j++)
                {
                    string nombreCarta = GetNombreCarta(j);
                    Carta<PalosBarFrancesa> carta = new Carta<PalosBarFrancesa>(nombreCarta, palo, true);
                    cartas[contador - 1] = carta;
                    contador++;
                }
            }
        }

        private string GetNombreCarta(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "As";
                case 11:
                    return "Jota";
                case 12:
                    return "Reina";
                case 13:
                    return "Rey";
                default:
                    return numero.ToString();
            }
        }

        public bool CartaRoja(Carta<PalosBarFrancesa> c)
        {
            return c.palo == PalosBarFrancesa.Corazones || c.palo == PalosBarFrancesa.Diamantes;
        }

        public bool CartaNegra(Carta<PalosBarFrancesa> c)
        {
            return c.palo == PalosBarFrancesa.Treboles || c.palo == PalosBarFrancesa.Picas;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BarajaEspañola barajaEspañola = new BarajaEspañola(true);
            barajaEspañola.CrearBaraja();
            barajaEspañola.Barajar();
            List<Carta<PalosBarEspañola>> cartasRepartidasEspañola = barajaEspañola.DarCartas(5);
            Console.WriteLine("Cartas disponibles en la baraja española:" + barajaEspañola.CartasDisponibles());
            List<Carta<PalosBarEspañola>> cartasMontonEspañola = barajaEspañola.CartasMonton();
            List<Carta<PalosBarEspañola>> cartasBarajaEspañola = barajaEspañola.MostrarBaraja();

            BarajaFrancesa barajaFrancesa = new BarajaFrancesa();
            barajaFrancesa.CrearBaraja();
            barajaFrancesa.Barajar();
            List<Carta<PalosBarFrancesa>> cartasRepartidasFrancesa = barajaFrancesa.DarCartas(5);
            Console.WriteLine("\nCartas disponibles en la baraja francesa:" + barajaFrancesa.CartasDisponibles());
            List<Carta<PalosBarFrancesa>> cartasMontonFrancesa = barajaFrancesa.CartasMonton();
            List<Carta<PalosBarFrancesa>> cartasBarajaFrancesa = barajaFrancesa.MostrarBaraja();

            Console.WriteLine(
                
                $"\nCartas repartidas de la baraja española:\n{string.Join("\n", cartasRepartidasEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))} " +

                $"\nCartas en el montón de la baraja española:\n{string.Join("\n", cartasMontonEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\nCartas en la baraja española:\n{string.Join("\n", cartasBarajaEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\nCartas repartidas de la baraja francesa:\n{string.Join("\n", cartasRepartidasFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\nCartas en el montón de la baraja francesa:\n{string.Join("\n", cartasMontonFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\nCartas en la baraja francesa:\n{string.Join("\n", cartasBarajaFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}");

           /* foreach (Carta<PalosBarEspañola> carta in cartasRepartidasEspañola)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("\nCartas en el montón de la baraja española:\n");
            foreach (Carta<PalosBarEspañola> carta in cartasMontonEspañola)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("\nCartas en la baraja española:\n");
            foreach (Carta<PalosBarEspañola> carta in cartasBarajaEspañola)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("\nCartas repartidas de la baraja francesa:\n");
            foreach (Carta<PalosBarFrancesa> carta in cartasRepartidasFrancesa)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("\nCartas en el montón de la baraja francesa:\n");
            foreach (Carta<PalosBarFrancesa> carta in cartasMontonFrancesa)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }

            Console.WriteLine("\nCartas en la baraja francesa:\n");
            foreach (Carta<PalosBarFrancesa> carta in cartasBarajaFrancesa)
            {
                Console.WriteLine($"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}");
            }*/

            Console.ReadKey();
        }
    }
}
