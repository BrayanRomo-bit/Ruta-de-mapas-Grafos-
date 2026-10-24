using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Representa un nodo adyacente junto con la información de peso de la arista que los conecta.
    /// </summary>
    public class ElementoAdyacente
    {
        public Nodo Destino { get; set; }
        public bool EsPonderada { get; set; }
        public double? Peso { get; set; }

        public ElementoAdyacente(Nodo destino, bool esPonderada, double? peso)
        {
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            EsPonderada = esPonderada;
            Peso = esPonderada ? peso : null;
        }

        public override string ToString()
        {
            return EsPonderada ? $"{Destino.Nombre} (Peso: {Peso:0.##})" : $"{Destino.Nombre}";
        }
    }
}
