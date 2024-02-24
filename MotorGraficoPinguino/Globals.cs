using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace MotorGraficoPinguino
{
    internal class Globals
    {
        public static float Time { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch Spritebatch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static Point WindowsSize { get; set; }

        public static Vector2 PosPlayer = new Vector2(100, 0);

        public static GameTime gameTime { get; set; }

        public static List<Keys> KeysPinguino1 = new List<Keys>
        {
            Keys.Left,
            Keys.Up,
            Keys.Right
        };

        public static List<Keys> KeysPinguino2 = new List<Keys>
        {
            Keys.A,
            Keys.W,
            Keys.D

        };

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}
