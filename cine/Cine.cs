using System;
using System.Linq;

namespace cine
{
    internal class Cine
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

}
