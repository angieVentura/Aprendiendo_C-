using System;
using System.Collections.Generic;
using System.Linq;

namespace Libro
{
    class Libro
    {
        private int _numPaginas;
        private string _ISBN, _titulo, _autor;

        public int NumPaginas
        {
            get { return _numPaginas; }
            set { _numPaginas = value; }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Mostrar()
        {
            return $"El libro {_titulo} con ISBN {_ISBN} creado por el autor {_autor} tiene {_numPaginas} páginas.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>
            {
                new Libro { ISBN = "978-0132350884", Titulo = "Clean Code: A Handbook of Agile Software Craftsmanship", Autor = "Robert C. Martin", NumPaginas = 464 },
                new Libro { ISBN = "978-0201485677", Titulo = "Refactoring: Improving the Design of Existing Code", Autor = "Martin Fowler", NumPaginas = 455 }/*,
                new Libro { ISBN = "978-0101010101", Titulo = "3", Autor = "A", NumPaginas = 464 }*/
            };

            foreach (Libro libro in libros)
                Console.WriteLine($"\n{libro.Mostrar()}");

            var libroConMasPaginas = libros.OrderByDescending(l => l.NumPaginas).First();

            Console.WriteLine(
                libros.Count(l => l.NumPaginas == libroConMasPaginas.NumPaginas) > 1
                ? $"\nLos libros con más páginas son:" +
                  $"\n{string.Join("\n", libros.Where(l => l.NumPaginas == libroConMasPaginas.NumPaginas).Select(l => l.Titulo))}"
                : $"\nEl libro con más páginas es: {libroConMasPaginas.Titulo}"
            );
            Console.ReadKey();
        }
    }
}
