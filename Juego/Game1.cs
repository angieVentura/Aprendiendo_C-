using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Juego
{
    public class Animation
    {
        private Texture2D texture;
        private int frameWidth;
        private int frameHeight;
        private int frameCount;
        private int currentFrame;
        private float frameTime;
        private float timer;
        private int row;
        private bool move,right,up;
        private Vector2 movimiento;

        public Animation(Texture2D texture, int frameWidth, int frameHeight, int frameCount, float frameTime, int row, bool move, bool right, bool up, Vector2 movimiento)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.timer = 0;
            this.currentFrame = 0;
            this.row = row;
            this.move = move;
            this.movimiento = movimiento;
            
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
         
            Rectangle sourceRectangle = new Rectangle(currentFrame * frameWidth, row * frameHeight, frameWidth, frameHeight);
            spriteBatch.Draw(texture, position , sourceRectangle, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, pinguinoPrueba, FondoP;
        int[,] escenario;
        Vector2 posFotograma = new Vector2(5, 400);

        public enum PinguinoAnimation
        {
            Caminar,
            Saltar,
            Wait
        }

        PinguinoAnimation currentPinguinoAnimation;
        Animation currentAnimation;
        Animation caminarAnimation;
        Animation waitAnimation;
        bool desEnX;
        bool desEnY;
        SpriteEffects flipHorizontal = SpriteEffects.FlipHorizontally;

        public Game1()
        {
            //pantalla de 800 x 600
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            escenario = new int[10, 25];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (i == 9) 
                        escenario[i, j] = 1;
                    else
                        escenario[i, j] = 0;
                }
            }

        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            piso = Content.Load<Texture2D>("Terrain Tileset");
            fondoC1 = Content.Load<Texture2D>("sky_lightened");
            fondoC2 = Content.Load<Texture2D>("glacial_mountains");
            fondoC3 = Content.Load<Texture2D>("clouds_mg_2");
            fondoC4 = Content.Load<Texture2D>("clouds_mg_1");
            pinguinoSprites = Content.Load<Texture2D>("pinguino/pinguino");
            pinguinoPrueba = Content.Load<Texture2D>("pinguino/pinguino");
            FondoP = Content.Load<Texture2D>("Fondo");
            caminarAnimation = new Animation(pinguinoSprites,144, 144, 6, 100, 0, true, desEnX, desEnY, new Vector2(5, 0));
            waitAnimation = new Animation(pinguinoSprites, 144, 144, 4, 1000, 3, false, false, false, new Vector2(0,0));
            currentPinguinoAnimation = PinguinoAnimation.Wait;
            //currentAnimation = waitAnimation;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                
                currentAnimation = caminarAnimation;
                posFotograma.X += 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                currentPinguinoAnimation = PinguinoAnimation.Caminar;

            }
            else
            {
                currentPinguinoAnimation = PinguinoAnimation.Wait;
                currentAnimation = waitAnimation;
            }

            currentAnimation.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Escena
            Vector2 escalaPiso = new Vector2(2.0f, 2.0f);
            Vector2 escalaFondos = new Vector2(2.11f, 2.11f);
            //Personajes
            Vector2 escalaPinguinos = new Vector2(0.3f, 0.3f);
            //Debug
            Color backgroundColor = Color.Red;

            _spriteBatch.Begin();
            
            //Fondo
            Rectangle fondoRec = new Rectangle(0, 0, 380, 225);
            _spriteBatch.Draw(fondoC1, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC2, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC3, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC4, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);

            // Dibujando pisososoosos jejejejejje
            var positionsToDraw = from i in Enumerable.Range(0, 10) from j in Enumerable.Range(0, 25) where escenario[i, j] == 1 select new Vector2(j * 32, i * 50);

            foreach (var position in positionsToDraw)
            {
                Rectangle pisoNieve = new Rectangle(20, 208, 16, 16);
                _spriteBatch.Draw(piso, position, pisoNieve, Color.White, 0f, Vector2.Zero, escalaPiso, SpriteEffects.None, 0f);
            }

            //Personajes
            currentAnimation.Draw(_spriteBatch, posFotograma, null, Color.White, 0.37f);


            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}