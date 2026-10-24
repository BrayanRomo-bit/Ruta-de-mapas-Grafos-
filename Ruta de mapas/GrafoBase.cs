using System;
using System.Collections.Generic;

namespace Ruta_de_mapas
{ 
     public abstract class GrafoBase : IGrafo
    {
        public abstract string NombreTipoEstructura { get; }

        public bool EsDirigido { get; set; }
        public bool EsPonderado { get; set; }

        public abstract IEnumerable<Nodo> Nodos { get; }
        public abstract IEnumerable<Arista> Aristas { get; }

        public abstract int Count { get; }
        public int CantidadNodos
        {
            get { return Count; }
        }
        public abstract int CantidadAristas { get; }

        protected GrafoBase(bool esDirigido = false, bool esPonderado = false)
        {
            EsDirigido = esDirigido;
            EsPonderado = esPonderado;
        }

        protected abstract void InsertarNodoInterno(Nodo nodo);
        protected abstract void InsertarAristaInterno(Arista arista);
        protected abstract bool EliminarAristaInterno(Arista arista);
        protected abstract int EliminarAristasVinculadasInterno(Nodo vertice);
        protected abstract bool EliminarNodoInterno(Nodo nodo);
        protected abstract void LimpiarColeccionesInternas();

        public abstract Nodo? BuscarNodo(string nombre);
        public abstract Nodo? BuscarNodoPorCoordenadas(int px, int py);

        public virtual bool AgregarVertice(string nombre, int x, int y, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                mensaje = Mensajes.NombreVacio;
                return false;
            }

            nombre = nombre.Trim();

            if (BuscarNodo(nombre) != null)
            {
                mensaje = string.Format(Mensajes.VerticeYaExiste, nombre);
                return false;
            }

            InsertarNodoInterno(new Nodo(nombre, x, y));
            mensaje = string.Format(Mensajes.VerticeAgregado, nombre);
            return true;
        }

        public virtual bool AgregarArista(string nombreOrigen, string nombreDestino, bool esPonderada, double peso, out string mensaje)
        {
            Nodo? origen = BuscarNodo(nombreOrigen);
            Nodo? destino = BuscarNodo(nombreDestino);

            if (origen == null || destino == null)
            {
                mensaje = Mensajes.VerticeNoExiste;
                return false;
            }

            if (origen.Equals(destino))
            {
                mensaje = Mensajes.BucleNoPermitido;
                return false;
            }

            bool existe = false;

            foreach (Arista a in Aristas)
            {
                if (EsDirigido)
                {
                    if (a.Origen.Equals(origen) && a.Destino.Equals(destino))
                    {
                        existe = true;
                        break;
                    }
                }
                else
                {
                    bool conexionNormal = a.Origen.Equals(origen) && a.Destino.Equals(destino);
                    bool conexionInversa = a.Origen.Equals(destino) && a.Destino.Equals(origen);

                    if (conexionNormal || conexionInversa)
                    {
                        existe = true;
                        break;
                    }
                }
            }

            if (existe)
            {
                mensaje = EsDirigido
                    ? string.Format(Mensajes.AristaDirigidaYaExiste, nombreOrigen, nombreDestino)
                    : string.Format(Mensajes.AristaNoDirigidaYaExiste, nombreOrigen, nombreDestino);
                return false;
            }

            InsertarAristaInterno(new Arista(origen, destino, esPonderada, peso));

            if (esPonderada)
            {
                mensaje = EsDirigido
                    ? string.Format(Mensajes.ConexionDirigidaPonderadaAgregada, nombreOrigen, nombreDestino, peso)
                    : string.Format(Mensajes.ConexionNoDirigidaPonderadaAgregada, nombreOrigen, nombreDestino, peso);
            }
            else
            {
                mensaje = EsDirigido
                    ? string.Format(Mensajes.ConexionDirigidaNoPonderadaAgregada, nombreOrigen, nombreDestino)
                    : string.Format(Mensajes.ConexionNoDirigidaNoPonderadaAgregada, nombreOrigen, nombreDestino);
            }

            return true;
        }

        public bool AgregarArista(string nombreOrigen, string nombreDestino, double peso, out string mensaje)
        {
            return AgregarArista(nombreOrigen, nombreDestino, true, peso, out mensaje);
        }

        public bool AgregarArista(string nombreOrigen, string nombreDestino, out string mensaje)
        {
            return AgregarArista(nombreOrigen, nombreDestino, false, 1.0, out mensaje);
        }

