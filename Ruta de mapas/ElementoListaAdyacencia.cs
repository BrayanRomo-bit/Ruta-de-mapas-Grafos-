using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Representa la entrada de un vértice y su lista de nodos adyacentes en la Lista de Adyacencia.
    /// </summary>
    public class ElementoListaAdyacencia
    {
        public Nodo Vertice { get; set; }
        public List<ElementoAdyacente> Adyacentes { get; } = new List<ElementoAdyacente>();

        public ElementoListaAdyacencia(Nodo vertice)
        {
            Vertice = vertice ?? throw new ArgumentNullException(nameof(vertice));
        }

        public string Formatear(bool forzarPonderado = false)
        {
            if (Adyacentes.Count == 0) return "∅ (Sin conexiones adyacentes)";

            return string.Join("  ➔  ", Adyacentes.Select(a =>
                (a.EsPonderada || forzarPonderado) && a.Peso.HasValue
                    ? $"[ {a.Destino.Nombre} | Peso: {a.Peso.Value:0.##} ]"
                    : $"[ {a.Destino.Nombre} ]"
            ));
        }
    }
}
