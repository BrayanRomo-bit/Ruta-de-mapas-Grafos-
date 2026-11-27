using System;
using System.Collections.Generic;

namespace Ruta_de_mapas.Tests
{
    public class GraphOperationsTests
    {
        public static IEnumerable<object[]> GraphFactories()
        {
            yield return new object[] { new Func<bool, bool, BaseGraph>((d, w) => new SimpleListGraph(d, w)) };
            yield return new object[] { new Func<bool, bool, BaseGraph>((d, w) => new LinkedListGraph(d, w)) };
            yield return new object[] { new Func<bool, bool, BaseGraph>((d, w) => new ListGraph(d, w)) };
        }

        [Theory]
        [MemberData(nameof(GraphFactories))]
        public void AddVertex_RejectsEmptyAndDuplicateNamesCaseInsensitive(Func<bool, bool, BaseGraph> createGraph)
        {
            BaseGraph graph = createGraph(false, false);

            Assert.False(graph.AddVertex("   ", out _));
            Assert.True(graph.AddVertex("Centro", 10, 20, out _));
            Assert.False(graph.AddVertex("centro", 30, 40, out _));
            Assert.Equal(1, graph.VertexCount);
        }

        [Theory]
        [MemberData(nameof(GraphFactories))]
        public void AddEdge_RejectsSelfLoopsAndDuplicates_RespectsDirectedMode(Func<bool, bool, BaseGraph> createGraph)
        {
            BaseGraph undirected = createGraph(false, false);
            undirected.AddVertex("A", out _);
            undirected.AddVertex("B", out _);

            Assert.False(undirected.AddEdge("A", "A", out _));
            Assert.True(undirected.AddEdge("A", "B", out _));
            Assert.False(undirected.AddEdge("B", "A", out _));
            Assert.Equal(1, undirected.EdgeCount);

            BaseGraph directed = createGraph(true, true);
            directed.AddVertex("A", out _);
            directed.AddVertex("B", out _);

            Assert.False(directed.AddEdge("A", "B", true, null, out _));
            Assert.True(directed.AddEdge("A", "B", 15, out _));
            Assert.True(directed.AddEdge("B", "A", 20, out _));
            Assert.False(directed.AddEdge("A", "B", 30, out _));
            Assert.Equal(2, directed.EdgeCount);
        }

        [Theory]
        [MemberData(nameof(GraphFactories))]
        public void RemoveVertex_RemovesOrphanedEdges(Func<bool, bool, BaseGraph> createGraph)
        {
            BaseGraph graph = createGraph(false, false);
            graph.AddVertex("A", out _);
            graph.AddVertex("B", out _);
            graph.AddVertex("C", out _);
            graph.AddEdge("A", "B", out _);
            graph.AddEdge("A", "C", out _);
            graph.AddEdge("B", "C", out _);

            Assert.True(graph.RemoveVertex("A", out int orphanedEdges, out _));
            Assert.Equal(2, orphanedEdges);
            Assert.Equal(2, graph.VertexCount);
            Assert.Equal(1, graph.EdgeCount);
            Assert.False(graph.AreAdjacent("A", "B", out _, out _));
            Assert.True(graph.AreAdjacent("B", "C", out _, out _));
        }

        [Theory]
        [MemberData(nameof(GraphFactories))]
        public void GenerateTextAdjacencyMatrix_And_AdjacencyList_ReflectWeightsAndDirection(Func<bool, bool, BaseGraph> createGraph)
        {
            BaseGraph graph = createGraph(true, true);
            graph.AddVertex("A", out _);
            graph.AddVertex("B", out _);
            graph.AddVertex("C", out _);
            graph.AddEdge("A", "B", 42, out _);
            graph.AddEdge("B", "C", out _);

            string[,] matrix = graph.GenerateTextAdjacencyMatrix(out string[] names);
            Assert.Equal(new[] { "A", "B", "C" }, names);
            Assert.Equal("42", matrix[0, 1]);
            Assert.Equal("0", matrix[1, 0]);
            Assert.Equal("1", matrix[1, 2]);
            Assert.Equal("0", matrix[2, 1]);

            List<AdjacencyListEntry> list = graph.GenerateAdjacencyList();
            Assert.Equal(3, list.Count);
            Assert.Single(list[0].Adjacents);
            Assert.Equal("B", list[0].Adjacents[0].Destination.Name);
            Assert.Equal(42, list[0].Adjacents[0].Weight);
            Assert.Empty(list[2].Adjacents);
        }
    }
}
