using System;
using System.Linq;

namespace productos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto[] productos = new Producto[10];
            productos[0] = new Perecedero("Manzana", 10.0, 1);
            productos[1] = new Perecedero("Lechuga", 10.0, 2);
            productos[2] = new Perecedero("Pollo", 10.0, 3);
            productos[3] = new NoPerecedero("Arroz", 20.0, "Tipo 1");
            productos[4] = new NoPerecedero("Aceite", 20.0, "Tipo 2");
            productos[5] = new NoPerecedero("Sal", 20.0, "Tipo 3");
            productos[6] = new Perecedero("Pan", 10.0, 1);
            productos[7] = new Perecedero("Queso", 10.0, 2);
            productos[8] = new Perecedero("Tomate", 10.0, 3);
            productos[9] = new NoPerecedero("Azúcar", 20.0, "Tipo 4");

            int cantidad = 5;

            Console.WriteLine("\nPrecio sin calcular:\n");
            Array.ForEach(productos, producto => Console.WriteLine($"{producto.ToString()} - Precio Total: {producto.Precio * cantidad}"));

            Console.WriteLine("\nPrecio calculado:\n");
            Array.ForEach(productos, producto => Console.WriteLine($"{producto.ToString()} - Precio Total: {Math.Round(producto.Calcular(cantidad), 2)}"));

            Console.ReadKey();
        }
    }
}
