using System;
using System.Linq;

namespace agendaTelefonica
{
    internal class Program
    {
        static public void EstructuraMenu(string titulo, string estructura)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Enumerable.Range(0, Console.WindowHeight).ToList().ForEach(i => { Console.SetCursorPosition(0, i); Enumerable.Range(0, Console.WindowWidth / 4).ToList().ForEach(j => Console.Write(estructura)); });
            ImprimirMensaje(titulo, 5, 2);
        }

        static public void MostrarMenu(string[] menu, int posMenu)
        {

            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(5, i + 4);
                Console.ForegroundColor = (i == posMenu) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.WriteLine(menu[i]);
            }
        }

        static public void ImprimirMensaje(string mensaje, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }

        static public string InputPosicion(int x, int yMensaje, int yEntrada, string mensaje)
        {

            Console.SetCursorPosition(x, yMensaje);
            Console.Write(mensaje);
            Console.SetCursorPosition(x, yEntrada);
            return Console.ReadLine();
        }

        static public void ReHacerMenu(string mensaje, string titulo, string estructura, int y, string[] menu, int posMenu)
        {
            ImprimirMensaje(mensaje, 35, y);
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            EstructuraMenu(titulo, estructura);
            MostrarMenu(menu, posMenu);
        }
        static void Main(string[] args)
        {

            string[] menu = { "Listar Contactos", "Añadir Contacto", "Existe Contacto", "Buscar Contacto", "Eliminar Contacto", "¿Agenda Llena?", "Espacio Agenda", "Salir" };

            Random rand = new Random();
            int cantContactos = 0;
            bool dato = int.TryParse(InputPosicion(0, 0, 3, "Ingrese el tamaño de la agenda de contactos(minimo: 6, maximo: 100), si desea usar la agenda por defecto ingrese el número 0"), out cantContactos);

            if (!dato) Environment.Exit(0);

            while (cantContactos != 0 && (cantContactos < 6 || cantContactos > 100))
            {
                ImprimirMensaje(" ".PadLeft(100, ' '), 0, 7);
                int.TryParse(InputPosicion(0, 5, 7, "Número fuera de rango, ingrese un número entre 6 y 100"), out cantContactos);
            }

            Agenda agenda = cantContactos == 0 ? new Agenda() : new Agenda(cantContactos);
            agenda.contactos[0] = new Contacto("Juan", "+54 9 11 1111-1111");
            agenda.contactos[1] = new Contacto("María", "+54 9 11 2222-2222");

            int posMenu = 0;
            Console.CursorVisible = false;
            EstructuraMenu("MENU", " ");
            MostrarMenu(menu, posMenu);

            while (true)
            {
                var tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.DownArrow)
                {
                    posMenu = (posMenu + 1) % menu.Length;
                    MostrarMenu(menu, posMenu);
                }
                else if (tecla.Key == ConsoleKey.UpArrow)
                {
                    posMenu--;
                    if (posMenu < 0) posMenu = menu.Length - 1;
                    MostrarMenu(menu, posMenu);
                }
                else if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;

                    switch (posMenu)
                    {
                        case 0:

                            ImprimirMensaje($"Listado de Contactos: \n\n{agenda.ListarContactos()}", 35, 3);

                            for (int i = 0; i < Console.WindowHeight - 5; i++)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                ImprimirMensaje(" ".PadLeft(Console.WindowWidth / 4), 0, 3 + i);
                            }
                            MostrarMenu(menu, posMenu);
                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 25, menu, posMenu);

                            break;
                        case 1:
                            ImprimirMensaje("Añadir Contacto", 35, 3);
                            string nombre = InputPosicion(35, 5, 7, $"Ingrese el nombre:");
                            string tel = InputPosicion(35, 9, 11, $"Ingrese el teléfono:");

                            string[] motivos = agenda.AniadirContacto(new Contacto(nombre, tel));

                            ImprimirMensaje( motivos.Any(m => m != null) ? $"{string.Join(", ", motivos)}." : "Contacto añadido correctamente.", 35, 13);

                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 15, menu, posMenu);

                            break;
                        case 2:
                            ImprimirMensaje("Existe Contacto", 35, 3);
                            nombre = InputPosicion(35, 5, 7, $"Ingrese el nombre:");

                            Contacto contacto = agenda.contactos.FirstOrDefault(c => c.nombre != null && c.nombre.ToLower() == nombre.ToLower());

                            bool existe = contacto != null && agenda.ExisteContacto(contacto);

                            ImprimirMensaje(existe ? "El contacto sí existe." : "El contacto no existe.", 35, 9);

                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 10, menu, posMenu);


                            break;
                        case 3:
                            ImprimirMensaje("Buscar Contacto", 35, 3);

                            nombre = InputPosicion(35, 5, 7, $"Ingrese el nombre:");

                            string buscar = agenda.BuscarContacto(nombre);

                            ImprimirMensaje(buscar != null ? $"Se encontro al contacto, su teléfono es: {buscar}." : "El contacto no fue encontrado.", 35, 9);
                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 10, menu, posMenu);

                            break;
                        case 4:
                            ImprimirMensaje("Eliminar Contacto", 35, 3);
                            nombre = InputPosicion(35, 5, 7, $"Ingrese el nombre:");

                            bool eliminado = agenda.EliminarContacto(agenda.contactos.FirstOrDefault(c => c.nombre != null && c.nombre.ToLower() == nombre.ToLower()));
                            ImprimirMensaje(eliminado ? "El contacto fue eliminado" : "El contacto no fue eliminado", 35, 9);
                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 10, menu, posMenu);
                            break;
                        case 5:
                            ImprimirMensaje("¿Agenda Llena?", 35, 3);
                            ImprimirMensaje(agenda.AgendaLlena() ? "La agenda esta llena" : "La agenda no esta llena.", 35, 5);
                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 10, menu, posMenu);

                            break;
                        case 6:
                            ImprimirMensaje("Espacio Agenda", 35, 3);

                            ImprimirMensaje(agenda.HuecosLibres() > 0 ? $"Espacio disponible: {agenda.HuecosLibres()}" : "No queda espacio en la agenda", 35, 5);
                            ReHacerMenu("Toque cualquier tecla para acceder al menu", "MENU", " ", 10, menu, posMenu);

                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                    }
                }
            }

        }
    }
}
