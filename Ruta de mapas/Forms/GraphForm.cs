using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    public partial class GraphForm : Form
    {
        // The 3 graph implementations managed polymorphically through BaseGraph
        private readonly BaseGraph[] graphStructures = new BaseGraph[]
        {
            new SimpleListGraph(isDirected: false, isWeighted: false),
            new LinkedListGraph(isDirected: false, isWeighted: false),
            new ListGraph(isDirected: false, isWeighted: false)
        };

        // 0 = Custom Simple List, 1 = .NET LinkedList<T>, 2 = .NET List<T>
        private int activeStructureIndex = 0;
        private BaseGraph ActiveGraph => graphStructures[activeStructureIndex];

        // Graph canvas interaction state
        private Vertex? selectedVertex = null;
        private Vertex? draggedVertex = null;
        private int dragOffsetX = 0;
        private int dragOffsetY = 0;

        // Highlighted visual elements of the graph
        private Edge? highlightedEdge = null;
        private Vertex? highlightedVertexA = null;
        private Vertex? highlightedVertexB = null;

        // Click position selected for the next vertex
        private Point? nextVertexClickPosition = null;

        // Last BFS/DFS traversal executed (null = no traversal marks on the canvas)
        private TraversalResult? traversalResult = null;

        public GraphForm()
        {
            InitializeComponent();
            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            this.Load += GraphForm_Load;

            cmbGraphStructure.Items.Clear();
            cmbGraphStructure.Items.AddRange(new object[]
            {
                "Lista Simple Propia",
                ".NET LinkedList<T>",
                ".NET List<T>"
            });
            cmbGraphStructure.SelectedIndex = 0;
            cmbGraphStructure.SelectedIndexChanged += CmbGraphStructure_SelectedIndexChanged;

            rbUndirected.CheckedChanged += RbGraphDirection_CheckedChanged;
            rbDirected.CheckedChanged += RbGraphDirection_CheckedChanged;

            rbUnweighted.CheckedChanged += RbGraphWeighting_CheckedChanged;
            rbWeighted.CheckedChanged += RbGraphWeighting_CheckedChanged;

            chkWeightedEdge.CheckedChanged += ChkWeightedEdge_CheckedChanged;

            panelGraphCanvas.Paint += PanelGraphCanvas_Paint;
            panelGraphCanvas.Resize += PanelGraphCanvas_Resize;
            panelGraphCanvas.MouseDown += PanelGraphCanvas_MouseDown;
            panelGraphCanvas.MouseMove += PanelGraphCanvas_MouseMove;
            panelGraphCanvas.MouseUp += PanelGraphCanvas_MouseUp;
            panelGraphCanvas.MouseDoubleClick += PanelGraphCanvas_MouseDoubleClick;

            panelGraphOperations.Resize += PanelGraphOperations_Resize;

            btnViewAdjacencyMatrix.Click += BtnViewAdjacencyMatrix_Click;
            btnViewAdjacencyList.Click += BtnViewAdjacencyList_Click;
            btnClearGraph.Click += BtnClearGraph_Click;

            btnAddVertex.Click += BtnAddVertex_Click;
            btnAddEdge.Click += BtnAddEdge_Click;

            btnRemoveVertex.Click += BtnRemoveVertex_Click;
            btnRemoveEdge.Click += BtnRemoveEdge_Click;

            btnCheckAdjacency.Click += BtnCheckAdjacency_Click;
            btnViewAdjacents.Click += BtnViewAdjacents_Click;

            // Traversals (BFS / DFS)
            btnBfs.Click += (sender, e) => RunTraversal(useBfs: true);
            btnDfs.Click += (sender, e) => RunTraversal(useBfs: false);
            btnClearTraversal.Click += (sender, e) => ClearTraversalMarks();
            cmbTraversalOrigin.SelectedIndexChanged += (sender, e) => ClearTraversalMarks();
        }

        private void GraphForm_Load(object? sender, EventArgs e)
        {
            AdjustResponsiveControls();
            UpdateInsertionControlsState();
            SyncVertexComboBoxes();
            LogEvent(LogCategories.Startup, $"Sistema de grafos iniciado con '{ActiveGraph.StructureTypeName}' ({ActiveGraph.VertexCount} vértices). Haz clic en el mapa para ubicar un vértice.");
        }

        private void CmbGraphStructure_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ChangeGraphStructure();
        }

        private void RbGraphDirection_CheckedChanged(object? sender, EventArgs e)
        {
            ChangeGraphDirectionMode();
        }

        private void RbGraphWeighting_CheckedChanged(object? sender, EventArgs e)
        {
            ChangeDefaultWeightingMode();
        }

        private void ChkWeightedEdge_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateInsertionControlsState();
        }

        private void PanelGraphCanvas_Resize(object? sender, EventArgs e)
        {
            panelGraphCanvas.Invalidate();
        }

        private void PanelGraphOperations_Resize(object? sender, EventArgs e)
        {
            AdjustResponsiveControls();
        }

        private void BtnViewAdjacencyMatrix_Click(object? sender, EventArgs e)
        {
            new AdjacencyMatrixForm(ActiveGraph).ShowDialog(this);
        }

        private void BtnViewAdjacencyList_Click(object? sender, EventArgs e)
        {
            new AdjacencyListForm(ActiveGraph).ShowDialog(this);
        }

        private void ChangeGraphStructure()
        {
            if (cmbGraphStructure.SelectedIndex < 0) return;
            if (cmbGraphStructure.SelectedIndex == activeStructureIndex) return;

            List<Vertex> previousVertices = ActiveGraph.GetAllVertices();
            List<Edge> previousEdges = ActiveGraph.GetAllEdges();
            bool isDirected = rbDirected.Checked;
            bool isWeighted = rbWeighted.Checked;

            activeStructureIndex = cmbGraphStructure.SelectedIndex;

            ActiveGraph.ClearGraph();
            ActiveGraph.IsDirected = isDirected;
            ActiveGraph.IsWeighted = isWeighted;

            for (int i = 0; i < previousVertices.Count; i++)
            {
                Vertex vertex = previousVertices[i];
                ActiveGraph.AddVertex(vertex.Name, vertex.X, vertex.Y, out _);
            }
            for (int i = 0; i < previousEdges.Count; i++)
            {
                Edge edge = previousEdges[i];
                double? weight = edge.IsWeighted ? edge.Weight : null;
                ActiveGraph.AddEdge(edge.Origin.Name, edge.Destination.Name, edge.IsWeighted, weight, out _);
            }

            LogEvent(LogCategories.GraphType, $"Estructura cambiada a: {ActiveGraph.StructureTypeName} ({ActiveGraph.VertexCount} vértices, {ActiveGraph.EdgeCount} aristas).");
            panelGraphCanvas.Invalidate();
        }

        private void ChangeGraphDirectionMode()
        {
            bool isDirected = rbDirected.Checked;
            for (int i = 0; i < graphStructures.Length; i++)
            {
                graphStructures[i].IsDirected = isDirected;
            }

            string directionModeText = isDirected ? "DIRIGIDO (A -> B)" : "NO DIRIGIDO (A <-> B)";
            LogEvent(LogCategories.GraphType, $"Modo de dirección cambiado a: {directionModeText}.");

            highlightedEdge = null;
            lblAdjacencyResult.BackColor = Color.White;
            lblAdjacencyResult.ForeColor = Color.Black;
            lblAdjacencyResult.Text = $"Grafo configurado como {directionModeText}.";

            ClearTraversalMarks();   // a traversal result depends on whether the graph is directed
            panelGraphCanvas.Invalidate();
        }

        private void ChangeDefaultWeightingMode()
        {
            bool isWeighted = rbWeighted.Checked;
            for (int i = 0; i < graphStructures.Length; i++)
            {
                graphStructures[i].IsWeighted = isWeighted;
            }

            chkWeightedEdge.Checked = isWeighted;

            string weightingModeText = isWeighted ? "PONDERADO (por defecto)" : "NO PONDERADO (por defecto)";
            LogEvent(LogCategories.GraphType, $"Modo de ponderación predeterminado: {weightingModeText}.");

            UpdateInsertionControlsState();
            panelGraphCanvas.Invalidate();
        }

        private void UpdateInsertionControlsState()
        {
            bool isWeighted = chkWeightedEdge.Checked;
            numEdgeWeight.Enabled = isWeighted;
            lblEdgeWeight.ForeColor = isWeighted ? Color.Black : Color.Gray;
        }

        private void BtnAddVertex_Click(object? sender, EventArgs e)
        {
            string vertexName = txtVertexName.Text.Trim();
            if (string.IsNullOrEmpty(vertexName))
            {
                MessageBox.Show("Ingresa un nombre para el vértice.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVertexName.Focus();
                return;
            }

            Point location = GetLocationForNewVertex();
            bool success = ActiveGraph.AddVertex(vertexName, location.X, location.Y, out string message);

            if (success)
            {
                LogEvent(LogCategories.Insertion, message);
                txtVertexName.Clear();
                nextVertexClickPosition = null;

                SyncVertexComboBoxes();
                panelGraphCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Point GetLocationForNewVertex()
        {
            if (nextVertexClickPosition.HasValue)
            {
                return nextVertexClickPosition.Value;
            }

            int currentCount = ActiveGraph.VertexCount;
            int margin = VisualConfig.CanvasMargin * 2;
            int availableWidth = Math.Max(100, panelGraphCanvas.Width - (margin * 2));
            int availableHeight = Math.Max(100, panelGraphCanvas.Height - (margin * 2));

            int stepX = 80;
            int stepY = 70;

            int newX = margin + ((currentCount * stepX) % availableWidth);
            int row = (currentCount * stepX) / availableWidth;
            int newY = margin + ((row * stepY) % availableHeight);

            return new Point(newX, newY);
        }

        private void BtnAddEdge_Click(object? sender, EventArgs e)
        {
            string originName = cmbOriginVertex.Text;
            string destinationName = cmbDestinationVertex.Text;

            if (string.IsNullOrEmpty(originName) || string.IsNullOrEmpty(destinationName))
            {
                MessageBox.Show("Selecciona el vértice origen y destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isWeighted = chkWeightedEdge.Checked;
            double? weight = isWeighted ? (double)numEdgeWeight.Value : null;

            bool success = ActiveGraph.AddEdge(originName, destinationName, isWeighted, weight, out string message);

            if (success)
            {
                LogEvent(LogCategories.Insertion, message);
                SyncVertexComboBoxes();
                panelGraphCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemoveVertex_Click(object? sender, EventArgs e)
        {
            string vertexName = cmbRemoveVertex.Text;
            if (string.IsNullOrEmpty(vertexName)) return;

            bool success = ActiveGraph.RemoveVertex(vertexName, out int orphanedEdges, out string message);

            if (success)
            {
                LogEvent(LogCategories.Deletion, message);
                if (orphanedEdges > 0)
                {
                    LogEvent(LogCategories.Orphaned, $"Se eliminaron automáticamente {orphanedEdges} aristas huérfanas conectadas a '{vertexName}'.");
                }

                if (selectedVertex != null && string.Equals(selectedVertex.Name, vertexName, StringComparison.OrdinalIgnoreCase)) selectedVertex = null;
                if (highlightedVertexA != null && string.Equals(highlightedVertexA.Name, vertexName, StringComparison.OrdinalIgnoreCase)) highlightedVertexA = null;
                if (highlightedVertexB != null && string.Equals(highlightedVertexB.Name, vertexName, StringComparison.OrdinalIgnoreCase)) highlightedVertexB = null;
                highlightedEdge = null;

                SyncVertexComboBoxes();
                panelGraphCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemoveEdge_Click(object? sender, EventArgs e)
        {
            string originName = cmbRemoveEdgeOrigin.Text;
            string destinationName = cmbRemoveEdgeDestination.Text;

            if (string.IsNullOrEmpty(originName) || string.IsNullOrEmpty(destinationName)) return;

            bool success = ActiveGraph.RemoveEdge(originName, destinationName, out string message);

            if (success)
            {
                LogEvent(LogCategories.Deletion, message);
                highlightedEdge = null;
                SyncVertexComboBoxes();
                panelGraphCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCheckAdjacency_Click(object? sender, EventArgs e)
        {
            string vertexAName = cmbAdjacencyVertexA.Text;
            string vertexBName = cmbAdjacencyVertexB.Text;

            if (string.IsNullOrEmpty(vertexAName) || string.IsNullOrEmpty(vertexBName)) return;

            bool areAdjacent = ActiveGraph.AreAdjacent(vertexAName, vertexBName, out Edge? connectingEdge, out string message);

            highlightedVertexA = ActiveGraph.FindVertex(vertexAName);
            highlightedVertexB = ActiveGraph.FindVertex(vertexBName);
            highlightedEdge = connectingEdge;

            if (areAdjacent)
            {
                lblAdjacencyResult.BackColor = Color.White;
                lblAdjacencyResult.ForeColor = Color.Black;
                lblAdjacencyResult.Text = message;
                LogEvent(LogCategories.Adjacency, message);
            }
            else
            {
                lblAdjacencyResult.BackColor = Color.White;
                lblAdjacencyResult.ForeColor = Color.Black;
                lblAdjacencyResult.Text = message;
                LogEvent(LogCategories.Adjacency, message);
            }

            panelGraphCanvas.Invalidate();
        }

        private void BtnViewAdjacents_Click(object? sender, EventArgs e)
        {
            string vertexName = cmbAdjacencyVertexA.Text;
            if (string.IsNullOrEmpty(vertexName)) return;

            List<AdjacentElement> adjacents = ActiveGraph.GetDetailedAdjacents(vertexName);

            if (adjacents.Count == 0)
            {
                lblAdjacencyResult.BackColor = Color.White;
                lblAdjacencyResult.ForeColor = Color.Black;
                lblAdjacencyResult.Text = $"El vértice '{vertexName}' no tiene vértices adyacentes.";
            }
            else
            {
                List<string> adjacentTexts = new List<string>(adjacents.Count);
                for (int i = 0; i < adjacents.Count; i++)
                {
                    AdjacentElement adjacent = adjacents[i];
                    if (adjacent.IsWeighted && adjacent.Weight.HasValue)
                    {
                        adjacentTexts.Add($"{adjacent.Destination.Name} (peso: {adjacent.Weight.Value:0.##})");
                    }
                    else
                    {
                        adjacentTexts.Add($"{adjacent.Destination.Name} (no ponderada)");
                    }
                }

                string joinedList = string.Join(", ", adjacentTexts);

                lblAdjacencyResult.BackColor = Color.White;
                lblAdjacencyResult.ForeColor = Color.Black;
                string relationType = ActiveGraph.IsDirected ? "Sucesores (salientes)" : "Vecinos";
                lblAdjacencyResult.Text = $"{relationType} de '{vertexName}' ({adjacents.Count}):\n{joinedList}";
                LogEvent(LogCategories.Neighbors, $"{relationType} de '{vertexName}': [{joinedList}].");
            }
        }

        // ===================== Traversals (BFS / DFS) =====================

        private void RunTraversal(bool useBfs)
        {
            if (ActiveGraph.VertexCount == 0)
            {
                MessageBox.Show("Add at least one vertex before traversing the graph.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string originName = cmbTraversalOrigin.Text;
            if (string.IsNullOrEmpty(originName))
            {
                MessageBox.Show("Select the origin vertex of the traversal.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The origin is the vertex selected in cmbTraversalOrigin (by default, the first vertex created)
            TraversalResult result = useBfs ? TraversalAlgorithms.Bfs(ActiveGraph, originName) : TraversalAlgorithms.Dfs(ActiveGraph, originName);
            traversalResult = result;

            // One-line result in the canvas footer
            lblTraversalStatus.Text = $"{result.Type} from {result.Origin}: {string.Join(" → ", result.Order)}";

            // Full detail in the log
            string graphKind = ActiveGraph.IsDirected ? "directed" : "undirected";
            string details = $"{result.Type} from '{result.Origin}' ({graphKind} graph) | Order: {string.Join(", ", result.Order)}";
            if (result.Distances != null)
            {
                details += " | Distances: " + string.Join(", ", result.Order.ConvertAll(name => $"{name}={result.Distances[name]}"));
            }
            if (result.Unreached.Count > 0)
            {
                details += $" | Unreached: {string.Join(", ", result.Unreached)}";
            }
            LogEvent(LogCategories.Traversal, details);

            panelGraphCanvas.Invalidate();
        }

        private void ClearTraversalMarks()
        {
            traversalResult = null;
            UpdateTraversalOriginText();
            panelGraphCanvas.Invalidate();
        }

        private void UpdateTraversalOriginText()
        {
            lblTraversalStatus.Text = string.IsNullOrEmpty(cmbTraversalOrigin.Text)
                ? "Traversals: add vertices (the default origin is the first one)."
                : $"Traversal origin: {cmbTraversalOrigin.Text}. Choose BFS or DFS.";
        }



        private void PanelGraphCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (Pen gridPen = new Pen(VisualConfig.GridColor, 1))
            {
                for (int x = 0; x < panelGraphCanvas.Width; x += VisualConfig.GridSpacing)
                {
                    graphics.DrawLine(gridPen, x, 0, x, panelGraphCanvas.Height);
                }
                for (int y = 0; y < panelGraphCanvas.Height; y += VisualConfig.GridSpacing)
                {
                    graphics.DrawLine(gridPen, 0, y, panelGraphCanvas.Width, y);
                }
            }

            DrawGraphModeBadge(graphics);

            List<Edge> edges = ActiveGraph.GetAllEdges();
            bool isDirected = ActiveGraph.IsDirected;

            for (int i = 0; i < edges.Count; i++)
            {
                Edge edge = edges[i];
                bool isHighlighted = edge.Equals(highlightedEdge);
                Color edgeColor = isHighlighted ? VisualConfig.HighlightedEdgeColor : VisualConfig.NormalEdgeColor;
                float edgeWidth = isHighlighted ? VisualConfig.HighlightedEdgeWidth : VisualConfig.NormalEdgeWidth;

                using (Pen edgePen = new Pen(edgeColor, edgeWidth))
                {
                    edgePen.StartCap = LineCap.Round;
                    edgePen.EndCap = LineCap.Round;
                    graphics.DrawLine(edgePen, edge.Origin.X, edge.Origin.Y, edge.Destination.X, edge.Destination.Y);

                    if (isDirected)
                    {
                        DrawEdgeArrow(graphics, edgePen, edge.Origin, edge.Destination);
                    }
                }

                if (edge.IsWeighted && edge.Weight.HasValue)
                {
                    DrawWeightBadge(graphics, edge, isHighlighted);
                }
            }

            List<Vertex> vertices = ActiveGraph.GetAllVertices();
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex vertex = vertices[i];
                bool isSelected = vertex.Equals(selectedVertex);
                bool isVerified = vertex.Equals(highlightedVertexA) || vertex.Equals(highlightedVertexB);

                int radius = vertex.Radius;
                int diameter = radius * 2;

                using (SolidBrush shadowBrush = new SolidBrush(VisualConfig.ShadowColor))
                {
                    graphics.FillEllipse(shadowBrush, vertex.X - radius + 2, vertex.Y - radius + 3, diameter, diameter);
                }

                Color vertexColor = VisualConfig.NormalVertexColor;
                if (isSelected) vertexColor = VisualConfig.SelectedVertexColor;
                else if (isVerified) vertexColor = VisualConfig.HighlightedVertexColor;

                using (SolidBrush vertexBrush = new SolidBrush(vertexColor))
                {
                    graphics.FillEllipse(vertexBrush, vertex.X - radius, vertex.Y - radius, diameter, diameter);
                }

                using (Pen borderPen = new Pen(Color.White, VisualConfig.VertexBorderWidth))
                {
                    graphics.DrawEllipse(borderPen, vertex.X - radius, vertex.Y - radius, diameter, diameter);
                }

                using (SolidBrush centerBrush = new SolidBrush(Color.White))
                {
                    graphics.FillEllipse(centerBrush, vertex.X - VisualConfig.CenterDotRadius, vertex.Y - VisualConfig.CenterDotRadius, VisualConfig.CenterDotDiameter, VisualConfig.CenterDotDiameter);
                }

                DrawVertexLabel(graphics, vertex, isSelected || isVerified);
                DrawTraversalMarks(graphics, vertex);
            }
        }

        private void DrawGraphModeBadge(Graphics graphics)
        {
            List<Edge> edges = ActiveGraph.GetAllEdges();
            int weightedCount = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].IsWeighted)
                {
                    weightedCount++;
                }
            }
            int unweightedCount = edges.Count - weightedCount;

            string directionText = ActiveGraph.IsDirected ? "Dirigido (→)" : "No Dirigido (↔)";
            string modeText = $"Estructura: [{ActiveGraph.StructureTypeName}]  |  Tipo: {directionText}  |  Aristas: {weightedCount} Pond., {unweightedCount} No Pond.";

            using (Font font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold))
            {
                SizeF textSize = graphics.MeasureString(modeText, font);
                RectangleF badgeRect = new RectangleF(14, 12, textSize.Width + 16, textSize.Height + 8);

                using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(240, 248, 250, 252)))
                using (Pen borderPen = new Pen(Color.FromArgb(203, 213, 225), 1f))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
                {
                    graphics.FillRectangle(backgroundBrush, badgeRect);
                    graphics.DrawRectangle(borderPen, badgeRect.X, badgeRect.Y, badgeRect.Width, badgeRect.Height);
                    graphics.DrawString(modeText, font, textBrush, badgeRect.X + 8, badgeRect.Y + 4);
                }
            }
        }

        private static void DrawWeightBadge(Graphics graphics, Edge edge, bool highlight)
        {
            float midX = (edge.Origin.X + edge.Destination.X) / 2f;
            float midY = (edge.Origin.Y + edge.Destination.Y) / 2f;

            float deltaX = edge.Destination.X - edge.Origin.X;
            float deltaY = edge.Destination.Y - edge.Origin.Y;
            float distance = MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance > 0.001f)
            {
                float normalX = -deltaY / distance;
                float normalY = deltaX / distance;
                midX += normalX * 14f;
                midY += normalY * 14f;
            }

            string weightText = edge.Weight?.ToString("0.##") ?? "";

            using (Font font = new Font("Segoe UI", 8.25F, FontStyle.Bold))
            {
                SizeF textSize = graphics.MeasureString(weightText, font);
                float width = Math.Max(22f, textSize.Width + 10f);
                float height = Math.Max(18f, textSize.Height + 4f);
                RectangleF weightRect = new RectangleF(midX - width / 2f, midY - height / 2f, width, height);

                Color backgroundColor = highlight ? VisualConfig.HighlightedWeightBackgroundColor : VisualConfig.NormalWeightBackgroundColor;
                Color borderColor = highlight ? VisualConfig.HighlightedWeightBorderColor : VisualConfig.NormalWeightBorderColor;
                Color textColor = highlight ? VisualConfig.HighlightedWeightTextColor : VisualConfig.NormalWeightTextColor;

                using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
                using (Pen borderPen = new Pen(borderColor, 1.5f))
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    graphics.FillRectangle(backgroundBrush, weightRect);
                    graphics.DrawRectangle(borderPen, weightRect.X, weightRect.Y, weightRect.Width, weightRect.Height);

                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    graphics.DrawString(weightText, font, textBrush, weightRect, stringFormat);
                }
            }
        }

        private static void DrawVertexLabel(Graphics graphics, Vertex vertex, bool highlight)
        {
            using (Font font = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                SizeF textSize = graphics.MeasureString(vertex.Name, font);
                float posX = vertex.X - textSize.Width / 2;
                float posY = vertex.Y + vertex.Radius + 3;

                RectangleF labelRect = new RectangleF(posX - 4, posY - 1, textSize.Width + 8, textSize.Height + 2);
                Color backgroundColor = highlight ? VisualConfig.LabelTextColor : VisualConfig.LabelBackgroundColor;
                Color textColor = highlight ? Color.White : VisualConfig.LabelTextColor;

                using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
                using (Pen borderPen = new Pen(Color.FromArgb(180, 189, 195, 199), 1f))
                using (SolidBrush textBrush = new SolidBrush(textColor))
                {
                    graphics.FillRectangle(backgroundBrush, labelRect);
                    graphics.DrawRectangle(borderPen, labelRect.X, labelRect.Y, labelRect.Width, labelRect.Height);
                    graphics.DrawString(vertex.Name, font, textBrush, posX, posY);
                }
            }
        }

        // Amber ring + "ORIGIN" tag on the origin vertex (always visible) and, after a traversal,
        // a badge with the visit order and (BFS only) the distance "d=n" from the origin.
        private void DrawTraversalMarks(Graphics graphics, Vertex vertex)
        {
            int radius = vertex.Radius;

            // 1) Traversal origin
            if (string.Equals(vertex.Name, cmbTraversalOrigin.Text, StringComparison.OrdinalIgnoreCase))
            {
                using (Pen ringPen = new Pen(VisualConfig.OriginRingColor, 3.5f))
                {
                    graphics.DrawEllipse(ringPen, vertex.X - radius - 5, vertex.Y - radius - 5, (radius + 5) * 2, (radius + 5) * 2);
                }

                using (Font font = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (SolidBrush tagBrush = new SolidBrush(VisualConfig.OriginRingColor))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    SizeF textSize = graphics.MeasureString("ORIGIN", font);
                    RectangleF tagRect = new RectangleF(vertex.X - textSize.Width / 2f - 3f, vertex.Y - radius - 10f - textSize.Height, textSize.Width + 6f, textSize.Height);
                    graphics.FillRectangle(tagBrush, tagRect);
                    graphics.DrawString("ORIGIN", font, textBrush, tagRect.X + 3f, tagRect.Y);
                }
            }

            // 2) Result of the last traversal
            if (traversalResult == null) return;

            if (traversalResult.OrderPosition.TryGetValue(vertex.Name, out int visitPosition))
            {
                float diameter = 22f;
                RectangleF badgeRect = new RectangleF(vertex.X + radius * 0.8f - diameter / 2f, vertex.Y - radius * 0.8f - diameter / 2f, diameter, diameter);

                using (Font font = new Font("Segoe UI", 8.25F, FontStyle.Bold))
                using (SolidBrush badgeBrush = new SolidBrush(VisualConfig.TraversalBadgeColor))
                using (SolidBrush textBrush = new SolidBrush(VisualConfig.TraversalBadgeTextColor))
                using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    graphics.FillEllipse(badgeBrush, badgeRect);
                    graphics.DrawString(visitPosition.ToString(), font, textBrush, badgeRect, format);
                }
            }

            if (traversalResult.Distances != null && traversalResult.Distances.TryGetValue(vertex.Name, out int distance))
            {
                string distanceText = $"d={distance}";

                using (Font font = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (SolidBrush badgeBrush = new SolidBrush(VisualConfig.TraversalBadgeColor))
                using (SolidBrush textBrush = new SolidBrush(VisualConfig.TraversalBadgeTextColor))
                using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    SizeF textSize = graphics.MeasureString(distanceText, font);
                    float width = textSize.Width + 2f;
                    float height = 16f;
                    RectangleF badgeRect = new RectangleF(vertex.X - radius * 0.8f - width / 2f, vertex.Y - radius * 0.8f - height / 2f, width, height);
                    graphics.FillRectangle(badgeBrush, badgeRect);
                    graphics.DrawString(distanceText, font, textBrush, badgeRect, format);
                }
            }
        }

        private static void DrawEdgeArrow(Graphics graphics, Pen edgePen, Vertex origin, Vertex destination)
        {
            double angle = Math.Atan2(destination.Y - origin.Y, destination.X - origin.X);
            int tipX = (int)(destination.X - destination.Radius * Math.Cos(angle));
            int tipY = (int)(destination.Y - destination.Radius * Math.Sin(angle));

            Point leftArrowPoint = new Point(
                (int)(tipX - VisualConfig.ArrowLength * Math.Cos(angle - VisualConfig.ArrowAngle)),
                (int)(tipY - VisualConfig.ArrowLength * Math.Sin(angle - VisualConfig.ArrowAngle)));
            Point rightArrowPoint = new Point(
                (int)(tipX - VisualConfig.ArrowLength * Math.Cos(angle + VisualConfig.ArrowAngle)),
                (int)(tipY - VisualConfig.ArrowLength * Math.Sin(angle + VisualConfig.ArrowAngle)));

            using (SolidBrush arrowBrush = new SolidBrush(edgePen.Color))
            {
                graphics.FillPolygon(arrowBrush, new Point[] { new Point(tipX, tipY), leftArrowPoint, rightArrowPoint });
            }
        }

        private void PanelGraphCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Vertex? clickedVertex = ActiveGraph.FindVertexByCoordinates(e.X, e.Y);
                if (clickedVertex != null)
                {
                    draggedVertex = clickedVertex;
                    dragOffsetX = clickedVertex.X - e.X;
                    dragOffsetY = clickedVertex.Y - e.Y;

                    if (selectedVertex == null || selectedVertex.Equals(clickedVertex))
                    {
                        selectedVertex = clickedVertex;
                        cmbOriginVertex.SelectedItem = clickedVertex.Name;
                        cmbRemoveVertex.SelectedItem = clickedVertex.Name;
                        cmbAdjacencyVertexA.SelectedItem = clickedVertex.Name;
                    }
                    else
                    {
                        cmbDestinationVertex.SelectedItem = clickedVertex.Name;
                        cmbAdjacencyVertexB.SelectedItem = clickedVertex.Name;
                        selectedVertex = clickedVertex;
                    }
                }
                else
                {
                    nextVertexClickPosition = new Point(e.X, e.Y);
                    selectedVertex = null;
                }
                panelGraphCanvas.Invalidate();
            }
        }

        private void PanelGraphCanvas_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (ActiveGraph.FindVertexByCoordinates(e.X, e.Y) == null)
            {
                nextVertexClickPosition = new Point(e.X, e.Y);
                txtVertexName.Focus();
                txtVertexName.SelectAll();
            }
        }

        private void PanelGraphCanvas_MouseMove(object? sender, MouseEventArgs e)
        {
            lblCanvasCoordinates.Text = $"Posición: (X: {e.X}, Y: {e.Y})";

            if (draggedVertex != null && e.Button == MouseButtons.Left)
            {
                int margin = VisualConfig.CanvasMargin;
                int newX = Math.Max(margin, Math.Min(panelGraphCanvas.Width - margin, e.X + dragOffsetX));
                int newY = Math.Max(margin, Math.Min(panelGraphCanvas.Height - margin, e.Y + dragOffsetY));

                draggedVertex.X = newX;
                draggedVertex.Y = newY;

                panelGraphCanvas.Invalidate();
            }
        }

        private void PanelGraphCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (draggedVertex != null)
            {
                draggedVertex = null;
                panelGraphCanvas.Invalidate();
            }
        }

        private void SyncVertexComboBoxes()
        {
            List<Vertex> vertices = ActiveGraph.GetAllVertices();

            string? selectedOrigin = cmbOriginVertex.Text;
            string? selectedDestination = cmbDestinationVertex.Text;
            string? selectedRemoveVertex = cmbRemoveVertex.Text;
            string? selectedRemoveEdgeOrigin = cmbRemoveEdgeOrigin.Text;
            string? selectedRemoveEdgeDestination = cmbRemoveEdgeDestination.Text;
            string? selectedAdjacencyA = cmbAdjacencyVertexA.Text;
            string? selectedAdjacencyB = cmbAdjacencyVertexB.Text;
            string? selectedTraversalOrigin = cmbTraversalOrigin.Text;

            cmbOriginVertex.Items.Clear();
            cmbDestinationVertex.Items.Clear();
            cmbRemoveVertex.Items.Clear();
            cmbRemoveEdgeOrigin.Items.Clear();
            cmbRemoveEdgeDestination.Items.Clear();
            cmbAdjacencyVertexA.Items.Clear();
            cmbAdjacencyVertexB.Items.Clear();
            cmbTraversalOrigin.Items.Clear();

            for (int i = 0; i < vertices.Count; i++)
            {
                string vertexName = vertices[i].Name;
                cmbOriginVertex.Items.Add(vertexName);
                cmbDestinationVertex.Items.Add(vertexName);
                cmbRemoveVertex.Items.Add(vertexName);
                cmbRemoveEdgeOrigin.Items.Add(vertexName);
                cmbRemoveEdgeDestination.Items.Add(vertexName);
                cmbAdjacencyVertexA.Items.Add(vertexName);
                cmbAdjacencyVertexB.Items.Add(vertexName);
                cmbTraversalOrigin.Items.Add(vertexName);
            }

            RestoreComboBoxSelection(cmbOriginVertex, selectedOrigin, 0);
            RestoreComboBoxSelection(cmbDestinationVertex, selectedDestination, vertices.Count > 1 ? 1 : 0);
            RestoreComboBoxSelection(cmbRemoveVertex, selectedRemoveVertex, 0);
            RestoreComboBoxSelection(cmbRemoveEdgeOrigin, selectedRemoveEdgeOrigin, 0);
            RestoreComboBoxSelection(cmbRemoveEdgeDestination, selectedRemoveEdgeDestination, vertices.Count > 1 ? 1 : 0);
            RestoreComboBoxSelection(cmbAdjacencyVertexA, selectedAdjacencyA, 0);
            RestoreComboBoxSelection(cmbAdjacencyVertexB, selectedAdjacencyB, vertices.Count > 1 ? 1 : 0);

            // The default traversal origin is the first vertex created (index 0)
            RestoreComboBoxSelection(cmbTraversalOrigin, selectedTraversalOrigin, 0);

            // If the graph changed, the previous traversal is no longer valid
            ClearTraversalMarks();
        }

        private static void RestoreComboBoxSelection(ComboBox comboBox, string? previousSelection, int defaultIndex)
        {
            if (comboBox.Items.Count == 0) return;
            if (!string.IsNullOrEmpty(previousSelection) && comboBox.Items.Contains(previousSelection))
            {
                comboBox.SelectedItem = previousSelection;
            }
            else if (defaultIndex >= 0 && defaultIndex < comboBox.Items.Count)
            {
                comboBox.SelectedIndex = defaultIndex;
            }
        }

        private void LogEvent(string category, string text)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            lstGraphLog.Items.Insert(0, $"[{timestamp}] [{category}] {text}");
        }

        private void AdjustResponsiveControls()
        {
            int horizontalMargin = 11;
            int controlSpacing = 16;

            txtVertexName.Width = Math.Max(100, btnAddVertex.Left - horizontalMargin - 12);
            cmbRemoveVertex.Width = Math.Max(100, btnRemoveVertex.Left - horizontalMargin - 12);

            AdjustHorizontalPair(grpGraphInsertion, cmbOriginVertex, cmbDestinationVertex, horizontalMargin, controlSpacing);
            AdjustHorizontalPair(grpGraphDeletion, cmbRemoveEdgeOrigin, cmbRemoveEdgeDestination, horizontalMargin, controlSpacing);
            AdjustHorizontalPair(grpGraphAdjacency, cmbAdjacencyVertexA, cmbAdjacencyVertexB, horizontalMargin, controlSpacing);
            AdjustHorizontalPair(grpGraphAdjacency, btnCheckAdjacency, btnViewAdjacents, horizontalMargin, controlSpacing);
            AdjustHorizontalPair(grpTraversals, btnBfs, btnDfs, horizontalMargin, controlSpacing);

            // Room is reserved below the Adjacency group for the Traversals group
            int availableAdjacencyHeight = panelGraphOperations.ClientSize.Height - grpGraphAdjacency.Top - 12 - (grpTraversals.Height + 8);
            if (availableAdjacencyHeight >= 220)
            {
                grpGraphAdjacency.Height = availableAdjacencyHeight;
                lblAdjacencyResult.Height = Math.Max(80, grpGraphAdjacency.ClientSize.Height - lblAdjacencyResult.Top - 12);
            }

            grpTraversals.Top = grpGraphAdjacency.Bottom + 8;
        }

        private static void AdjustHorizontalPair(Control container, Control leftControl, Control rightControl, int margin, int spacing)
        {
            int totalWidth = container.ClientSize.Width - (margin * 2) - spacing;
            if (totalWidth <= 80) return;

            int halfWidth = totalWidth / 2;
            leftControl.Left = margin;
            leftControl.Width = halfWidth;

            rightControl.Left = margin + halfWidth + spacing;
            rightControl.Width = totalWidth - halfWidth;
        }

        private void BtnClearGraph_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas vaciar el grafo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < graphStructures.Length; i++)
                {
                    graphStructures[i].ClearGraph();
                }

                selectedVertex = null;
                highlightedEdge = null;
                highlightedVertexA = null;
                highlightedVertexB = null;
                nextVertexClickPosition = null;
                SyncVertexComboBoxes();
                panelGraphCanvas.Invalidate();
                LogEvent(LogCategories.Clear, "El grafo ha sido vaciado por completo.");
            }
        }
    }
}