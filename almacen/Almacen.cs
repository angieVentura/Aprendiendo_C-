using System.Linq;

namespace almacen
{
    internal class Almacen
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
            if (!estanterias.Cast<Bebida>().Any(b => b != null && b.id == bebida.id))
            {
                for (int fila = 0; fila < estanterias.GetLength(0); fila++)
                {
                    for (int columna = 0; columna < estanterias.GetLength(1); columna++)
                    {
                        if (estanterias[fila, columna] == null)
                        {
                            estanterias[fila, columna] = bebida;
                            return;
                        }
                    }
                }
            }
        }

        public void EliminarProducto(int id)
        {
            for (int fila = 0; fila < estanterias.GetLength(0); fila++)
            {
                for (int columna = 0; columna < estanterias.GetLength(1); columna++)
                {
                    if (estanterias[fila, columna] != null && estanterias[fila, columna].id == id)
                    {
                        estanterias[fila, columna] = null;
                        return;
                    }
                }
            }
        }

        public string MostrarInformacion(Bebida bebida)
        {
            if (bebida is AguaMineral aguaMineral) return $"{bebida.id},{bebida.nombre} ,{bebida.marca}, {bebida.litros}, {aguaMineral.origen}, {aguaMineral.precio}";
            if (bebida is BebidaAzucarada bebidaAzucarada) return $"{bebida.id},{bebida.nombre} , {bebida.marca}, {bebida.litros}, {bebidaAzucarada.porcentajeAzucar}, {bebidaAzucarada.promocion}, {bebidaAzucarada.precio}";
            return $"{bebida.id}, {bebida.nombre} ,{bebida.marca}, {bebida.litros}, {bebida.precio}";
        }
    }
}
