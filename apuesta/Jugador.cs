namespace apuesta
{
    internal class Jugador : IParticipante
    {
        public int dinero { get; set; }
        public string nombre { get; set; }
        public int victorias { get; set; }

        public string[] respuesta;

        public Jugador(string nombre, int dinero, int victorias, string[] respuesta)
        {
            this.nombre = nombre;
            this.dinero = dinero;
            this.victorias = victorias;
            this.respuesta = respuesta;
        }

        public bool PuedeParticipar()
        {
            return dinero > 0;
        }

        public void Apostar(int monto)
        {
            dinero -= monto;
        }

        public void IncrementarDinero(int monto)
        {
            dinero += monto;
        }

        public void IncrementarVictorias()
        {
            this.victorias += 1;
        }

        public string MostrarResultados()
        {
            return $"Jugador: {nombre}, Dinero: {dinero}, Victorias: {victorias}";
        }

    }
}
