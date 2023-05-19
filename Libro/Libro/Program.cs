using System;
using System.Linq;

namespace Libro
{

    /*
6) Crear una clase Libro que contenga los siguientes atributos:
– ISBN
– Título
– Autor
– Número de páginas
Crear sus respectivos métodos get y set correspondientes para cada atributo. 
Crear el método que muestre la información relativa al libro con el siguiente formato:
«El libro con ISBN creado por el autor tiene páginas»
En el fichero main, crear 2 objetos Libro (los valores que se quieran) y 
mostrarlos por pantalla.
Por último, indicar cuál de los 2 tiene más páginas.
*/
    class Libro
    {
        int ISBN;
        string titulo;
        string autor;
        int numPaginas;
        
        //get
        public int getISBN()
        {
            return this.ISBN;
        }

        public string getTitulo()
        {
            return this.titulo;
        }

        public int getNumPaginas()
        {
            return this.numPaginas;
        }

        public string getAutor()
        {
            return this.autor;
        }
        //set
        public void setISBN(int isbn)
        {
            this.ISBN = isbn;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void setNumPaginas(int numPaginas)
        {
            this.numPaginas = numPaginas;
        }

        public void setAutor(string autor)
        {
            this.autor = autor;
        }

        public string mostrar()
        {
            return $" El libro {this.titulo} con ISBN {this.ISBN} creado por el autor {this.autor} tiene {this.numPaginas} páginas.";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro[] libros = new Libro[2];

            libros[0] = new Libro();
            libros[0].setTitulo("El Punto");
            libros[0].setAutor("Peter Reynolds");
            libros[0].setISBN(13223423);
            libros[0].setNumPaginas(20);
            Console.WriteLine(libros[0].mostrar());

            libros[1] = new Libro();
            libros[1].setTitulo("La Biblia");
            libros[1].setAutor("Dios");
            libros[1].setISBN(13223423);
            libros[1].setNumPaginas(1890);
            Console.WriteLine(libros[1].mostrar());

            
            
            Console.ReadKey();
        }
    }

}
