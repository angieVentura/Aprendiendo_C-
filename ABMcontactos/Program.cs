using System;
using System.Collections.Generic;
using System.Linq;

namespace ABMcontactos
{
    class Contacto
    {
        public string name;
        public string surname;
        public string email;
        public string phone;

        public Contacto(string name, string surname, string email, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
        }

        public string mostrar()
        {
            return $"{name} {surname}, {email}, {phone}";
        }

        static public string buscar(string buscar, List<Contacto> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == buscar || list[i].email.ToLower() == buscar.ToLower())
                {
                    return $"{i}";
                }
            }

            return null;
        }

        static public string validarEmail(string email)
        {

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == ' ') return null;
                if (email[i] == '@') return email;
            }
            return null;
        }


        static public void alta(string name, string surname, string email, string phone, List<Contacto> list)
        {
            list.Add(new Contacto(name, surname, email, phone));
        }

        static public string borrar(string buscar, List<Contacto> list)
        {
            string resultado = Contacto.buscar(buscar, list);
            if (resultado != null)
            {
                list.RemoveAt(Convert.ToInt16(resultado));
                return resultado;
            }
            return null;
        }

        static public string modificar(string nuevo, string resultado, string modificar, int op, List<Contacto> list)
        {
            switch (op)
            {
                case 0:

                    list[Convert.ToInt16(resultado)].name = nuevo;

                    break;
                case 1:
                    list[Convert.ToInt16(resultado)].surname = nuevo;

                    break;
                case 2:
                    string validarMail = Contacto.validarEmail(nuevo);

                    if (validarMail != null)
                    {
                        list[Convert.ToInt16(resultado)].email = nuevo;
                    }
                    else
                    {
                        return nuevo;
                    }
                    break;
                case 3:
                    list[Convert.ToInt16(resultado)].phone = nuevo;
                    break;
            }

            return null;
        }


        internal class Program
        {

            static void Main(string[] args)
            {
                int op;
                bool suceso;
                string estadoCase;
                string email;
                List<Contacto> list = new List<Contacto>();

                //Creo contactos
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Contacto($"Contacto{i}", $"Contactozo{i}", $"Contacto{i}@gmail.com", $"1234567{i}"));
                }
                //Creo menu
                string[] menu = { "MENU", "[0] Alta de contacto", "[1] Baja de contacto", "[2] Modificar contacto", "[3] Listar Contactos", "[4] Salir" };
                for (int i = 0; i < menu.Count(); i++)
                {
                    Console.WriteLine(menu[i]);
                }
                //Creo opcion
                suceso = int.TryParse(Console.ReadLine(), out op);
                if (!suceso) Environment.Exit(0);

                while (true)
                {
                    switch (op)
                    {
                        case 0: //alta de contacto

                            string name = mensaje("Ingrese el nombre del contacto");
                            string apellido = mensaje("Ingrese el apellido del contacto");
                            email = mensaje("Ingrese el email del contacto");
                            string valEmail = Contacto.validarEmail(email);
                            while (valEmail == null)
                            {
                                email = mensaje("Ingrese el email nuevamente del contacto");
                                valEmail = Contacto.validarEmail(email);
                            }
                            string telefono = mensaje("Ingrese el telefono del contacto");

                            Contacto.alta(name, apellido, email, telefono, list);
                            Console.WriteLine("Se a registrado el contacto.");


                            suceso = int.TryParse(Console.ReadLine(), out op);
                            if (!suceso) Environment.Exit(0);
                            break;
                        case 1: // Baja de contacto

                            email = mensaje("Ingrese el email del usuario a dar de baja");

                            string eliminado = Contacto.borrar(email, list);

                            if (eliminado == null)
                            {
                                Console.WriteLine("No se encontro al usaurio que quiere borrar.");
                            }
                            else
                            {
                                Console.WriteLine("El usuario fue eliminado.");
                            }

                            suceso = int.TryParse(Console.ReadLine(), out op);
                            if (!suceso) Environment.Exit(0);
                            break;
                        case 2: // Modificar contacto
                            string[] menuXikito = { "Ingrse la opción a modificar", "[0] Nombre", "[1] Apellido", "[2] Email", "[3] Telefono" };
                            int ops;

                            email = mensaje("Ingrese el email del usuario a modificar");
                            string resultado = Contacto.buscar(email, list);

                            if (resultado != null)
                            {
                                for (int i = 0; i < menuXikito.Count(); i++)
                                {
                                    Console.WriteLine(menuXikito[i]);

                                }

                                bool suceso2 = int.TryParse(Console.ReadLine(), out ops);
                                if (!suceso2) Environment.Exit(0);
                                string nuevo = mensaje("Ingrese el nuevo dato.");
                                string modificar = Contacto.modificar(nuevo, resultado, email, ops, list);
                                Console.WriteLine(modificar);
                                if (modificar == nuevo)
                                {
                                    nuevo = mensaje("Nuevo email no valido, intente nuevamente");
                                    modificar = Contacto.modificar(nuevo, resultado, email, ops, list);
                                    while (modificar == nuevo)
                                    {
                                        nuevo = mensaje("Nuevo email no valido, intente nuevamente");
                                        modificar = Contacto.modificar(nuevo, resultado, email, ops, list);
                                    }

                                }

                                Console.WriteLine("El usuario se modifico exitosamente");


                            }
                            else
                            {
                                Console.WriteLine("No se encontro al usuario que desea modificar.");
                            }

                            suceso = int.TryParse(Console.ReadLine(), out op);
                            if (!suceso) Environment.Exit(0);
                            break;
                        case 3: // Listar contactos

                            for (int i = 0; i < list.Count; i++)
                            {
                                Console.WriteLine(list[i].mostrar());
                            }

                            suceso = int.TryParse(Console.ReadLine(), out op);
                            if (!suceso) Environment.Exit(0);
                            break;
                        case 4: //salir

                            Environment.Exit(0);
                            break;
                    }
                }

                Console.ReadLine();
            }

            static public string mensaje(string mensaje)
            {
                Console.WriteLine(mensaje);
                return Console.ReadLine();
            }
        }
    }
}