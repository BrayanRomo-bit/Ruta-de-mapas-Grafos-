using System.Drawing;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    partial class FormMatriz
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblInfo;
        private DataGridView dgv;
        private Panel panelFooter;
        private Button btnVerLista;

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
            btnVerLista = new Button();
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
            panelHeader.Height = 70;
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(12, 8, 12, 8);
            // 
            // lblInfo
            // 
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblInfo.ForeColor = Color.FromArgb(30, 41, 59);
            lblInfo.Name = "lblInfo";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.BackgroundColor = ColorFondoTabla;
            dgv.BorderStyle = BorderStyle.None;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersWidth = 70;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            dgv.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnVerLista);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 48;
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10, 6, 10, 6);
            // 
            // btnVerLista
            // 
            btnVerLista.BackColor = Color.FromArgb(9, 132, 227);
            btnVerLista.Cursor = Cursors.Hand;
            btnVerLista.Dock = DockStyle.Right;
            btnVerLista.FlatStyle = FlatStyle.Flat;
            btnVerLista.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnVerLista.ForeColor = Color.White;
            btnVerLista.Name = "btnVerLista";
            btnVerLista.Text = "📋 Ver Lista de Adyacencia";
            btnVerLista.UseVisualStyleBackColor = false;
            btnVerLista.Width = 200;
            // 
            // FormMatriz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(AnchoVentanaPorDefecto, AltoVentanaPorDefecto);
            MinimumSize = new Size(480, 360);
            Controls.Add(dgv);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            Name = "FormMatriz";
            StartPosition = FormStartPosition.CenterParent;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
