using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Implementación de Grafo basada en la estructura personalizada de Lista Simple Propia (ListaSimple{T}).
    /// </summary>
    public class GrafoListaSimple : GrafoBase
    {
        public override string NombreTipoEstructura
        {
            get { return "Lista Simple Propia"; }
        }

        private readonly ListaSimple<Nodo> nodos;
        private readonly ListaSimple<Arista> aristas;

        public ListaSimple<Nodo> NodosListaSimple
        {
            get { return nodos; }
        }

        public ListaSimple<Arista> AristasListaSimple
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

        public GrafoListaSimple(bool esDirigido = false, bool esPonderado = false)
            : base(esDirigido, esPonderado)
        {
            nodos = new ListaSimple<Nodo>();
            aristas = new ListaSimple<Arista>();
        }

        protected override void InsertarNodoInterno(Nodo nodo)
        {
            nodos.Add(nodo);
        }

        protected override void InsertarAristaInterno(Arista arista)
        {
            aristas.Add(arista);
        }

        protected override bool EliminarAristaInterno(Arista arista)
        {
            return aristas.Remove(arista);
        }

        protected override int EliminarAristasVinculadasInterno(Nodo vertice)
        {
            int eliminadas = 0;
            List<Arista> paraEliminar = new List<Arista>();
            foreach (Arista a in aristas)
            {
                if (a.Origen.Equals(vertice) || a.Destino.Equals(vertice))
                {
                    paraEliminar.Add(a);
                }
            }
            foreach (Arista a in paraEliminar)
            {
                if (aristas.Remove(a))
                {
                    eliminadas++;
                }
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
            string buscado = nombre.Trim();
            foreach (Nodo n in nodos)
            {
                if (string.Equals(n.Nombre, buscado, StringComparison.OrdinalIgnoreCase))
                {
                    return n;
                }
            }
            return null;
        }

        public override Nodo? BuscarNodoPorCoordenadas(int px, int py)
        {
            Nodo? encontrado = null;
            foreach (Nodo n in nodos)
            {
                if (n.ContienePunto(px, py))
                {
                    encontrado = n;
                }
            }
            return encontrado;
        }
    }
}
