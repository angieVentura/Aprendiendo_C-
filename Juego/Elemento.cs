using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Juego
{
    public class Elemento
    {
        public string Tipo { get; set; }
        public Vector2 Posicion { get; set; }
        public Vector2 Tamano { get; set; }
        public Animation Animacion { get; set; }

        public Elemento(string tipo, Vector2 posicion, Vector2 tamano, Animation animacion)
        {
            Tipo = tipo;
            Posicion = posicion;
            Tamano = tamano;
            Animacion = animacion;
        }
    }
}
