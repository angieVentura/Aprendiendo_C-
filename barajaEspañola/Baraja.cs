using System;
using System.Collections.Generic;
using System.Linq;

namespace barajaEspañola
{
    internal abstract class Baraja<T, P>
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
}
