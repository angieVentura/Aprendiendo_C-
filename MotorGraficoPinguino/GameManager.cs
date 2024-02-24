using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace MotorGraficoPinguino
{

    internal class GameManager
    {
        private readonly GameObjects _gameObjects;
        private readonly Player _player;

        public GameManager() {
        
            _gameObjects = new GameObjects();
            _player = new Player(Globals.PosPlayer, _gameObjects.objects, Globals.KeysPinguino1);
        }

        public void LoadContent()
        {
            _gameObjects.LoadContent();
            _player.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public void Draw()
        {

            _gameObjects.Draw();
            _player.Draw();
        }
    }
}
