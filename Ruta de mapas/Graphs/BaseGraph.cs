using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Abstract base class defining the contract and shared behavior of a Graph,
    /// enabling inheritance and polymorphism across different underlying storage structures.
    /// </summary>
    public abstract class BaseGraph
    {
        public abstract string StructureTypeName { get; }

        public bool IsDirected { get; set; }
        public bool IsWeighted { get; set; }

        public abstract int VertexCount { get; }
        public abstract int EdgeCount { get; }

        protected BaseGraph(bool isDirected = false, bool isWeighted = false)
        {
            IsDirected = isDirected;
            IsWeighted = isWeighted;
        }

        public abstract bool AddVertex(string name, int? x, int? y, out string message);

        public bool AddVertex(string name, out string message)
        {
            return AddVertex(name, null, null, out message);
        }

        public abstract bool AddEdge(string originName, string destinationName, bool isWeighted, double? weight, out string message);

        public bool AddEdge(string originName, string destinationName, double weight, out string message)
        {
            return AddEdge(originName, destinationName, true, weight, out message);
        }

        public bool AddEdge(string originName, string destinationName, out string message)
        {
            return AddEdge(originName, destinationName, false, null, out message);
        }

        public abstract bool RemoveEdge(string originName, string destinationName, out string message);

        public abstract bool RemoveVertex(string name, out int orphanedEdges, out string message);

        public abstract bool AreAdjacent(string vertexAName, string vertexBName, out Edge? connectingEdge, out string message);

        public virtual List<Vertex> GetAdjacentVertices(string name)
        {
            List<AdjacentElement> detailedAdjacents = GetDetailedAdjacents(name);
            List<Vertex> neighbors = new List<Vertex>(detailedAdjacents.Count);
            for (int i = 0; i < detailedAdjacents.Count; i++)
            {
                neighbors.Add(detailedAdjacents[i].Destination);
            }
            return neighbors;
        }

        public abstract List<AdjacentElement> GetDetailedAdjacents(string name);

        public abstract string[,] GenerateTextAdjacencyMatrix(out string[] vertexNames);

        public virtual List<AdjacencyListEntry> GenerateAdjacencyList()
        {
            List<Vertex> allVertices = GetAllVertices();
            List<AdjacencyListEntry> adjacencyList = new List<AdjacencyListEntry>(allVertices.Count);

            for (int i = 0; i < allVertices.Count; i++)
            {
                Vertex vertex = allVertices[i];
                AdjacencyListEntry entry = new AdjacencyListEntry(vertex);
                List<AdjacentElement> detailedAdjacents = GetDetailedAdjacents(vertex.Name);
                for (int j = 0; j < detailedAdjacents.Count; j++)
                {
                    entry.Adjacents.Add(detailedAdjacents[j]);
                }
                adjacencyList.Add(entry);
            }

            return adjacencyList;
        }

        public abstract Vertex? FindVertex(string name);

        public abstract Vertex? FindVertexByCoordinates(int coordinateX, int coordinateY);

        public abstract List<Vertex> GetAllVertices();

        public abstract List<Edge> GetAllEdges();

        public abstract void ClearGraph();

        protected string BuildEdgeAddedMessage(string originName, string destinationName, bool isWeighted, double? weight)
        {
            if (isWeighted && weight.HasValue)
            {
                return IsDirected
                    ? string.Format(Messages.DirectedWeightedEdgeAdded, originName, destinationName, weight.Value)
                    : string.Format(Messages.UndirectedWeightedEdgeAdded, originName, destinationName, weight.Value);
            }

            return IsDirected
                ? string.Format(Messages.DirectedUnweightedEdgeAdded, originName, destinationName)
                : string.Format(Messages.UndirectedUnweightedEdgeAdded, originName, destinationName);
        }

        protected string BuildAdjacencyMessage(string vertexAName, string vertexBName, Edge? connectingEdge)
        {
            if (connectingEdge != null)
            {
                if (connectingEdge.IsWeighted && connectingEdge.Weight.HasValue)
                {
                    return IsDirected
                        ? string.Format(Messages.AdjacentDirectedWeighted, vertexAName, vertexBName, connectingEdge.Weight.Value)
                        : string.Format(Messages.AdjacentUndirectedWeighted, vertexAName, vertexBName, connectingEdge.Weight.Value);
                }

                return IsDirected
                    ? string.Format(Messages.AdjacentDirectedUnweighted, vertexAName, vertexBName)
                    : string.Format(Messages.AdjacentUndirectedUnweighted, vertexAName, vertexBName);
            }

            return IsDirected
                ? string.Format(Messages.NotAdjacentDirected, vertexAName, vertexBName)
                : string.Format(Messages.NotAdjacentUndirected, vertexAName, vertexBName);
        }
    }
}
