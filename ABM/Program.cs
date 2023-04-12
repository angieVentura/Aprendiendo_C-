using System;
using System.Collections.Generic;
using System.Linq;

namespace ABM
{
    /*Supongamos que se desea crear un programa para manejar una lista de contactos. Cada contacto debe tener un nombre, un número de teléfono 
      y una dirección de correo electrónico. El programa debe permitir al usuario agregar nuevos contactos, eliminar contactos existentes y 
      modificar la información de los contactos.*/

    /*1. Método buscar por DNI y que devuelva verdadero o falso
      2. Método buscar por DNI y que devuelva un objeto Persona en caso de que lo haya encontrado y en caso contrario que devuelva null.
      3. Método eliminar que reciba como parámetro un DNI
      4. Método */
    class Persona
    {
        public string name;
        public string DNI;

        public Persona(string name, string DNI)
        {
            this.name = name;
            this.DNI = DNI;
        }

        public string mostrar()
        {
            return $"{name}, {DNI}";
        }

        static public bool buscarBool(string buscar, List<Persona> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DNI == buscar)
                {
                    return true;
                }
            }
            return false;
        }

        static public string buscarObjeto(string buscar, List<Persona> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DNI == buscar)
                {
                    return list[i].mostrar();
                }

            }
            return null;

        }

        static public string eliminar(string buscar, List<Persona> list)
        {
            string encontrado = buscarObjeto(buscar, list);

            if (encontrado != null)
            {
                list.RemoveAll(c => c.DNI == buscar);
                return buscar;
            }
            return null;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> list = new List<Persona>();
            string buscar;
            list.Add(new Persona("Sergio", "12.345.678"));
            list.Add(new Persona("Rosas", "11.345.678"));
            list.Add(new Persona("San Martin", "10.345.678"));
            list.Add(new Persona("Belgrano", "09.345.678"));

            string[] menu = { "Menu", "[0] Método buscar por DNI y que devuelva verdadero o falso",
                              "[1] Método buscar por DNI y que devuelva un objeto Persona en caso de que lo haya encontrado y en caso contrario que devuelva null",
                              "[2] Método eliminar que reciba como parámetro un DNI" };

            for (int i = 0; i < menu.Count(); i++)
            {
                Console.WriteLine(menu[i]);
            }

            Console.WriteLine("Seleccione una opción");
            int op;
            bool suceso = int.TryParse(Console.ReadLine(), out op);
            if (!suceso) Environment.Exit(0);

            while (true)
            {
                switch (op)
                {
                    case 0:
                        Console.WriteLine("Ingrese el DNI para buscar a la persona");
                        buscar = Console.ReadLine();

                        bool encontrado = Persona.buscarBool(buscar, list);

                        Console.WriteLine($"{encontrado.ToString()}");

                        suceso = int.TryParse(Console.ReadLine(), out op);
                        if (!suceso) Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Ingrese el DNI para buscar a la persona");
                        buscar = Console.ReadLine();

                        string encontradoStr = Persona.buscarObjeto(buscar, list);

                        if (encontradoStr != null)
                        {
                            Console.WriteLine($"{encontradoStr}");
                        }
                        else
                        {
                            Console.WriteLine("null");
                        }
                        suceso = int.TryParse(Console.ReadLine(), out op);
                        if (!suceso) Environment.Exit(0);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el DNI para aliminar a la persona del registro");
                        buscar = Console.ReadLine();

                        string eliminado = Persona.eliminar(buscar, list);

                        if (eliminado == null)
                        {
                            Console.WriteLine("No se encontro al usuario");
                        }
                        else
                        {
                            Console.WriteLine("El usuario fue eliminado");
                        }
                        suceso = int.TryParse(Console.ReadLine(), out op);
                        if (!suceso) Environment.Exit(0);
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
