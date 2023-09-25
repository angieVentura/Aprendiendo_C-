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
        private Texture2D texture;
        private int frameWidth, frameHeight, frameCount, currentFrame, row, x;
        private float frameTime, timer;
        private bool left;

        public Animation(Texture2D texture, int frameWidth, int frameHeight, int frameCount, float frameTime, int row, bool left, int x)
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
            this.x = x;
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

            Rectangle sourceRectangle = new Rectangle(x + (currentFrame * frameWidth), row * frameHeight, frameWidth, frameHeight);
            spriteBatch.Draw(texture, position, sourceRectangle, color, 0f, Vector2.Zero, scale, left ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }
    }
}
