using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Window to display the graph's Adjacency List,
    /// showing the chained connections of each vertex (with or without weights).
    /// </summary>
    public partial class AdjacencyListForm : Form
    {
        private const int DefaultWindowWidth = 750;
        private const int DefaultWindowHeight = 480;

        private readonly BaseGraph currentGraph;

        public AdjacencyListForm(BaseGraph graph)
        {
            currentGraph = graph ?? throw new ArgumentNullException(nameof(graph));
            InitializeComponent();
            LoadListData(currentGraph.IsDirected, currentGraph.IsWeighted, currentGraph.StructureTypeName, currentGraph.GenerateAdjacencyList());
            btnViewAdjacencyMatrix.Click += BtnViewAdjacencyMatrix_Click;
        }

        private void LoadListData(bool isDirected, bool isWeighted, string structureName, List<AdjacencyListEntry> adjacencyList)
        {
            string directedLabel = isDirected ? "Dirigido" : "No Dirigido";
            string weightedLabel = isWeighted ? "Ponderado" : "No Ponderado";

            this.Text = $"Lista de Adyacencia ({directedLabel} - {weightedLabel}) - [{structureName}]";

            lblAdjacencyListInfo.Text = isWeighted
                ? $"📌 LISTA DE ADYACENCIA PONDERADA [{structureName}]: Estructura donde cada vértice origen contiene la lista de sus adyacentes con sus respectivos pesos [ Vecino | Peso: W ]."
                : $"📌 LISTA DE ADYACENCIA SIMPLE [{structureName}]: Estructura donde cada vértice contiene la lista de sus vértices adyacentes directos [ Vecino ].";

            for (int i = 0; i < adjacencyList.Count; i++)
            {
                AdjacencyListEntry entry = adjacencyList[i];
                string degreeDescription = entry.Adjacents.Count == 1 ? "1 conexión" : $"{entry.Adjacents.Count} conexiones";
                string formattedList = entry.Format(isWeighted);

                int rowIndex = dgvAdjacencyList.Rows.Add(entry.Vertex.Name, degreeDescription, formattedList);

                if (entry.Adjacents.Count > 0)
                {
                    dgvAdjacencyList.Rows[rowIndex].Cells[0].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    dgvAdjacencyList.Rows[rowIndex].Cells[0].Style.ForeColor = Color.FromArgb(9, 132, 227);
                    dgvAdjacencyList.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(20, 90, 50);
                }
                else
                {
                    dgvAdjacencyList.Rows[rowIndex].Cells[2].Style.ForeColor = Color.FromArgb(148, 163, 184);
                }
            }
        }

        private void BtnViewAdjacencyMatrix_Click(object? sender, EventArgs e)
        {
            this.Hide();
            new AdjacencyMatrixForm(currentGraph).ShowDialog();
            this.Close();
        }
    }
}
