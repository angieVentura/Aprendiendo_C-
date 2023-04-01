using System;
using System.Collections.Generic;

namespace personasDNI
{
    class Persona
    {
        public string name;
        public string dni;

        //Constructor por defaul - Mismo nombre que la clase
        public Persona()
        {
        }

        //Segundo constructor - Mismo nombre que la clase
        public Persona(string name, string dni)
        {
            this.name = name;
            this.dni = dni;
        }
        //Mas de un constructor = sobrecarga de constructores

        //Metodo para mostrar los datos del objeto
        public string mostrarTodo()
        {
            return name + ", " + dni;
        }

        static public string buscar(string dni, List<Persona> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].dni == dni)
                {
                    return list[i].name;
                }
            }

            return null;


        }

        static public string borrar(string dni, List<Persona> list)
        {

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].dni == dni)
                {
                    list.RemoveAt(i);
                    return list[i].name;
                }


            }
            return null;

        }

    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<Persona> list = new List<Persona>();
            Persona persona1;

            list.Add(new Persona("Sergio", "12.345.678"));
            list.Add(new Persona("Pablo", "87.654.321"));
            list.Add(new Persona("Florencia", "12.435.678"));


            int op;
            Console.WriteLine("Ingrese un 1 para buscar una persona por DNI.");
            Console.WriteLine("Ingrese un 2 para eliminar a una persona.");

            op = Convert.ToInt16(Console.ReadLine());

            switch (op)
            {
                case 1:
                    //buscar por dni
                    Console.Write("Ingrese un DNI: ");
                    string dni = Console.ReadLine();

                    string encontrao = Persona.buscar(dni, list);

                    if (encontrao == null)
                    {
                        Console.WriteLine("No se encontro");
                        Console.WriteLine(encontrao);
                    }
                    else
                    {
                        Console.WriteLine("Se encontro");
                        Console.WriteLine(encontrao);
                    }
                    break;
                case 2:
                    Console.Write("Ingrese un DNI: ");
                    dni = Console.ReadLine();

                    string encontrau = Persona.buscar(dni, list);
                    if (encontrau == null)
                    {
                        Console.WriteLine("La persona que quiere borrar no existe");

                    }
                    else
                    {
                        Console.WriteLine(encontrau + " fue borrado");
                    }
                    break;

            }

            Console.ReadKey();

        }
    }
}