using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Represents a vertex entry and its list of adjacent vertices in the Adjacency List.
    /// </summary>
    public class AdjacencyListEntry
    {
        public Vertex Vertex { get; set; }
        public List<AdjacentElement> Adjacents { get; } = new List<AdjacentElement>();

        public AdjacencyListEntry(Vertex vertex)
        {
            Vertex = vertex ?? throw new ArgumentNullException(nameof(vertex));
        }

        public string Format(bool forceWeighted = false)
        {
            if (Adjacents.Count == 0) return "∅ (Sin conexiones adyacentes)";

            List<string> parts = new List<string>(Adjacents.Count);
            for (int i = 0; i < Adjacents.Count; i++)
            {
                AdjacentElement adjacent = Adjacents[i];
                if ((adjacent.IsWeighted || forceWeighted) && adjacent.Weight.HasValue)
                {
                    parts.Add($"[ {adjacent.Destination.Name} | Peso: {adjacent.Weight.Value:0.##} ]");
                }
                else
                {
                    parts.Add($"[ {adjacent.Destination.Name} ]");
                }
            }

            return string.Join("  ➔  ", parts);
        }
    }
}
