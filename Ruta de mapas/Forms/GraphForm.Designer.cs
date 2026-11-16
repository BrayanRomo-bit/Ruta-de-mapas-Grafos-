namespace Ruta_de_mapas
{
    partial class GraphForm
    {
        private System.ComponentModel.IContainer components = null;

        // Main area
        private System.Windows.Forms.SplitContainer splitMainContainer;

        // Graph canvas (Left)
        private GraphCanvasPanel panelGraphCanvas;
        private System.Windows.Forms.Panel panelCanvasFooter;
        private System.Windows.Forms.Label lblCanvasCoordinates;

        // Graph operations side panel (Right)
        private System.Windows.Forms.Panel panelGraphOperations;

        // 1. Vertex and edge insertion
        private System.Windows.Forms.GroupBox grpGraphInsertion;
        private System.Windows.Forms.TextBox txtVertexName;
        private System.Windows.Forms.Button btnAddVertex;
        private System.Windows.Forms.ComboBox cmbOriginVertex;
        private System.Windows.Forms.ComboBox cmbDestinationVertex;
        private System.Windows.Forms.CheckBox chkWeightedEdge;
        private System.Windows.Forms.Label lblEdgeWeight;
        private System.Windows.Forms.NumericUpDown numEdgeWeight;
        private System.Windows.Forms.Button btnAddEdge;

        // 2. Vertex and edge deletion
        private System.Windows.Forms.GroupBox grpGraphDeletion;
        private System.Windows.Forms.ComboBox cmbRemoveVertex;
        private System.Windows.Forms.Button btnRemoveVertex;
        private System.Windows.Forms.ComboBox cmbRemoveEdgeOrigin;
        private System.Windows.Forms.ComboBox cmbRemoveEdgeDestination;
        private System.Windows.Forms.Button btnRemoveEdge;

        // 3. Adjacency verification and neighbors
        private System.Windows.Forms.GroupBox grpGraphAdjacency;
        private System.Windows.Forms.ComboBox cmbAdjacencyVertexA;
        private System.Windows.Forms.ComboBox cmbAdjacencyVertexB;
        private System.Windows.Forms.Button btnCheckAdjacency;
        private System.Windows.Forms.Button btnViewAdjacents;
        private System.Windows.Forms.Label lblAdjacencyResult;

        // Bottom log bar
        private System.Windows.Forms.ListBox lstGraphLog;

        // Top bar
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Panel panelGraphDirection;
        private System.Windows.Forms.Label lblDirectionTitle;
        private System.Windows.Forms.RadioButton rbUndirected;
        private System.Windows.Forms.RadioButton rbDirected;
        private System.Windows.Forms.Panel panelGraphWeighting;
        private System.Windows.Forms.Label lblWeightingTitle;
        private System.Windows.Forms.RadioButton rbUnweighted;
        private System.Windows.Forms.RadioButton rbWeighted;
        private System.Windows.Forms.Panel panelGraphStructure;
        private System.Windows.Forms.Label lblStructureTitle;
        private System.Windows.Forms.ComboBox cmbGraphStructure;
        private System.Windows.Forms.Button btnViewAdjacencyMatrix;
        private System.Windows.Forms.Button btnViewAdjacencyList;
        private System.Windows.Forms.Button btnClearGraph;

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
            splitMainContainer = new SplitContainer();
            panelGraphCanvas = new GraphCanvasPanel();
            panelCanvasFooter = new Panel();
            lblCanvasCoordinates = new Label();
            panelGraphOperations = new Panel();
            grpGraphAdjacency = new GroupBox();
            lblAdjacencyResult = new Label();
            btnViewAdjacents = new Button();
            btnCheckAdjacency = new Button();
            cmbAdjacencyVertexB = new ComboBox();
            cmbAdjacencyVertexA = new ComboBox();
            grpGraphDeletion = new GroupBox();
            btnRemoveEdge = new Button();
            cmbRemoveEdgeDestination = new ComboBox();
            cmbRemoveEdgeOrigin = new ComboBox();
            btnRemoveVertex = new Button();
            cmbRemoveVertex = new ComboBox();
            grpGraphInsertion = new GroupBox();
            btnAddEdge = new Button();
            numEdgeWeight = new NumericUpDown();
            lblEdgeWeight = new Label();
            chkWeightedEdge = new CheckBox();
            cmbDestinationVertex = new ComboBox();
            cmbOriginVertex = new ComboBox();
            btnAddVertex = new Button();
            txtVertexName = new TextBox();
            lstGraphLog = new ListBox();
            panelTopBar = new Panel();
            btnClearGraph = new Button();
            btnViewAdjacencyList = new Button();
            btnViewAdjacencyMatrix = new Button();
            panelGraphStructure = new Panel();
            lblStructureTitle = new Label();
            cmbGraphStructure = new ComboBox();
            panelGraphWeighting = new Panel();
            lblWeightingTitle = new Label();
            rbWeighted = new RadioButton();
            rbUnweighted = new RadioButton();
            panelGraphDirection = new Panel();
            lblDirectionTitle = new Label();
            rbDirected = new RadioButton();
            rbUndirected = new RadioButton();
            lblSystemTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitMainContainer).BeginInit();
            splitMainContainer.Panel1.SuspendLayout();
            splitMainContainer.Panel2.SuspendLayout();
            splitMainContainer.SuspendLayout();
            panelCanvasFooter.SuspendLayout();
            panelGraphOperations.SuspendLayout();
            grpGraphAdjacency.SuspendLayout();
            grpGraphDeletion.SuspendLayout();
            grpGraphInsertion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEdgeWeight).BeginInit();
            panelTopBar.SuspendLayout();
            panelGraphStructure.SuspendLayout();
            panelGraphWeighting.SuspendLayout();
            panelGraphDirection.SuspendLayout();
            SuspendLayout();
            // 
            // splitMainContainer
            // 
            splitMainContainer.Dock = DockStyle.Fill;
            splitMainContainer.FixedPanel = FixedPanel.Panel2;
            splitMainContainer.Location = new Point(0, 67);
            splitMainContainer.Margin = new Padding(3, 4, 3, 4);
            splitMainContainer.Name = "splitMainContainer";
            // 
            // splitMainContainer.Panel1
            // 
            splitMainContainer.Panel1.Controls.Add(panelGraphCanvas);
            splitMainContainer.Panel1.Controls.Add(panelCanvasFooter);
            // 
            // splitMainContainer.Panel2
            // 
            splitMainContainer.Panel2.Controls.Add(panelGraphOperations);
            splitMainContainer.Size = new Size(1234, 774);
            splitMainContainer.SplitterDistance = 853;
            splitMainContainer.SplitterWidth = 5;
            splitMainContainer.TabIndex = 1;
            // 
            // panelGraphCanvas
            // 
            panelGraphCanvas.BackColor = Color.FromArgb(250, 251, 252);
            panelGraphCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelGraphCanvas.Cursor = Cursors.Cross;
            panelGraphCanvas.Dock = DockStyle.Fill;
            panelGraphCanvas.Location = new Point(0, 0);
            panelGraphCanvas.Margin = new Padding(3, 4, 3, 4);
            panelGraphCanvas.Name = "panelGraphCanvas";
            panelGraphCanvas.Size = new Size(853, 741);
            panelGraphCanvas.TabIndex = 0;
            // 
            // panelCanvasFooter
            // 
            panelCanvasFooter.BackColor = Color.FromArgb(241, 242, 246);
            panelCanvasFooter.BorderStyle = BorderStyle.FixedSingle;
            panelCanvasFooter.Controls.Add(lblCanvasCoordinates);
            panelCanvasFooter.Dock = DockStyle.Bottom;
            panelCanvasFooter.Location = new Point(0, 741);
            panelCanvasFooter.Margin = new Padding(3, 4, 3, 4);
            panelCanvasFooter.Name = "panelCanvasFooter";
            panelCanvasFooter.Size = new Size(853, 33);
            panelCanvasFooter.TabIndex = 1;
            // 
            // lblCanvasCoordinates
            // 
            lblCanvasCoordinates.AutoSize = true;
            lblCanvasCoordinates.Font = new Font("Segoe UI", 8.25F);
            lblCanvasCoordinates.ForeColor = Color.FromArgb(45, 52, 54);
            lblCanvasCoordinates.Location = new Point(7, 7);
            lblCanvasCoordinates.Name = "lblCanvasCoordinates";
            lblCanvasCoordinates.Size = new Size(126, 19);
            lblCanvasCoordinates.TabIndex = 0;
            lblCanvasCoordinates.Text = "Posición: (X: 0, Y: 0)";
            // 
            // panelGraphOperations
            // 
            panelGraphOperations.AutoScroll = true;
            panelGraphOperations.Controls.Add(grpGraphAdjacency);
            panelGraphOperations.Controls.Add(grpGraphDeletion);
            panelGraphOperations.Controls.Add(grpGraphInsertion);
            panelGraphOperations.Dock = DockStyle.Fill;
            panelGraphOperations.Location = new Point(0, 0);
            panelGraphOperations.Margin = new Padding(3, 4, 3, 4);
            panelGraphOperations.Name = "panelGraphOperations";
            panelGraphOperations.Padding = new Padding(7, 8, 7, 8);
            panelGraphOperations.Size = new Size(376, 774);
            panelGraphOperations.TabIndex = 0;
            // 
            // grpGraphAdjacency
            // 
            grpGraphAdjacency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpGraphAdjacency.BackColor = Color.FromArgb(248, 252, 248);
            grpGraphAdjacency.Controls.Add(lblAdjacencyResult);
            grpGraphAdjacency.Controls.Add(btnViewAdjacents);
            grpGraphAdjacency.Controls.Add(btnCheckAdjacency);
            grpGraphAdjacency.Controls.Add(cmbAdjacencyVertexB);
            grpGraphAdjacency.Controls.Add(cmbAdjacencyVertexA);
            grpGraphAdjacency.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpGraphAdjacency.ForeColor = Color.Black;
            grpGraphAdjacency.Location = new Point(7, 452);
            grpGraphAdjacency.Margin = new Padding(3, 4, 3, 4);
            grpGraphAdjacency.Name = "grpGraphAdjacency";
            grpGraphAdjacency.Padding = new Padding(3, 4, 3, 4);
            grpGraphAdjacency.Size = new Size(362, 287);
            grpGraphAdjacency.TabIndex = 2;
            grpGraphAdjacency.TabStop = false;
            grpGraphAdjacency.Text = "4.2.2.3 Verificación de Adyacencia";
            // 
            // lblAdjacencyResult
            // 
            lblAdjacencyResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAdjacencyResult.BackColor = Color.FromArgb(238, 242, 245);
            lblAdjacencyResult.BorderStyle = BorderStyle.FixedSingle;
            lblAdjacencyResult.Font = new Font("Segoe UI", 9F);
            lblAdjacencyResult.ForeColor = Color.FromArgb(45, 52, 54);
            lblAdjacencyResult.Location = new Point(11, 130);
            lblAdjacencyResult.Name = "lblAdjacencyResult";
            lblAdjacencyResult.Padding = new Padding(6);
            lblAdjacencyResult.Size = new Size(339, 140);
            lblAdjacencyResult.TabIndex = 4;
            lblAdjacencyResult.Text = "Comprueba la adyacencia entre dos vértices o consulta los adyacentes de un vértice.";
            lblAdjacencyResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnViewAdjacents
            // 
            btnViewAdjacents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewAdjacents.BackColor = Color.FromArgb(99, 110, 114);
            btnViewAdjacents.Cursor = Cursors.Hand;
            btnViewAdjacents.FlatStyle = FlatStyle.Flat;
            btnViewAdjacents.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnViewAdjacents.ForeColor = Color.White;
            btnViewAdjacents.Location = new Point(190, 80);
            btnViewAdjacents.Margin = new Padding(3, 4, 3, 4);
            btnViewAdjacents.Name = "btnViewAdjacents";
            btnViewAdjacents.Size = new Size(160, 40);
            btnViewAdjacents.TabIndex = 3;
            btnViewAdjacents.Text = "Obtener Adyacentes";
            btnViewAdjacents.UseVisualStyleBackColor = false;
            // 
            // btnCheckAdjacency
            // 
            btnCheckAdjacency.BackColor = Color.FromArgb(0, 184, 148);
            btnCheckAdjacency.Cursor = Cursors.Hand;
            btnCheckAdjacency.FlatStyle = FlatStyle.Flat;
            btnCheckAdjacency.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnCheckAdjacency.ForeColor = Color.White;
            btnCheckAdjacency.Location = new Point(11, 80);
            btnCheckAdjacency.Margin = new Padding(3, 4, 3, 4);
            btnCheckAdjacency.Name = "btnCheckAdjacency";
            btnCheckAdjacency.Size = new Size(160, 40);
            btnCheckAdjacency.TabIndex = 2;
            btnCheckAdjacency.Text = "Verificar Adyacencia";
            btnCheckAdjacency.UseVisualStyleBackColor = false;
            // 
            // cmbAdjacencyVertexB
            // 
            cmbAdjacencyVertexB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbAdjacencyVertexB.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdjacencyVertexB.Font = new Font("Segoe UI", 9F);
            cmbAdjacencyVertexB.FormattingEnabled = true;
            cmbAdjacencyVertexB.Location = new Point(190, 35);
            cmbAdjacencyVertexB.Margin = new Padding(3, 4, 3, 4);
            cmbAdjacencyVertexB.Name = "cmbAdjacencyVertexB";
            cmbAdjacencyVertexB.Size = new Size(159, 28);
            cmbAdjacencyVertexB.TabIndex = 1;
            // 
            // cmbAdjacencyVertexA
            // 
            cmbAdjacencyVertexA.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdjacencyVertexA.Font = new Font("Segoe UI", 9F);
            cmbAdjacencyVertexA.FormattingEnabled = true;
            cmbAdjacencyVertexA.Location = new Point(11, 35);
            cmbAdjacencyVertexA.Margin = new Padding(3, 4, 3, 4);
            cmbAdjacencyVertexA.Name = "cmbAdjacencyVertexA";
            cmbAdjacencyVertexA.Size = new Size(159, 28);
            cmbAdjacencyVertexA.TabIndex = 0;
            // 
            // grpGraphDeletion
            // 
            grpGraphDeletion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpGraphDeletion.BackColor = Color.FromArgb(254, 248, 248);
            grpGraphDeletion.Controls.Add(btnRemoveEdge);
            grpGraphDeletion.Controls.Add(cmbRemoveEdgeDestination);
            grpGraphDeletion.Controls.Add(cmbRemoveEdgeOrigin);
            grpGraphDeletion.Controls.Add(btnRemoveVertex);
            grpGraphDeletion.Controls.Add(cmbRemoveVertex);
            grpGraphDeletion.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpGraphDeletion.ForeColor = Color.Black;
            grpGraphDeletion.Location = new Point(7, 230);
            grpGraphDeletion.Margin = new Padding(3, 4, 3, 4);
            grpGraphDeletion.Name = "grpGraphDeletion";
            grpGraphDeletion.Padding = new Padding(3, 4, 3, 4);
            grpGraphDeletion.Size = new Size(362, 210);
            grpGraphDeletion.TabIndex = 1;
            grpGraphDeletion.TabStop = false;
            grpGraphDeletion.Text = "4.2.2.2 Eliminación (Limpia Huérfanos)";
            // 
            // btnRemoveEdge
            // 
            btnRemoveEdge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRemoveEdge.BackColor = Color.Transparent;
            btnRemoveEdge.Cursor = Cursors.Hand;
            btnRemoveEdge.FlatStyle = FlatStyle.Flat;
            btnRemoveEdge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnRemoveEdge.ForeColor = Color.Black;
            btnRemoveEdge.Location = new Point(11, 147);
            btnRemoveEdge.Margin = new Padding(3, 4, 3, 4);
            btnRemoveEdge.Name = "btnRemoveEdge";
            btnRemoveEdge.Size = new Size(339, 43);
            btnRemoveEdge.TabIndex = 4;
            btnRemoveEdge.Text = " Quitar Arista";
            btnRemoveEdge.UseVisualStyleBackColor = false;
            // 
            // cmbRemoveEdgeDestination
            // 
            cmbRemoveEdgeDestination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbRemoveEdgeDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRemoveEdgeDestination.Font = new Font("Segoe UI", 9F);
            cmbRemoveEdgeDestination.FormattingEnabled = true;
            cmbRemoveEdgeDestination.Location = new Point(190, 99);
            cmbRemoveEdgeDestination.Margin = new Padding(3, 4, 3, 4);
            cmbRemoveEdgeDestination.Name = "cmbRemoveEdgeDestination";
            cmbRemoveEdgeDestination.Size = new Size(159, 28);
            cmbRemoveEdgeDestination.TabIndex = 3;
            // 
            // cmbRemoveEdgeOrigin
            // 
            cmbRemoveEdgeOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRemoveEdgeOrigin.Font = new Font("Segoe UI", 9F);
            cmbRemoveEdgeOrigin.FormattingEnabled = true;
            cmbRemoveEdgeOrigin.Location = new Point(11, 99);
            cmbRemoveEdgeOrigin.Margin = new Padding(3, 4, 3, 4);
            cmbRemoveEdgeOrigin.Name = "cmbRemoveEdgeOrigin";
            cmbRemoveEdgeOrigin.Size = new Size(159, 28);
            cmbRemoveEdgeOrigin.TabIndex = 2;
            // 
            // btnRemoveVertex
            // 
            btnRemoveVertex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveVertex.BackColor = Color.White;
            btnRemoveVertex.Cursor = Cursors.Hand;
            btnRemoveVertex.FlatStyle = FlatStyle.Flat;
            btnRemoveVertex.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnRemoveVertex.ForeColor = SystemColors.WindowText;
            btnRemoveVertex.Location = new Point(195, 32);
            btnRemoveVertex.Margin = new Padding(3, 4, 3, 4);
            btnRemoveVertex.Name = "btnRemoveVertex";
            btnRemoveVertex.Size = new Size(155, 36);
            btnRemoveVertex.TabIndex = 1;
            btnRemoveVertex.Text = " Quitar Vértice";
            btnRemoveVertex.UseVisualStyleBackColor = false;
            // 
            // cmbRemoveVertex
            // 
            cmbRemoveVertex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRemoveVertex.Font = new Font("Segoe UI", 9F);
            cmbRemoveVertex.FormattingEnabled = true;
            cmbRemoveVertex.Location = new Point(11, 35);
            cmbRemoveVertex.Margin = new Padding(3, 4, 3, 4);
            cmbRemoveVertex.Name = "cmbRemoveVertex";
            cmbRemoveVertex.Size = new Size(171, 28);
            cmbRemoveVertex.TabIndex = 0;
            // 
            // grpGraphInsertion
            // 
            grpGraphInsertion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpGraphInsertion.BackColor = Color.FromArgb(248, 249, 250);
            grpGraphInsertion.Controls.Add(btnAddEdge);
            grpGraphInsertion.Controls.Add(numEdgeWeight);
            grpGraphInsertion.Controls.Add(lblEdgeWeight);
            grpGraphInsertion.Controls.Add(chkWeightedEdge);
            grpGraphInsertion.Controls.Add(cmbDestinationVertex);
            grpGraphInsertion.Controls.Add(cmbOriginVertex);
            grpGraphInsertion.Controls.Add(btnAddVertex);
            grpGraphInsertion.Controls.Add(txtVertexName);
            grpGraphInsertion.Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
            grpGraphInsertion.ForeColor = Color.FromArgb(45, 52, 54);
            grpGraphInsertion.Location = new Point(7, 8);
            grpGraphInsertion.Margin = new Padding(3, 4, 3, 4);
            grpGraphInsertion.Name = "grpGraphInsertion";
            grpGraphInsertion.Padding = new Padding(3, 4, 3, 4);
            grpGraphInsertion.Size = new Size(362, 214);
            grpGraphInsertion.TabIndex = 0;
            grpGraphInsertion.TabStop = false;
            grpGraphInsertion.Text = "4.2.2.1 Inserción";
            // 
            // btnAddEdge
            // 
            btnAddEdge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddEdge.BackColor = Color.White;
            btnAddEdge.Cursor = Cursors.Hand;
            btnAddEdge.FlatStyle = FlatStyle.Flat;
            btnAddEdge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnAddEdge.ForeColor = Color.Black;
            btnAddEdge.Location = new Point(11, 158);
            btnAddEdge.Margin = new Padding(3, 4, 3, 4);
            btnAddEdge.Name = "btnAddEdge";
            btnAddEdge.Size = new Size(339, 44);
            btnAddEdge.TabIndex = 7;
            btnAddEdge.Text = "Conectar Vértices (Arista)";
            btnAddEdge.UseVisualStyleBackColor = false;
            // 
            // numEdgeWeight
            // 
            numEdgeWeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numEdgeWeight.Enabled = false;
            numEdgeWeight.Font = new Font("Segoe UI", 9F);
            numEdgeWeight.Location = new Point(256, 117);
            numEdgeWeight.Margin = new Padding(3, 4, 3, 4);
            numEdgeWeight.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numEdgeWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numEdgeWeight.Name = "numEdgeWeight";
            numEdgeWeight.Size = new Size(93, 27);
            numEdgeWeight.TabIndex = 6;
            numEdgeWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblEdgeWeight
            // 
            lblEdgeWeight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEdgeWeight.AutoSize = true;
            lblEdgeWeight.Font = new Font("Segoe UI", 9F);
            lblEdgeWeight.ForeColor = Color.Gray;
            lblEdgeWeight.Location = new Point(211, 120);
            lblEdgeWeight.Name = "lblEdgeWeight";
            lblEdgeWeight.Size = new Size(42, 20);
            lblEdgeWeight.TabIndex = 5;
            lblEdgeWeight.Text = "Peso:";
            // 
            // chkWeightedEdge
            // 
            chkWeightedEdge.AutoSize = true;
            chkWeightedEdge.Cursor = Cursors.Hand;
            chkWeightedEdge.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            chkWeightedEdge.Location = new Point(11, 119);
            chkWeightedEdge.Name = "chkWeightedEdge";
            chkWeightedEdge.Size = new Size(207, 23);
            chkWeightedEdge.TabIndex = 4;
            chkWeightedEdge.Text = "Arista Ponderada (con peso)";
            chkWeightedEdge.UseVisualStyleBackColor = true;
            // 
            // cmbDestinationVertex
            // 
            cmbDestinationVertex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbDestinationVertex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestinationVertex.Font = new Font("Segoe UI", 9F);
            cmbDestinationVertex.FormattingEnabled = true;
            cmbDestinationVertex.Location = new Point(190, 76);
            cmbDestinationVertex.Margin = new Padding(3, 4, 3, 4);
            cmbDestinationVertex.Name = "cmbDestinationVertex";
            cmbDestinationVertex.Size = new Size(159, 28);
            cmbDestinationVertex.TabIndex = 3;
            // 
            // cmbOriginVertex
            // 
            cmbOriginVertex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOriginVertex.Font = new Font("Segoe UI", 9F);
            cmbOriginVertex.FormattingEnabled = true;
            cmbOriginVertex.Location = new Point(11, 76);
            cmbOriginVertex.Margin = new Padding(3, 4, 3, 4);
            cmbOriginVertex.Name = "cmbOriginVertex";
            cmbOriginVertex.Size = new Size(159, 28);
            cmbOriginVertex.TabIndex = 2;
            // 
            // btnAddVertex
            // 
            btnAddVertex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddVertex.BackColor = Color.Transparent;
            btnAddVertex.Cursor = Cursors.Hand;
            btnAddVertex.FlatStyle = FlatStyle.Flat;
            btnAddVertex.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            btnAddVertex.ForeColor = Color.Black;
            btnAddVertex.Location = new Point(218, 29);
            btnAddVertex.Margin = new Padding(3, 4, 3, 4);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(133, 36);
            btnAddVertex.TabIndex = 1;
            btnAddVertex.Text = "Nuevo Vértice";
            btnAddVertex.UseVisualStyleBackColor = false;
            // 
            // txtVertexName
            // 
            txtVertexName.Font = new Font("Segoe UI", 9F);
            txtVertexName.Location = new Point(11, 32);
            txtVertexName.Margin = new Padding(3, 4, 3, 4);
            txtVertexName.Name = "txtVertexName";
            txtVertexName.PlaceholderText = "Nombre vértice...";
            txtVertexName.Size = new Size(194, 27);
            txtVertexName.TabIndex = 0;
            // 
            // lstGraphLog
            // 
            lstGraphLog.BackColor = Color.FromArgb(45, 52, 54);
            lstGraphLog.BorderStyle = BorderStyle.None;
            lstGraphLog.Dock = DockStyle.Bottom;
            lstGraphLog.Font = new Font("Consolas", 8F);
            lstGraphLog.ForeColor = Color.FromArgb(223, 230, 233);
            lstGraphLog.FormattingEnabled = true;
            lstGraphLog.Location = new Point(0, 841);
            lstGraphLog.Margin = new Padding(3, 4, 3, 4);
            lstGraphLog.Name = "lstGraphLog";
            lstGraphLog.Size = new Size(1234, 90);
            lstGraphLog.TabIndex = 2;
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.White;
            panelTopBar.Controls.Add(btnClearGraph);
            panelTopBar.Controls.Add(btnViewAdjacencyList);
            panelTopBar.Controls.Add(btnViewAdjacencyMatrix);
            panelTopBar.Controls.Add(panelGraphStructure);
            panelTopBar.Controls.Add(panelGraphWeighting);
            panelTopBar.Controls.Add(panelGraphDirection);
            panelTopBar.Controls.Add(lblSystemTitle);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Margin = new Padding(3, 4, 3, 4);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1234, 67);
            panelTopBar.TabIndex = 0;
            // 
            // btnClearGraph
            // 
            btnClearGraph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearGraph.BackColor = Color.FromArgb(214, 48, 49);
            btnClearGraph.Cursor = Cursors.Hand;
            btnClearGraph.FlatStyle = FlatStyle.Flat;
            btnClearGraph.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnClearGraph.ForeColor = Color.White;
            btnClearGraph.Location = new Point(1124, 13);
            btnClearGraph.Margin = new Padding(3, 4, 3, 4);
            btnClearGraph.Name = "btnClearGraph";
            btnClearGraph.Size = new Size(95, 40);
            btnClearGraph.TabIndex = 5;
            btnClearGraph.Text = "\U0001f9f9 Vaciar";
            btnClearGraph.UseVisualStyleBackColor = false;
            // 
            // btnViewAdjacencyList
            // 
            btnViewAdjacencyList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewAdjacencyList.BackColor = Color.FromArgb(108, 92, 231);
            btnViewAdjacencyList.Cursor = Cursors.Hand;
            btnViewAdjacencyList.FlatStyle = FlatStyle.Flat;
            btnViewAdjacencyList.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnViewAdjacencyList.ForeColor = Color.White;
            btnViewAdjacencyList.Location = new Point(1005, 13);
            btnViewAdjacencyList.Margin = new Padding(3, 4, 3, 4);
            btnViewAdjacencyList.Name = "btnViewAdjacencyList";
            btnViewAdjacencyList.Size = new Size(112, 40);
            btnViewAdjacencyList.TabIndex = 4;
            btnViewAdjacencyList.Text = "📋 Lista";
            btnViewAdjacencyList.UseVisualStyleBackColor = false;
            // 
            // btnViewAdjacencyMatrix
            // 
            btnViewAdjacencyMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewAdjacencyMatrix.BackColor = Color.FromArgb(9, 132, 227);
            btnViewAdjacencyMatrix.Cursor = Cursors.Hand;
            btnViewAdjacencyMatrix.FlatStyle = FlatStyle.Flat;
            btnViewAdjacencyMatrix.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnViewAdjacencyMatrix.ForeColor = Color.White;
            btnViewAdjacencyMatrix.Location = new Point(885, 13);
            btnViewAdjacencyMatrix.Margin = new Padding(3, 4, 3, 4);
            btnViewAdjacencyMatrix.Name = "btnViewAdjacencyMatrix";
            btnViewAdjacencyMatrix.Size = new Size(113, 40);
            btnViewAdjacencyMatrix.TabIndex = 3;
            btnViewAdjacencyMatrix.Text = "📊 Matriz";
            btnViewAdjacencyMatrix.UseVisualStyleBackColor = false;
            // 
            // panelGraphStructure
            // 
            panelGraphStructure.Controls.Add(lblStructureTitle);
            panelGraphStructure.Controls.Add(cmbGraphStructure);
            panelGraphStructure.Location = new Point(690, 4);
            panelGraphStructure.Name = "panelGraphStructure";
            panelGraphStructure.Size = new Size(185, 58);
            panelGraphStructure.TabIndex = 3;
            // 
            // lblStructureTitle
            // 
            lblStructureTitle.AutoSize = true;
            lblStructureTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblStructureTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblStructureTitle.Location = new Point(3, 3);
            lblStructureTitle.Name = "lblStructureTitle";
            lblStructureTitle.Size = new Size(140, 17);
            lblStructureTitle.TabIndex = 0;
            lblStructureTitle.Text = "ESTRUCTURA DE LISTA:";
            // 
            // cmbGraphStructure
            // 
            cmbGraphStructure.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGraphStructure.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            cmbGraphStructure.FormattingEnabled = true;
            cmbGraphStructure.Location = new Point(3, 24);
            cmbGraphStructure.Name = "cmbGraphStructure";
            cmbGraphStructure.Size = new Size(178, 25);
            cmbGraphStructure.TabIndex = 1;
            // 
            // panelGraphWeighting
            // 
            panelGraphWeighting.Controls.Add(lblWeightingTitle);
            panelGraphWeighting.Controls.Add(rbWeighted);
            panelGraphWeighting.Controls.Add(rbUnweighted);
            panelGraphWeighting.Location = new Point(440, 4);
            panelGraphWeighting.Name = "panelGraphWeighting";
            panelGraphWeighting.Size = new Size(245, 58);
            panelGraphWeighting.TabIndex = 2;
            // 
            // lblWeightingTitle
            // 
            lblWeightingTitle.AutoSize = true;
            lblWeightingTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblWeightingTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblWeightingTitle.Location = new Point(3, 3);
            lblWeightingTitle.Name = "lblWeightingTitle";
            lblWeightingTitle.Size = new Size(176, 17);
            lblWeightingTitle.TabIndex = 0;
            lblWeightingTitle.Text = "MODO PREDETERMINADO:";
            // 
            // rbWeighted
            // 
            rbWeighted.AutoSize = true;
            rbWeighted.Cursor = Cursors.Hand;
            rbWeighted.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbWeighted.ForeColor = Color.Black;
            rbWeighted.Location = new Point(130, 26);
            rbWeighted.Name = "rbWeighted";
            rbWeighted.Size = new Size(97, 23);
            rbWeighted.TabIndex = 2;
            rbWeighted.Text = "Ponderado";
            rbWeighted.UseVisualStyleBackColor = true;
            // 
            // rbUnweighted
            // 
            rbUnweighted.AutoSize = true;
            rbUnweighted.Checked = true;
            rbUnweighted.Cursor = Cursors.Hand;
            rbUnweighted.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbUnweighted.ForeColor = Color.Black;
            rbUnweighted.Location = new Point(6, 26);
            rbUnweighted.Name = "rbUnweighted";
            rbUnweighted.Size = new Size(120, 23);
            rbUnweighted.TabIndex = 1;
            rbUnweighted.TabStop = true;
            rbUnweighted.Text = "No Ponderado";
            rbUnweighted.UseVisualStyleBackColor = true;
            // 
            // panelGraphDirection
            // 
            panelGraphDirection.Controls.Add(lblDirectionTitle);
            panelGraphDirection.Controls.Add(rbDirected);
            panelGraphDirection.Controls.Add(rbUndirected);
            panelGraphDirection.Location = new Point(200, 4);
            panelGraphDirection.Name = "panelGraphDirection";
            panelGraphDirection.Size = new Size(235, 58);
            panelGraphDirection.TabIndex = 1;
            // 
            // lblDirectionTitle
            // 
            lblDirectionTitle.AutoSize = true;
            lblDirectionTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblDirectionTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDirectionTitle.Location = new Point(3, 3);
            lblDirectionTitle.Name = "lblDirectionTitle";
            lblDirectionTitle.Size = new Size(81, 17);
            lblDirectionTitle.TabIndex = 0;
            lblDirectionTitle.Text = "DIRECCIÓN:";
            // 
            // rbDirected
            // 
            rbDirected.AutoSize = true;
            rbDirected.Cursor = Cursors.Hand;
            rbDirected.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbDirected.ForeColor = Color.Black;
            rbDirected.Location = new Point(135, 26);
            rbDirected.Name = "rbDirected";
            rbDirected.Size = new Size(81, 23);
            rbDirected.TabIndex = 2;
            rbDirected.Text = "Dirigido";
            rbDirected.UseVisualStyleBackColor = true;
            // 
            // rbUndirected
            // 
            rbUndirected.AutoSize = true;
            rbUndirected.Checked = true;
            rbUndirected.Cursor = Cursors.Hand;
            rbUndirected.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            rbUndirected.ForeColor = Color.Black;
            rbUndirected.Location = new Point(6, 26);
            rbUndirected.Name = "rbUndirected";
            rbUndirected.Size = new Size(104, 23);
            rbUndirected.TabIndex = 1;
            rbUndirected.TabStop = true;
            rbUndirected.Text = "No Dirigido";
            rbUndirected.UseVisualStyleBackColor = true;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSystemTitle.ForeColor = Color.Black;
            lblSystemTitle.Location = new Point(12, 17);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(183, 28);
            lblSystemTitle.TabIndex = 0;
            lblSystemTitle.Text = "Sistema de Grafos";
            // 
            // GraphForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1234, 931);
            Controls.Add(splitMainContainer);
            Controls.Add(lstGraphLog);
            Controls.Add(panelTopBar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(969, 718);
            Name = "GraphForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Grafos - 3 Tipos de Listas";
            splitMainContainer.Panel1.ResumeLayout(false);
            splitMainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMainContainer).EndInit();
            splitMainContainer.ResumeLayout(false);
            panelCanvasFooter.ResumeLayout(false);
            panelCanvasFooter.PerformLayout();
            panelGraphOperations.ResumeLayout(false);
            grpGraphAdjacency.ResumeLayout(false);
            grpGraphDeletion.ResumeLayout(false);
            grpGraphInsertion.ResumeLayout(false);
            grpGraphInsertion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEdgeWeight).EndInit();
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            panelGraphStructure.ResumeLayout(false);
            panelGraphStructure.PerformLayout();
            panelGraphWeighting.ResumeLayout(false);
            panelGraphWeighting.PerformLayout();
            panelGraphDirection.ResumeLayout(false);
            panelGraphDirection.PerformLayout();
            ResumeLayout(false);
        }
    }
}
