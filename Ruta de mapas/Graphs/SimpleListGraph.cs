using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Graph implementation backed by a custom singly linked list (SimpleList{T}).
    /// Inherits from <see cref="BaseGraph"/> and implements its operations polymorphically.
    /// </summary>
    public class SimpleListGraph : BaseGraph
    {
        public override string StructureTypeName
        {
            get { return "Lista Simple Propia"; }
        }

        private readonly SimpleList<Vertex> vertices;
        private readonly SimpleList<Edge> edges;

        public SimpleList<Vertex> Vertices
        {
            get { return vertices; }
        }

        public SimpleList<Edge> Edges
        {
            get { return edges; }
        }

        public override int VertexCount
        {
            get { return vertices.Count; }
        }

        public override int EdgeCount
        {
            get { return edges.Count; }
        }

        public SimpleListGraph(bool isDirected = false, bool isWeighted = false)
            : base(isDirected, isWeighted)
        {
            vertices = new SimpleList<Vertex>();
            edges = new SimpleList<Edge>();
        }

        public override bool AddVertex(string name, int? x, int? y, out string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                message = Messages.EmptyVertexName;
                return false;
            }

            string cleanName = name.Trim();

            if (FindVertex(cleanName) != null)
            {
                message = string.Format(Messages.VertexAlreadyExists, cleanName);
                return false;
            }

            if (x.HasValue && y.HasValue)
            {
                vertices.Add(new Vertex(cleanName, x.Value, y.Value));
            }
            else if (x.HasValue || y.HasValue)
            {
                vertices.Add(new Vertex(cleanName, x ?? 0, y ?? 0));
            }
            else
            {
                vertices.Add(new Vertex(cleanName));
            }

            message = string.Format(Messages.VertexAdded, cleanName);
            return true;
        }

        public override bool AddEdge(string originName, string destinationName, bool isWeighted, double? weight, out string message)
        {
            Vertex? origin = FindVertex(originName);
            Vertex? destination = FindVertex(destinationName);

            if (origin == null || destination == null)
            {
                message = Messages.VertexDoesNotExist;
                return false;
            }

            if (origin.Equals(destination))
            {
                message = Messages.SelfLoopNotAllowed;
                return false;
            }

            if (isWeighted && !weight.HasValue)
            {
                message = Messages.WeightRequiredForWeightedEdge;
                return false;
            }

            bool exists = false;
            SimpleListNode<Edge>? current = edges.Head;

            while (current != null)
            {
                Edge edge = current.Value;
                if (IsDirected)
                {
                    if (edge.Origin.Equals(origin) && edge.Destination.Equals(destination))
                    {
                        exists = true;
                        break;
                    }
                }
                else
                {
                    bool normalConnection = edge.Origin.Equals(origin) && edge.Destination.Equals(destination);
                    bool reverseConnection = edge.Origin.Equals(destination) && edge.Destination.Equals(origin);

                    if (normalConnection || reverseConnection)
                    {
                        exists = true;
                        break;
                    }
                }
                current = current.Next;
            }

            if (exists)
            {
                message = IsDirected
                    ? string.Format(Messages.DirectedEdgeAlreadyExists, originName, destinationName)
                    : string.Format(Messages.UndirectedEdgeAlreadyExists, originName, destinationName);
                return false;
            }

            double? assignedWeight = isWeighted ? weight : null;
            edges.Add(new Edge(origin, destination, isWeighted, assignedWeight));
            message = BuildEdgeAddedMessage(originName, destinationName, isWeighted, assignedWeight);
            return true;
        }

        public override bool RemoveEdge(string originName, string destinationName, out string message)
        {
            Vertex? origin = FindVertex(originName);
            Vertex? destination = FindVertex(destinationName);

            if (origin == null || destination == null)
            {
                message = Messages.VertexDoesNotExist;
                return false;
            }

            Edge? edgeToRemove = null;
            SimpleListNode<Edge>? current = edges.Head;

            while (current != null)
            {
                Edge edge = current.Value;
                if (IsDirected)
                {
                    if (edge.Origin.Equals(origin) && edge.Destination.Equals(destination))
                    {
                        edgeToRemove = edge;
                        break;
                    }
                }
                else
                {
                    bool normalConnection = edge.Origin.Equals(origin) && edge.Destination.Equals(destination);
                    bool reverseConnection = edge.Origin.Equals(destination) && edge.Destination.Equals(origin);

                    if (normalConnection || reverseConnection)
                    {
                        edgeToRemove = edge;
                        break;
                    }
                }
                current = current.Next;
            }

            if (edgeToRemove == null)
            {
                message = Messages.EdgeNotFound;
                return false;
            }

            edges.Remove(edgeToRemove);
            message = string.Format(Messages.EdgeRemoved, originName, destinationName);
            return true;
        }

        public override bool RemoveVertex(string name, out int orphanedEdges, out string message)
        {
            orphanedEdges = 0;
            Vertex? targetVertex = FindVertex(name);

            if (targetVertex == null)
            {
                message = string.Format(Messages.TargetVertexDoesNotExist, name);
                return false;
            }

            List<Edge> edgesToRemove = new List<Edge>();
            SimpleListNode<Edge>? current = edges.Head;

            while (current != null)
            {
                Edge edge = current.Value;
                if (edge.Origin.Equals(targetVertex) || edge.Destination.Equals(targetVertex))
                {
                    edgesToRemove.Add(edge);
                }
                current = current.Next;
            }

            for (int i = 0; i < edgesToRemove.Count; i++)
            {
                if (edges.Remove(edgesToRemove[i]))
                {
                    orphanedEdges++;
                }
            }

            vertices.Remove(targetVertex);
            message = string.Format(Messages.VertexRemoved, name, orphanedEdges);
            return true;
        }

        public override bool AreAdjacent(string vertexAName, string vertexBName, out Edge? connectingEdge, out string message)
        {
            connectingEdge = null;
            Vertex? vertexA = FindVertex(vertexAName);
            Vertex? vertexB = FindVertex(vertexBName);

            if (vertexA == null || vertexB == null)
            {
                message = Messages.VertexDoesNotExist;
                return false;
            }

            SimpleListNode<Edge>? current = edges.Head;
            while (current != null)
            {
                Edge edge = current.Value;
                if (IsDirected)
                {
                    if (edge.Origin.Equals(vertexA) && edge.Destination.Equals(vertexB))
                    {
                        connectingEdge = edge;
                        break;
                    }
                }
                else
                {
                    bool normalConnection = edge.Origin.Equals(vertexA) && edge.Destination.Equals(vertexB);
                    bool reverseConnection = edge.Origin.Equals(vertexB) && edge.Destination.Equals(vertexA);

                    if (normalConnection || reverseConnection)
                    {
                        connectingEdge = edge;
                        break;
                    }
                }
                current = current.Next;
            }

            message = BuildAdjacencyMessage(vertexAName, vertexBName, connectingEdge);
            return connectingEdge != null;
        }

        public override List<AdjacentElement> GetDetailedAdjacents(string name)
        {
            Vertex? origin = FindVertex(name);
            if (origin == null) return new List<AdjacentElement>();

            List<AdjacentElement> neighbors = new List<AdjacentElement>();
            SimpleListNode<Edge>? current = edges.Head;

            while (current != null)
            {
                Edge edge = current.Value;
                if (IsDirected)
                {
                    if (edge.Origin.Equals(origin))
                    {
                        neighbors.Add(new AdjacentElement(edge.Destination, edge.IsWeighted, edge.Weight));
                    }
                }
                else
                {
                    if (edge.Origin.Equals(origin))
                    {
                        neighbors.Add(new AdjacentElement(edge.Destination, edge.IsWeighted, edge.Weight));
                    }
                    else if (edge.Destination.Equals(origin))
                    {
                        neighbors.Add(new AdjacentElement(edge.Origin, edge.IsWeighted, edge.Weight));
                    }
                }
                current = current.Next;
            }

            return neighbors;
        }

        public override string[,] GenerateTextAdjacencyMatrix(out string[] vertexNames)
        {
            int totalVertices = vertices.Count;
            vertexNames = new string[totalVertices];

            int index = 0;
            SimpleListNode<Vertex>? currentVertex = vertices.Head;
            while (currentVertex != null)
            {
                vertexNames[index] = currentVertex.Value.Name;
                index++;
                currentVertex = currentVertex.Next;
            }

            string[,] adjacencyMatrix = new string[totalVertices, totalVertices];
            for (int i = 0; i < totalVertices; i++)
            {
                for (int j = 0; j < totalVertices; j++)
                {
                    adjacencyMatrix[i, j] = "0";
                }
            }

            SimpleListNode<Edge>? currentEdge = edges.Head;
            while (currentEdge != null)
            {
                Edge edge = currentEdge.Value;
                int originIndex = vertices.IndexOf(edge.Origin);
                int destinationIndex = vertices.IndexOf(edge.Destination);

                if (originIndex != -1 && destinationIndex != -1)
                {
                    string value = (edge.IsWeighted && edge.Weight.HasValue)
                        ? edge.Weight.Value.ToString("0.##")
                        : "1";

                    adjacencyMatrix[originIndex, destinationIndex] = value;
                    if (!IsDirected)
                    {
                        adjacencyMatrix[destinationIndex, originIndex] = value;
                    }
                }
                currentEdge = currentEdge.Next;
            }

            return adjacencyMatrix;
        }

        public override int[,] GenerateAdjacencyMatrix(out string[] vertexNames)
        {
            int totalVertices = vertices.Count;
            vertexNames = new string[totalVertices];

            int index = 0;
            SimpleListNode<Vertex>? currentVertex = vertices.Head;
            while (currentVertex != null)
            {
                vertexNames[index] = currentVertex.Value.Name;
                index++;
                currentVertex = currentVertex.Next;
            }

            int[,] adjacencyMatrix = new int[totalVertices, totalVertices];
            SimpleListNode<Edge>? currentEdge = edges.Head;

            while (currentEdge != null)
            {
                Edge edge = currentEdge.Value;
                int originIndex = vertices.IndexOf(edge.Origin);
                int destinationIndex = vertices.IndexOf(edge.Destination);

                if (originIndex != -1 && destinationIndex != -1)
                {
                    int value = (edge.IsWeighted && edge.Weight.HasValue)
                        ? (int)Math.Round(edge.Weight.Value)
                        : 1;

                    adjacencyMatrix[originIndex, destinationIndex] = value;
                    if (!IsDirected)
                    {
                        adjacencyMatrix[destinationIndex, originIndex] = value;
                    }
                }
                currentEdge = currentEdge.Next;
            }

            return adjacencyMatrix;
        }

        public override Vertex? FindVertex(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            string searchName = name.Trim();

            SimpleListNode<Vertex>? current = vertices.Head;
            while (current != null)
            {
                if (string.Equals(current.Value.Name, searchName, StringComparison.OrdinalIgnoreCase))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        public override Vertex? FindVertexByCoordinates(int coordinateX, int coordinateY)
        {
            Vertex? foundVertex = null;
            SimpleListNode<Vertex>? current = vertices.Head;
            while (current != null)
            {
                if (current.Value.ContainsPoint(coordinateX, coordinateY))
                {
                    foundVertex = current.Value;
                }
                current = current.Next;
            }
            return foundVertex;
        }

        public override List<Vertex> GetAllVertices()
        {
            return vertices.ToList();
        }

        public override List<Edge> GetAllEdges()
        {
            return edges.ToList();
        }

        public override void ClearGraph()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
