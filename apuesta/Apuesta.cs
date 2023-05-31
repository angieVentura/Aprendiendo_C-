namespace apuesta
{
    internal class Apuesta : IJuego
    {
        public int MontoMinimo { get; }
        public int MinimoAciertos { get; }
        public int PozoAcumulado { get; }
        public int CantidadPartidos { get; }
        public string[] resultado;

        public Apuesta(int montoMin, int minAc, int pozoAc, int cantPar, string[] resultado)
        {
            MontoMinimo = montoMin;
            MinimoAciertos = minAc;
            PozoAcumulado = pozoAc;
            CantidadPartidos = cantPar;
            this.resultado = resultado;
        }
    }
}
