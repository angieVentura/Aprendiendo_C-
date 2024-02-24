using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MotorGraficoPinguino
{
    class GameObject
    {
        public Vector2 pos;
        public string type;
        public Color color;
        public Animation animation;
        public int width, height;

        public GameObject(Vector2 pos, string type, Color color, Animation animation, int width, int height)
        {
            this.pos = pos;
            this.type = type;
            this.color = color;
            this.animation = animation;
            this.width = width;
            this.height = height;
        }
    }
}