        public virtual bool EliminarArista(string nombreOrigen, string nombreDestino, out string mensaje)
        {
            Nodo? origen = BuscarNodo(nombreOrigen);
            Nodo? destino = BuscarNodo(nombreDestino);

            if (origen == null || destino == null)
            {
                mensaje = Mensajes.VerticeNoExiste;
                return false;
            }

            Arista? aristaAEliminar = null;

            foreach (Arista a in Aristas)
            {
                if (EsDirigido)
                {
                    if (a.Origen.Equals(origen) && a.Destino.Equals(destino))
                    {
                        aristaAEliminar = a;
                        break;
                    }
                }
                else
                {
                    bool conexionNormal = a.Origen.Equals(origen) && a.Destino.Equals(destino);
                    bool conexionInversa = a.Origen.Equals(destino) && a.Destino.Equals(origen);

                    if (conexionNormal || conexionInversa)
                    {
                        aristaAEliminar = a;
                        break;
                    }
                }
            }

            if (aristaAEliminar == null)
            {
                mensaje = Mensajes.AristaNoEncontrada;
                return false;
            }

            EliminarAristaInterno(aristaAEliminar);
            mensaje = string.Format(Mensajes.AristaEliminada, nombreOrigen, nombreDestino);
            return true;
        }

        public virtual bool EliminarVertice(string nombre, out int aristasHuerfanas, out string mensaje)
        {
            aristasHuerfanas = 0;
            Nodo? objetivo = BuscarNodo(nombre);

            if (objetivo == null)
            {
                mensaje = string.Format(Mensajes.VerticeObjetivoNoExiste, nombre);
                return false;
            }

            aristasHuerfanas = EliminarAristasVinculadasInterno(objetivo);
            EliminarNodoInterno(objetivo);

            mensaje = string.Format(Mensajes.VerticeEliminado, nombre, aristasHuerfanas);
            return true;
        }    

        public virtual bool SonAdyacentes(string nombreA, string nombreB, out Arista? aristaConexion, out string mensaje)
        {
            aristaConexion = null;
            Nodo? a = BuscarNodo(nombreA);
            Nodo? b = BuscarNodo(nombreB);

            if (a == null || b == null)
            {
                mensaje = Mensajes.VerticeNoExiste;
                return false;
            }

            foreach (Arista ar in Aristas)
            {
                if (EsDirigido)
                {
                    if (ar.Origen.Equals(a) && ar.Destino.Equals(b))
                    {
                        aristaConexion = ar;
                        break;
                    }
                }
                else
                {
                    bool conexionNormal = ar.Origen.Equals(a) && ar.Destino.Equals(b);
                    bool conexionInversa = ar.Origen.Equals(b) && ar.Destino.Equals(a);

                    if (conexionNormal || conexionInversa)
                    {
                        aristaConexion = ar;
                        break;
                    }
                }
            }

            if (aristaConexion != null)
            {
                if (aristaConexion.EsPonderada && aristaConexion.Peso.HasValue)
                {
                    mensaje = EsDirigido
                        ? string.Format(Mensajes.SonAdyacentesDirigidoPonderado, nombreA, nombreB, aristaConexion.Peso.Value)
                        : string.Format(Mensajes.SonAdyacentesNoDirigidoPonderado, nombreA, nombreB, aristaConexion.Peso.Value);
                }
                else
                {
                    mensaje = EsDirigido
                        ? string.Format(Mensajes.SonAdyacentesDirigidoNoPonderado, nombreA, nombreB)
                        : string.Format(Mensajes.SonAdyacentesNoDirigidoNoPonderado, nombreA, nombreB);
                }
                return true;
            }

            mensaje = EsDirigido
                ? string.Format(Mensajes.NoSonAdyacentesDirigido, nombreA, nombreB)
                : string.Format(Mensajes.NoSonAdyacentesNoDirigido, nombreA, nombreB);

            return false;
        }

        public virtual List<Nodo> ObtenerAdyacentes(string nombre)
        {
            List<ElementoAdyacente> detallados = ObtenerAdyacentesDetallados(nombre);
            List<Nodo> vecinos = new List<Nodo>(detallados.Count);
            foreach (ElementoAdyacente elemento in detallados)
            {
                vecinos.Add(elemento.Destino);
            }
            return vecinos;
        }

        public virtual List<ElementoAdyacente> ObtenerAdyacentesDetallados(string nombre)
        {
            Nodo? origen = BuscarNodo(nombre);
            if (origen == null) return new List<ElementoAdyacente>();

            List<ElementoAdyacente> vecinos = new List<ElementoAdyacente>();
            foreach (Arista a in Aristas)
            {
                if (EsDirigido)
                {
                    if (a.Origen.Equals(origen))
                    {
                        vecinos.Add(new ElementoAdyacente(a.Destino, a.EsPonderada, a.Peso));
                    }
                }
                else
                {
                    if (a.Origen.Equals(origen))
                    {
                        vecinos.Add(new ElementoAdyacente(a.Destino, a.EsPonderada, a.Peso));
                    }
                    else if (a.Destino.Equals(origen))
                    {
                        vecinos.Add(new ElementoAdyacente(a.Origen, a.EsPonderada, a.Peso));
                    }
                }
            }

            return vecinos;
        }

