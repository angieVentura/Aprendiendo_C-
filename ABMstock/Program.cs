using System;
using System.Collections.Generic;
using System.Linq;

namespace practica2
{
    class Stock
    {
        public string name;
        public string proveedor;
        public int cantidad;
        public string id;

        public Stock(string name, string proveedor, int cantidad, string id)
        {
            this.name = name;
            this.proveedor = proveedor;
            this.cantidad = cantidad;
            this.id = id;
        }

        //listar
        public string mostrar()
        {
            return id + ", " + name + ", " + proveedor + ", " + cantidad;
        }

        //buscar
        static public string buscar(string dato, List<Stock> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name.ToLower() == dato.ToLower() || list[i].id == dato)
                {
                    return $"{i}";
                }
            }

            return null;
        }

        //Eliminar
        static public string eliminar(string dato, List<Stock> list)
        {
            string encontrado = buscar(dato, list);

            if (encontrado != null)
            {
                string nombre = list[Convert.ToInt16(encontrado)].name;
                list.RemoveAt(Convert.ToInt16(encontrado));
                return nombre;
            }

            return null;
        }

        //Alta
        static public string alta(string nombre, string proveedor, int cantidad, List<Stock> list)
        {
            int idInt = Convert.ToInt16(list[list.Count - 1].id) + 1;
            list.Add(new Stock(nombre, proveedor, cantidad, Convert.ToString(idInt)));
            return nombre;
        }

        //modificar
        static public string modificar(string modificar, string nuevoStr, int op, int nuevoInt, string id, List<Stock> list)
        {

            switch (op)
            {
                case 0:

                    list[Convert.ToInt16(id)].name = nuevoStr;
                    break;
                case 1:
                    list[Convert.ToInt16(id)].proveedor = nuevoStr;
                    break;
                case 2:
                    list[Convert.ToInt16(id)].cantidad = nuevoInt;
                    break;
            }

            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Stock> list = new List<Stock>();
            int opc;
            string dato;
            string resultado;
            bool estado = true;
            string[] menu = { "MENU", "[0] Listar Stock", "[1] Buscar Productos", "[2] Eliminar Productos", "[3] Alta de Producto", "[4] Modificar Producto", "[5] Salir" };
            list.Add(new Stock("Pollo", "Granja Doña Pepa", 3, "1"));
            list.Add(new Stock("Arroz", "GRanja", 4, "2"));
            list.Add(new Stock("POlllo", "GRanja", 5, "5"));

            for (int i = 0; i < menu.Count(); i++)
            {
                Console.WriteLine(menu[i]);
            }

            opc = Convert.ToInt16(Console.ReadLine());

            while (estado)
            {
                switch (opc)
                {
                    case 0:
                        //Listar
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i].mostrar());
                        }

                        opc = Convert.ToInt16(Console.ReadLine());
                        break;
                    case 1:
                        //Buscar

                        Console.WriteLine("Ingrese nombre o ID del producto");
                        dato = Console.ReadLine();
                        resultado = Stock.buscar(dato, list);

                        if (resultado != null)
                        {
                            Console.WriteLine(list[Convert.ToInt16(resultado)].mostrar());
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el producto");
                        }
                        opc = Convert.ToInt16(Console.ReadLine());
                        break;
                    case 2:
                        //Eliminar
                        Console.WriteLine("Ingrese nombre o ID del producto");
                        dato = Console.ReadLine();
                        resultado = Stock.eliminar(dato, list);
                        if (resultado != null)
                        {
                            Console.WriteLine($"El producto {resultado} fue eliminado");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el producto");
                        }
                        opc = Convert.ToInt16(Console.ReadLine());
                        break;
                    case 3:
                        //Alta

                        Console.WriteLine("Ingrese nombre del producto");
                        dato = Console.ReadLine();
                        Console.WriteLine("Ingrese el proveedor del producto");
                        string preveedor = Console.ReadLine();
                        Console.WriteLine("Ingrese la cantidad del producto");
                        int cantidad = Convert.ToInt16(Console.ReadLine());

                        resultado = Stock.alta(dato, preveedor, cantidad, list);

                        if (resultado == dato)
                        {
                            Console.WriteLine($"{dato} fue ingresado al stock");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        opc = Convert.ToInt16(Console.ReadLine());
                        break;
                    case 4:
                        //Modificar
                        int nuevoInt = 0;
                        string nuevoStr = "";
                        Console.WriteLine("Ingrese nombre o ID del producto");
                        dato = Console.ReadLine();

                        string encotrado = Stock.buscar(dato, list);

                        if (encotrado != null)
                        {
                            string[] menuChico = { "Seleccione dato a modificar", "[0] Nombre", "[1] Proveedor", "[2] Cantidad" };

                            for (int i = 0; i < menuChico.Count(); i++)
                            {
                                Console.WriteLine($"{menuChico[i]}");
                            }

                            int opci = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Ingrese el nuevo dato");

                            if (opci == 2)
                            {
                                nuevoInt = Convert.ToInt16(Console.ReadLine());
                            }
                            else
                            {
                                nuevoStr = Console.ReadLine();
                            }

                            string modificado = Stock.modificar(dato, nuevoStr, opci, nuevoInt, encotrado, list);
                            Console.WriteLine("El usuario se modifico con exito");
                          
                        }
                        else
                        {
                            Console.WriteLine("No se encontro al usuario que desea modificar.");
                        }
                        opc = Convert.ToInt16(Console.ReadLine());
                        break;
                    case 5:
                        //Salir
                        Environment.Exit(0);
                        break;

                }
            }

            Console.ReadKey();
        }
    }
}
