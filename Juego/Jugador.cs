using Juego;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using static Juego.Game1;

namespace Juego
{
    internal class Jugador
    {

        public Vector2 posFotograma;
        public Rectangle pinguinoRect;
        public List<Elemento> elementos;
        public Elementos tipoElementos;
        public List<Animationes> animaciones;
        public Vector2 velocidadPinguino;
        public float gravedad;
        public int sueloY;
        public bool jugadorEnElSuelo;
        public bool entro,activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight;
        public Animation currentAnimation;
        public string message, salioRampa = "";
        public List<Keys> keys;
        public Jugador compa;


        public Jugador(Vector2 posicion, List<Elemento> elementos, List<Animationes> animationes, Vector2 velocidadPinguino, float gravedad, int sueloY, bool jugadorEnElSuelo, bool activarSalto, bool left, bool muroColIzq, bool muroColDer, bool hielo, bool platHielo, bool salto, bool hieloRight, List<Keys> keys)
        {
            this.posFotograma = posicion;

            this.elementos = elementos;
            this.animaciones = animationes;
            this.velocidadPinguino = velocidadPinguino;
            this.gravedad = gravedad;
            this.sueloY = sueloY;
            this.jugadorEnElSuelo = jugadorEnElSuelo;
            this.activarSalto = activarSalto;
            this.left = left;
            this.muroColDer = muroColDer;
            this.hielo = hielo;
            this.salto = salto;
            this.muroColIzq = muroColIzq;
            this.platHielo = platHielo;
            this.hieloRight = hieloRight;
            this.keys = keys;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            message = $" {salioRampa}, {entro},{velocidadPinguino}";
            hielo = false;
            hieloRight = false;
            salioRampa = "";
            hielo = false;
            hieloRight = false;
            gravedad = 0.25f;
            //pinPos = $"PinguinoX: {posFotograma.X} PinguinoY: {posFotograma.Y}";
            
            muroColDer = false;
            muroColIzq = false;
            pinguinoRect = new Rectangle((int)posFotograma.X, (int)posFotograma.Y, 54, 54);

            foreach (var muro in elementos.Where(e => e.Tipo == Elementos.Muro))
            {
                Rectangle muroRect = new Rectangle((int)muro.Posicion.X + 3, (int)muro.Posicion.Y, (int)muro.Width + 12, (int)muro.Height);

                if (IsColliding(pinguinoRect, muroRect))
                {
                    //colEnXB = $"Col en X| pinDer:{pinguinoRect.Right}| mureLeft:{muroRect.Left}";

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

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10 , (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;

                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > 0 && puntoBajoPin <= plataformaRect.Y)
                {
                    // message = "Col plat";
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

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width - 2, (int)plataforma.Height);

                int interFin = plataformaRect.X + 32;
                int interIni = plataformaRect.X;
                int pinguinoEnX = pinguinoRect.Right;
                int posPinXrespectoPlatX = pinguinoEnX - interIni;
                int noTomaRect = 32 - posPinXrespectoPlatX;
                int topTriParaX = plataformaRect.Y + noTomaRect;

                if (IsColliding(pinguinoRect, plataformaRect) && pinguinoRect.Y + 52.7 >= topTriParaX && velocidadPinguino.Y > -0.5)
                {

                    hielo = true;
                    salioRampa = "L";

                    //posFotograma.Y += (float)3;
                    gravedad = 0;
                    posFotograma.X -= (float)3.3;
                    posFotograma.Y += (float)4;
                    gravedad = 0.3f;
                    velocidadPinguino.Y = 0;


                    if (pinguinoRect.X <= plataformaRect.X && !platHielo && jugadorEnElSuelo)
                    {
                        //colEnXB = "Entro al if de x";
                        muroColDer = true;
                        posFotograma.X += (float)3.3;
                        posFotograma.Y -= (float)4;
                    }
                    break;
                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.PlataformaInclinadaDer))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width - 2, (int)plataforma.Height);
                int interFin = plataformaRect.X + 32;
                int interIni = plataformaRect.X;
                int pinguinoEnX = pinguinoRect.Left + 13;
                int posPinXrespectoPlatX = pinguinoEnX - interIni;
                int noTomaRect = 32 - posPinXrespectoPlatX;
                int topTriParaX = plataformaRect.Y + posPinXrespectoPlatX;
                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > -0.5 && pinguinoRect.Y + 52.7 >= topTriParaX)
                {

                    //colEnYB = $"IntFin: {interFin}\nIntIni: {interIni}\npinguinoEnX: {pinguinoEnX}\nposPinXrespetoPlatX:{posPinXrespectoPlatX}\nnoTomaRect:{noTomaRect}\ntopTriParaX: {topTriParaX}\nTope{pinguinoRect.Y + 52.7 >= topTriParaX}";
                    hieloRight = true;
                    salioRampa = "R";

                    //posFotograma.Y += (float)3;
                    gravedad = 0;
                    posFotograma.X += (float)3.3;
                    posFotograma.Y += (float)4;
                    gravedad = 0.3f;
                    velocidadPinguino.Y = 0;

                    if (pinguinoRect.X <= plataformaRect.X && !platHielo && jugadorEnElSuelo)
                    {
                        // colEnXB = "Entro al if de x";
                        muroColDer = true;
                        posFotograma.X -= (float)3.3;
                        posFotograma.Y -= (float)4;
                    }
                    break;
                }
            }



