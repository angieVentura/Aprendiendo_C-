using System;
using System.Collections.Generic;
using System.Linq;

namespace ABM
{
    class usuario
    {
        public string name;
        public string dni;

        public usuario(string name, string dni)
        {
            this.name = name;
            this.dni = dni;
        }
        public string mostrarTodo()
        {
            string formato = dni.Insert(2, ".").Insert(6, ".");
            return name + ", " + formato;
        }

        static public string buscar(string dni, string name, List<usuario> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].dni == dni)
                {
                    return list[i].name;
                }
                else if (list[i].name.ToLower() == name.ToLower())
                {
                    return list[i].name;
                }
            }

            return null;
        }

        static public string alta(string name, string dni, List<usuario> list)
        {
            if (dni == "" || name == "") return null;
            if (dni.Length != 8 || !dni.All(char.IsDigit)) return dni;
            list.Add(new usuario(name, dni)); return name;
        }

        static public string borrar(string dni, List<usuario> list)
        {

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].dni == dni)
                {
                    list.RemoveAt(i);
                    return "eliminao";
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
                    if (nuevo.Length != 8) return nuevo;
                    list[i].dni = nuevo;
                }
                else if (list[i].name.ToLower() == name.ToLower())
                {
                    if (nuevo == "") return nuevo;
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
            string[] menu = { "Alta Usuario", "Baja usuario", "Modificar Usuario", "Listar Usuarios", "Salir" };

            list.Add(new usuario("Sergio", "12345678"));
            list.Add(new usuario("Pablo", "87654321"));
            list.Add(new usuario("Florencia", "12435678"));

            void estructuraMenu(string titulo, string estructura)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    for (int j = 0; j < Console.WindowWidth / 4; j++)
                    {
                        Console.Write(estructura);
                    }
                }
                imprimirMensaje(titulo, 5, 2);
            }

            estructuraMenu("MENU", " ");
            int opc;
            int posMenu = 0;
            Console.CursorVisible = false;

            void mostrarMenu()
            {

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.SetCursorPosition(5, i + 4);
                    Console.ForegroundColor = (i == posMenu) ? ConsoleColor.Black : ConsoleColor.Gray;
                    Console.WriteLine(menu[i]);
                }
            }

            void imprimirMensaje(string mensaje, int x, int y)
            {

                Console.SetCursorPosition(x, y);
                Console.WriteLine(mensaje);
            }

            string leerEntradaEnPosicion(int x, int yMensaje, int yEntrada, string mensaje)
            {

                Console.SetCursorPosition(x, yMensaje);
                Console.Write(mensaje);
                Console.SetCursorPosition(x, yEntrada);
                return Console.ReadLine();
            }

            void rehacerMenu(string mensaje, string titulo, string estructura, int y)
            {
                imprimirMensaje(mensaje, 35, y);
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                estructuraMenu(titulo, estructura);
                mostrarMenu();
            }

            mostrarMenu();

            while (true)
            {
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.DownArrow)
                {
                    posMenu = (posMenu + 1) % menu.Length;
                    mostrarMenu();
                }
                else if (tecla.Key == ConsoleKey.UpArrow)
                {
                    posMenu--;
                    if (posMenu < 0) posMenu = menu.Length - 1;
                    mostrarMenu();
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;

                    switch (posMenu)
                    {
                        case 0:
                            imprimirMensaje("Seleccionaste Alta Usuario", 35, 3);
                            string name = leerEntradaEnPosicion(35, 5, 7, "Ingrese el nombre del usuario:");
                            string dni = leerEntradaEnPosicion(35, 9, 11, "Ingrese el DNI del usuario:");
                            string alta = usuario.alta(name, dni, list);
                            imprimirMensaje(alta == dni ? "El DNI debe tener 8 números" : alta == null ? "Nombre o DNI inválido" : $"El usuario {name} fue registrado exitosamente", 35, 13);
                            rehacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 15);

                            break;
                        case 1:
                            imprimirMensaje("Seleccionaste Baja Usuario", 35, 3);
                            dni = leerEntradaEnPosicion(35, 5, 7, "Ingrese el DNI del usuario a borrar:");
                            imprimirMensaje(usuario.borrar(dni, list) == null ? "La usuario que quiere borrar no existe" : "El usuario fue eliminado exitosamente", 35, 9);
                            rehacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 11);

                            break;
                        case 2:
                            imprimirMensaje("Seleccionaste Modificar Usuario", 35, 3);
                            string[] menuXikito = { "OPCIONES PARA MODIFICAR", "[1]DNI", "[2]Usuario" };

                            for (int i = 0; i < menuXikito.Length; i++)
                            {
                                Console.SetCursorPosition(35, i + 5);
                                Console.WriteLine(menuXikito[i]);
                            }

                            bool modEstado = true;

                            while (modEstado)
                            {
                                imprimirMensaje(" ", 35, 9);
                                Console.SetCursorPosition(35, 9);
                                bool success = int.TryParse(Console.ReadLine(), out opc);
                                if (!success) Environment.Exit(0);

                                if (opc == 1)
                                {
                                    dni = leerEntradaEnPosicion(35, 11, 13, "Ingrese el DNI del usuario a modificar:");
                                    string buscar = usuario.buscar(dni, "", list);

                                    if (buscar == null)
                                    {
                                        imprimirMensaje("No se encontró al usuario que quiere modificar", 35, 15);
                                    }
                                    else
                                    {
                                        bool estado = true;

                                        while (estado)
                                        {
                                            string nuevo = leerEntradaEnPosicion(35, 15, 17, "Ingrese el nuevo DNI:");
                                            if (usuario.modificar(dni, nuevo, "", list) == nuevo)
                                            {
                                                imprimirMensaje("".PadLeft(45), 35, 17);
                                                imprimirMensaje("El DNI debe tener 8 números, ingresar el DNI nuevamente", 35, 19);
                                            }
                                            else
                                            {
                                                imprimirMensaje("".PadLeft(60), 35, 19);
                                                imprimirMensaje("El DNI del usuario se modificó exitosamente.", 35, 19);
                                                estado = false;
                                            }
                                        }
                                    }
                                    modEstado = false;
                                    rehacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", buscar == null ? 17 : 21);
                                }
                                else if (opc == 2)
                                {
                                    name = leerEntradaEnPosicion(35, 11, 13, "Ingrese el nombre del usuario a modificar:");
                                    string buscar = usuario.buscar("", name, list);

                                    if (buscar == null)
                                    {
                                        imprimirMensaje("No se encontró al usuario que quiere modificar", 35, 15);
                                    }
                                    else
                                    {
                                        bool estado = true;

                                        while (estado)
                                        {
                                            string nuevo = leerEntradaEnPosicion(35, 15, 17, "Ingrese el nuevo nombre:");
                                            if (usuario.modificar("", nuevo, name, list) == nuevo)
                                            {
                                                imprimirMensaje("".PadLeft(45), 35, 17);
                                                imprimirMensaje("Nombre invalido, vuelva a ingresar el nombre", 35, 19);
                                            }
                                            else
                                            {
                                                imprimirMensaje("".PadLeft(45), 35, 19);
                                                imprimirMensaje("El nombre del usuario se modificó exitosamente.", 35, 19);
                                                estado = false;
                                            }
                                        }
                                    }

                                    modEstado = false;
                                    rehacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", buscar == null ? 17 : 21);

                                }
                                else
                                {
                                    imprimirMensaje("Ingresa una opción valida.", 35, 11);
                                }
                            }
                            break;
                        case 3:
                            imprimirMensaje("Seleccionaste Listar Usuarios", 35, 3);
                            imprimirMensaje("Lista De Usuarios", 35, 5);
                            string tablaHeader = string.Format("{0,-20} {1,-10}", "Nombres", "DNI");
                            imprimirMensaje(tablaHeader, 35, 7);
                            int fila = 9;
                            list.ForEach(usuario =>
                            {
                                string filaTabla = string.Format("{0,-20} {1,-10}", usuario.name, usuario.dni);
                                imprimirMensaje(filaTabla, 35, fila);
                                fila++;
                            });

                            rehacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", list.Count + 10);

                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}