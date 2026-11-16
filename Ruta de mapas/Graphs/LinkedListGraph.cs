using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Graph implementation backed by .NET's doubly linked list collection (LinkedList{T}).
    /// Inherits from <see cref="BaseGraph"/> and implements its operations polymorphically.
    /// </summary>
    public class LinkedListGraph : BaseGraph
    {
        public override string StructureTypeName
        {
            get { return ".NET LinkedList<T>"; }
        }

        private readonly LinkedList<Vertex> vertices;
        private readonly LinkedList<Edge> edges;

        public LinkedList<Vertex> Vertices
        {
            get { return vertices; }
        }

        public LinkedList<Edge> Edges
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

        public LinkedListGraph(bool isDirected = false, bool isWeighted = false)
            : base(isDirected, isWeighted)
        {
            vertices = new LinkedList<Vertex>();
            edges = new LinkedList<Edge>();
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
                vertices.AddLast(new Vertex(cleanName, x.Value, y.Value));
            }
            else if (x.HasValue || y.HasValue)
            {
                vertices.AddLast(new Vertex(cleanName, x ?? 0, y ?? 0));
            }
            else
            {
                vertices.AddLast(new Vertex(cleanName));
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
            LinkedListNode<Edge>? current = edges.First;

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
            edges.AddLast(new Edge(origin, destination, isWeighted, assignedWeight));
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

            LinkedListNode<Edge>? nodeToRemove = null;
            LinkedListNode<Edge>? current = edges.First;

            while (current != null)
            {
                Edge edge = current.Value;
                if (IsDirected)
                {
                    if (edge.Origin.Equals(origin) && edge.Destination.Equals(destination))
                    {
                        nodeToRemove = current;
                        break;
                    }
                }
                else
                {
                    bool normalConnection = edge.Origin.Equals(origin) && edge.Destination.Equals(destination);
                    bool reverseConnection = edge.Origin.Equals(destination) && edge.Destination.Equals(origin);

                    if (normalConnection || reverseConnection)
                    {
                        nodeToRemove = current;
                        break;
                    }
                }
                current = current.Next;
            }

            if (nodeToRemove == null)
            {
                message = Messages.EdgeNotFound;
                return false;
            }

            edges.Remove(nodeToRemove);
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

            LinkedListNode<Edge>? current = edges.First;
            while (current != null)
            {
                LinkedListNode<Edge>? next = current.Next;
                Edge edge = current.Value;

                if (edge.Origin.Equals(targetVertex) || edge.Destination.Equals(targetVertex))
                {
                    edges.Remove(current);
                    orphanedEdges++;
                }

                current = next;
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

            LinkedListNode<Edge>? current = edges.First;
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
            LinkedListNode<Edge>? current = edges.First;

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

        private int GetVertexIndex(Vertex targetVertex)
        {
            int index = 0;
            LinkedListNode<Vertex>? current = vertices.First;
            while (current != null)
            {
                if (current.Value.Equals(targetVertex))
                {
                    return index;
                }
                index++;
                current = current.Next;
            }
            return -1;
        }

        public override string[,] GenerateTextAdjacencyMatrix(out string[] vertexNames)
        {
            int totalVertices = vertices.Count;
            vertexNames = new string[totalVertices];

            int index = 0;
            LinkedListNode<Vertex>? currentVertex = vertices.First;
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

            LinkedListNode<Edge>? currentEdge = edges.First;
            while (currentEdge != null)
            {
                Edge edge = currentEdge.Value;
                int originIndex = GetVertexIndex(edge.Origin);
                int destinationIndex = GetVertexIndex(edge.Destination);

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
            LinkedListNode<Vertex>? currentVertex = vertices.First;
            while (currentVertex != null)
            {
                vertexNames[index] = currentVertex.Value.Name;
                index++;
                currentVertex = currentVertex.Next;
            }

            int[,] adjacencyMatrix = new int[totalVertices, totalVertices];
            LinkedListNode<Edge>? currentEdge = edges.First;

            while (currentEdge != null)
            {
                Edge edge = currentEdge.Value;
                int originIndex = GetVertexIndex(edge.Origin);
                int destinationIndex = GetVertexIndex(edge.Destination);

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

            LinkedListNode<Vertex>? current = vertices.First;
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
            LinkedListNode<Vertex>? current = vertices.Last;
            while (current != null)
            {
                if (current.Value.ContainsPoint(coordinateX, coordinateY))
                {
                    return current.Value;
                }
                current = current.Previous;
            }
            return null;
        }

        public override List<Vertex> GetAllVertices()
        {
            List<Vertex> result = new List<Vertex>(vertices.Count);
            LinkedListNode<Vertex>? current = vertices.First;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }
            return result;
        }

        public override List<Edge> GetAllEdges()
        {
            List<Edge> result = new List<Edge>(edges.Count);
            LinkedListNode<Edge>? current = edges.First;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }
            return result;
        }

        public override void ClearGraph()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
