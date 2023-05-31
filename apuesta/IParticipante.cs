namespace apuesta
{
    internal interface IParticipante
    {
        int dinero { get; }
        string nombre { get; }
        int victorias { get; }
        bool PuedeParticipar();
        void Apostar(int monto);
        void IncrementarDinero(int monto);
        void IncrementarVictorias();
        string MostrarResultados();
    }

}
