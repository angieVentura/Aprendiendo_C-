using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace Juego
{

    public class Elemento
    {
        public string Tipo { get; set; }
        public Vector2 Posicion { get; set; }
        public Vector2 Tamano { get; set; }
        public Animation Animacion { get; set; }

        public Elemento(string tipo, Vector2 posicion, Vector2 tamano, Animation animacion)
        {
            Tipo = tipo;
            Posicion = posicion;
            Tamano = tamano;
            Animacion = animacion;
        }
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;
        Texture2D piso, fondoC1, fondoC2, fondoC3, fondoC4, pinguinoSprites, pinguinoPrueba, FondoP;
        List<Elemento> elementos = new List<Elemento>();
        Vector2 posFotograma = new Vector2(5, 516);
        int cantPiso = 0;
        Vector2 velocidadPinguino = Vector2.Zero;
        float gravedad = 0.5f;
        int sueloY = 516;
        bool jugadorEnElSuelo = true;
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
        Animation caminarAnimationL;
        Animation pisoHielo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;
            IsMouseVisible = true;

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
            caminarAnimation = new Animation(pinguinoSprites, 144, 144, 6, 100, 0, false, 0);
            waitAnimation = new Animation(pinguinoSprites, 144, 144, 4, 1000, 3, false, 0);
            caminarAnimationL = new Animation(pinguinoSprites, 144, 144, 6, 100, 0, true, 0);
            pisoHielo = new Animation(piso, 16, 16, 1, 1, 16, false, 16);
            for (int i = 0; i < 25; i++)
            {
                elementos.Add(new Elemento("Plataforma", new Vector2(i * 32, 568), new Vector2(100, 20), pisoHielo));
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var elemento in elementos)
            {
                elemento.Animacion.Update(gameTime);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                currentAnimation = caminarAnimation;
                posFotograma.X += 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                currentPinguinoAnimation = PinguinoAnimation.Caminar;
                currentAnimation = caminarAnimationL;
                posFotograma.X -= 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && jugadorEnElSuelo)
            {
                velocidadPinguino.Y = -10.0f; // Valocidad con la que sube, luego quiero ajustarla
            }
            else
            {
                currentPinguinoAnimation = PinguinoAnimation.Wait;
                currentAnimation = waitAnimation;
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

    }
}