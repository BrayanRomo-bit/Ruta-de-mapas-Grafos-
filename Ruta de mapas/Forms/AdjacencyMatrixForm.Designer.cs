using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    partial class AdjacencyMatrixForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblMatrixInfo;
        private DataGridView dgvAdjacencyMatrix;
        private Panel panelFooter;
        private Button btnViewAdjacencyList;

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
            lblMatrixInfo = new Label();
            dgvAdjacencyMatrix = new DataGridView();
            panelFooter = new Panel();
            btnViewAdjacencyList = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdjacencyMatrix).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(241, 245, 249);
            panelHeader.Controls.Add(lblMatrixInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(12, 8, 12, 8);
            // 
            // lblMatrixInfo
            // 
            lblMatrixInfo.Dock = DockStyle.Fill;
            lblMatrixInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblMatrixInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblMatrixInfo.Name = "lblMatrixInfo";
            // 
            // dgvAdjacencyMatrix
            // 
            dgvAdjacencyMatrix.AllowUserToAddRows = false;
            dgvAdjacencyMatrix.AllowUserToDeleteRows = false;
            dgvAdjacencyMatrix.AllowUserToResizeRows = false;
            dgvAdjacencyMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAdjacencyMatrix.BackgroundColor = TableBackgroundColor;
            dgvAdjacencyMatrix.BorderStyle = BorderStyle.None;
            dgvAdjacencyMatrix.Dock = DockStyle.Fill;
            dgvAdjacencyMatrix.EnableHeadersVisualStyles = false;
            dgvAdjacencyMatrix.Name = "dgvAdjacencyMatrix";
            dgvAdjacencyMatrix.ReadOnly = true;
            dgvAdjacencyMatrix.RowHeadersWidth = 70;
            dgvAdjacencyMatrix.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgvAdjacencyMatrix.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvAdjacencyMatrix.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvAdjacencyMatrix.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdjacencyMatrix.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgvAdjacencyMatrix.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvAdjacencyMatrix.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvAdjacencyMatrix.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdjacencyMatrix.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvAdjacencyMatrix.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnViewAdjacencyList);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 48;
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10, 6, 10, 6);
            // 
            // btnViewAdjacencyList
            // 
            btnViewAdjacencyList.BackColor = SystemColors.Control;
            btnViewAdjacencyList.Cursor = Cursors.Hand;
            btnViewAdjacencyList.Dock = DockStyle.Right;
            btnViewAdjacencyList.FlatStyle = FlatStyle.Standard;
            btnViewAdjacencyList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnViewAdjacencyList.ForeColor = SystemColors.ControlText;
            btnViewAdjacencyList.Name = "btnViewAdjacencyList";
            btnViewAdjacencyList.Text = "Ver Lista de Adyacencia";
            btnViewAdjacencyList.UseVisualStyleBackColor = true;
            btnViewAdjacencyList.Width = 200;
            // 
            // AdjacencyMatrixForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(DefaultWindowWidth, DefaultWindowHeight);
            MinimumSize = new Size(480, 360);
            Controls.Add(dgvAdjacencyMatrix);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Name = "AdjacencyMatrixForm";
            StartPosition = FormStartPosition.CenterParent;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdjacencyMatrix).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
