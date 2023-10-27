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
        public Elementos Tipo { get; set; }
        public Vector2 Posicion { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public Animation Animacion { get; set; }

        public Elemento(Elementos tipo, Vector2 posicion, float height, float width, Animation animacion)
        {
            Tipo = tipo;
            Posicion = posicion;
            Height = height; 
            Width = width;
            Animacion = animacion;
        }
    }
}
