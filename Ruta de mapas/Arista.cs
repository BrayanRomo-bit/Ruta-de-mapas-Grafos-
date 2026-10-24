using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Representa una arista (conexión) entre dos vértices.
    /// Soporta explícitamente aristas ponderadas (con peso numérico) y no ponderadas.
    /// </summary>
    public class Arista : IEquatable<Arista>
    {
        public Nodo Origen { get; set; }
        public Nodo Destino { get; set; }
         
        public bool EsPonderada { get; set; }
         
        public double? Peso { get; set; }

        public Arista(Nodo origen, Nodo destino, bool esPonderada, double peso)
        {
            Origen = origen ?? throw new ArgumentNullException(nameof(origen));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            EsPonderada = esPonderada;
            Peso = esPonderada ? peso : null;
        }

        public Arista(Nodo origen, Nodo destino, double? peso = null)
        {
            Origen = origen ?? throw new ArgumentNullException(nameof(origen));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            if (peso.HasValue)
            {
                EsPonderada = true;
                Peso = peso.Value;
            }
            else
            {
                EsPonderada = false;
                Peso = null;
            }
        }

        public bool Equals(Arista? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Origen.Equals(other.Origen) && Destino.Equals(other.Destino);
        }

        public override bool Equals(object? obj) => Equals(obj as Arista);

        public override int GetHashCode() => HashCode.Combine(Origen, Destino);

        public override string ToString()
        {
            return EsPonderada
                ? $"{Origen.Nombre} -> {Destino.Nombre} (Ponderada, Peso: {Peso:0.##})"
                : $"{Origen.Nombre} -> {Destino.Nombre} (No Ponderada)";
        }
    }
}
