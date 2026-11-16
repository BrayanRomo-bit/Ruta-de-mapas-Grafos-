using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    partial class AdjacencyListForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblAdjacencyListInfo;
        private DataGridView dgvAdjacencyList;
        private Panel panelFooter;
        private Button btnViewAdjacencyMatrix;

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
            lblAdjacencyListInfo = new Label();
            dgvAdjacencyList = new DataGridView();
            panelFooter = new Panel();
            btnViewAdjacencyMatrix = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjacencyList).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(241, 245, 249);
            panelHeader.Controls.Add(lblAdjacencyListInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 65;
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(12, 10, 12, 10);
            // 
            // lblAdjacencyListInfo
            // 
            lblAdjacencyListInfo.Dock = DockStyle.Fill;
            lblAdjacencyListInfo.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
            lblAdjacencyListInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblAdjacencyListInfo.Name = "lblAdjacencyListInfo";
            // 
            // dgvAdjacencyList
            // 
            dgvAdjacencyList.AllowUserToAddRows = false;
            dgvAdjacencyList.AllowUserToDeleteRows = false;
            dgvAdjacencyList.AllowUserToResizeRows = false;
            dgvAdjacencyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdjacencyList.BackgroundColor = Color.FromArgb(248, 249, 250);
            dgvAdjacencyList.BorderStyle = BorderStyle.None;
            dgvAdjacencyList.Dock = DockStyle.Fill;
            dgvAdjacencyList.EnableHeadersVisualStyles = false;
            dgvAdjacencyList.Name = "dgvAdjacencyList";
            dgvAdjacencyList.ReadOnly = true;
            dgvAdjacencyList.RowHeadersVisible = false;
            dgvAdjacencyList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdjacencyList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgvAdjacencyList.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvAdjacencyList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvAdjacencyList.ColumnHeadersHeight = 36;
            dgvAdjacencyList.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvAdjacencyList.DefaultCellStyle.Padding = new Padding(4);
            dgvAdjacencyList.RowTemplate.Height = 34;

            dgvAdjacencyList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVertex",
                HeaderText = "Vértice",
                FillWeight = 20
            });

            dgvAdjacencyList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDegree",
                HeaderText = "Grado / Conexiones",
                FillWeight = 25
            });

            dgvAdjacencyList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAdjacents",
                HeaderText = "Vértices Adyacentes (Lista Enlazada)",
                FillWeight = 55
            });
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnViewAdjacencyMatrix);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 48;
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10, 6, 10, 6);
            // 
            // btnViewAdjacencyMatrix
            // 
            btnViewAdjacencyMatrix.BackColor = SystemColors.Control;
            btnViewAdjacencyMatrix.Cursor = Cursors.Hand;
            btnViewAdjacencyMatrix.Dock = DockStyle.Right;
            btnViewAdjacencyMatrix.FlatStyle = FlatStyle.Standard;
            btnViewAdjacencyMatrix.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewAdjacencyMatrix.ForeColor = SystemColors.ControlText;
            btnViewAdjacencyMatrix.Name = "btnViewAdjacencyMatrix";
            btnViewAdjacencyMatrix.Text = "Ver Matriz de Adyacencia";
            btnViewAdjacencyMatrix.UseVisualStyleBackColor = true;
            btnViewAdjacencyMatrix.Width = 200;
            // 
            // AdjacencyListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(DefaultWindowWidth, DefaultWindowHeight);
            MinimumSize = new Size(520, 360);
            Controls.Add(dgvAdjacencyList);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Name = "AdjacencyListForm";
            StartPosition = FormStartPosition.CenterParent;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdjacencyList).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
