using System;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca
{
    class Libro
    {
        public string titulo;
        public bool disponible;

        public Libro(string titulo, bool disponible)
        {
            this.titulo = titulo;
            this.disponible = disponible;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> list = new List<Libro>();
            int op;
            bool estado;
            list.Add(new Libro("La Odisea", true));
            list.Add(new Libro("El Quijote", false));
            list.Add(new Libro("Cien Años de Soledad", true));
            string[] menu = { "[1]Buscar libro", "[2]Devolver Ejemplar de Libro", "[3]Pedir Libro", "[4]Salir" };
            Console.WriteLine("Biblioteca");
            for (int i = 0; i < menu.Count(); i++)
                Console.WriteLine($"{menu[i]}");

            estado = int.TryParse(Console.ReadLine(), out op);
            while (true)
            {
                switch (op)
                {
                    case 1:

                        Console.WriteLine("Ingrese titulo del libro a buscar");
                        string estadoL = "";
                        string titulo = Console.ReadLine();
                        Libro encontrado = list.Find(t => t.titulo.ToLower() == titulo.ToLower());
                        if (encontrado != null)
                        {
                            estadoL = encontrado.disponible == true ? "Disponible" : "Prestado";
                        }

                        Console.WriteLine(encontrado != null ? $"{encontrado.titulo}, {estadoL}" : "No se encontro el libro");
                        estado = int.TryParse(Console.ReadLine(), out op);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese titulo del ejemplar a devolver");
                        titulo = Console.ReadLine();
                        encontrado = list.Find(t => t.titulo.ToLower() == titulo.ToLower());
                        if (encontrado != null)
                        {
                            encontrado.disponible = true;
                        }
                        Console.WriteLine(encontrado != null ? "Libro devulto" : "No se encontro el libro");
                        estado = int.TryParse(Console.ReadLine(), out op);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese titulo del ejemplar a prestar");
                        titulo = Console.ReadLine();
                        encontrado = list.Find(t => t.titulo.ToLower() == titulo.ToLower());
                        if (encontrado != null)
                        {
                            encontrado.disponible = false;
                        }
                        Console.WriteLine(encontrado != null ? "Libro prestado" : "No se encontro el libro");
                        estado = int.TryParse(Console.ReadLine(), out op);
                        break;
                    case 4:

                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
