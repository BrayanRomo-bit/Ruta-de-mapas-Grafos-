using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Represents an adjacent vertex together with the weight information of the connecting edge.
    /// </summary>
    public class AdjacentElement
    {
        public Vertex Destination { get; set; }
        public bool IsWeighted { get; set; }
        public double? Weight { get; set; }

        public AdjacentElement(Vertex destination, bool isWeighted, double? weight)
        {
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            IsWeighted = isWeighted;
            Weight = isWeighted ? weight : null;
        }

        public override string ToString()
        {
            return IsWeighted && Weight.HasValue
                ? $"{Destination.Name} (Weight: {Weight.Value:0.##})"
                : $"{Destination.Name}";
        }
    }
}