            if (keyboardState.IsKeyDown(keys[1]) && activarSalto && keyboardState.IsKeyDown(keys[2]) && jugadorEnElSuelo && posFotograma.X > -100 && !hielo)
            {

                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "verticalJump").GetAnimation;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 3;
                activarSalto = false;
            }
            else if (keyboardState.IsKeyDown(keys[1]) && activarSalto && keyboardState.IsKeyDown(keys[0]) && jugadorEnElSuelo && !hielo)
            {
                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "verticalJumpL").GetAnimation;
                velocidadPinguino.Y = -10.0f;
                posFotograma.X += 3;
                activarSalto = false;
            }
            else if (keyboardState.IsKeyDown(keys[2]) && !muroColDer && !hielo && !hieloRight)
            {
                left = false;

                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "caminarAnimation").GetAnimation;
                posFotograma.X += 3;

                if (keyboardState.IsKeyDown(keys[1]) && jugadorEnElSuelo)
                {
                    currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "verticalJump").GetAnimation;
                    velocidadPinguino.Y = -10.0f;
                }
            }
            else if (keyboardState.IsKeyDown(keys[0]) && !muroColIzq && !hielo && !hieloRight)
            {

                if (!keyboardState.IsKeyDown(keys[2]))
                {
                    left = true;
                    posFotograma.X -= 3;
                    currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "caminarAnimationL").GetAnimation;
                }

                if (keyboardState.IsKeyDown(keys[1]) && jugadorEnElSuelo)
                {

                    currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "verticalJumpL").GetAnimation;
                    velocidadPinguino.Y = -10.0f;
                }

            }
            else if (keyboardState.IsKeyDown(keys[1]) && jugadorEnElSuelo)
            {
                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == (!left ? "bend" : "bendL")).GetAnimation;
                activarSalto = true;
            }
            else if (keyboardState.IsKeyUp(keys[1]) && activarSalto && jugadorEnElSuelo)
            {
                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == (!left ? "verticalJump" : "verticalJumpL")).GetAnimation;
                velocidadPinguino.Y = -10.0f;
                activarSalto = false;
            }
            else if (hielo)
            {
                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "fallingLeft").GetAnimation;
            }
            else if (hieloRight)
            {
                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "fallingRight").GetAnimation;
            }
            else if (!activarSalto)
            {

                currentAnimation = animaciones.FirstOrDefault(a => a.nombre == (!left ? "waitAnimation" : "waitAnimationL")).GetAnimation;
            }

            //pinVelo = $"velocidadPin: {velocidadPinguino.Y}\nEsta en el suelo: {jugadorEnElSuelo}\nActivar salto: {activarSalto}\nColDer:{muroColDer}\nColIzq:{muroColIzq}";

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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch, posFotograma, Color.White, 1.1f);

        }

        private bool IsColliding(Rectangle pinguinoRect, Rectangle plataformaRect)
        {
            return pinguinoRect.Intersects(plataformaRect);
        }
    }
}
