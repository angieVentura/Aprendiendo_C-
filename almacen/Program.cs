using System.Linq;

namespace almacen
{
    class Bebida
    {
        public int id;
        public string nombre, marca;
        public double litros, precio;

        public Bebida(int id, string nombre, string marca, double litros, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.marca = marca;
            this.litros = litros;
            this.precio = precio;
        }
    }

    class AguaMineral : Bebida
    {
        public string origen;

        public AguaMineral(int id, string nombre, string marca, double litros, double precio, string origen) : base(id, nombre, marca, litros, precio)
        {
            this.origen = origen;
        }
    }

    class BebidaAzucarada : Bebida
    {
        public double porcentajeAzucar;
        public bool promocion;

        public BebidaAzucarada(int id, string nombre, string marca, double litros, double precio, double porcentajeAzucar, bool promocion) : base(id, nombre, marca, litros, precio)
        {
            this.porcentajeAzucar = porcentajeAzucar;
            this.promocion = promocion;
        }

        public double Descuento()
        {
            return promocion ? precio * 0.9 : precio;
        }
    }

    class Almacen
    {
        public Bebida[,] estanterias;

        public Almacen(int filas, int columnas)
        {
            estanterias = new Bebida[filas, columnas];
        }

        public double CalcularPrecioTotal()
        {
            return estanterias.Cast<Bebida>().Where(b => b != null).Sum(b => b.precio);
        }

        public double CalcularPrecioMarca(string marca)
        {
            return estanterias.Cast<Bebida>().Where(b => b != null && b.marca == marca).Sum(b => b.precio);
        }

        public double CalcularPrecioEstanteria(int columna)
        {
            return Enumerable.Range(0, estanterias.GetLength(0)).Sum(fila => estanterias[fila, columna]?.precio ?? 0);
        }

        public void AgregarProducto(Bebida bebida)
        {
            if (!estanterias.Cast<Bebida>().Any(b => b.id == bebida.id))
                for (int fila = 0; fila < estanterias.GetLength(0); fila++)
                    for (int columna = 0; columna < estanterias.GetLength(1); columna++)
                        if (estanterias[fila, columna] != null)
                        {
                            estanterias[fila, columna] = bebida;
                            fila = estanterias.GetLength(0);
                            break;
                        }

        }

        public void EliminarProducto(int id)
        {
            for (int fila = 0; fila < estanterias.GetLength(0); fila++)
                for (int columna = 0; columna < estanterias.GetLength(1); columna++)
                    if (estanterias[fila, columna].id == id) estanterias[fila, columna] = null;
        }

        public string MostrarInformacion(Bebida bebida)
        {
            if (bebida is AguaMineral aguaMineral) return $"{bebida.id}, {bebida.marca}, {bebida.litros}, {aguaMineral.origen}";
            if (bebida is BebidaAzucarada bebidaAzucarada) return $"{bebida.id}, {bebida.marca}, {bebida.litros}, {bebidaAzucarada.porcentajeAzucar}, {bebidaAzucarada.promocion}";
            return $"{bebida.id}, {bebida.marca}, {bebida.litros}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
