using System.Collections.Generic;

namespace Ruta_de_mapas
{
    
    public interface IGrafo
    {
         /// Nombre descriptivo del tipo de lista o estructura subyacente.
         string NombreTipoEstructura { get; }

        bool EsDirigido { get; set; }
        bool EsPonderado { get; set; }

        IEnumerable<Nodo> Nodos { get; }
        IEnumerable<Arista> Aristas { get; }

        int Count { get; }
        int CantidadNodos { get; }
        int CantidadAristas { get; }

        // 4.2.2.1 Inserción
        bool AgregarVertice(string nombre, int x, int y, out string mensaje);
        bool AgregarArista(string nombreOrigen, string nombreDestino, bool esPonderada, double peso, out string mensaje);
        bool AgregarArista(string nombreOrigen, string nombreDestino, double peso, out string mensaje);
        bool AgregarArista(string nombreOrigen, string nombreDestino, out string mensaje);

        // 4.2.2.2 Eliminación
        bool EliminarArista(string nombreOrigen, string nombreDestino, out string mensaje);
        bool EliminarVertice(string nombre, out int aristasHuerfanas, out string mensaje);

        // 4.2.2.3 Adyacencia
        bool SonAdyacentes(string nombreA, string nombreB, out Arista? aristaConexion, out string mensaje);
        List<Nodo> ObtenerAdyacentes(string nombre);
        List<ElementoAdyacente> ObtenerAdyacentesDetallados(string nombre);

        // Representaciones
        string[,] GenerarMatrizAdyacenciaTexto(out string[] nombres);
        int[,] GenerarMatrizAdyacencia(out string[] nombres);
        List<ElementoListaAdyacencia> GenerarListaAdyacencia();

        // Búsqueda y utilidades
        Nodo? BuscarNodo(string nombre);
        Nodo? BuscarNodoPorCoordenadas(int px, int py);
        List<Nodo> ObtenerTodosLosNodos();
        List<Arista> ObtenerTodasLasAristas();
        void LimpiarGrafo();
        void CopiarDesde(IGrafo origen);
    }
}
