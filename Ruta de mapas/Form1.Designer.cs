namespace Ruta_de_mapas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Área principal
        private System.Windows.Forms.SplitContainer splitMain;

        // Lienzo (Izquierda)
        private DoubleBufferedPanel panelCanvas;
        private System.Windows.Forms.Panel panelCanvasFooter;
        private System.Windows.Forms.Label lblCoords;

        // Panel Lateral de Operaciones (Derecha)
        private System.Windows.Forms.Panel panelOperaciones;

        // 1. Inserción
        private System.Windows.Forms.GroupBox grpInsercion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAgregarVertice;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.CheckBox chkPonderada;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.NumericUpDown numPeso;
        private System.Windows.Forms.Button btnAgregarArista;

        // 2. Eliminación
        private System.Windows.Forms.GroupBox grpEliminacion;
        private System.Windows.Forms.ComboBox cmbEliminarVertice;
        private System.Windows.Forms.Button btnEliminarVertice;
        private System.Windows.Forms.ComboBox cmbEliminarAristaOrig;
        private System.Windows.Forms.ComboBox cmbEliminarAristaDest;
        private System.Windows.Forms.Button btnEliminarArista;

        // 3. Adyacencia
        private System.Windows.Forms.GroupBox grpAdyacencia;
        private System.Windows.Forms.ComboBox cmbAdyA;
        private System.Windows.Forms.ComboBox cmbAdyB;
        private System.Windows.Forms.Button btnVerificarAdyacencia;
        private System.Windows.Forms.Button btnVerVecinos;
        private System.Windows.Forms.Label lblResultadoAdyacencia;

        // Barra de Registro Inferior
        private System.Windows.Forms.ListBox lstLog;

        // Barra Superior
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelTipoDireccion;
        private System.Windows.Forms.Label lblTituloDir;
        private System.Windows.Forms.RadioButton rbNoDirigido;
        private System.Windows.Forms.RadioButton rbDirigido;
        private System.Windows.Forms.Panel panelTipoPonderacion;
        private System.Windows.Forms.Label lblTituloPond;
        private System.Windows.Forms.RadioButton rbNoPonderado;
        private System.Windows.Forms.RadioButton rbPonderado;
        private System.Windows.Forms.Panel panelTipoListaGrafo;
        private System.Windows.Forms.Label lblTituloTipoLista;
        private System.Windows.Forms.ComboBox cmbTipoListaGrafo;
        private System.Windows.Forms.Button btnVerMatriz;
        private System.Windows.Forms.Button btnVerLista;
        private System.Windows.Forms.Button btnLimpiar;

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
            splitMain = new SplitContainer();
            panelCanvas = new DoubleBufferedPanel();
            panelCanvasFooter = new Panel();
            lblCoords = new Label();
            panelOperaciones = new Panel();
            grpAdyacencia = new GroupBox();
            lblResultadoAdyacencia = new Label();
            btnVerVecinos = new Button();
            btnVerificarAdyacencia = new Button();
            cmbAdyB = new ComboBox();
            cmbAdyA = new ComboBox();
            grpEliminacion = new GroupBox();
            btnEliminarArista = new Button();
            cmbEliminarAristaDest = new ComboBox();
            cmbEliminarAristaOrig = new ComboBox();
            btnEliminarVertice = new Button();
            cmbEliminarVertice = new ComboBox();
            grpInsercion = new GroupBox();
            btnAgregarArista = new Button();
            numPeso = new NumericUpDown();
            lblPeso = new Label();
            chkPonderada = new CheckBox();
            cmbDestino = new ComboBox();
            cmbOrigen = new ComboBox();
            btnAgregarVertice = new Button();
            txtNombre = new TextBox();
            lstLog = new ListBox();
            panelTop = new Panel();
            btnLimpiar = new Button();
            btnVerLista = new Button();
            btnVerMatriz = new Button();
            panelTipoListaGrafo = new Panel();
            lblTituloTipoLista = new Label();
            cmbTipoListaGrafo = new ComboBox();
            panelTipoPonderacion = new Panel();
            lblTituloPond = new Label();
            rbPonderado = new RadioButton();
            rbNoPonderado = new RadioButton();
            panelTipoDireccion = new Panel();
            lblTituloDir = new Label();
            rbDirigido = new RadioButton();
            rbNoDirigido = new RadioButton();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            panelCanvasFooter.SuspendLayout();
            panelOperaciones.SuspendLayout();
            grpAdyacencia.SuspendLayout();
            grpEliminacion.SuspendLayout();
            grpInsercion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            panelTop.SuspendLayout();
            panelTipoListaGrafo.SuspendLayout();
            panelTipoPonderacion.SuspendLayout();
            panelTipoDireccion.SuspendLayout();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel2;
            splitMain.Location = new Point(0, 67);
            splitMain.Margin = new Padding(3, 4, 3, 4);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(panelCanvas);
            splitMain.Panel1.Controls.Add(panelCanvasFooter);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(panelOperaciones);
            splitMain.Size = new Size(1234, 774);
            splitMain.SplitterDistance = 853;
            splitMain.SplitterWidth = 5;
            splitMain.TabIndex = 1;
            // 
            // panelCanvas
            // 
            panelCanvas.BackColor = Color.FromArgb(250, 251, 252);
            panelCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelCanvas.Cursor = Cursors.Cross;
            panelCanvas.Dock = DockStyle.Fill;
            panelCanvas.Location = new Point(0, 0);
            panelCanvas.Margin = new Padding(3, 4, 3, 4);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(853, 741);
            panelCanvas.TabIndex = 0;
            // 
            // panelCanvasFooter
            // 
            panelCanvasFooter.BackColor = Color.FromArgb(241, 242, 246);
            panelCanvasFooter.BorderStyle = BorderStyle.FixedSingle;
            panelCanvasFooter.Controls.Add(lblCoords);
            panelCanvasFooter.Dock = DockStyle.Bottom;
            panelCanvasFooter.Location = new Point(0, 741);
            panelCanvasFooter.Margin = new Padding(3, 4, 3, 4);
            panelCanvasFooter.Name = "panelCanvasFooter";
            panelCanvasFooter.Size = new Size(853, 33);
            panelCanvasFooter.TabIndex = 1;
            // 
            // lblCoords
            // 
            lblCoords.AutoSize = true;
            lblCoords.Font = new Font("Segoe UI", 8.25F);
            lblCoords.ForeColor = Color.FromArgb(45, 52, 54);
            lblCoords.Location = new Point(7, 7);
            lblCoords.Name = "lblCoords";
            lblCoords.Size = new Size(126, 19);
            lblCoords.TabIndex = 0;
            lblCoords.Text = "Posición: (X: 0, Y: 0)";
            // 
            // panelOperaciones
            // 
            panelOperaciones.AutoScroll = true;
            panelOperaciones.Controls.Add(grpAdyacencia);
            panelOperaciones.Controls.Add(grpEliminacion);
            panelOperaciones.Controls.Add(grpInsercion);
            panelOperaciones.Dock = DockStyle.Fill;
            panelOperaciones.Location = new Point(0, 0);
            panelOperaciones.Margin = new Padding(3, 4, 3, 4);
            panelOperaciones.Name = "panelOperaciones";
            panelOperaciones.Padding = new Padding(7, 8, 7, 8);
            panelOperaciones.Size = new Size(376, 774);
            panelOperaciones.TabIndex = 0;
            // 
            // grpAdyacencia
            // 
            grpAdyacencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAdyacencia.BackColor = Color.FromArgb(248, 252, 248);
            grpAdyacencia.Controls.Add(lblResultadoAdyacencia);
            grpAdyacencia.Controls.Add(btnVerVecinos);
            grpAdyacencia.Controls.Add(btnVerificarAdyacencia);
            grpAdyacencia.Controls.Add(cmbAdyB);
            grpAdyacencia.Controls.Add(cmbAdyA);
            grpAdyacencia.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpAdyacencia.ForeColor = Color.Black;
            grpAdyacencia.Location = new Point(7, 452);
            grpAdyacencia.Margin = new Padding(3, 4, 3, 4);
            grpAdyacencia.Name = "grpAdyacencia";
            grpAdyacencia.Padding = new Padding(3, 4, 3, 4);
            grpAdyacencia.Size = new Size(362, 287);
            grpAdyacencia.TabIndex = 2;
            grpAdyacencia.TabStop = false;
            grpAdyacencia.Text = "4.2.2.3 Verificación de Adyacencia";
            // 
            // lblResultadoAdyacencia
            // 
            lblResultadoAdyacencia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResultadoAdyacencia.BackColor = Color.FromArgb(238, 242, 245);
            lblResultadoAdyacencia.BorderStyle = BorderStyle.FixedSingle;
            lblResultadoAdyacencia.Font = new Font("Segoe UI", 9F);
            lblResultadoAdyacencia.ForeColor = Color.FromArgb(45, 52, 54);
            lblResultadoAdyacencia.Location = new Point(11, 130);
            lblResultadoAdyacencia.Name = "lblResultadoAdyacencia";
            lblResultadoAdyacencia.Padding = new Padding(6);
            lblResultadoAdyacencia.Size = new Size(339, 140);
            lblResultadoAdyacencia.TabIndex = 4;
            lblResultadoAdyacencia.Text = "Comprueba la adyacencia entre dos nodos o consulta los vecinos de un nodo.";
            lblResultadoAdyacencia.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVerVecinos
            // 
            btnVerVecinos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerVecinos.BackColor = Color.FromArgb(99, 110, 114);
            btnVerVecinos.Cursor = Cursors.Hand;
            btnVerVecinos.FlatStyle = FlatStyle.Flat;
            btnVerVecinos.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnVerVecinos.ForeColor = Color.White;
            btnVerVecinos.Location = new Point(190, 80);
            btnVerVecinos.Margin = new Padding(3, 4, 3, 4);
            btnVerVecinos.Name = "btnVerVecinos";
            btnVerVecinos.Size = new Size(160, 40);
            btnVerVecinos.TabIndex = 3;
            btnVerVecinos.Text = "Obtener Adyacentes";
            btnVerVecinos.UseVisualStyleBackColor = false;
            // 
            // btnVerificarAdyacencia
            // 
            btnVerificarAdyacencia.BackColor = Color.FromArgb(0, 184, 148);
            btnVerificarAdyacencia.Cursor = Cursors.Hand;
            btnVerificarAdyacencia.FlatStyle = FlatStyle.Flat;
            btnVerificarAdyacencia.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnVerificarAdyacencia.ForeColor = Color.White;
            btnVerificarAdyacencia.Location = new Point(11, 80);
            btnVerificarAdyacencia.Margin = new Padding(3, 4, 3, 4);
            btnVerificarAdyacencia.Name = "btnVerificarAdyacencia";
            btnVerificarAdyacencia.Size = new Size(160, 40);
            btnVerificarAdyacencia.TabIndex = 2;
            btnVerificarAdyacencia.Text = "Verificar Adyacencia";
            btnVerificarAdyacencia.UseVisualStyleBackColor = false;
            // 
            // cmbAdyB
            // 
            cmbAdyB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbAdyB.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdyB.Font = new Font("Segoe UI", 9F);
            cmbAdyB.FormattingEnabled = true;
            cmbAdyB.Location = new Point(190, 35);
            cmbAdyB.Margin = new Padding(3, 4, 3, 4);
            cmbAdyB.Name = "cmbAdyB";
            cmbAdyB.Size = new Size(159, 28);
            cmbAdyB.TabIndex = 1;
            // 
            // cmbAdyA
            // 
            cmbAdyA.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdyA.Font = new Font("Segoe UI", 9F);
            cmbAdyA.FormattingEnabled = true;
            cmbAdyA.Location = new Point(11, 35);
            cmbAdyA.Margin = new Padding(3, 4, 3, 4);
            cmbAdyA.Name = "cmbAdyA";
            cmbAdyA.Size = new Size(159, 28);
            cmbAdyA.TabIndex = 0;
            // 
            // grpEliminacion
            // 
            grpEliminacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpEliminacion.BackColor = Color.FromArgb(254, 248, 248);
            grpEliminacion.Controls.Add(btnEliminarArista);
            grpEliminacion.Controls.Add(cmbEliminarAristaDest);
            grpEliminacion.Controls.Add(cmbEliminarAristaOrig);
            grpEliminacion.Controls.Add(btnEliminarVertice);
            grpEliminacion.Controls.Add(cmbEliminarVertice);
            grpEliminacion.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpEliminacion.ForeColor = Color.Black;
            grpEliminacion.Location = new Point(7, 230);
            grpEliminacion.Margin = new Padding(3, 4, 3, 4);
            grpEliminacion.Name = "grpEliminacion";
            grpEliminacion.Padding = new Padding(3, 4, 3, 4);
            grpEliminacion.Size = new Size(362, 210);
            grpEliminacion.TabIndex = 1;
            grpEliminacion.TabStop = false;
            grpEliminacion.Text = "4.2.2.2 Eliminación (Limpia Huérfanos)";
            // 
            // btnEliminarArista
            // 
            btnEliminarArista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminarArista.BackColor = Color.Transparent;
            btnEliminarArista.Cursor = Cursors.Hand;
            btnEliminarArista.FlatStyle = FlatStyle.Flat;
            btnEliminarArista.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnEliminarArista.ForeColor = Color.Black;
            btnEliminarArista.Location = new Point(11, 147);
            btnEliminarArista.Margin = new Padding(3, 4, 3, 4);
            btnEliminarArista.Name = "btnEliminarArista";
            btnEliminarArista.Size = new Size(339, 43);
            btnEliminarArista.TabIndex = 4;
            btnEliminarArista.Text = " Quitar Arista";
            btnEliminarArista.UseVisualStyleBackColor = false;
            // 
            // cmbEliminarAristaDest
            // 
            cmbEliminarAristaDest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbEliminarAristaDest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEliminarAristaDest.Font = new Font("Segoe UI", 9F);
            cmbEliminarAristaDest.FormattingEnabled = true;
            cmbEliminarAristaDest.Location = new Point(190, 99);
            cmbEliminarAristaDest.Margin = new Padding(3, 4, 3, 4);
            cmbEliminarAristaDest.Name = "cmbEliminarAristaDest";
            cmbEliminarAristaDest.Size = new Size(159, 28);
            cmbEliminarAristaDest.TabIndex = 3;
            // 
            // cmbEliminarAristaOrig
            // 
            cmbEliminarAristaOrig.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEliminarAristaOrig.Font = new Font("Segoe UI", 9F);
            cmbEliminarAristaOrig.FormattingEnabled = true;
            cmbEliminarAristaOrig.Location = new Point(11, 99);
            cmbEliminarAristaOrig.Margin = new Padding(3, 4, 3, 4);
            cmbEliminarAristaOrig.Name = "cmbEliminarAristaOrig";
            cmbEliminarAristaOrig.Size = new Size(159, 28);
            cmbEliminarAristaOrig.TabIndex = 2;
            // 
            // btnEliminarVertice
            // 
            btnEliminarVertice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarVertice.BackColor = Color.White;
            btnEliminarVertice.Cursor = Cursors.Hand;
            btnEliminarVertice.FlatStyle = FlatStyle.Flat;
            btnEliminarVertice.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnEliminarVertice.ForeColor = SystemColors.WindowText;
            btnEliminarVertice.Location = new Point(195, 32);
            btnEliminarVertice.Margin = new Padding(3, 4, 3, 4);
            btnEliminarVertice.Name = "btnEliminarVertice";
            btnEliminarVertice.Size = new Size(155, 36);
            btnEliminarVertice.TabIndex = 1;
            btnEliminarVertice.Text = " Quitar Vértice";
            btnEliminarVertice.UseVisualStyleBackColor = false;
            // 
            // cmbEliminarVertice
            // 
            cmbEliminarVertice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEliminarVertice.Font = new Font("Segoe UI", 9F);
            cmbEliminarVertice.FormattingEnabled = true;
            cmbEliminarVertice.Location = new Point(11, 35);
            cmbEliminarVertice.Margin = new Padding(3, 4, 3, 4);
            cmbEliminarVertice.Name = "cmbEliminarVertice";
            cmbEliminarVertice.Size = new Size(171, 28);
            cmbEliminarVertice.TabIndex = 0;
            // 
            // grpInsercion
            // 
            grpInsercion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInsercion.BackColor = Color.FromArgb(248, 249, 250);
            grpInsercion.Controls.Add(btnAgregarArista);
            grpInsercion.Controls.Add(numPeso);
            grpInsercion.Controls.Add(lblPeso);
            grpInsercion.Controls.Add(chkPonderada);
            grpInsercion.Controls.Add(cmbDestino);
            grpInsercion.Controls.Add(cmbOrigen);
            grpInsercion.Controls.Add(btnAgregarVertice);
            grpInsercion.Controls.Add(txtNombre);
            grpInsercion.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpInsercion.ForeColor = Color.FromArgb(45, 52, 54);
            grpInsercion.Location = new Point(7, 8);
            grpInsercion.Margin = new Padding(3, 4, 3, 4);
            grpInsercion.Name = "grpInsercion";
            grpInsercion.Padding = new Padding(3, 4, 3, 4);
            grpInsercion.Size = new Size(362, 214);
            grpInsercion.TabIndex = 0;
            grpInsercion.TabStop = false;
            grpInsercion.Text = "4.2.2.1 Inserción";
            // 
            // btnAgregarArista
            // 
            btnAgregarArista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAgregarArista.BackColor = Color.White;
            btnAgregarArista.Cursor = Cursors.Hand;
            btnAgregarArista.FlatStyle = FlatStyle.Flat;
            btnAgregarArista.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnAgregarArista.ForeColor = Color.Black;
            btnAgregarArista.Location = new Point(11, 158);
            btnAgregarArista.Margin = new Padding(3, 4, 3, 4);
            btnAgregarArista.Name = "btnAgregarArista";
            btnAgregarArista.Size = new Size(339, 44);
            btnAgregarArista.TabIndex = 7;
            btnAgregarArista.Text = "Conectar Nodos (Arista)";
            btnAgregarArista.UseVisualStyleBackColor = false;
            // 
            // numPeso
            // 
            numPeso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numPeso.Enabled = false;
            numPeso.Font = new Font("Segoe UI", 9F);
            numPeso.Location = new Point(256, 117);
            numPeso.Margin = new Padding(3, 4, 3, 4);
            numPeso.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numPeso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(93, 27);
            numPeso.TabIndex = 6;
            numPeso.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPeso
            // 
            lblPeso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI", 9F);
            lblPeso.ForeColor = Color.Gray;
            lblPeso.Location = new Point(211, 120);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(42, 20);
            lblPeso.TabIndex = 5;
            lblPeso.Text = "Peso:";
            // 
            // chkPonderada
            // 
            chkPonderada.AutoSize = true;
            chkPonderada.Cursor = Cursors.Hand;
            chkPonderada.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            chkPonderada.Location = new Point(11, 119);
            chkPonderada.Name = "chkPonderada";
            chkPonderada.Size = new Size(207, 23);
            chkPonderada.TabIndex = 4;
            chkPonderada.Text = "Arista Ponderada (con peso)";
            chkPonderada.UseVisualStyleBackColor = true;
            // 
            // cmbDestino
            // 
            cmbDestino.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.Font = new Font("Segoe UI", 9F);
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(190, 76);
            cmbDestino.Margin = new Padding(3, 4, 3, 4);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(159, 28);
            cmbDestino.TabIndex = 3;
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.Font = new Font("Segoe UI", 9F);
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(11, 76);
            cmbOrigen.Margin = new Padding(3, 4, 3, 4);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(159, 28);
            cmbOrigen.TabIndex = 2;
            // 
            // btnAgregarVertice
            // 
            btnAgregarVertice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAgregarVertice.BackColor = Color.Transparent;
            btnAgregarVertice.Cursor = Cursors.Hand;
            btnAgregarVertice.FlatStyle = FlatStyle.Flat;
            btnAgregarVertice.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnAgregarVertice.ForeColor = Color.Black;
            btnAgregarVertice.Location = new Point(218, 29);
            btnAgregarVertice.Margin = new Padding(3, 4, 3, 4);
            btnAgregarVertice.Name = "btnAgregarVertice";
            btnAgregarVertice.Size = new Size(133, 36);
            btnAgregarVertice.TabIndex = 1;
            btnAgregarVertice.Text = "Nuevo Vértice";
            btnAgregarVertice.UseVisualStyleBackColor = false;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(11, 32);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre nodo...";
            txtNombre.Size = new Size(194, 27);
            txtNombre.TabIndex = 0;
            // 
            // lstLog
            // 
            lstLog.BackColor = Color.FromArgb(45, 52, 54);
            lstLog.BorderStyle = BorderStyle.None;
            lstLog.Dock = DockStyle.Bottom;
            lstLog.Font = new Font("Consolas", 8F);
            lstLog.ForeColor = Color.FromArgb(223, 230, 233);
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(0, 841);
            lstLog.Margin = new Padding(3, 4, 3, 4);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(1234, 90);
            lstLog.TabIndex = 2;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnLimpiar);
            panelTop.Controls.Add(btnVerLista);
            panelTop.Controls.Add(btnVerMatriz);
            panelTop.Controls.Add(panelTipoListaGrafo);
            panelTop.Controls.Add(panelTipoPonderacion);
            panelTop.Controls.Add(panelTipoDireccion);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1234, 67);
            panelTop.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiar.BackColor = Color.FromArgb(214, 48, 49);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(1124, 13);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(95, 40);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "\U0001f9f9 Vaciar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnVerLista
            // 
            btnVerLista.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerLista.BackColor = Color.FromArgb(108, 92, 231);
            btnVerLista.Cursor = Cursors.Hand;
            btnVerLista.FlatStyle = FlatStyle.Flat;
            btnVerLista.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnVerLista.ForeColor = Color.White;
            btnVerLista.Location = new Point(1005, 13);
            btnVerLista.Margin = new Padding(3, 4, 3, 4);
            btnVerLista.Name = "btnVerLista";
            btnVerLista.Size = new Size(112, 40);
            btnVerLista.TabIndex = 4;
            btnVerLista.Text = "📋 Lista";
            btnVerLista.UseVisualStyleBackColor = false;
            // 
            // btnVerMatriz
            // 
            btnVerMatriz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerMatriz.BackColor = Color.FromArgb(9, 132, 227);
            btnVerMatriz.Cursor = Cursors.Hand;
            btnVerMatriz.FlatStyle = FlatStyle.Flat;
            btnVerMatriz.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnVerMatriz.ForeColor = Color.White;
            btnVerMatriz.Location = new Point(885, 13);
            btnVerMatriz.Margin = new Padding(3, 4, 3, 4);
            btnVerMatriz.Name = "btnVerMatriz";
            btnVerMatriz.Size = new Size(113, 40);
            btnVerMatriz.TabIndex = 3;
            btnVerMatriz.Text = "📊 Matriz";
            btnVerMatriz.UseVisualStyleBackColor = false;
            // 
            // panelTipoListaGrafo
            // 
            panelTipoListaGrafo.Controls.Add(lblTituloTipoLista);
            panelTipoListaGrafo.Controls.Add(cmbTipoListaGrafo);
            panelTipoListaGrafo.Location = new Point(690, 4);
            panelTipoListaGrafo.Name = "panelTipoListaGrafo";
            panelTipoListaGrafo.Size = new Size(185, 58);
            panelTipoListaGrafo.TabIndex = 3;
            // 
            // lblTituloTipoLista
            // 
            lblTituloTipoLista.AutoSize = true;
            lblTituloTipoLista.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTituloTipoLista.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloTipoLista.Location = new Point(3, 3);
            lblTituloTipoLista.Name = "lblTituloTipoLista";
            lblTituloTipoLista.Size = new Size(140, 17);
            lblTituloTipoLista.TabIndex = 0;
            lblTituloTipoLista.Text = "ESTRUCTURA DE LISTA:";
            // 
            // cmbTipoListaGrafo
            // 
            cmbTipoListaGrafo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoListaGrafo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            cmbTipoListaGrafo.FormattingEnabled = true;
            cmbTipoListaGrafo.Location = new Point(3, 24);
            cmbTipoListaGrafo.Name = "cmbTipoListaGrafo";
            cmbTipoListaGrafo.Size = new Size(178, 25);
            cmbTipoListaGrafo.TabIndex = 1;
            // 
            // panelTipoPonderacion
            // 
            panelTipoPonderacion.Controls.Add(lblTituloPond);
            panelTipoPonderacion.Controls.Add(rbPonderado);
            panelTipoPonderacion.Controls.Add(rbNoPonderado);
            panelTipoPonderacion.Location = new Point(440, 4);
            panelTipoPonderacion.Name = "panelTipoPonderacion";
            panelTipoPonderacion.Size = new Size(245, 58);
            panelTipoPonderacion.TabIndex = 2;
            // 
            // lblTituloPond
            // 
            lblTituloPond.AutoSize = true;
            lblTituloPond.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTituloPond.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloPond.Location = new Point(3, 3);
            lblTituloPond.Name = "lblTituloPond";
            lblTituloPond.Size = new Size(176, 17);
            lblTituloPond.TabIndex = 0;
            lblTituloPond.Text = "MODO PREDETERMINADO:";
            // 
            // rbPonderado
            // 
            rbPonderado.AutoSize = true;
            rbPonderado.Cursor = Cursors.Hand;
            rbPonderado.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbPonderado.ForeColor = Color.Black;
            rbPonderado.Location = new Point(130, 26);
            rbPonderado.Name = "rbPonderado";
            rbPonderado.Size = new Size(97, 23);
            rbPonderado.TabIndex = 2;
            rbPonderado.Text = "Ponderado";
            rbPonderado.UseVisualStyleBackColor = true;
            // 
            // rbNoPonderado
            // 
            rbNoPonderado.AutoSize = true;
            rbNoPonderado.Checked = true;
            rbNoPonderado.Cursor = Cursors.Hand;
            rbNoPonderado.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbNoPonderado.ForeColor = Color.Black;
            rbNoPonderado.Location = new Point(6, 26);
            rbNoPonderado.Name = "rbNoPonderado";
            rbNoPonderado.Size = new Size(120, 23);
            rbNoPonderado.TabIndex = 1;
            rbNoPonderado.TabStop = true;
            rbNoPonderado.Text = "No Ponderado";
            rbNoPonderado.UseVisualStyleBackColor = true;
            // 
            // panelTipoDireccion
            // 
            panelTipoDireccion.Controls.Add(lblTituloDir);
            panelTipoDireccion.Controls.Add(rbDirigido);
            panelTipoDireccion.Controls.Add(rbNoDirigido);
            panelTipoDireccion.Location = new Point(200, 4);
            panelTipoDireccion.Name = "panelTipoDireccion";
            panelTipoDireccion.Size = new Size(235, 58);
            panelTipoDireccion.TabIndex = 1;
            // 
            // lblTituloDir
            // 
            lblTituloDir.AutoSize = true;
            lblTituloDir.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTituloDir.ForeColor = Color.FromArgb(100, 116, 139);
            lblTituloDir.Location = new Point(3, 3);
            lblTituloDir.Name = "lblTituloDir";
            lblTituloDir.Size = new Size(81, 17);
            lblTituloDir.TabIndex = 0;
            lblTituloDir.Text = "DIRECCIÓN:";
            // 
            // rbDirigido
            // 
            rbDirigido.AutoSize = true;
            rbDirigido.Cursor = Cursors.Hand;
            rbDirigido.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbDirigido.ForeColor = Color.Black;
            rbDirigido.Location = new Point(135, 26);
            rbDirigido.Name = "rbDirigido";
            rbDirigido.Size = new Size(81, 23);
            rbDirigido.TabIndex = 2;
            rbDirigido.Text = "Dirigido";
            rbDirigido.UseVisualStyleBackColor = true;
            // 
            // rbNoDirigido
            // 
            rbNoDirigido.AutoSize = true;
            rbNoDirigido.Checked = true;
            rbNoDirigido.Cursor = Cursors.Hand;
            rbNoDirigido.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbNoDirigido.ForeColor = Color.Black;
            rbNoDirigido.Location = new Point(6, 26);
            rbNoDirigido.Name = "rbNoDirigido";
            rbNoDirigido.Size = new Size(104, 23);
            rbNoDirigido.TabIndex = 1;
            rbNoDirigido.TabStop = true;
            rbNoDirigido.Text = "No Dirigido";
            rbNoDirigido.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.Location = new Point(12, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(183, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Grafos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1234, 931);
            Controls.Add(splitMain);
            Controls.Add(lstLog);
            Controls.Add(panelTop);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(969, 718);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Grafos - 3 Tipos de Listas";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            panelCanvasFooter.ResumeLayout(false);
            panelCanvasFooter.PerformLayout();
            panelOperaciones.ResumeLayout(false);
            grpAdyacencia.ResumeLayout(false);
            grpEliminacion.ResumeLayout(false);
            grpInsercion.ResumeLayout(false);
            grpInsercion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelTipoListaGrafo.ResumeLayout(false);
            panelTipoListaGrafo.PerformLayout();
            panelTipoPonderacion.ResumeLayout(false);
            panelTipoPonderacion.PerformLayout();
            panelTipoDireccion.ResumeLayout(false);
            panelTipoDireccion.PerformLayout();
            ResumeLayout(false);
        }
    }
}
