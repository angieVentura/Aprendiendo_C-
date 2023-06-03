using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baraja
{
    internal class Baraja
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
}
