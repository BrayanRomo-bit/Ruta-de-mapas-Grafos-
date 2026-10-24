using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Implementación de Grafo basada en la colección doblemente enlazada estándar de .NET (LinkedList{T}).
    /// </summary>
    public class GrafoLinkedList : GrafoBase
    {
        public override string NombreTipoEstructura
        {
            get { return ".NET LinkedList<T>"; }
        }

        private readonly LinkedList<Nodo> nodos;
        private readonly LinkedList<Arista> aristas;

        public LinkedList<Nodo> NodosLinkedList
        {
            get { return nodos; }
        }

        public LinkedList<Arista> AristasLinkedList
        {
            get { return aristas; }
        }

        public override IEnumerable<Nodo> Nodos
        {
            get { return nodos; }
        }

        public override IEnumerable<Arista> Aristas
        {
            get { return aristas; }
        }

        public override int Count
        {
            get { return nodos.Count; }
        }

        public override int CantidadAristas
        {
            get { return aristas.Count; }
        }

        public GrafoLinkedList(bool esDirigido = false, bool esPonderado = false)
            : base(esDirigido, esPonderado)
        {
            nodos = new LinkedList<Nodo>();
            aristas = new LinkedList<Arista>();
        }

        protected override void InsertarNodoInterno(Nodo nodo)
        {
            nodos.AddLast(nodo);
        }

        protected override void InsertarAristaInterno(Arista arista)
        {
            aristas.AddLast(arista);
        }

        protected override bool EliminarAristaInterno(Arista arista)
        {
            return aristas.Remove(arista);
        }

        protected override int EliminarAristasVinculadasInterno(Nodo vertice)
        {
            int eliminadas = 0;
            LinkedListNode<Arista>? actual = aristas.First;
            while (actual != null)
            {
                LinkedListNode<Arista>? siguiente = actual.Next;
                Arista a = actual.Value;
                if (a.Origen.Equals(vertice) || a.Destino.Equals(vertice))
                {
                    aristas.Remove(actual);
                    eliminadas++;
                }
                actual = siguiente;
            }
            return eliminadas;
        }

        protected override bool EliminarNodoInterno(Nodo nodo)
        {
            return nodos.Remove(nodo);
        }

        protected override void LimpiarColeccionesInternas()
        {
            nodos.Clear();
            aristas.Clear();
        }

        public override Nodo? BuscarNodo(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            foreach (Nodo n in nodos)
            {
                if (string.Equals(n.Nombre, nombre.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return n;
                }
            }
            return null;
        }

        public override Nodo? BuscarNodoPorCoordenadas(int px, int py)
        {
            LinkedListNode<Nodo>? actual = nodos.Last;
            while (actual != null)
            {
                if (actual.Value.ContienePunto(px, py))
                {
                    return actual.Value;
                }
                actual = actual.Previous;
            }
            return null;
        }
    }
}
