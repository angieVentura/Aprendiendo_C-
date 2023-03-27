using System;
using System.Collections.Generic;

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

        public void bajar()
        {
            if (y < 10)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");

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
            TimeSpan tiempoTrasncurrido;

            //hecho por mi
            bool bajar;

            int final = 10;
            int maxAnc = 10;


            while (true)
            {
                int cont = 0;
                horaActual = DateTime.Now;
                tiempoTrasncurrido = horaActual - hora;
                if (tiempoTrasncurrido.Milliseconds >= 900)
                {

                    list.Add(new Copo(rand.Next(10), 0));
                    hora = DateTime.Now;

                    foreach (Copo copoLista in list)
                    {
                        if (copoLista.y == final)
                        {
                            cont++;
                        }

                        bajar = true;
                        foreach (Copo temp in list)
                        {
                            if ((temp.x == copoLista.x) && (temp.y == copoLista.y + 1))
                            {
                                bajar = false;
                                break;
                            }

                        }
                        if (bajar)
                        {
                            copoLista.bajar();
                            copoLista.mostrar();
                        }
                    }

                    if (cont == maxAnc)
                    {
                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            if (list[i].y == final)
                            {
                                list.RemoveAt(i);
                                for (int j = maxAnc; j >= 0; j-- )
                                {
                                    Console.SetCursorPosition(j, final);
                                    Console.Write(" ");
                                }
                               
                            }
                        }

                    }

                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("A");

                }
            }

            Console.ReadKey();
        }
    }

}