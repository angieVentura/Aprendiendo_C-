using System;
using System.Collections.Generic;
using System.Linq;

namespace barajaEspañola
{
    public enum PalosBarEspañola
    {
        Espadas,
        Bastos,
        Oros,
        Copas
    }

    public enum PalosBarFrancesa
    {
        Diamantes,
        Picas,
        Corazones,
        Treboles
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BarajaEspañola barajaEspañola = new BarajaEspañola(true);
            barajaEspañola.CrearBaraja();
            barajaEspañola.Barajar();
            List<Carta<PalosBarEspañola>> cartasRepartidasEspañola = barajaEspañola.DarCartas(5);
            Console.WriteLine("Cartas disponibles en la baraja española:" + barajaEspañola.CartasDisponibles());
            List<Carta<PalosBarEspañola>> cartasMontonEspañola = barajaEspañola.CartasMonton();
            List<Carta<PalosBarEspañola>> cartasBarajaEspañola = barajaEspañola.MostrarBaraja();

            BarajaFrancesa barajaFrancesa = new BarajaFrancesa();
            barajaFrancesa.CrearBaraja();
            barajaFrancesa.Barajar();
            List<Carta<PalosBarFrancesa>> cartasRepartidasFrancesa = barajaFrancesa.DarCartas(5);
            Console.WriteLine("\nCartas disponibles en la baraja francesa:" + barajaFrancesa.CartasDisponibles());
            List<Carta<PalosBarFrancesa>> cartasMontonFrancesa = barajaFrancesa.CartasMonton();
            List<Carta<PalosBarFrancesa>> cartasBarajaFrancesa = barajaFrancesa.MostrarBaraja();

            Console.WriteLine(
                
                $"\nCartas repartidas de la baraja española:\n\n{string.Join("\n", cartasRepartidasEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))} " +

                $"\n\nCartas en el montón de la baraja española:\n\n{string.Join("\n", cartasMontonEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\n\nCartas en la baraja española:\n\n{string.Join("\n", cartasBarajaEspañola.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\n\nCartas repartidas de la baraja francesa:\n\n{string.Join("\n", cartasRepartidasFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\n\nCartas en el montón de la baraja francesa:\n\n{string.Join("\n", cartasMontonFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}" +

                $"\n\nCartas en la baraja francesa:\n\n{string.Join("\n", cartasBarajaFrancesa.Select(carta => $"Identificador: {carta.id} - {carta.palo} - Disponible: {carta.disponible}"))}");

            Console.ReadKey();
        }
    }
}
