using System;
using System.Collections.Generic;

namespace listaDinamica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 10, 23123, 43, 34, 10, 34, 234, 2, 4 };
            Console.WriteLine("\nLista sin modificaciones");
            mostrar(list);
            // 1.Buscar los elementos que contengan el numero 10 e insertar antes el numero 0
            antesdeDiez(list);
            Console.WriteLine("\nAntes de 10");
            mostrar(list);

            //2.Buscar los elementos que contengan el numero 10 e insertar después el numero 0
            despuesDeDiez(list);
            Console.WriteLine("\nDespues de 10");           
            mostrar(list);
            
            //3.Buscar el elemento que contenga el numero 10 e insertar antes y después un 0
            antesYdespues10(list);
            Console.WriteLine("\nAntes y despues de 10");
            mostrar(list);

            //4.Eliminar en primer y el ultimo elemento

            elPrim(list);
            Console.WriteLine("\nElimino el primero y el ultimo");
            mostrar(list);

            //5.Eliminar en segundo y el ante ultimo elemento

            penUlt(list);
            Console.WriteLine("\nElimino el penultimo");
            mostrar(list);


            void antesdeDiez(List<int> lista)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == 10)
                    {
                        list.Insert(i, 0);
                    i++;
                    }
                }
            }

            void despuesDeDiez(List<int> lista)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (lista[i] == 10)
                    {
                        list.Insert(i+ 1, 0);
                        i++;
                    }
                }
            }

            void mostrar(List<int> lista)
            {
                foreach (int num in lista)
                {
                    Console.Write($"{num}, ");
                }
            }

            void antesYdespues10(List<int> lista)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == 10)
                    {
                        lista.Insert(i, 0);
                        i++;
                        lista.Insert(i+ 1, 0);
                        i++;
                    }
                }
            }

            void elPrim(List<int> lista)
            {
              
                    lista.RemoveAt(0);
                    lista.RemoveAt(list.Count - 1);
            }

            void penUlt(List<int> lista)
            {
                lista.RemoveAt(list.Count - 2);
            }

            Console.ReadLine();
        }
    }
}