        public virtual string[,] GenerarMatrizAdyacenciaTexto(out string[] nombres)
        {
            List<Nodo> listaNodos = ObtenerTodosLosNodos();
            nombres = new string[listaNodos.Count];
            for (int i = 0; i < listaNodos.Count; i++)
            {
                nombres[i] = listaNodos[i].Nombre;
            }

            int total = listaNodos.Count;
            string[,] matriz = new string[total, total];

            for (int i = 0; i < total; i++)
            {
                for (int j = 0; j < total; j++)
                {
                    matriz[i, j] = "0";
                }
            }

            foreach (Arista a in Aristas)
            {
                int idxOrigen = listaNodos.IndexOf(a.Origen);
                int idxDestino = listaNodos.IndexOf(a.Destino);

                if (idxOrigen != -1 && idxDestino != -1)
                {
                    string valor;
                    if (a.EsPonderada && a.Peso.HasValue)
                    {
                        valor = a.Peso.Value.ToString("0.##");
                    }
                    else
                    {
                        valor = "1";
                    }

                    matriz[idxOrigen, idxDestino] = valor;
                    if (!EsDirigido)
                    {
                        matriz[idxDestino, idxOrigen] = valor;
                    }
                }
            }

            return matriz;
        }

        public virtual int[,] GenerarMatrizAdyacencia(out string[] nombres)
        {
            List<Nodo> listaNodos = ObtenerTodosLosNodos();
            nombres = new string[listaNodos.Count];
            for (int i = 0; i < listaNodos.Count; i++)
            {
                nombres[i] = listaNodos[i].Nombre;
            }

            int total = listaNodos.Count;
            int[,] matriz = new int[total, total];

            foreach (Arista a in Aristas)
            {
                int idxOrigen = listaNodos.IndexOf(a.Origen);
                int idxDestino = listaNodos.IndexOf(a.Destino);

                if (idxOrigen != -1 && idxDestino != -1)
                {
                    int valor;
                    if (a.EsPonderada && a.Peso.HasValue)
                    {
                        valor = (int)Math.Round(a.Peso.Value);
                    }
                    else
                    {
                        valor = 1;
                    }

                    matriz[idxOrigen, idxDestino] = valor;
                    if (!EsDirigido)
                    {
                        matriz[idxDestino, idxOrigen] = valor;
                    }
                }
            }

            return matriz;
        }

        public virtual List<ElementoListaAdyacencia> GenerarListaAdyacencia()
        {
            List<ElementoListaAdyacencia> listaAdyacencia = new List<ElementoListaAdyacencia>();

            foreach (Nodo n in Nodos)
            {
                ElementoListaAdyacencia item = new ElementoListaAdyacencia(n);
                List<ElementoAdyacente> detallados = ObtenerAdyacentesDetallados(n.Nombre);
                foreach (ElementoAdyacente det in detallados)
                {
                    item.Adyacentes.Add(det);
                }
                listaAdyacencia.Add(item);
            }

            return listaAdyacencia;
        }

        public virtual List<Nodo> ObtenerTodosLosNodos()
        {
            List<Nodo> resultado = new List<Nodo>();
            foreach (Nodo n in Nodos)
            {
                resultado.Add(n);
            }
            return resultado;
        }

        public virtual List<Arista> ObtenerTodasLasAristas()
        {
            List<Arista> resultado = new List<Arista>();
            foreach (Arista a in Aristas)
            {
                resultado.Add(a);
            }
            return resultado;
        }

        public virtual void LimpiarGrafo()
        {
            LimpiarColeccionesInternas();
        }

        public virtual void CopiarDesde(IGrafo origen)
        {
            if (origen == null) return;

            LimpiarGrafo();
            EsDirigido = origen.EsDirigido;
            EsPonderado = origen.EsPonderado;

            foreach (Nodo n in origen.Nodos)
            {
                AgregarVertice(n.Nombre, n.X, n.Y, out _);
            }

            foreach (Arista a in origen.Aristas)
            {
                double peso = a.Peso.HasValue ? a.Peso.Value : 1.0;
                AgregarArista(a.Origen.Nombre, a.Destino.Nombre, a.EsPonderada, peso, out _);
            }
        }
    }
}
