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
    public enum Elementos
    {
        Plataforma,
        Decoracion,
        Muro,
        PlataformaInclinadaDer,
        PlataformaInclinadaIzq,
        PlataformaHieloSup,
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private const int SIZE_PINGUINO = 48;

        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, decoracion;
        List<Elemento> elementos = new List<Elemento>();
        static Vector2 posFotograma = new Vector2(5, 435);

        string pinPos, pinRect, pinVelo, colEnXB, colEnYB = "";

        Vector2 velocidadPinguino = Vector2.Zero;
        float gravedad = 0.25f;
        int sueloY = 535;
        bool jugadorEnElSuelo = true;
        bool activarSalto, left, bajando, muroColIzq, muroColDer, hielo, NO_PASAR, platHielo, salto = false;

        public enum PinguinoAnimation
        {
            Caminar,
            Jump,
            VerticalJump,
            Bend,
            Wait
        }

        PinguinoAnimation currentPinguinoAnimation;
        Animation currentAnimation, caminarAnimation, caminarAnimationL, waitAnimation, waitAnimationL, pisoHielo, jump, jumpL, bend, bendL, verticalJump, verticalJumpL, pisoLateralIzqSinNieve, pisoLateralDerSinNieve, pisoEsqSupIzqNieve, pisoEsqSupDerNieve, hieloMedio, hieloMedioIzq, hieloMedioDer, pisoMedio, hieloEsqIzq, hieloBordeSup, hieloEsqDer, pisoBordeSupHielo, plataformaPiedra, fallingLeft, EsqLateralIzqHieloNieve;

        SpriteFont pinguinoPos;
        SpriteFont plataFormaRect;
        SpriteFont gravedadPinguino;
        SpriteFont sueloPos;
        SpriteFont colEnX;
        SpriteFont colEnY;

        Matrix viewMatrix;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;

        }

        public int C(int cordenada)
        {
            return 32 * cordenada;
        }
        public int Cy(int cordenada)
        {
            return 32 * cordenada;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            piso = Content.Load<Texture2D>("TIERRA");
            fondoC1 = Content.Load<Texture2D>("sky_lightened");
            fondoC2 = Content.Load<Texture2D>("glacial_mountains");
            fondoC3 = Content.Load<Texture2D>("clouds_mg_2");
            fondoC4 = Content.Load<Texture2D>("clouds_mg_1");
            pinguinoSprites = Content.Load<Texture2D>("pinguino200-export");
            decoracion = Content.Load<Texture2D>("decoracion");

            //Pinguino1
            caminarAnimation = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, false, 0);
            caminarAnimationL = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, true, 0);
            waitAnimation = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, false, 0);
            waitAnimationL = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, true, 0);
            jump = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, false, 2);
            jumpL = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, true, 2);
            verticalJump = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, false, 1);
            verticalJumpL = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, true, 1);
            bend = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, false, 1);
            bendL = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, true, 1);
            fallingLeft = new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, true, 0 );
            //Escena--------------------------------------------------------------------------------------------------------------------------------
            //Piso por defecto
            pisoHielo = new Animation(piso, 16, 16, 1, 1, 16, false, 1);
            //Bloques de nieve
            pisoLateralIzqSinNieve = new Animation(piso, 16, 16, 1, 1, 14, false, 0);
            pisoLateralDerSinNieve = new Animation(piso, 16, 16, 1, 1, 14, false, 2);
            pisoEsqSupIzqNieve = new Animation(piso, 16, 16, 1, 1, 13, false, 0);
            pisoEsqSupDerNieve = new Animation(piso, 16, 16, 1, 1, 13, false, 2);
            pisoMedio = new Animation(piso, 16, 16, 1, 1, 14, false, 1);
            pisoBordeSupHielo = new Animation(piso, 16, 16, 1, 1, 13, false, 1);

            plataformaPiedra = new Animation(decoracion, 42 + 20, 8, 1, 1000, 0, false, 0);

            //hielo
            hieloEsqIzq = new Animation(piso, 16, 16, 1, 1, 26, false, 0);
            hieloEsqDer = new Animation(piso, 16, 16, 1, 1, 26, false, 2);
            hieloBordeSup = new Animation(piso, 16, 16, 1, 1, 26, false, 1);
            hieloMedio = new Animation(piso, 16, 16, 1, 1, 27, false, 1);
            hieloMedioDer = new Animation(piso, 16, 16, 1, 1, 26, false, 4);
            hieloMedioIzq = new Animation(piso, 16, 16, 1, 1, 26, false, 3);
            EsqLateralIzqHieloNieve = new Animation(piso, 16, 16, 1, 1, 26, false, 5);

            //Carga de elementos Piso por defecto y Bloques de piso
            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(i * C(1), Cy(15)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoBordeSupHielo));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(18)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(19)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(20)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(21)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
            }

            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(25 + i), Cy(18)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoBordeSupHielo));

            }

            //Hieloo
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(28), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloEsqIzq));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(29), Cy(15)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloEsqIzq));

            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(32), Cy(15)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloEsqDer));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(33), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloEsqDer));

            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloMedioIzq));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(32), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloMedioDer));

            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(30), Cy(15)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloBordeSup));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloMedio));
            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(31), Cy(15)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloBordeSup));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(31), Cy(16)), pisoHielo.frameHeight, pisoHielo.frameWidth, hieloMedio));

            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(28), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, EsqLateralIzqHieloNieve));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio)); 
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(31), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(32), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(33), Cy(17)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoLateralDerSinNieve));

            //Esto es un bloque tipo |-|
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(7), Cy(14)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoLateralIzqSinNieve));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(7), Cy(13)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoEsqSupIzqNieve));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(8), Cy(14)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoMedio));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(9), Cy(14)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoLateralDerSinNieve));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(9), Cy(13)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoEsqSupDerNieve));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(8), Cy(13)), pisoHielo.frameHeight, pisoHielo.frameWidth, pisoBordeSupHielo));

            //Plataforma
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(12), Cy(11)), plataformaPiedra.frameHeight, plataformaPiedra.frameWidth, plataformaPiedra));


            pinguinoPos = Content.Load<SpriteFont>("arial");
            plataFormaRect = Content.Load<SpriteFont>("arial");
            gravedadPinguino = Content.Load<SpriteFont>("arial");
            sueloPos = Content.Load<SpriteFont>("arial");
            colEnX = Content.Load<SpriteFont>("arial");
            colEnY = Content.Load<SpriteFont>("arial");

            muroColDer = false;
            muroColIzq = false;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            hielo = false;
            colEnXB = $"if de x no";

            pinPos = $"PinguinoX: {posFotograma.X} PinguinoY: {posFotograma.Y}";
            NO_PASAR = false;
            muroColDer = false;
            muroColIzq = false;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-posFotograma.X + GraphicsDevice.Viewport.Width / 2, -posFotograma.Y + 136 + GraphicsDevice.Viewport.Height / 2, 0));


            foreach (var elemento in elementos)
            {
                elemento.Animacion.Update(gameTime);
            }

            Rectangle pinguinoRect = new Rectangle((int)posFotograma.X, (int)posFotograma.Y, 54, 54);

            foreach (var muro in elementos.Where(e => e.Tipo == Elementos.Muro))
            {
                Rectangle muroRect = new Rectangle((int)muro.Posicion.X + 3, (int)muro.Posicion.Y, (int)muro.Width + 12, (int)muro.Height);

                if (IsColliding(pinguinoRect, muroRect))
                {
                    colEnXB = $"Col en X";

                    if (pinguinoRect.X > muroRect.X)
                    {
                        muroColIzq = true;
                    }
                    else
                    {
                        muroColDer = true;
                    }
                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.Plataforma))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                pinRect = $"plataformaX: {plataformaRect.X} plataformaY: {plataformaRect.Y}\n plataformaWidth: {plataformaRect.Width} plataformaHeight:{plataformaRect.Height} puntoBajo: {puntoBajoPin}\nRect left: {plataformaRect.Left} rect rigth:{plataformaRect.Right}";

                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > 0 && puntoBajoPin <= plataformaRect.Y)
                {
                    platHielo = false;
                    posFotograma.Y = plataformaRect.Y - 53;
                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;
                    break;
                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.PlataformaHieloSup))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                if (IsColliding(pinguinoRect, plataformaRect))
                {

                    platHielo = true;

                    posFotograma.Y = plataformaRect.Y - 53;
                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;

                    break;

                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.PlataformaInclinadaIzq))
            {
              
                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 6, (int)plataforma.Posicion.Y, (int)plataforma.Width , (int)plataforma.Height);

                if (IsColliding(pinguinoRect, plataformaRect))
                {
                    int interFin = plataformaRect.X + 32;
                    int interIni = plataformaRect.X;
                    int pinguinoEnX = pinguinoRect.Right;
                    int posPinXrespectoPlatX = pinguinoEnX - interIni;
                    int noTomaRect = 32 - posPinXrespectoPlatX;
                    int topTriParaX = plataformaRect.Y + noTomaRect;



                   
                    if (pinguinoRect.Y + 52.7 >= topTriParaX)
                    {
                        hielo = true;
                        //posFotograma.Y += (float)3;
                        gravedad = 0;
                        posFotograma.X -= (float)3.3;
                        posFotograma.Y += (float)4;
                        gravedad = 0.3f;
                        velocidadPinguino.Y = 0;
                    }

                    if (pinguinoRect.X <= plataformaRect.X && !platHielo && jugadorEnElSuelo)
                    {
                        colEnXB = "Entro al if de x";
                        muroColDer = true;
                        posFotograma.X += (float)3.3;
                        posFotograma.Y -= (float)4;
                    }

                    break;
                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.PlataformaInclinadaDer))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 6, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                if (IsColliding(pinguinoRect, plataformaRect))
                {
                    int interFin = plataformaRect.X + 32;
                    int interIni = plataformaRect.X;
                    int pinguinoEnX = pinguinoRect.Left + 13;
                    int posPinXrespectoPlatX = pinguinoEnX - interIni;
                    int noTomaRect = 32 - posPinXrespectoPlatX;
                    int topTriParaX = plataformaRect.Y + posPinXrespectoPlatX;
                    colEnYB = $"IntFin: {interFin}\nIntIni: {interIni}\npinguinoEnX: {pinguinoEnX}\nposPinXrespetoPlatX:{posPinXrespectoPlatX}\nnoTomaRect:{noTomaRect}\ntopTriParaX: {topTriParaX}\nTope{pinguinoRect.Y + 52.7 >= topTriParaX}";

                    if (pinguinoRect.Y + 52.7 >= topTriParaX)
                    {
                    hielo = true;
                        //posFotograma.Y += (float)3;
                        gravedad = 0;
                        posFotograma.X += (float)3.3;
                        posFotograma.Y += (float)4;
                        gravedad = 0.3f;
                        velocidadPinguino.Y = 0;
                    }

                    if (pinguinoRect.X <= plataformaRect.X && !platHielo && jugadorEnElSuelo)
                    {
                        colEnXB = "Entro al if de x";
                        muroColDer = true;
                        posFotograma.X -= (float)3.3;
                        posFotograma.Y -= (float)4;
                    }
                    break;

                }
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Up) && activarSalto && Keyboard.GetState().IsKeyDown(Keys.Right) && jugadorEnElSuelo && posFotograma.X > -100 )
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = verticalJump;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 2;
                activarSalto = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && activarSalto && Keyboard.GetState().IsKeyDown(Keys.Left) && jugadorEnElSuelo )
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = verticalJumpL;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 2;
                activarSalto = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && !muroColDer && !hielo )
            {
                left = false;
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                currentAnimation = caminarAnimation;
                posFotograma.X += 3;

                if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
                {
                    currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                    currentAnimation = verticalJump;
                    velocidadPinguino.Y = -10.0f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !muroColIzq && !hielo )
            {

                if (!Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    left = true;
                    posFotograma.X -= 3;
                    currentAnimation = caminarAnimationL;
                    currentPinguinoAnimation = PinguinoAnimation.Caminar;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo )
                {
                    currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                    currentAnimation = verticalJumpL;
                    velocidadPinguino.Y = -10.0f;
                }

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.Bend;
                currentAnimation = !left ? bend : bendL;
                activarSalto = true;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Up) && activarSalto && jugadorEnElSuelo)
            {
                currentPinguinoAnimation = PinguinoAnimation.VerticalJump;
                currentAnimation = !left ? verticalJump : verticalJumpL;
                velocidadPinguino.Y = -10.0f;
                activarSalto = false;
            } else if (Keyboard.GetState().IsKeyDown(Keys.Left) || hielo)
            {
                currentAnimation = fallingLeft;
            }
            else if (!activarSalto)
            {
                currentPinguinoAnimation = PinguinoAnimation.Wait;
                currentAnimation = !left ? waitAnimation : waitAnimationL;
            }

            pinVelo = $"velocidadPin: {velocidadPinguino.Y}\nEsta en el suelo: {jugadorEnElSuelo}\nActivar salto: {activarSalto}\nColDer:{muroColDer}\nColIzq:{muroColIzq}";

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
            Vector2 escalaFondoMontaña = new Vector2(5f, 5f);
            //Personajes
            //Debug
            Color backgroundColor = Color.Red;

            _spriteBatch.Begin(transformMatrix: viewMatrix);
            //Fondo
            Rectangle fondoRec = new Rectangle(0, 0, 380, 225);
            _spriteBatch.Draw(fondoC1, new Vector2(0, -500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC2, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC3, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
            _spriteBatch.Draw(fondoC4, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);

            //Elemento de la matriz 
            foreach (var elemento in elementos)
            {
                elemento.Animacion.Draw(_spriteBatch, elemento.Posicion, Color.White, 2.0f);
            }

            //Personajes
            currentAnimation.Draw(_spriteBatch, posFotograma, Color.White, 1.1f);

            _spriteBatch.DrawString(pinguinoPos, pinPos, new Vector2( posFotograma.X - 200, posFotograma.Y - 120), Color.White);
            _spriteBatch.DrawString(plataFormaRect, pinRect, new Vector2(posFotograma.X - 350, posFotograma.Y - 100), Color.White);
            //_spriteBatch.DrawString(sueloPos, pinVelo, new Vector2(posFotograma.X, posFotograma.Y - 80), Color.White);
            _spriteBatch.DrawString(colEnX, colEnXB, new Vector2(posFotograma.X, posFotograma.Y - 60), Color.White);
            _spriteBatch.DrawString(colEnY, colEnYB, new Vector2(posFotograma.X + 50, posFotograma.Y - 200), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


        private bool IsColliding(Rectangle pinguinoRect, Rectangle plataformaRect)
        {
            return pinguinoRect.Intersects(plataformaRect);
        }
    }
}