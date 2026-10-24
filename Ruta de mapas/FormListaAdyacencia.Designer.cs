using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    partial class FormListaAdyacencia
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblInfo;
        private DataGridView dgv;
        private Panel panelFooter;
        private Button btnVerMatriz;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblInfo = new Label();
            dgv = new DataGridView();
            panelFooter = new Panel();
            btnVerMatriz = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(241, 245, 249);
            panelHeader.Controls.Add(lblInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 65;
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(12, 10, 12, 10);
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
            lblInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblInfo.Name = "lblInfo";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgv.BorderStyle = BorderStyle.None;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.Padding = new Padding(4);
            dgv.RowTemplate.Height = 34;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVertice",
                HeaderText = "Vértice",
                FillWeight = 20
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Grado / Conexiones",
                FillWeight = 25
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLista",
                HeaderText = "Nodos Adyacentes (Lista Enlazada)",
                FillWeight = 55
            });
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnVerMatriz);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 48;
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10, 6, 10, 6);
            // 
            // btnVerMatriz
            // 
            btnVerMatriz.BackColor = Color.FromArgb(0, 184, 148);
            btnVerMatriz.Cursor = Cursors.Hand;
            btnVerMatriz.Dock = DockStyle.Right;
            btnVerMatriz.FlatStyle = FlatStyle.Flat;
            btnVerMatriz.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnVerMatriz.ForeColor = Color.White;
            btnVerMatriz.Name = "btnVerMatriz";
            btnVerMatriz.Text = "📊 Ver Matriz de Adyacencia";
            btnVerMatriz.UseVisualStyleBackColor = false;
            btnVerMatriz.Width = 200;
            // 
            // FormListaAdyacencia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(AnchoVentanaPorDefecto, AltoVentanaPorDefecto);
            MinimumSize = new Size(520, 360);
            Controls.Add(dgv);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Name = "FormListaAdyacencia";
            StartPosition = FormStartPosition.CenterParent;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
