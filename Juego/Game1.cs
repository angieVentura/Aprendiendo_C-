using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Juego
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, pinguinoPrueba;
        int[,] escenario;
        float timer;
        int threshold;
        Rectangle[] pinguino;
        byte previousAnimationIndex;
        byte currentAnimationIndex;


        public Game1()
        {
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            timer = 0;

            threshold = 250;



            previousAnimationIndex = 2;
            currentAnimationIndex = 1;
            // TODO: use this.Content to load your game content here

            piso = Content.Load<Texture2D>("Terrain Tileset");
            fondoC1 = Content.Load<Texture2D>("sky_lightened");
            fondoC2 = Content.Load<Texture2D>("glacial_mountains");
            fondoC3 = Content.Load<Texture2D>("clouds_mg_2");
            fondoC4 = Content.Load<Texture2D>("clouds_mg_1");
          //  pinguinoSprites = Content.Load<Texture2D>("pinguinoCaminando-sheet");
            pinguinoPrueba = Content.Load<Texture2D>("pinguinoCaminando1");
       
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Check if the timer has exceeded the threshold.
            if (timer > threshold)
            {
                // If Alex is in the middle sprite of the animation.
                if (currentAnimationIndex == 1)
                {
                    // If the previous animation was the left-side sprite, then the next animation should be the right-side sprite.
                    if (previousAnimationIndex == 0)
                    {
                        currentAnimationIndex = 2;
                    }
                    else
                    // If not, then the next animation should be the left-side sprite.
                    {
                        currentAnimationIndex = 0;
                    }
                    // Track the animation.
                    previousAnimationIndex = currentAnimationIndex;
                }
                // If Alex was not in the middle sprite of the animation, he should return to the middle sprite.
                else
                {
                    currentAnimationIndex = 1;
                }
                // Reset the timer.
                timer = 0;
            }
            // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Vector2 escalaPiso = new Vector2(2.0f, 2.0f);

            Vector2 escalaFondos = new Vector2(2.11f, 2.11f);

            Vector2 escalaPinguinos = new Vector2(2.5f, 2.5f);
 


            _spriteBatch.Begin();
            Rectangle fondoRec = new Rectangle(0, 0, 380, 225);
            _spriteBatch.Draw(fondoC1, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC2, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC3, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC4, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);


            // Dibujando pisososoosos
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (escenario[i, j] == 1) 
                    {
                        Rectangle pisoNieve = new Rectangle(20, 208, 16, 16);
                        _spriteBatch.Draw(piso, new Vector2(j * 32, i * 50), pisoNieve, Color.White, 0f, Vector2.Zero, escalaPiso, SpriteEffects.None, 0f);
                        
                    }
                }
            }

            //Rectangle pinguinoRec = new Rectangle(20, 208, 16, 16);
          /*  Rectangle[] pinguino = new Rectangle[6];

            pinguino[0] = new Rectangle(0, 0, 16, 16);
            pinguino[1] = new Rectangle(16, 0, 16, 16);
            pinguino[2] = new Rectangle(32, 0, 16, 16);
            pinguino[3] = new Rectangle(48, 0, 16, 16);
            pinguino[4] = new Rectangle(64, 0, 16, 16);
            pinguino[5] = new Rectangle(80, 0, 16, 16);

            _spriteBatch.Draw(pinguinoSprites, new Vector2(10,395), pinguino[currentAnimationIndex], Color.White, 0f, Vector2.Zero, escalaPinguinos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(pinguinoPrueba, new Vector2(0, 0), new Rectangle(0, 0, 32, 32), Color.White, 0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0f);*/
            _spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}