namespace cine
{
    internal class Asiento
    {
        public string etiqueta;
        public Espectador espectador;
        public int x, y;

        public Asiento(string etiqueta, int x, int y)
        {
            this.etiqueta = etiqueta;
            this.x = x;
            this.y = y;
            espectador = null;
        }

        public void Ocupar(Espectador espectador)
        {
            this.espectador = espectador;
        }

        public bool EstaOcupado()
        {
            return espectador != null;
        }
    }
}
