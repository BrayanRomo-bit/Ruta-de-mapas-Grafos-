namespace Ruta_de_mapas
{
    /// <summary>
    /// Constantes de mensajes del sistema para las operaciones del grafo.
    /// </summary>
    public static class Mensajes
    {
        public const string NombreVacio = "El nombre del vértice no puede estar vacío.";
        public const string VerticeYaExiste = "El vértice '{0}' ya existe.";
        public const string VerticeNoExiste = "Uno o ambos vértices no existen.";
        public const string VerticeObjetivoNoExiste = "El vértice '{0}' no existe.";
        public const string BucleNoPermitido = "No se permiten bucles de un nodo consigo mismo.";
        public const string AristaDirigidaYaExiste = "Ya existe una arista dirigida de '{0}' a '{1}'.";
        public const string AristaNoDirigidaYaExiste = "Ya existe una conexión entre '{0}' y '{1}'.";
        public const string AristaNoEncontrada = "No se encontró la arista especificada.";
        public const string VerticeAgregado = "Vértice '{0}' agregado exitosamente.";
        public const string ConexionDirigidaAgregada = "Conexión dirigida (->) agregada entre '{0}' y '{1}'.";
        public const string ConexionNoDirigidaAgregada = "Conexión no dirigida (<->) agregada entre '{0}' y '{1}'.";
        public const string ConexionDirigidaPonderadaAgregada = "Conexión dirigida (->) PONDERADA agregada de '{0}' a '{1}' con peso {2:0.##}.";
        public const string ConexionDirigidaNoPonderadaAgregada = "Conexión dirigida (->) NO PONDERADA agregada de '{0}' a '{1}'.";
        public const string ConexionNoDirigidaPonderadaAgregada = "Conexión no dirigida (<->) PONDERADA agregada entre '{0}' y '{1}' con peso {2:0.##}.";
        public const string ConexionNoDirigidaNoPonderadaAgregada = "Conexión no dirigida (<->) NO PONDERADA agregada entre '{0}' y '{1}'.";
        public const string AristaEliminada = "Arista entre '{0}' y '{1}' eliminada.";
        public const string VerticeEliminado = "Vértice '{0}' eliminado. Se limpiaron {1} aristas huérfanas vinculadas.";
        public const string SonAdyacentesDirigido = "SÍ SON ADYACENTES: Existe conexión dirigida de '{0}' a '{1}'.";
        public const string SonAdyacentesNoDirigido = "SÍ SON ADYACENTES: '{0}' y '{1}' están conectados.";
        public const string SonAdyacentesDirigidoPonderado = "SÍ SON ADYACENTES: Conexión dirigida '{0}' -> '{1}' (Ponderada, Peso: {2:0.##}).";
        public const string SonAdyacentesDirigidoNoPonderado = "SÍ SON ADYACENTES: Conexión dirigida '{0}' -> '{1}' (No ponderada).";
        public const string SonAdyacentesNoDirigidoPonderado = "SÍ SON ADYACENTES: '{0}' y '{1}' están conectados (Ponderada, Peso: {2:0.##}).";
        public const string SonAdyacentesNoDirigidoNoPonderado = "SÍ SON ADYACENTES: '{0}' y '{1}' están conectados (No ponderada).";
        public const string NoSonAdyacentesDirigido = "NO son adyacentes: No hay arista en el sentido '{0}' -> '{1}'.";
        public const string NoSonAdyacentesNoDirigido = "NO son adyacentes: No existe conexión entre '{0}' y '{1}'.";
    }
}
