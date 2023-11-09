using Juego;
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
    class Animationes
    {
        public string nombre;
        public Animation animation;

        public Animationes(string nombre, Animation animation)
        {
            this.nombre = nombre;
            this.animation = animation;
        }

        public Animation GetAnimation
        {
            get { return animation; }
        }
    }

    public enum Elementos
    {
        Plataforma,
        Decoracion,
        Muro,
        PlataformaInclinadaDer,
        PlataformaInclinadaIzq,
        PlataformaHieloSup,
        Transparente
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private const int SIZE_PINGUINO = 48;
        const int SIZE_TILE = 16;

        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, decoracion;
        List<Elemento> elementos = new List<Elemento>();
        static Vector2 posFotograma = new Vector2(5, 435);

        string pinPos, pinRect, pinVelo, colEnXB, colEnYB = "";

        Vector2 velocidadPinguino = Vector2.Zero;
        float gravedad = 0.25f;
        int sueloY = 535;
        bool jugadorEnElSuelo = true;
        bool activarSalto, left, bajando, muroColIzq, muroColDer, hielo, NO_PASAR, platHielo, salto, hieloRight = false;

        public enum PinguinoAnimation
        {
            Caminar,
            Jump,
            VerticalJump,
            Bend,
            Wait
        }

        SpriteFont colEnX;
        Matrix viewMatrix;
        Jugador pinguino1, pinguino2;

        List<Keys> keysPinguino1 = new List<Keys>
        {
            Keys.Left,
            Keys.Up,
            Keys.Right           
        }; 
        
        List<Keys> keysPinguino2 = new List<Keys>
        {
            Keys.A,           
            Keys.W,
            Keys.D
        };

        List<Animationes> animaciones;

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
            animaciones = new List<Animationes> {
                // Animaciones de los pingüinos
                new Animationes("caminarAnimation", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, false, 0)),
                new Animationes("caminarAnimationL", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, true, 0)),
                new Animationes("waitAnimation", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, false, 0)),
                new Animationes("waitAnimationL", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, true, 0)),
                new Animationes("jump", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, false, 2)),
                new Animationes("jumpL", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, true, 2)),
                new Animationes("verticalJump", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, false, 1)),
                new Animationes("verticalJumpL", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, true, 1)),
                new Animationes("bend", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, false, 1)),
                new Animationes("bendL", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, true, 1)),
                new Animationes("fallingLeft", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, true, 0)),
                new Animationes("fallingRight", new Animation(pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, false, 0)),

                // Animaciones de la escena
                new Animationes("pisoHielo", new Animation(piso, 16, 16, 1, 1, 16, false, 1)),
                new Animationes("pisoLateralIzqSinNieve", new Animation(piso, 16, 16, 1, 1, 14, false, 0)),
                new Animationes("pisoLateralDerSinNieve",  new Animation(piso, 16, 16, 1, 1, 14, false, 2)),
                new Animationes("pisoEsqSupIzqNieve", new Animation(piso, 16, 16, 1, 1, 13, false, 0)),
                new Animationes("pisoEsqSupDerNieve", new Animation(piso, 16, 16, 1, 1, 13, false, 2)),
                new Animationes("pisoMedio", new Animation(piso, 16, 16, 1, 1, 14, false, 1)),
                new Animationes("pisoBordeSupHielo", new Animation(piso, 16, 16, 1, 1, 13, false, 1)),
                new Animationes("plataformaPiedra",  new Animation(decoracion, 42 + 20, 8, 1, 1000, 0, false, 0)),
                new Animationes("hieloEsqIzq", new Animation(piso, 16, 16, 1, 1, 26, false, 0)),
                new Animationes("hieloEsqDer", new Animation(piso, 16, 16, 1, 1, 26, false, 2)),
                new Animationes("hieloBordeSup",  new Animation(piso, 16, 16, 1, 1, 26, false, 1)),
                new Animationes("hieloMedio", new Animation(piso, 16, 16, 1, 1, 27, false, 1)),
                new Animationes("hieloMedioDer", new Animation(piso, 16, 16, 1, 1, 26, false, 4)),
                new Animationes("hieloMedioIzq", new Animation(piso, 16, 16, 1, 1, 26, false, 3)),
                new Animationes("EsqLateralIzqHieloNieve", new Animation(piso, 16, 16, 1, 1, 26, false, 5)),
                new Animationes("transparente", new Animation(piso,16, 16, 1, 1000, 15, false, 6))
            };

            //Carga de elementos Piso por defecto y Bloques de piso
            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(i * C(1), Cy(15)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(18)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(19)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(20)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(21)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            }

            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(12), Cy(11)), 8, 48, animaciones.FirstOrDefault(a => a.nombre == "plataformaPiedra").GetAnimation));

            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(25 + i), Cy(18)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo").GetAnimation));
            }


            //Hieloo
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(28), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloEsqIzq").GetAnimation));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(29), Cy(15)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloEsqIzq").GetAnimation));

            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(32), Cy(15)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloEsqDer").GetAnimation));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(33), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloEsqDer").GetAnimation));

            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloMedioIzq").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(32), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloMedioDer").GetAnimation));

            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(30), Cy(15)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloBordeSup").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoHielo").GetAnimation));
            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(31), Cy(15)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "hieloBordeSup").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(31), Cy(16)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoHielo").GetAnimation));

            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(28), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "EsqLateralIzqHieloNieve").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(31), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(32), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(33), Cy(17)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoLateralDerSinNieve").GetAnimation));


            //Esto es un bloque tipo |-|
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(7), Cy(14)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoLateralIzqSinNieve").GetAnimation));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(7), Cy(13)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoEsqSupIzqNieve").GetAnimation));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(8), Cy(14)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoMedio").GetAnimation));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(9), Cy(14)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoLateralDerSinNieve").GetAnimation));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(9), Cy(13)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoEsqSupDerNieve").GetAnimation));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(8), Cy(13)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo").GetAnimation));

            //Plataforma
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(12), Cy(11)), SIZE_TILE, SIZE_TILE, animaciones.FirstOrDefault(a => a.nombre == "plataformaPiedra").GetAnimation));

            pinguinoPos = Content.Load<SpriteFont>("arial");
            plataFormaRect = Content.Load<SpriteFont>("arial");
            gravedadPinguino = Content.Load<SpriteFont>("arial");
            sueloPos = Content.Load<SpriteFont>("arial");
            colEnX = Content.Load<SpriteFont>("arial");
            colEnY = Content.Load<SpriteFont>("arial");

            muroColDer = false;
            muroColIzq = false;

            pinguino1 = new Jugador(posFotograma, elementos, animaciones, velocidadPinguino, gravedad, sueloY, jugadorEnElSuelo, activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight, keysPinguino1); 
            pinguino2 = new Jugador(posFotograma, elementos, animaciones, velocidadPinguino, gravedad, sueloY, jugadorEnElSuelo, activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight, keysPinguino2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();
            colEnXB = pinguino1.message;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-pinguino1.posFotograma.X + GraphicsDevice.Viewport.Width / 2, -pinguino1.posFotograma.Y + 136 + GraphicsDevice.Viewport.Height / 2, 0));
            foreach (var elemento in elementos)
            {
                elemento.Animacion.Update(gameTime);
            }

            pinguino1.Update(gameTime, keyboardState);
            pinguino2.Update(gameTime, keyboardState);

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
            pinguino1.Draw(_spriteBatch);
            pinguino2.Draw(_spriteBatch);

            _spriteBatch.DrawString(colEnX, colEnXB, new Vector2(pinguino1.posFotograma.X, posFotograma.Y - 60), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }

}

/*
*/