using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruletaRusa
{
    internal class Jugador
    {
        public int id;
        public string nombre;
        public bool vivo;

        public Jugador(int id, string nombre, bool vivo)
        {
            this.id = id;
            this.nombre = nombre;
            this.vivo = vivo;
        }

        public void Disparar(Revolver revolver)
        {
            vivo = !revolver.DispararRe();
        }
    }
}
