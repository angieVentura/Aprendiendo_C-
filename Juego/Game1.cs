using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Juego
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, pinguinoPrueba, FondoP;
        List<Elemento> elementos = new List<Elemento>();
        Vector2 posFotograma = new Vector2(5, 528);
        int cantPiso = 0;
        Vector2 velocidadPinguino = Vector2.Zero;
        float gravedad = 0.5f;
        int sueloY = 528;
        bool jugadorEnElSuelo = true;
        bool activarSalto = false;
        bool left = false;
        public enum PinguinoAnimation
        {
            Caminar,
            Jump,
            VerticalJump,
            Bend,
            Wait
        }

        public enum Elementos
        {
            Plataforma,
            Decoracion
        }

        bool estaAgachado = false;

        PinguinoAnimation currentPinguinoAnimation;
        Animation currentAnimation;
        Animation caminarAnimation;
        Animation caminarAnimationL;
        Animation waitAnimation;
        Animation waitAnimationL;
        Animation pisoHielo;
        Animation jump;
        Animation jumpL;
        Animation bend;
        Animation bendL;
        Animation verticalJump;
        Animation verticalJumpL;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            IsMouseVisible = false;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            piso = Content.Load<Texture2D>("Terrain Tileset");
            fondoC1 = Content.Load<Texture2D>("sky_lightened");
            fondoC2 = Content.Load<Texture2D>("glacial_mountains");
            fondoC3 = Content.Load<Texture2D>("clouds_mg_2");
            fondoC4 = Content.Load<Texture2D>("clouds_mg_1");
            pinguinoSprites = Content.Load<Texture2D>("pinguino/pinguino" );
            pinguinoPrueba = Content.Load<Texture2D>("pinguino/pinguino");
            FondoP = Content.Load<Texture2D>("Fondo");

            //Pinguino1
            caminarAnimation = new Animation(pinguinoSprites, 144, 144, 6, 100, 0, false, 0);
            caminarAnimationL = new Animation(pinguinoSprites, 144, 144, 6, 100, 0, true, 0);
            waitAnimation = new Animation(pinguinoSprites, 144, 144, 8, 450, 6, false, 0);
            waitAnimationL = new Animation(pinguinoSprites, 144, 144, 8, 450, 6, true, 0);
            jump = new Animation(pinguinoSprites, 144, 144, 8, 100, 8, false, 2);
            jumpL = new Animation(pinguinoSprites, 144, 144, 8, 100, 8, true, 2);
            verticalJump = new Animation(pinguinoSprites, 144, 144, 5, 150, 2, false, 1);
            verticalJumpL = new Animation(pinguinoSprites, 144, 144, 5, 150, 2, true, 1);
            bend = new Animation(pinguinoSprites, 144, 144, 1, 1000, 8, false, 1);
            bendL = new Animation(pinguinoSprites, 144, 144, 1, 1000, 8, true, 1);
            //Escena
            pisoHielo = new Animation(piso, 16, 16, 1, 1, 16, false, 1);
            for (int i = 0; i < 20; i++)
            {
                elementos.Add(new Elemento("Plataforma", new Vector2((i+5) * 32, 568), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoHielo));
            }
            elementos.Add(new Elemento("Plataforma", new Vector2(10 * 32, 536), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoHielo));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var elemento in elementos)
            {
                elemento.Animacion.Update(gameTime);
            }

            Rectangle pinguinoRect = new Rectangle((int)posFotograma.X, (int)posFotograma.Y, 54, 54);

            // Verifica colisiones con las plataformas
            foreach (var plataforma in elementos.Where(e => e.Tipo == "Plataforma"))
            {
                
                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);

                if (IsColliding(pinguinoRect, plataformaRect))
                {
                    float posX = plataformaRect.X;
                    posFotograma.Y = plataformaRect.Y - 54;
                    float posLol = posFotograma.Y;
                    float posPlatRect = plataformaRect.Y;
                    float AnimaPing = caminarAnimation.frameHeight;

                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;
                    break;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && activarSalto && Keyboard.GetState().IsKeyDown(Keys.Right) && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = verticalJump;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 1;
                activarSalto = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && activarSalto && Keyboard.GetState().IsKeyDown(Keys.Left) && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = verticalJumpL;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 1;
                activarSalto = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                left = false; 
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                currentAnimation = caminarAnimation;
                posFotograma.X += 1;

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
                {
                    currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                    currentAnimation = verticalJump;
                    velocidadPinguino.Y = -10.0f;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) )
            {
                left = true; 
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                currentAnimation = caminarAnimationL;
                posFotograma.X -= 1;

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
                {
                    currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                    currentAnimation = verticalJumpL;
                    velocidadPinguino.Y = -10.0f;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.Bend;
                currentAnimation = !left? bend : bendL;
                activarSalto = true;
            } 
            else if (Keyboard.GetState().IsKeyUp(Keys.Up) && activarSalto && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = !left ? verticalJump : verticalJumpL;
                velocidadPinguino.Y = -10.0f;
                activarSalto= false;
            }
            else if(!activarSalto && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.Wait;
                currentAnimation = !left? waitAnimation : waitAnimationL;              
            }

            velocidadPinguino.Y += gravedad;
            posFotograma.Y += velocidadPinguino.Y;

            // Verificar si el lokito esta en el suelo
            if (posFotograma.Y >= sueloY)
            {
                posFotograma.Y = sueloY; // Para que el lokito no se vaya a la estratosfera
                velocidadPinguino.Y = 0.0f; // No velocidad vertical 
                jugadorEnElSuelo = true;
            }
            else
            {
                jugadorEnElSuelo = false;
            }

            currentAnimation.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Escena
            Vector2 escalaFondos = new Vector2(2.11f, 2.11f);
            //Personajes
            //Debug
            Color backgroundColor = Color.Red;

            _spriteBatch.Begin();
            //Fondo
            Rectangle fondoRec = new Rectangle(0, 0, 380, 225);
            _spriteBatch.Draw(fondoC1, new Vector2(0, 0), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC2, new Vector2(0, 124), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC3, new Vector2(0, 124), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC4, new Vector2(0, 124), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondos, SpriteEffects.None, 0f);

            //Elemento de la matriz 
            foreach (var elemento in elementos)
            {
                elemento.Animacion.Draw(_spriteBatch, elemento.Posicion, Color.White, 2.0f);
            }

            //Personajes
            currentAnimation.Draw(_spriteBatch, posFotograma, Color.White, 0.37f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


        private bool IsColliding(Rectangle pinguinoRect, Rectangle plataformaRect)
        {
            return pinguinoRect.Intersects(plataformaRect);
        }
    }
}