namespace apuesta
{
    internal interface IJuego
    {
        int MontoMinimo { get; }
        int MinimoAciertos { get; }
        int PozoAcumulado { get; }
        int CantidadPartidos { get; }
    }
}
