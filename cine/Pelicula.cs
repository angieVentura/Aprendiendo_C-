namespace cine
{
    internal class Pelicula
    {
        public string titulo, director, duracion;
        public int edadMin;

        public Pelicula(string titulo, string director, string duracion, int edadMin)
        {
            this.titulo = titulo;
            this.director = director;
            this.duracion = duracion;
            this.edadMin = edadMin;
        }
    }
}
