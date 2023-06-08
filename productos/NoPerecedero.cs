namespace productos
{
    internal class NoPerecedero : Producto
    {
        public string tipo;

        public NoPerecedero(string nombre, double precio, string tipo) : base(nombre, precio)
        {
            this.tipo = tipo;
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $", tipo: {tipo}";
        }

        public override double Calcular(int producto)
        {
            return base.Calcular(producto);
        }
    }
}