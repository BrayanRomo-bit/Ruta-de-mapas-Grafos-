using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Graph traversals: BFS (breadth-first, uses a QUEUE) and DFS (depth-first, uses a STACK).
    /// Both run in O(V + E) time and O(V + E) extra space.
    ///
    /// The traversal only READS the graph (GetAllVertices, GetAllEdges, IsDirected).
    /// It never adds, removes or changes vertices or edges, and it does not use
    /// GetAdjacentVertices / GetDetailedAdjacents (each call scans every edge, which would make
    /// the traversal O(V * E)).
    ///
    /// Plan:
    ///   1. Preparation, O(V + E): vertex name -> index, and the adjacency array "adjacency".
    ///   2. The traversal itself, O(V + E), reading the neighbors from adjacency[u].
    ///
    /// Neighbors are visited in the order the vertices were created.
    /// </summary>
    public static class TravesalAlgorithms
    {
        // ===============================================================
        //  BFS (breadth-first) with a QUEUE. The ORIGIN is the 'origin' parameter.
        // ===============================================================
        public static TraversalResult Bfs(BaseGraph graph, string origin)
        {
            // ---------- PREPARATION  O(V + E) ----------
            List<Vertex> vertices = graph.GetAllVertices();                         // O(V)
            int vertexCount = vertices.Count;
            Dictionary<string, int> indexByName = BuildIndex(vertices);             // O(V)
            int startIndex = IndexOf(indexByName, origin);                          // (1) here the origin is known
            List<int>[] adjacency = BuildAdjacency(graph, indexByName, vertexCount); // O(V + E)

            // ---------- BFS ----------
            int[] distance = new int[vertexCount];
            Array.Fill(distance, -1);                  // -1 = not visited
            List<string> order = new List<string>();
            Queue<int> queue = new Queue<int>();

            distance[startIndex] = 0;                  // (2) the origin is at distance 0
            queue.Enqueue(startIndex);                 // (3) the first element in the queue is the origin

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                order.Add(vertices[u].Name);
                foreach (int v in adjacency[u])
                {
                    if (distance[v] == -1)
                    {
                        distance[v] = distance[u] + 1;
                        queue.Enqueue(v);
                    }
                }
            }

            return BuildResult("BFS", vertices, startIndex, order, distance);
        }

        // ===============================================================
        //  DFS (depth-first), iterative, with a STACK. The ORIGIN is the 'origin' parameter.
        // ===============================================================
        public static TraversalResult Dfs(BaseGraph graph, string origin)
        {
            // ---------- PREPARATION  O(V + E) ----------
            List<Vertex> vertices = graph.GetAllVertices();
            int vertexCount = vertices.Count;
            Dictionary<string, int> indexByName = BuildIndex(vertices);
            int startIndex = IndexOf(indexByName, origin);                          // (1) here the origin is known
            List<int>[] adjacency = BuildAdjacency(graph, indexByName, vertexCount);

            // ---------- DFS ----------
            bool[] visited = new bool[vertexCount];
            List<string> order = new List<string>();
            Stack<int> stack = new Stack<int>();

            stack.Push(startIndex);                    // (2) the first element in the stack is the origin

            while (stack.Count > 0)
            {
                int u = stack.Pop();
                if (visited[u]) continue;              // duplicate: it is discarded
                visited[u] = true;
                order.Add(vertices[u].Name);

                // In reverse so the first neighbor ends up on top of the stack
                for (int i = adjacency[u].Count - 1; i >= 0; i--)
                {
                    int v = adjacency[u][i];
                    if (!visited[v]) stack.Push(v);
                }
            }

            return BuildResult("DFS", vertices, startIndex, order, null);
        }

        // ===============================================================
        //  PREPARATION (everything is O(V + E))
        // ===============================================================

        // vertex name -> position in the vertex list.  O(V)
        // Uses OrdinalIgnoreCase because that is how the Vertex class compares names.
        private static Dictionary<string, int> BuildIndex(List<Vertex> vertices)
        {
            Dictionary<string, int> indexByName = new Dictionary<string, int>(vertices.Count, StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < vertices.Count; i++)
            {
                indexByName[vertices[i].Name] = i;
            }
            return indexByName;
        }

        // Converts the received name into its position and checks that it exists.  O(1)
        private static int IndexOf(Dictionary<string, int> indexByName, string origin)
        {
            int startIndex;
            if (origin == null || !indexByName.TryGetValue(origin.Trim(), out startIndex))
            {
                throw new ArgumentException($"The vertex '{origin}' does not exist in the graph.");
            }
            return startIndex;
        }

        // Builds the adjacency array WITHOUT calling Sort() or GetAdjacentVertices(), to stay in O(V + E).
        //
        //   Step 1: the arcs (u -> v) are grouped by DESTINATION v.            O(V + E)
        //   Step 2: the destinations v = 0..V-1 are visited in order and each
        //           v is appended to adjacency[u]. Every adjacency[u] ends up
        //           ordered by vertex position without sorting.                  O(V + E)
        //
        // In an UNDIRECTED graph each edge produces two arcs: (u -> v) and (v -> u).
        private static List<int>[] BuildAdjacency(BaseGraph graph, Dictionary<string, int> indexByName, int vertexCount)
        {
            List<int>[] byDestination = new List<int>[vertexCount];
            for (int i = 0; i < vertexCount; i++) byDestination[i] = new List<int>();

            List<Edge> edges = graph.GetAllEdges();                                 // O(E)
            bool isDirected = graph.IsDirected;
            for (int i = 0; i < edges.Count; i++)
            {
                int u = indexByName[edges[i].Origin.Name];
                int v = indexByName[edges[i].Destination.Name];
                byDestination[v].Add(u);                                            // arc u -> v
                if (!isDirected) byDestination[u].Add(v);                           // undirected: also v -> u
            }

            List<int>[] adjacency = new List<int>[vertexCount];
            for (int i = 0; i < vertexCount; i++) adjacency[i] = new List<int>();

            for (int v = 0; v < vertexCount; v++)                                   // O(V)
            {
                foreach (int u in byDestination[v])                                 // O(E) in total
                {
                    adjacency[u].Add(v);
                }
            }
            return adjacency;
        }

        // ===============================================================
        //  RESULT (O(V))
        // ===============================================================
        private static TraversalResult BuildResult(string type, List<Vertex> vertices, int startIndex,
                                                   List<string> order, int[]? distance)
        {
            Dictionary<string, int> orderPosition = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < order.Count; i++)
            {
                orderPosition[order[i]] = i + 1;
            }

            Dictionary<string, int>? distances = null;
            if (distance != null)
            {
                distances = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (distance[i] != -1) distances[vertices[i].Name] = distance[i];
                }
            }

            List<string> unreached = new List<string>();
            for (int i = 0; i < vertices.Count; i++)
            {
                if (!orderPosition.ContainsKey(vertices[i].Name)) unreached.Add(vertices[i].Name);
            }

            return new TraversalResult(type, vertices[startIndex].Name, order, orderPosition, distances, unreached);
        }
    }
}