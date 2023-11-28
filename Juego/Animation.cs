using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    public class Animation
    {
        public Texture2D texture;
        public int frameWidth, frameHeight, frameCount, currentFrame, row, column;
        public float frameTime, timer;
        public bool left;
        public string nombre;

        public Animation(Texture2D texture, int frameWidth, int frameHeight, int frameCount, float frameTime, int row, bool left, int column, string nombre)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.timer = 0;
            this.currentFrame = 0;
            this.row = row;
            this.left = left;
            this.column = column;
            this.nombre = nombre;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > frameTime)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float scale)
        {

            Rectangle sourceRectangle = new Rectangle(( column + currentFrame) * frameWidth, row * frameHeight, frameWidth, frameHeight);
            spriteBatch.Draw(texture, position, sourceRectangle, color, 0f, Vector2.Zero, scale, left ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }
    }
}
