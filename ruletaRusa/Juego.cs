using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruletaRusa
{
    internal class Juego
    {
        public List<Jugador> jugadores;
        public Revolver revolver;

        public Juego(List<Jugador> jugadores, Revolver revolver)
        {
            this.revolver = revolver;
            this.jugadores = jugadores;
        }

        public bool FinJuego()
        {
            return jugadores.Any(j => !j.vivo);
        }

        public List<String> Ronda(int cantJ)
        {
            List<string> estado = Enumerable.Range(0, jugadores.Count).Select(i => { jugadores[i].Disparar(revolver); string mensaje = $"El {jugadores[i].nombre} se dispara, no ha muerto en esta ronda"; revolver.SiguienteBala(); return mensaje; }).TakeWhile(_ => !FinJuego()).ToList();

            if (estado.Count < cantJ) estado.Add($"El {jugadores[estado.Count].nombre} se dispara, ha muerto. \n\nFin del juego.");

            return estado;
        }
    }
}
