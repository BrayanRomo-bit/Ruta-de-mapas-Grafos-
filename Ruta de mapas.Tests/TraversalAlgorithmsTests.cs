using System;

namespace Ruta_de_mapas.Tests
{
    public class TraversalAlgorithmsTests
    {
        [Fact]
        public void Bfs_ComputesOrderDistancesAndUnreachedVertices()
        {
            BaseGraph graph = new ListGraph(isDirected: false, isWeighted: false);
            graph.AddVertex("A", out _);
            graph.AddVertex("B", out _);
            graph.AddVertex("C", out _);
            graph.AddVertex("D", out _);
            graph.AddVertex("Z", out _);

            graph.AddEdge("A", "B", out _);
            graph.AddEdge("A", "C", out _);
            graph.AddEdge("B", "D", out _);

            TraversalResult result = TraversalAlgorithms.Bfs(graph, "A");

            Assert.Equal("BFS", result.Type);
            Assert.Equal("A", result.Origin);
            Assert.Equal(new[] { "A", "B", "C", "D" }, result.Order);
            Assert.NotNull(result.Distances);
            Assert.Equal(0, result.Distances!["A"]);
            Assert.Equal(1, result.Distances["B"]);
            Assert.Equal(1, result.Distances["C"]);
            Assert.Equal(2, result.Distances["D"]);
            Assert.Equal(new[] { "Z" }, result.Unreached);
        }

        [Fact]
        public void Dfs_RespectsDirectedEdgesAndVisitsInCreationOrder()
        {
            BaseGraph graph = new SimpleListGraph(isDirected: true, isWeighted: false);
            graph.AddVertex("A", out _);
            graph.AddVertex("B", out _);
            graph.AddVertex("C", out _);
            graph.AddVertex("D", out _);

            graph.AddEdge("A", "B", out _);
            graph.AddEdge("A", "C", out _);
            graph.AddEdge("B", "D", out _);

            TraversalResult result = TraversalAlgorithms.Dfs(graph, "A");

            Assert.Equal("DFS", result.Type);
            Assert.Equal(new[] { "A", "B", "D", "C" }, result.Order);
            Assert.Null(result.Distances);
            Assert.Empty(result.Unreached);

            TraversalResult fromC = TraversalAlgorithms.Dfs(graph, "C");
            Assert.Equal(new[] { "C" }, fromC.Order);
            Assert.Equal(new[] { "A", "B", "D" }, fromC.Unreached);
        }

        [Fact]
        public void Traversal_ThrowsArgumentException_WhenOriginDoesNotExist()
        {
            BaseGraph graph = new LinkedListGraph();
            graph.AddVertex("A", out _);

            Assert.Throws<ArgumentException>(() => TraversalAlgorithms.Bfs(graph, "NoExiste"));
            Assert.Throws<ArgumentException>(() => TraversalAlgorithms.Dfs(graph, "NoExiste"));
        }
    }
}
