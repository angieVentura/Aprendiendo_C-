using System;
using System.Linq;

namespace almacen
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Almacen almacen = new Almacen(5, 5);

            almacen.AgregarProducto(new AguaMineral(1, "Agua Mineral 1L", "Manantial X", 1, 1.5, "Manantial X"));
            almacen.AgregarProducto(new BebidaAzucarada(2, "Coca-Cola", "Coca-Cola Company", 2, 1.5, 10, true));
            almacen.AgregarProducto(new BebidaAzucarada(3, "Fanta", "Coca-Cola Company", 1.5, 1.5, 8, false));
            almacen.AgregarProducto(new Bebida(4, "Jugo de Naranja", "Marca Y", 0.5, 1.5));
            almacen.AgregarProducto(new AguaMineral(5, "Agua Mineral 500ml", "Manantial Z", 0.5, 1.5, "Manantial Z"));
            almacen.AgregarProducto(new BebidaAzucarada(6, "Pepsi", "PepsiCo", 2.5, 1.5, 12, true));
            almacen.AgregarProducto(new Bebida(7, "Jugo de Manzana", "Marca Y", 1, 1.5));

            double precioTotal = almacen.CalcularPrecioTotal();
            Console.WriteLine($"Precio total de todas las bebidas: {precioTotal}");

            double precioMarca = almacen.CalcularPrecioMarca("Coca-Cola Company");
            Console.WriteLine($"Precio total de la marca 'Coca-Cola Company': {precioMarca}");

            double precioEstanteria = almacen.CalcularPrecioEstanteria(0);
            Console.WriteLine($"Precio total de la estantería 0: {precioEstanteria}");

            almacen.EliminarProducto(2);

            for (int fila = 0; fila < almacen.estanterias.GetLength(0); fila++)
            {
                for (int columna = 0; columna < almacen.estanterias.GetLength(1); columna++)
                {
                    Bebida bebida = almacen.estanterias[fila, columna];
                    if (bebida != null)
                    {
                        string informacion = almacen.MostrarInformacion(bebida);
                        Console.WriteLine(informacion);
                    }
                }
            }

            Console.ReadKey();
        }

    }
}
