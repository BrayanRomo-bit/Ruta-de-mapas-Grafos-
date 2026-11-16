namespace Ruta_de_mapas
{
    /// <summary>
    /// Event categories for the application's graph operation log.
    /// </summary>
    public static class LogCategories
    {
        public const string Startup = "INICIO";
        public const string Insertion = "4.2.2.1 INSERCIÓN";
        public const string Deletion = "4.2.2.2 ELIMINACIÓN";
        public const string Orphaned = "HUÉRFANAS";
        public const string Adjacency = "4.2.2.3 ADYACENCIA";
        public const string Neighbors = "VECINOS";
        public const string GraphType = "TIPO GRAFO";
        public const string Clear = "LIMPIEZA";
    }
}
