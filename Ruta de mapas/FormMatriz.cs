using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Ventana para visualizar la matriz de adyacencia
    /// distinguiendo aristas no ponderadas (valor 1) y aristas ponderadas (peso numérico).
    /// </summary>
    public partial class FormMatriz : Form
    {
        private const int AnchoVentanaPorDefecto = 640;
        private const int AltoVentanaPorDefecto = 470;
        private static readonly Color ColorFondoTabla = Color.FromArgb(248, 249, 250);

        // Estilos para arista no ponderada (1)
        private static readonly Color ColorCeldaNoPonderada = Color.FromArgb(224, 242, 254);
        private static readonly Color ColorTextoNoPonderada = Color.FromArgb(3, 105, 161);

        // Estilos para arista ponderada (peso)
        private static readonly Color ColorCeldaPonderada = Color.FromArgb(212, 239, 223);
        private static readonly Color ColorTextoPonderada = Color.FromArgb(20, 90, 50);

        private readonly IGrafo grafo;

        public FormMatriz(IGrafo grafo)
        {
            this.grafo = grafo ?? throw new ArgumentNullException(nameof(grafo));

            InitializeComponent();
            CargarDatosMatriz();
            ConfigurarEventos();
        }

        private void CargarDatosMatriz()
        {
            string tipoDirigido = grafo.EsDirigido ? "Grafo Dirigido" : "Grafo No Dirigido";
            this.Text = $"Matriz de Adyacencia ({tipoDirigido}) - [{grafo.NombreTipoEstructura}]";

            lblInfo.Text = $"📌 MATRIZ DE ADYACENCIA [{grafo.NombreTipoEstructura}]: \n• Celda con '1': Arista no ponderada (simple).\n• Celda con número: Arista ponderada con su peso. \n• Celda con '0': Sin arista. Matriz {(grafo.EsDirigido ? "asimétrica" : "simétrica")}.";

            string[,] matriz = grafo.GenerarMatrizAdyacenciaTexto(out string[] nombres);

            for (int i = 0; i < nombres.Length; i++)
            {
                dgv.Columns.Add($"col_{nombres[i]}", nombres[i]);
            }

            for (int i = 0; i < nombres.Length; i++)
            {
                int filaIdx = dgv.Rows.Add();
                dgv.Rows[filaIdx].HeaderCell.Value = nombres[i];

                for (int j = 0; j < nombres.Length; j++)
                {
                    string valor = matriz[i, j];
                    dgv.Rows[filaIdx].Cells[j].Value = valor;

                    if (valor == "0")
                    {
                        dgv.Rows[filaIdx].Cells[j].Style.ForeColor = Color.FromArgb(148, 163, 184);
                    }
                    else if (valor == "1")
                    {
                        // Arista no ponderada
                        dgv.Rows[filaIdx].Cells[j].Style.BackColor = ColorCeldaNoPonderada;
                        dgv.Rows[filaIdx].Cells[j].Style.ForeColor = ColorTextoNoPonderada;
                        dgv.Rows[filaIdx].Cells[j].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else
                    {
                        // Arista ponderada con peso numérico
                        dgv.Rows[filaIdx].Cells[j].Style.BackColor = ColorCeldaPonderada;
                        dgv.Rows[filaIdx].Cells[j].Style.ForeColor = ColorTextoPonderada;
                        dgv.Rows[filaIdx].Cells[j].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                }
            }
        }

        private void ConfigurarEventos()
        {
            btnVerLista.Click += (s, e) =>
            {
                this.Hide();
                new FormListaAdyacencia(grafo).ShowDialog();
                this.Close();
            };
        }
    }
}
