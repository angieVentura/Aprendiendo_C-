using Juego;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
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
        public float sueloY;
        public float maxDer, maxIzq = 0;
        public bool jugadorEnElSuelo;
        public bool entro, activarSalto, left, muroColIzq, muroColDer, hielo, platHielo, salto, hieloRight, desactivarV;
        public bool topeLeft, topeRight = false;
        public Animation currentAnimation;
        public string message, salioRampa = "";
        public List<Keys> keys;
        public Vector2 posCompa;
        private const float maxDist = 100;
        public float posMedia, disMitadPin1X, disMitadPin2X;
        KeyboardState tecladoAnterior;
        Keys ultimaTeclaPresionada;


        public Jugador(Vector2 posicion, List<Elemento> elementos, List<Animationes> animationes, Vector2 velocidadPinguino, float gravedad, int sueloY, bool jugadorEnElSuelo, bool activarSalto, bool left, bool muroColIzq, bool muroColDer, bool hielo, bool platHielo, bool salto, bool hieloRight, List<Keys> keys, Vector2 compa)
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
            this.posCompa = compa;
        }



        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {

            hielo = false;
            hieloRight = false;
            salioRampa = "";
            hielo = false;
            hieloRight = false;
            gravedad = 0.25f;
            muroColDer = false;
            muroColIzq = false;
            pinguinoRect = new Rectangle((int)posFotograma.X, (int)posFotograma.Y, 54, 54);
            //gravedad = 0.3f;
            disMitadPin1X = posFotograma.X;
            disMitadPin2X = posCompa.X;

            desactivarV = false;

            float distMediaX = disMitadPin1X - disMitadPin2X;

            if (distMediaX < 0) distMediaX *= -1;

            posMedia = distMediaX == 0 ? 0 : (posFotograma.X > posCompa.X ? disMitadPin1X - (distMediaX / 2) : disMitadPin1X + (distMediaX / 2));

            maxIzq = disMitadPin2X - 50;
            maxDer = disMitadPin2X + 50;

            //message = $"yo: {disMitadPin1X}\nEl: {disMitadPin2X}\n{distMediaX}\n{distMediaX / 2}\nMaxDer:{maxDer}\nMaxIzq:{maxIzq}\n{posMedia}\nLeft: {topeLeft}\nRigth: {topeRight}";
            message = $"";
            KeyboardState tecladoActual = Keyboard.GetState();
            tecladoAnterior = tecladoActual;
            tecladoActual = Keyboard.GetState();

            if (tecladoActual.GetPressedKeys().Length > 0) ultimaTeclaPresionada = tecladoActual.GetPressedKeys()[0];



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

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.Rampa))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                int interFin = plataformaRect.X + 32;
                int interIni = plataformaRect.X;
                int pinguinoEnX = pinguinoRect.Right;
                int posPinXrespectoPlatX = pinguinoEnX - interIni + 1;

                int noTomaRect = 32 - (posPinXrespectoPlatX >= 32 ? 32 : posPinXrespectoPlatX);
                int topTriParaX = plataformaRect.Y  + noTomaRect;
                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > 0 && puntoBajoPin <= topTriParaX)
                {

                    platHielo = false;
                    posFotograma.Y = topTriParaX - 53;
                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;
                    message += $"\nposY:{posFotograma.Y}\npuntoBajo{puntoBajoPin}\npinResX:{posPinXrespectoPlatX}\nnoTomaRect:{noTomaRect}\nnewY{topTriParaX}";
                    break;

                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.Plataforma ))
            { 

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
           
                if (IsColliding(pinguinoRect, plataformaRect) )
                {
                    if (velocidadPinguino.Y > 0 && puntoBajoPin <= plataformaRect.Y && plataforma.Tipo == Elementos.Plataforma)
                    {
                        platHielo = false;
                        posFotograma.Y = plataformaRect.Y - 53;
                        jugadorEnElSuelo = true;
                        velocidadPinguino.Y = 0;
                    } 


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
                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                int interFin = plataformaRect.X + 32;
                int interIni = plataformaRect.X;
                int pinguinoEnX = pinguinoRect.Right;
                int posPinXrespectoPlatX = pinguinoEnX - interIni - 9;

                int noTomaRect = 32 - (posPinXrespectoPlatX >= 32 ? 32 : posPinXrespectoPlatX);
                int topTriParaX = plataformaRect.Y + noTomaRect;
                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > 0 && puntoBajoPin <= topTriParaX)
                {

                    salioRampa = "L";
                    hielo = true;
                    posFotograma.Y = topTriParaX - 53;
                    gravedad = (float)0.1;
                    if (posFotograma.X >= maxIzq) posFotograma.X -= 3;
                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;
                    message += $"\nposY:{posFotograma.Y}\npuntoBajo{puntoBajoPin}\npinResX:{posPinXrespectoPlatX}\nnoTomaRect:{noTomaRect}\nnewY{topTriParaX}\ntop{plataformaRect.Top}";
                    break;

                }
            }

            foreach (var plataforma in elementos.Where(e => e.Tipo == Elementos.PlataformaInclinadaDer))
            {

                Rectangle plataformaRect = new Rectangle((int)plataforma.Posicion.X + 10, (int)plataforma.Posicion.Y, (int)plataforma.Width, (int)plataforma.Height);
                float puntoBajoPin = (int)posFotograma.Y + 40;
                int interFin = plataformaRect.Right;
                int interIni = plataformaRect.X;
                int pinguinoEnX = pinguinoRect.Left;
                int posPinXrespectoPlatX = interFin - pinguinoEnX - 12;
                int noTomaRect = 32 - (posPinXrespectoPlatX >= 32 ? 32 : posPinXrespectoPlatX);
                int topTriParaX = plataformaRect.Y + noTomaRect;
                
                if (IsColliding(pinguinoRect, plataformaRect) && velocidadPinguino.Y > -0.5 && puntoBajoPin <= topTriParaX)
                {
                    hieloRight = true;
                    salioRampa = "R";
                    posFotograma.Y = topTriParaX - 53;
                    gravedad = (float)0.1;
                    if (posFotograma.X <= maxDer) posFotograma.X += (float)3;
                    jugadorEnElSuelo = true;
                    velocidadPinguino.Y = 0;
                    message += $"\nposY:{posFotograma.Y}\npuntoBajo{puntoBajoPin}\npinResX:{posPinXrespectoPlatX}\nnewY{topTriParaX}\ntop{plataformaRect.Top}\nplatLeft{plataformaRect.Right}\npinX{pinguinoEnX}\nfin{interFin}";
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

            

                if (posFotograma.X + 3 == maxDer)
                {
                    posFotograma.X += 3;

                }
                else if (posFotograma.X + 2 == maxDer)
                {
                    posFotograma.X += 2;

                }
                else if (posFotograma.X + 1 == maxDer)
                {
                    posFotograma.X += 1;

                }
                else if (posFotograma.X == maxDer)
                {
                    posFotograma.X += 0;
                }
                else if(posFotograma.X < maxDer)
                {
                    posFotograma.X += (float)3;
                }

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

                    if (posFotograma.X - 3 == maxIzq)
                    {
                        posFotograma.X -= 3;

                    }
                    else if (posFotograma.X - 2 == maxIzq)
                    {
                        posFotograma.X -= 2;

                    }
                    else if (posFotograma.X - 1 == maxIzq)
                    {
                        posFotograma.X -= 1;

                    }
                    else if (posFotograma.X == maxIzq)
                    {
                        posFotograma.X -= 0;

                    }
                    else if (posFotograma.X > maxIzq)
                    {
                        posFotograma.X -= (float)3;

                    }

                    currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "caminarAnimationL").GetAnimation;
                }

                if (keyboardState.IsKeyDown(keys[1]) && jugadorEnElSuelo)
                {

                    currentAnimation = animaciones.FirstOrDefault(a => a.nombre == "verticalJumpL").GetAnimation;
                    velocidadPinguino.Y = -10.0f;
                }

            }
            else if (keyboardState.IsKeyDown(keys[1]) && jugadorEnElSuelo && !hielo && !hieloRight)
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
