using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Ventana para visualizar la Lista de Adyacencia del grafo
    /// mostrando las conexiones encadenadas de cada vértice (con o sin pesos).
    /// </summary>
    public partial class FormListaAdyacencia : Form
    {
        private const int AnchoVentanaPorDefecto = 750;
        private const int AltoVentanaPorDefecto = 480;

        private readonly IGrafo grafo;

        public FormListaAdyacencia(IGrafo grafo)
        {
            this.grafo = grafo ?? throw new ArgumentNullException(nameof(grafo));

            InitializeComponent();
            CargarDatosLista();
            ConfigurarEventos();
        }

        private void CargarDatosLista()
        {
            string tipoDirigido = grafo.EsDirigido ? "Dirigido" : "No Dirigido";
            string tipoPonderado = grafo.EsPonderado ? "Ponderado" : "No Ponderado";

            this.Text = $"Lista de Adyacencia ({tipoDirigido} - {tipoPonderado}) - [{grafo.NombreTipoEstructura}]";

            lblInfo.Text = grafo.EsPonderado
                ? $"📌 LISTA DE ADYACENCIA PONDERADA [{grafo.NombreTipoEstructura}]: Estructura donde cada nodo origen contiene la lista de sus vecinos con sus respectivos pesos [ Vecino | Peso: W ]."
                : $"📌 LISTA DE ADYACENCIA SIMPLE [{grafo.NombreTipoEstructura}]: Estructura donde cada nodo contiene la lista de sus vértices vecinos directos [ Vecino ].";

            List<ElementoListaAdyacencia> listaAdy = grafo.GenerarListaAdyacencia();

            foreach (ElementoListaAdyacencia item in listaAdy)
            {
                string descCantidad = item.Adyacentes.Count == 1 ? "1 conexión" : $"{item.Adyacentes.Count} conexiones";
                string cadenaLista = item.Formatear(grafo.EsPonderado);

                int fila = dgv.Rows.Add(item.Vertice.Nombre, descCantidad, cadenaLista);

                if (item.Adyacentes.Count > 0)
                {
                    dgv.Rows[fila].Cells[0].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    dgv.Rows[fila].Cells[0].Style.ForeColor = Color.FromArgb(9, 132, 227);
                    dgv.Rows[fila].Cells[2].Style.ForeColor = Color.FromArgb(20, 90, 50);
                }
                else
                {
                    dgv.Rows[fila].Cells[2].Style.ForeColor = Color.FromArgb(148, 163, 184);
                }
            }
        }

        private void ConfigurarEventos()
        {
            btnVerMatriz.Click += (s, e) =>
            {
                this.Hide();
                new FormMatriz(grafo).ShowDialog();
                this.Close();
            };
        }
    }
}
