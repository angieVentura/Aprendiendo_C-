using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Xml.Linq;
namespace MotorGraficoPinguino
{
    internal class Player
    {

        private const float SPEED = 750f;
        private const float GRAVITY = 5000f;
        private const float JUMP = 1500f;
        private const int SIZE_PINGUINO = 32;
        private const int OFFSET = 10;
        private Vector2 _velocity;
        private bool _onGround = true;
        private List<Animationes> _animationes;
        private Texture2D _pinguinoSprites;
        private Texture2D _collider;


        public Vector2 pos;
        public Rectangle pinguinoRect;
        public List<GameObject> elementos;
        public Animation currentAnimation;
        public List<Keys> keys;


        public Player(Vector2 posicion, List<GameObject> elementos, List<Keys> keys)
        {
            this.pos = posicion;

            this.elementos = elementos;
            this.keys = keys;
        }

        private Rectangle CalculateBounds(Vector2 pos)
        {
            return new((int)pos.X + OFFSET, (int)pos.Y, SIZE_PINGUINO - (2 * OFFSET), SIZE_PINGUINO);
        }

        private void UpdatePosition()
        {
            _onGround = false;
            var newPos = pos + (_velocity * Globals.Time);
            Rectangle newRect = CalculateBounds(newPos);

            foreach (var collider in GameObjects.GetNearestColliders(newRect))
            {
                if(newPos.X != pos.X)
                {
                    newRect = CalculateBounds(new(newPos.X, pos.Y));
                    if (newRect.Intersects(collider))
                    {
                        if (newPos.X > pos.X)
                        {
                            newPos.X = collider.Left - SIZE_PINGUINO + OFFSET;
                        }
                        else
                        {
                            newPos.X = collider.Right - OFFSET;
                        }

                        continue;
                    }
                }


                newRect = CalculateBounds(new(pos.X, newPos.Y));
                if (newRect.Intersects(collider))
                {
                    if (_velocity.Y > 0)
                    {
                        newPos.Y = collider.Top - SIZE_PINGUINO;
                        _onGround = true;
                        _velocity.Y = 0;
                    }
                    else
                    {
                        newPos.Y = collider.Bottom;
                        _velocity.Y = 0;
                    }
                }
            }

        }

        private void UpdateVelocity()
        {
            var keyboard = Keyboard.GetState();
            //aca agregar las animaciones despues
            //currentAnimation = animaciones.FirstOrDefault(a => a.nombre == (!left ? "waitAnimation" : "waitAnimationL")).GetAnimation;
            if (keyboard.IsKeyDown(Keys.A)) _velocity.X = -SPEED;
            else if (keyboard.IsKeyDown(Keys.D)) _velocity.X = SPEED;
            else _velocity.X = 0;

            if (!_onGround) _velocity.Y += GRAVITY * Globals.Time;

            if(keyboard.IsKeyDown(Keys.Space) && _onGround)
            {
                _velocity.Y = -JUMP;
                _onGround = false;
            }
        }

        public void LoadContent()
        {
            _collider = Globals.Content.Load<Texture2D>("White");
            _pinguinoSprites = Globals.Content.Load<Texture2D>("pinguinoD");
            _animationes = new List<Animationes> {

                // Animaciones de los pingüinos
                
                new Animationes("caminarAnimation", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, 0, false)),
                new Animationes("caminarAnimationL", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 6, 100, 0, 0, true)),
                new Animationes("waitAnimation", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, 0, false)),
                new Animationes("waitAnimationL", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 450, 6, 0, true)),
                new Animationes("jump", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, 2, false)),
                new Animationes("jumpL", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 8, 100, 8, 2, true)),
                new Animationes("verticalJump", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, 1, false)),
                new Animationes("verticalJumpL", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 5, 150, 2, 1, true)),
                new Animationes("bend", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, 1, false)),
                new Animationes("bendL", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 8, 1, true)),
                new Animationes("fallingLeft", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, 0, true)),
                new Animationes("fallingRight", new Animation(_pinguinoSprites, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 12, 0, false)),

                //test
                new Animationes("D", new Animation(_collider, SIZE_PINGUINO, SIZE_PINGUINO, 1, 1000, 0, 0, false)),

                 
            };
            currentAnimation = _animationes.FirstOrDefault(a => a.nombre == "D").GetAnimation;

        }

        public void Update(GameTime gameTime)
        {

            UpdateVelocity();
            UpdatePosition();
            //pos += _velocity * Globals.Time;

            currentAnimation.Update(gameTime);
        }

        public void Draw()
        {
            currentAnimation.Draw(Globals.Spritebatch, pos, Color.Black, 1f);
              
        }

        private bool IsColliding(Rectangle pinguinoRect, Rectangle plataformaRect)
        {
            return pinguinoRect.Intersects(plataformaRect);
        }
    }
}