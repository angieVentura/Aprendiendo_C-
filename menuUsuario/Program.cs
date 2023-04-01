using System;
using System.Collections.Generic;
using System.Linq;

namespace ABM
{
    class usuario
    {
        public string name;
        public string dni;

        //Constructor por defaul - Mismo nombre que la clase
        public usuario()
        {
        }

        //Segundo constructor - Mismo nombre que la clase
        public usuario(string name, string dni)
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

        static public string buscar(string dni, string name, List<usuario> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].dni == dni)
                {
                    return list[i].name;
                }
                else if (list[i].name == name)
                {
                    return list[i].name;
                }
            }

            return null;


        }

        static public string alta(string dni, string name, List<usuario> list)
        {
            list.Add(new usuario(dni, name));

            return null;
        }

        static public string borrar(string dni, List<usuario> list)
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

        static public string modificar(string dni, string nuevo, string name, List<usuario> list)
        {

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].dni == dni)
                {
                    list[i].dni = nuevo;

                }
                else if (list[i].name == name)
                {
                    list[i].name = nuevo;

                }

            }
            return null;

        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<usuario> list = new List<usuario>();
            usuario usuario1;

            list.Add(new usuario("Sergio", "12.345.678"));
            list.Add(new usuario("Pablo", "87.654.321"));
            list.Add(new usuario("Florencia", "12.435.678"));


            int op;
            int opc;
            string[] menu =
            {
                "MENU DE OPCIONES","[1]Alta Usuario", "[2]Baja usuario", "[3]Modificar Usuario", "[4]Listar Usuarios", "[5]Salir"
            };

            for (int i = 0; i < menu.Count(); i++)
            {
                Console.SetCursorPosition(5, i + 1);
                Console.WriteLine(menu[i]);
            }

            op = Convert.ToInt16(Console.ReadLine());

            while (true)
            {
                switch (op)
                {
                    case 1:

                        Console.WriteLine("Ingrese el nombre del usuario:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ingrese el DNI del usuario:");
                        string dni = Console.ReadLine();

                        string insert = usuario.alta(name, dni, list);

                        Console.WriteLine("El usuario fue registrado existosamente");

                        break;

                    case 2:
                        Console.Write("Ingrese el DNI del usuario a borrar:");
                        dni = Console.ReadLine();

                        string encontrau = usuario.borrar(dni, list);
                        if (encontrau == null)
                        {
                            Console.WriteLine("La usuario que quiere borrar no existe");

                        }
                        else
                        {
                            Console.WriteLine(encontrau + " fue borrado");
                        }
                        break;

                    case 3:

                        string[] menuXikito =
                        {
                      "OPCIONES PARA MODIFICAR","[1]DNI", "[2]Usuario"
                    };

                        for (int i = 0; i < menuXikito.Count(); i++)
                        {
                            Console.SetCursorPosition(5, i + 10);
                            Console.WriteLine(menuXikito[i]);
                        }

                        opc = Convert.ToInt16(Console.ReadLine());



                        if (opc == 1)
                        {
                            Console.WriteLine("Ingrese el DNI del usuario a modificar:");
                            dni = Console.ReadLine();


                            string buscar = usuario.buscar(dni, "", list);

                            if (buscar == null)
                            {
                                Console.WriteLine("No se encontro al usuario que quiere modificar");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nuevo DNI:");
                                string nuevo = Console.ReadLine();

                                string encontraoo = usuario.modificar(dni, nuevo, "", list);
                                Console.WriteLine("El usuario se modifico exitosamente.");
                            }


                        }
                        else if (opc == 2)
                        {
                            Console.WriteLine("Ingrese el nombre del usuario a modificar:");
                            name = Console.ReadLine();

                            string buscar = usuario.buscar("", name, list);

                            if (buscar == null)
                            {
                                Console.WriteLine("No se encontro al usuario que quiere modificar");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese el nuevo nombre:");
                                string nuevo = Console.ReadLine();
                                string encontraoo = usuario.modificar("", nuevo, name, list);
                                Console.WriteLine("El usuario se modifico exitosamente.");
                            }

                        }

                        break;
                    case 4:

                        Console.WriteLine("Lista De Usuarios");

                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i].mostrarTodo());
                        }

                        break;

                    case 5:

                        Environment.Exit(0);

                        break;

                }



                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                op = 0;
                for (int i = 0; i < menu.Count(); i++)
                {
                    Console.SetCursorPosition(5, i + 1);
                    Console.WriteLine(menu[i]);
                }
                op = Convert.ToInt16(Console.ReadLine());
            }



            Console.ReadKey();

        }
    }
}


