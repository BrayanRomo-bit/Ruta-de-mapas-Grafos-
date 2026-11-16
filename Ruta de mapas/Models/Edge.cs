using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Represents an edge connecting two vertices in a graph.
    /// Supports weighted edges (with numeric weight) and unweighted edges (null weight).
    /// </summary>
    public class Edge : IEquatable<Edge>
    {
        public Vertex Origin { get; set; }
        public Vertex Destination { get; set; }

        /// <summary>
        /// Indicates whether this edge is weighted (has an assigned weight/cost).
        /// </summary>
        public bool IsWeighted { get; set; }

        /// <summary>
        /// Assigned weight value. Null when the edge is unweighted.
        /// </summary>
        public double? Weight { get; set; }

        public Edge(Vertex origin, Vertex destination, bool isWeighted, double? weight)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            IsWeighted = isWeighted;
            Weight = isWeighted ? weight : null;
        }

        public Edge(Vertex origin, Vertex destination, double? weight = null)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            if (weight.HasValue)
            {
                IsWeighted = true;
                Weight = weight.Value;
            }
            else
            {
                IsWeighted = false;
                Weight = null;
            }
        }

        public bool Equals(Edge? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Origin.Equals(other.Origin) && Destination.Equals(other.Destination);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Edge);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, Destination);
        }

        public override string ToString()
        {
            return IsWeighted && Weight.HasValue
                ? $"{Origin.Name} -> {Destination.Name} (Weighted, Weight: {Weight.Value:0.##})"
                : $"{Origin.Name} -> {Destination.Name} (Unweighted)";
        }
    }
}
