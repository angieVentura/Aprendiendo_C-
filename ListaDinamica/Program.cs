using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> lista = new List<int> { 5, 10, 15, 10, 20, 25, 30, 10, 35, 40, 10, 45, 50, 55, 10 };
        Console.WriteLine("Lista original:");
        mostrarLista(lista);

        antesDe10(lista);
        Console.WriteLine("\nLista después de insertar 0 antes de los elementos que contienen 10:");
        mostrarLista(lista);

        despuesDe10(lista);
        Console.WriteLine("\nLista después de insertar 0 después de los elementos que contienen 10:");
        mostrarLista(lista);

        antesYdespues(lista);
        Console.WriteLine("\nLista después de insertar 0 antes y después de los elementos que contienen 10:");
        mostrarLista(lista);

        primeroUltimo(lista);
        Console.WriteLine("\nLista después de eliminar el primer y último elemento:");
        mostrarLista(lista);

        segundoYpenultimo(lista);
        Console.WriteLine("\nLista después de eliminar el segundo y anteúltimo elemento:");
        mostrarLista(lista);

        Console.ReadLine();
    }

    public static void antesDe10(List<int> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == 10)
            {
                lista.Insert(i, 0);
                i++;
            }
        }
    }

    public static void despuesDe10(List<int> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == 10)
            {
                lista.Insert(i + 1, 0);
                i++;
            }
        }
    }

    public static void antesYdespues(List<int> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == 10)
            {
                lista.Insert(i, 0);
                lista.Insert(i + 2, 0);
                i += 2;
            }
        }
    }

    public static void primeroUltimo(List<int> lista)
    {
        lista.RemoveAt(0);
        lista.RemoveAt(lista.Count - 1);
    }

    public static void segundoYpenultimo(List<int> lista)
    {
        lista.RemoveAt(1);
        lista.RemoveAt(lista.Count - 2);
    }

    public static void mostrarLista(List<int> lista)
    {
        foreach (int elemento in lista)
        {
            Console.Write("{0} ", elemento);
        }
    }
}
