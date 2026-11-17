using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Result of a graph traversal (BFS or DFS) started from an origin vertex.
    /// </summary>
    public class TraversalResult
    {
        /// <summary>"BFS" or "DFS".</summary>
        public string Type { get; }

        /// <summary>Name of the vertex where the traversal started.</summary>
        public string Origin { get; }

        /// <summary>Vertex names in the order they were visited.</summary>
        public List<string> Order { get; }

        /// <summary>Vertex name -> visit position (1, 2, 3...). Used to draw the badges on the canvas.</summary>
        public Dictionary<string, int> OrderPosition { get; }

        /// <summary>BFS only: vertex name -> minimum number of edges from the origin. Null for DFS.</summary>
        public Dictionary<string, int>? Distances { get; }

        /// <summary>Vertices that cannot be reached from the origin.</summary>
        public List<string> Unreached { get; }

        public TraversalResult(string type, string origin, List<string> order,
                               Dictionary<string, int> orderPosition,
                               Dictionary<string, int>? distances,
                               List<string> unreached)
        {
            Type = type;
            Origin = origin;
            Order = order;
            OrderPosition = orderPosition;
            Distances = distances;
            Unreached = unreached;
        }
    }
}