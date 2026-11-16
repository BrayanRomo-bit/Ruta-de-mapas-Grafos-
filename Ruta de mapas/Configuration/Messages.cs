namespace Ruta_de_mapas
{
    /// <summary>
    /// System message constants for graph operations.
    /// </summary>
    public static class Messages
    {
        public const string EmptyVertexName = "El nombre del vértice no puede estar vacío.";
        public const string VertexAlreadyExists = "El vértice '{0}' ya existe.";
        public const string VertexDoesNotExist = "Uno o ambos vértices no existen.";
        public const string TargetVertexDoesNotExist = "El vértice '{0}' no existe.";
        public const string SelfLoopNotAllowed = "No se permiten bucles de un vértice consigo mismo.";
        public const string WeightRequiredForWeightedEdge = "Una arista ponderada requiere un peso numérico válido.";
        public const string DirectedEdgeAlreadyExists = "Ya existe una arista dirigida de '{0}' a '{1}'.";
        public const string UndirectedEdgeAlreadyExists = "Ya existe una conexión entre '{0}' y '{1}'.";
        public const string EdgeNotFound = "No se encontró la arista especificada.";
        public const string VertexAdded = "Vértice '{0}' agregado exitosamente.";
        public const string DirectedWeightedEdgeAdded = "Conexión dirigida (->) PONDERADA agregada de '{0}' a '{1}' con peso {2:0.##}.";
        public const string DirectedUnweightedEdgeAdded = "Conexión dirigida (->) NO PONDERADA agregada de '{0}' a '{1}'.";
        public const string UndirectedWeightedEdgeAdded = "Conexión no dirigida (<->) PONDERADA agregada entre '{0}' y '{1}' con peso {2:0.##}.";
        public const string UndirectedUnweightedEdgeAdded = "Conexión no dirigida (<->) NO PONDERADA agregada entre '{0}' y '{1}'.";
        public const string EdgeRemoved = "Arista entre '{0}' y '{1}' eliminada.";
        public const string VertexRemoved = "Vértice '{0}' eliminado. Se limpiaron {1} aristas huérfanas vinculadas.";
        public const string AdjacentDirectedWeighted = "SÍ SON ADYACENTES: Conexión dirigida '{0}' -> '{1}' (Ponderada, Peso: {2:0.##}).";
        public const string AdjacentDirectedUnweighted = "SÍ SON ADYACENTES: Conexión dirigida '{0}' -> '{1}' (No ponderada).";
        public const string AdjacentUndirectedWeighted = "SÍ SON ADYACENTES: '{0}' y '{1}' están conectados (Ponderada, Peso: {2:0.##}).";
        public const string AdjacentUndirectedUnweighted = "SÍ SON ADYACENTES: '{0}' y '{1}' están conectados (No ponderada).";
        public const string NotAdjacentDirected = "NO son adyacentes: No hay arista en el sentido '{0}' -> '{1}'.";
        public const string NotAdjacentUndirected = "NO son adyacentes: No existe conexión entre '{0}' y '{1}'.";
    }
}
