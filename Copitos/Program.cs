using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (y < 9)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");

                // Verificar si hay otro copo en la posición debajo
                foreach (Copo temp in list)
                {
                    if (temp.x == x && temp.y == y + 1)
                    {
                        return; // No bajar
                    }
                }
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
            /*
                        list.Add(new Copo(0, 0));
                        list.Add(new Copo(1, 0));
                        list.Add(new Copo(2, 0));
                        list.Add(new Copo(3, 0));
                        list.Add(new Copo(0, 1));
                        list.Add(new Copo(1, 1));
                        list.Add(new Copo(2, 1));
                        list.Add(new Copo(3, 1));
                        list.Add(new Copo(4, 1));
                        list.Add(new Copo(5, 1));
                        list.Add(new Copo(6, 1));
                        list.Add(new Copo(7, 1));
                        list.Add(new Copo(8, 1));
                        list.Add(new Copo(9, 1));


                        int sePaso = 0;

                        for(int i = 10;i > -1; i--)
                        {
                            int cont = 0;

                            foreach (Copo copitos in list)
                            {
                                if (copitos.y == i)
                                {
                                    cont++;

                                    if (cont == 9)
                                    {
                                        sePaso = i;

                                        Console.WriteLine(sePaso);
                                        list.RemoveAll(c => c.y == sePaso);

                                        break;
                                    }
                                }

                            }
                        }

                        foreach(Copo copitos in list)
                        {
                            Console.WriteLine($"x: {copitos.x}, y: {copitos.y}");
                        }
            */

            //int coposEnY = list.Count(c => c.y == list.Last().y);

            //    Console.WriteLine(sePaso); 

            /*  if ( == 9)
              {
                  list.RemoveAll(c => c.y == sePaso);
              }

              // coposEnY = list.Count(c => c.y == list.Last().y);


              for (int i = 10; i > -1; i--)
              {
                  int cont = 0;

                  foreach (Copo copitos in list)
                  {
                      if (copitos.y == i)
                      {
                          cont++;

                          if (cont == 9)
                          {
                              sePaso = i;
                              break;
                          }
                      }

                  }
              }

              Console.WriteLine(sePaso); //0
            */


            //hecho por mi
            while (true)
            {
                horaActual = DateTime.Now;
                tiempoTrasncurrido = horaActual - hora;
                if (tiempoTrasncurrido.Milliseconds == 300)
                {

                    

                    list.Add(new Copo(rand.Next(9), 0));
                    hora = DateTime.Now;



                    foreach (Copo copoLista in list)
                    {
                        copoLista.bajar(list);
                        copoLista.mostrar();
                    }

                    int sePaso = 0;

                    for (int i = 10; i > -1; i--)
                    {
                        int cont = 0;

                        foreach (Copo copitos in list)
                        {
                            if (copitos.y == i)
                            {
                                cont++;

                                if (cont == 9)
                                {
                                    sePaso = i;
                                    Console.WriteLine("");
                                    Console.SetCursorPosition(0, 10);
                                    Console.WriteLine("Fila eliminada: " + sePaso);
                                    list.RemoveAll(c => c.y == sePaso);

                                    break;
                                }
                            }

                        }
                    }
                }
            }
           
            Console.ReadKey();
        }
    }

}