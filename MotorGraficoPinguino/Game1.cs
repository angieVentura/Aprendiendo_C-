using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;

namespace MotorGraficoPinguino
{




    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D map, tiles, collider, pinguinoSprites;
        GameObjects gameObjects;
        Matrix viewMatrix;
        Vector3 camera;
        SpriteFont textureSize;
        List<Color> colorTiles;
        
        private const int SIZE_PINGUINO = 32;
        private GameManager _gameManager;
        



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            //this._graphics.PreferredBackBufferWidth = 800;
            //this._graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.Content = Content;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.Spritebatch = new SpriteBatch(GraphicsDevice);
            Globals.GraphicsDevice = GraphicsDevice;

            textureSize = Content.Load<SpriteFont>("arial");
            

            camera = new Vector3(0, 0, 0);



            _gameManager = new GameManager();


            _gameManager.LoadContent();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboardState = Keyboard.GetState();



            viewMatrix = Matrix.CreateTranslation(camera);
            //viewMatrix = Matrix.CreateTranslation(new Vector3(-pinguino1.posFotograma.X + GraphicsDevice.Viewport.Width / 2, -pinguino1.posFotograma.Y + 136 + GraphicsDevice.Viewport.Height / 2, 0));


            /*foreach (var gameObject in gameObjects.objects)
            {
                gameObject.animation.Update(gameTime);
            }*/

            // TODO: Add your update logic here
            Globals.Update(gameTime);

            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.Spritebatch.Begin();

            _gameManager.Draw();
            //_spriteBatch.DrawString(textureSize, gameObjects.tileSize, new Vector2(150, 0), Color.White);

            Globals.Spritebatch.End();
            base.Draw(gameTime);
        }
    }
}