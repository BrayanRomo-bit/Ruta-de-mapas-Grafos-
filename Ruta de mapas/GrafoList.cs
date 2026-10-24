using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{ 
    public class GrafoList : GrafoBase
    {
        public override string NombreTipoEstructura
        {
            get { return ".NET List<T>"; }
        }

        private readonly List<Nodo> nodos;
        private readonly List<Arista> aristas;

        public List<Nodo> NodosList
        {
            get { return nodos; }
        }

        public List<Arista> AristasList
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

        public GrafoList(bool esDirigido = false, bool esPonderado = false)
            : base(esDirigido, esPonderado)
        {
            nodos = new List<Nodo>();
            aristas = new List<Arista>();
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
            for (int i = aristas.Count - 1; i >= 0; i--)
            {
                Arista a = aristas[i];
                if (a.Origen.Equals(vertice) || a.Destino.Equals(vertice))
                {
                    aristas.RemoveAt(i);
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
            for (int i = 0; i < nodos.Count; i++)
            {
                if (string.Equals(nodos[i].Nombre, buscado, StringComparison.OrdinalIgnoreCase))
                {
                    return nodos[i];
                }
            }
            return null;
        }

        public override Nodo? BuscarNodoPorCoordenadas(int px, int py)
        {
            for (int i = nodos.Count - 1; i >= 0; i--)
            {
                if (nodos[i].ContienePunto(px, py))
                {
                    return nodos[i];
                }
            }
            return null;
        }
    }
}
