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
            Console.Write(y);
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
                Console.Write(y);
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

            int borraos = 0;    

            while (true)
            {
                horaActual = DateTime.Now;
                tiempoTrasncurrido = horaActual - hora;
                if (tiempoTrasncurrido.Milliseconds >= 900)
                {

                    list.Add(new Copo(rand.Next(9), 0));
                    hora = DateTime.Now;

                    foreach (Copo copoLista in list)
                    {
                        copoLista.bajar(list);
                        copoLista.mostrar();
                    }

                    int sePaso = 0;

                    for (int i = 9; i > 0; i--)
                    {
                        int cont = 0;

                        foreach (Copo copitos in list)
                        {
                            if (copitos.y == i)
                            {
                                cont++;

                                if (cont == 9)
                                {
                                    borraos++;
                                    sePaso = i;
                                    Console.WriteLine("");
                                    Console.SetCursorPosition(0, 10);
                                    Console.WriteLine("Fila eliminada: " + sePaso);
                                    Console.SetCursorPosition(0, 11);
                                    Console.WriteLine("cant filas borradas: " + borraos);

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