using System;
using System.Collections;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Implementación de una lista enlazada simple genérica propia (sin dependencias de System.Collections).
    /// </summary>
    /// <typeparam name="T">Tipo de dato de los elementos almacenados.</typeparam>
    public class ListaSimple<T> : IEnumerable<T>
    {
        private NodoListaSimple<T>? cabeza;
        private NodoListaSimple<T>? cola;
        private int conteo;

        public NodoListaSimple<T>? Cabeza => cabeza;
        public int Count => conteo;
        public bool EstaVacia => cabeza == null;

        public ListaSimple()
        {
            cabeza = null;
            cola = null;
            conteo = 0;
        }

        /// <summary>
        /// Agrega un elemento al final de la lista simple (O(1)).
        /// </summary>
        public void Add(T item)
        {
            NodoListaSimple<T> nuevo = new NodoListaSimple<T>(item);

            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola!.Siguiente = nuevo;
                cola = nuevo;
            }

            conteo++;
        }

        /// <summary>
        /// Elimina la primera ocurrencia del elemento especificado.
        /// </summary>
        public bool Remove(T item)
        {
            if (cabeza == null) return false;

            // Si es el primer elemento
            if (EqualityComparer<T>.Default.Equals(cabeza.Valor, item))
            {
                cabeza = cabeza.Siguiente;
                if (cabeza == null) cola = null;
                conteo--;
                return true;
            }

            NodoListaSimple<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (EqualityComparer<T>.Default.Equals(actual.Siguiente.Valor, item))
                {
                    if (ReferenceEquals(actual.Siguiente, cola))
                    {
                        cola = actual;
                    }
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    conteo--;
                    return true;
                }
                actual = actual.Siguiente;
            }

            return false;
        }

        /// <summary>
        /// Elimina todos los elementos que coincidan con el predicado dado y devuelve la cantidad eliminada.
        /// </summary>
        public int RemoveAll(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));
            if (cabeza == null) return 0;

            int eliminados = 0;

            // Eliminar desde el inicio mientras coincidan
            while (cabeza != null && match(cabeza.Valor))
            {
                cabeza = cabeza.Siguiente;
                conteo--;
                eliminados++;
            }

            if (cabeza == null)
            {
                cola = null;
                return eliminados;
            }

            NodoListaSimple<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (match(actual.Siguiente.Valor))
                {
                    if (ReferenceEquals(actual.Siguiente, cola))
                    {
                        cola = actual;
                    }
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    conteo--;
                    eliminados++;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }

            return eliminados;
        }

        /// <summary>
        /// Busca el primer elemento que cumpla con el predicado especificado.
        /// </summary>
        public T? Find(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                if (match(actual.Valor))
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }

            return default;
        }

        /// <summary>
        /// Busca el último elemento que cumpla con el predicado especificado.
        /// </summary>
        public T? FindLast(Predicate<T> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            T? ultimoEncontrado = default;
            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                if (match(actual.Valor))
                {
                    ultimoEncontrado = actual.Valor;
                }
                actual = actual.Siguiente;
            }

            return ultimoEncontrado;
        }

        /// <summary>
        /// Determina si un elemento está presente en la lista.
        /// </summary>
        public bool Contains(T item)
        {
            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                if (EqualityComparer<T>.Default.Equals(actual.Valor, item))
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        /// <summary>
        /// Obtiene el índice base cero de un elemento en la lista, o -1 si no existe.
        /// </summary>
        public int IndexOf(T item)
        {
            int indice = 0;
            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                if (EqualityComparer<T>.Default.Equals(actual.Valor, item))
                {
                    return indice;
                }
                indice++;
                actual = actual.Siguiente;
            }
            return -1;
        }

        /// <summary>
        /// Limpia por completo la lista simple.
        /// </summary>
        public void Clear()
        {
            cabeza = null;
            cola = null;
            conteo = 0;
        }

        /// <summary>
        /// Convierte los elementos de la lista en una List{T} de .NET estándar.
        /// </summary>
        public List<T> ToList()
        {
            List<T> resultado = new List<T>(conteo);
            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                resultado.Add(actual.Valor);
                actual = actual.Siguiente;
            }
            return resultado;
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodoListaSimple<T>? actual = cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
