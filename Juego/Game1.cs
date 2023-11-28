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
        Transparente,
        Rampa,
        PlataformaPiedra,
        Buttons,
        Menu,
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private const int SIZE_PINGUINO = 48;
        const int SIZE_TILE = 16;

        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, decoracion, menu, buttons;
        List<Elemento> elementos = new List<Elemento>();
        List<Elemento> elementosCamera = new List<Elemento>();
        List<Elemento> elementosCameraMenu = new List<Elemento>();

        static Vector2 posFotograma = new Vector2(5, 435);
        static Vector2 posFotograma2 = new Vector2(5, 435);
        string pinPos, pinRect, pinVelo, colEnXB, colEnYB = "";
        float medioTop, medioBottom, medioRigth, medioLeft = 0;
        Vector2 velocidadPinguino = Vector2.Zero;
        float gravedad = 0.25f;
        int sueloY = 535;
        bool jugadorEnElSuelo = true;
        bool showMenu = true;
        bool activarSalto, left, bajando, muroColIzq, muroColDer, hielo, NO_PASAR, platHielo, salto, hieloRight, actSaltoCompa = false;

        public enum PinguinoAnimation
        {
            Caminar,
            Jump,
            VerticalJump,
            Bend,
            Wait
        }

        SpriteFont colEnX, colEnY;
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

        List<Animation> animacion;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = false;
            IsMouseVisible = true;
        }

        public float distMax = 20;

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
            menu = Content.Load<Texture2D>("Inicio");
            buttons = Content.Load<Texture2D>("Buttons");
            //Pinguino1
            animacion = new List<Animation> {
                // Animaciones de los pingüinos
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, false, 0, "caminarAnimation"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, true, 0, "caminarAnimationL"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, false, 0, "waitAnimation"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, true, 0,"waitAnimationL"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, false, 2, "jump"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, true, 2, "jumpL"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, false, 1, "verticalJump"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, true, 1, "verticalJumpL"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, false, 1, "bend"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, true, 1, "bendL"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, true, 0, "fallingLeft"),
                new Animation (pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, false, 0, "fallingRight"),

                // Animaciones de la escena
               new Animation(piso, 16, 16, 1, 1, 16, false, 1, "pisoHielo"),
              new Animation(piso, 16, 16, 1, 1, 14, false, 0, "pisoLateralIzqSinNieve"),
             new Animation(piso, 16, 16, 1, 1, 16, false, 10, "rampaNieve"),
                 new Animation(piso, 16, 16, 1, 1, 14, false, 2, "pisoLateralDerSinNieve"),
                new Animation(piso, 16, 16, 1, 1, 13, false, 0, "pisoEsqSupIzqNieve"),
             new Animation(piso, 16, 16, 1, 1, 13, false, 2, "pisoEsqSupDerNieve"),
               new Animation(piso, 16, 16, 1, 1, 14, false, 1,"pisoMedio"),
                new Animation(piso, 16, 16, 1, 1, 13, false, 1, "pisoBordeSupHielo"),
                 new Animation(decoracion, 42 + 20, 8, 1, 1000, 0, false, 0, "plataformaPiedra"),
                new Animation (piso, 16, 16, 1, 1, 26, false, 1, "hieloEsqIzq"),
              new Animation(piso, 16, 16, 1, 1, 26, false, 2, "hieloEsqDer"),
                new Animation(piso, 16, 16, 1, 1, 26, false, 1, "hieloBordeSup"),
                new Animation(piso, 16, 16, 1, 1, 27, false, 1, "hieloMedio"),
                new Animation (piso, 16, 16, 1, 1, 26, false, 5, "hieloMedioDer"),
                new Animation (piso, 16, 16, 1, 1, 26, false, 4, "hieloMedioIzq"),
                new Animation (piso, 16, 16, 1, 1, 26, false, 5, "EsqLateralIzqHieloNieve"),
                new Animation(piso,16, 16, 1, 1000, 15, false, 6, "transparente"),

                //Menu
             new Animation(menu, 1200, 900, 1, 10000, 0, false, 0, "menuPortada"),
                new Animation (buttons, 112, 48, 1, 10000, 0, false, 0, "menuPlay"),
                new Animation (buttons, 112, 48, 1, 10000, 0, false, 1, "menuSelectedPlay"),
                new Animation (buttons, 112, 48, 1, 10000, 2, false, 0, "menuExit"),
               new Animation(buttons, 112, 48, 2, 10000, 6, false, 1, "menuSelectedExit"),
                new Animation (buttons, 112, 48, 1, 10000, 6, false, 0, "menuOpciones"),
                new Animation (buttons, 112, 48, 1, 10000, 6, false, 1, "menuSelectedOpciones"),


            };

            elementos.Add(new Elemento(Elementos.Menu, new Vector2(C(0), Cy(0)), 1200, 900, animacion.FirstOrDefault(a => a.nombre == "menuPortada")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(1)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuPlay")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(3)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuSelectedPlay")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(5)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuExit")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(7)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuSelectedExit")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(9)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuOpciones")));
            elementos.Add(new Elemento(Elementos.Buttons, new Vector2(C(1), Cy(11)), 112, 48, animacion.FirstOrDefault(a => a.nombre == "menuSelectedOpciones")));

            //Carga de elementos Piso por defecto y Bloques de piso
            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(i * C(1), Cy(15)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(18)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(19)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(20)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(21)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(22)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(22)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(23)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(i * C(1), Cy(24)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
            }
            elementos.Add(new Elemento(Elementos.Rampa, new Vector2(C(10), Cy(14)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "rampaNieve")));


            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(25 + i), Cy(18)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(19)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(20)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(21)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(22)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(23)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
                elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(25 + i), Cy(24)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
            }


            //Hieloo
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(28), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloEsqIzq")));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaIzq, new Vector2(C(29), Cy(15)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloEsqIzq")));

            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(32), Cy(15)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloEsqDer")));
            elementos.Add(new Elemento(Elementos.PlataformaInclinadaDer, new Vector2(C(33), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloEsqDer")));

            //elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloMedioIzq") ));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(32), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloMedioDer")));

            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(30), Cy(15)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloBordeSup")));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoHielo")));
            elementos.Add(new Elemento(Elementos.PlataformaHieloSup, new Vector2(C(31), Cy(15)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "hieloBordeSup")));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(31), Cy(16)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoHielo")));

            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(28), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "EsqLateralIzqHieloNieve")));
            //elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(29), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio") ));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(30), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(31), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(32), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio")));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(33), Cy(17)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoLateralDerSinNieve")));

            //Esto es un bloque tipo |-|
            /*elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(7), Cy(14)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoLateralIzqSinNieve") ));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(7), Cy(13)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoEsqSupIzqNieve") ));
            elementos.Add(new Elemento(Elementos.Decoracion, new Vector2(C(8), Cy(14)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoMedio") ));
            elementos.Add(new Elemento(Elementos.Muro, new Vector2(C(9), Cy(14)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoLateralDerSinNieve") ));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(9), Cy(13)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoEsqSupDerNieve") ));
            elementos.Add(new Elemento(Elementos.Plataforma, new Vector2(C(8), Cy(13)), SIZE_TILE, SIZE_TILE, animacion.FirstOrDefault(a => a.nombre == "pisoBordeSupHielo") ));
            */

            //Plataforma piedra
            elementos.Add(new Elemento(Elementos.PlataformaPiedra, new Vector2(C(12), Cy(10)), 8, 48, animacion.FirstOrDefault(a => a.nombre == "plataformaPiedra")));

            colEnX = Content.Load<SpriteFont>("arial");
            colEnY = Content.Load<SpriteFont>("arial");

            muroColDer = false;
            muroColIzq = false;

            pinguino1 = new Jugador(posFotograma, elementos, animacion, velocidadPinguino, gravedad, sueloY, jugadorEnElSuelo, activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight, keysPinguino1, posFotograma2);
            pinguino2 = new Jugador(posFotograma2, elementos, animacion, velocidadPinguino, gravedad, sueloY, jugadorEnElSuelo, activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight, keysPinguino2, posFotograma);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector3 camera = new Vector3(
                  0,
                  0,
                  0);
            viewMatrix = Matrix.CreateTranslation(camera);

            pinguino1.message += $"menu:{showMenu}";
            
            elementosCameraMenu = elementos.Where(e => e.Animacion.nombre.Contains("menu")).ToList();

            elementosCamera = elementos.Where(e => e.Posicion.Y < medioBottom && e.Posicion.Y > medioTop && e.Posicion.X > medioLeft && e.Posicion.X < medioRigth && !e.Animacion.nombre.Contains("menu")).ToList();

            foreach (var elemento in !showMenu ? elementosCamera : elementosCameraMenu)
            {
                elemento.Animacion.Update(gameTime);
            }
            if (!showMenu)
            {

                KeyboardState keyboardState = Keyboard.GetState();

                colEnXB = pinguino1.message;
                colEnYB = pinguino2.message;

                camera = new Vector3(
                    -pinguino1.posMedia == 0 ? -pinguino1.posFotograma.X + 367 : -pinguino1.posMedia + 370,
                    -pinguino1.posMediaY == 0 ? -pinguino1.posFotograma.Y + 267 : -pinguino1.posMediaY + 270,
                    0);

                viewMatrix = Matrix.CreateTranslation(camera);

                medioTop = pinguino1.posMediaY == 0 ? pinguino1.posFotograma.Y - 350 : pinguino1.posMediaY - 350;
                medioBottom = pinguino1.posMediaY == 0 ? pinguino1.posFotograma.Y + 350 : pinguino1.posMediaY + 350;
                medioRigth = pinguino1.posMedia == 0 ? pinguino1.posFotograma.X + 450 : pinguino1.posMedia + 450;
                medioLeft = pinguino1.posMedia == 0 ? pinguino1.posFotograma.X - 450 : pinguino1.posMedia - 450;

               



                pinguino1.elementos = elementosCamera;
                pinguino2.elementos = elementosCamera;



                pinguino1.posCompa = pinguino2.posFotograma;
                pinguino2.posCompa = pinguino1.posFotograma;
                pinguino1.compaSuelo = pinguino2.suelo;
                pinguino2.compaSuelo = pinguino1.suelo;
                pinguino1.platPiedraCompa = pinguino2.platPiedra;
                pinguino2.platPiedraCompa = pinguino1.platPiedra;
                pinguino1.cameraCompaX = pinguino2.cameraX;
                pinguino2.cameraCompaX = pinguino1.cameraX;
                pinguino1.cameraCompaY = pinguino2.cameraY;
                pinguino2.cameraCompaY = pinguino1.cameraY;
                pinguino1.compaBajo = pinguino2.bajo;
                pinguino2.compaBajo = pinguino1.bajo;
                pinguino1.colCompa = pinguino2.col;
                pinguino2.colCompa = pinguino1.col;


                pinguino1.Update(gameTime, keyboardState);
                pinguino2.Update(gameTime, keyboardState);
            }


            /*colEnXB += $"\nmediaX: {pinguino1.posMedia}" +
                   $"\nmediaY{pinguino1.posMediaY}" +
                   $"\nposX{pinguino1.posFotograma.X}" +
                   $"\npo2X{pinguino2.posFotograma.X}" +
                   $"\nPosY: {pinguino1.posFotograma.Y}" +
                   $"\nPo2Y: {pinguino2.posFotograma.Y}" +
                   $"\ncameraX:{pinguino1.cameraX}" +
                   $"\ncompaaX:{pinguino1.cameraCompaX}" +
                   $"\ncameraY:{pinguino1.cameraY}" +
                   $"\ncompaaY:{pinguino1.cameraCompaY}" +
                   $"\n2cameraX:{pinguino2.cameraX}" +
                   $"\n2compaaX:{pinguino2.cameraCompaX}" +
                   $"\n2cameraY:{pinguino2.cameraY}" +
                   $"\n2compaaY:{pinguino2.cameraCompaY}";

            colEnYB += $"\n{pinguino2.posMediaY}\nElem:{elementos.Count()}\nEleCam:{elementosCamera.Count()}\nmT:{medioTop}\nmB{medioBottom}\nmL{medioLeft}\nmR{medioRigth}";
            */


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
          
            if (!showMenu)
            {
                //Fondo
                Rectangle fondoRec = new Rectangle(0, 0, 380, 225);
                _spriteBatch.Draw(fondoC1, new Vector2(0, -500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
                _spriteBatch.Draw(fondoC2, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
                _spriteBatch.Draw(fondoC3, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);
                _spriteBatch.Draw(fondoC4, new Vector2(0, 124 - 500), fondoRec, Color.White, 0f, Vector2.Zero, escalaFondoMontaña, SpriteEffects.None, 0f);

                //Elemento de la matriz 

                //Personajes
                pinguino1.Draw(_spriteBatch);
                pinguino2.Draw(_spriteBatch);

              
            }
            else
            {
               /* Rectangle Menu = new Rectangle(0, 0, 1200, 900);
                Rectangle Buttons = new Rectangle(0, 0, 112, 48);
                _spriteBatch.Draw(menu, new Vector2(0, 0), Menu, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0f);
                _spriteBatch.Draw(buttons, new Vector2(0, 200), Buttons, Color.White, 0f, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0f);*/
            }

            foreach (var elemento in !showMenu ? elementosCamera : elementosCameraMenu)
            {
                elemento.Animacion.Draw(_spriteBatch, elemento.Posicion, Color.White, 2.0f);
            }

            _spriteBatch.DrawString(colEnX, colEnXB, new Vector2(pinguino1.posFotograma.X - 100, pinguino1.posFotograma.Y + 100), Color.White);
            _spriteBatch.DrawString(colEnY, colEnYB, new Vector2(pinguino2.posFotograma.X, pinguino2.posFotograma.Y + 100), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }

}
