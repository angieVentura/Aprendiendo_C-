using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorGraficoPinguino
{
    internal class Animationes
    {
        public string nombre;
        public Animation animation;

        public Animationes(string nombre, Animation animation)
        {
            this.nombre = nombre;
            this.animation = animation;
        }

        public Animation GetAnimation
        {
            get { return animation; }
        }
    }
}
