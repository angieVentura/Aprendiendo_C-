using System;
using System.Collections.Generic;
using System.Linq;

namespace Copitos
{
    class Copo
    {
        public int x, y;

        public Copo(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void mostrar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }

        public void bajar(List<Copo> list)
        {
            if (y < 10)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");

                if (list.Any(c => c.x == x && c.y == y + 1)) return;

                y++;

                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Copo> list = new List<Copo>();
            Random rand = new Random();
            DateTime hora = DateTime.Now;
            DateTime horaActual = DateTime.Now;
            Console.CursorVisible = false;
            int limiteY = 10;
            int limiteX = 10;

            while (true)
            {
                int completaX = 0;
                horaActual = DateTime.Now;
                if ((horaActual - hora).Milliseconds >= 300)
                {
                    list.Add(new Copo(rand.Next(10), 0));
                    hora = DateTime.Now;

                    foreach (Copo copoLista in list)
                    {
                        completaX += (copoLista.y == limiteY) ? 1 : 0;
                        copoLista.bajar(list);
                        copoLista.mostrar();
                    }

                    if (completaX == limiteX)
                    {
                        list.RemoveAll(c => c.y == limiteY);
                        Console.SetCursorPosition(0, limiteY);
                        Console.Write("".PadLeft(limiteX));
                    }
                }
            }
            Console.ReadKey();
        }
    }
}