using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Nodo de enlace simple para la estructura personalizada ListaSimple{T}.
    /// </summary>
    /// <typeparam name="T">Tipo del elemento almacenado.</typeparam>
    public class NodoListaSimple<T>
    {
        public T Valor { get; set; }
        public NodoListaSimple<T>? Siguiente { get; set; }

        public NodoListaSimple(T valor, NodoListaSimple<T>? siguiente = null)
        {
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
            Siguiente = siguiente;
        }

        public override string ToString()
        {
            return Valor?.ToString() ?? string.Empty;
        }
    }
}
