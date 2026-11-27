using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Window to display the graph's adjacency matrix,
    /// distinguishing unweighted edges (value 1) and weighted edges (numeric weight).
    /// </summary>
    public partial class AdjacencyMatrixForm : Form
    {
        private const int DefaultWindowWidth = 640;
        private const int DefaultWindowHeight = 470;
        private static readonly Color TableBackgroundColor = Color.FromArgb(248, 249, 250);

        private readonly BaseGraph currentGraph;

        public AdjacencyMatrixForm(BaseGraph graph)
        {
            currentGraph = graph ?? throw new ArgumentNullException(nameof(graph));
            InitializeComponent();
            string[,] adjacencyMatrix = currentGraph.GenerateTextAdjacencyMatrix(out string[] vertexNames);
            LoadMatrixData(currentGraph.IsDirected, currentGraph.StructureTypeName, adjacencyMatrix, vertexNames);
            btnViewAdjacencyList.Click += BtnViewAdjacencyList_Click;
        }

        private void LoadMatrixData(bool isDirected, string structureName, string[,] adjacencyMatrix, string[] vertexNames)
        {
            string directedLabel = isDirected ? "Grafo Dirigido" : "Grafo No Dirigido";
            this.Text = $"Matriz de Adyacencia ({directedLabel}) - [{structureName}]";

            lblMatrixInfo.Text = $"MATRIZ DE ADYACENCIA [{structureName}]: \n• Celda con '1': Arista no ponderada (simple).\n• Celda con número: Arista ponderada con su peso. \n• Celda con '0': Sin arista. Matriz {(isDirected ? "asimétrica" : "simétrica")}.";

            for (int i = 0; i < vertexNames.Length; i++)
            {
                dgvAdjacencyMatrix.Columns.Add($"col_{vertexNames[i]}", vertexNames[i]);
            }

            for (int i = 0; i < vertexNames.Length; i++)
            {
                int rowIndex = dgvAdjacencyMatrix.Rows.Add();
                dgvAdjacencyMatrix.Rows[rowIndex].HeaderCell.Value = vertexNames[i];

                for (int j = 0; j < vertexNames.Length; j++)
                {
                    string value = adjacencyMatrix[i, j];
                    dgvAdjacencyMatrix.Rows[rowIndex].Cells[j].Value = value;

                    if (value != "0")
                    {
                        dgvAdjacencyMatrix.Rows[rowIndex].Cells[j].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }
            }
        }

        private void BtnViewAdjacencyList_Click(object? sender, EventArgs e)
        {
            this.Hide();
            new AdjacencyListForm(currentGraph).ShowDialog();
            this.Close();
        }
    }
}
