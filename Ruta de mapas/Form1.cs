using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Ruta_de_mapas
{
    public partial class Form1 : Form
    {
        private IGrafo grafo = new GrafoListaSimple(esDirigido: false, esPonderado: false);

        // Estado de interacción gráfica
        private Nodo? nodoSeleccionado = null;
        private Nodo? nodoArrastrado = null;
        private int dragOffsetX = 0;
        private int dragOffsetY = 0;

        // Elementos visuales resaltados
        private Arista? aristaResaltada = null;
        private Nodo? nodoResaltadoA = null;
        private Nodo? nodoResaltadoB = null;

        // Posición seleccionada por clic para el siguiente vértice
        private Point? posicionClicSiguienteNodo = null;

        public Form1()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += (s, e) =>
            {
                AjustarControlesResponsivos();
                ActualizarEstadoControlesInsercion();
                SincronizarComboBoxes();
                RegistrarLog(CategoriasLog.Inicio, $"Sistema de grafos iniciado con '{grafo.NombreTipoEstructura}' ({grafo.Count} nodos). Haz clic en el mapa para ubicar un vértice.");
            };

            // Selector de tipo de lista / estructura de grafo
            cmbTipoListaGrafo.Items.Clear();
            cmbTipoListaGrafo.Items.AddRange(new object[]
            {
                "Lista Simple Propia",
                ".NET LinkedList<T>",
                ".NET List<T>"
            });
            cmbTipoListaGrafo.SelectedIndex = 0;
            cmbTipoListaGrafo.SelectedIndexChanged += (s, e) => CambiarEstructuraGrafo();

            // Selector de modo Dirigido / No Dirigido
            rbNoDirigido.CheckedChanged += (s, e) => CambiarModoGrafo();
            rbDirigido.CheckedChanged += (s, e) => CambiarModoGrafo();

            // Selector de modo Ponderado / No Ponderado predeterminado
            rbNoPonderado.CheckedChanged += (s, e) => CambiarModoPredeterminadoPonderacion();
            rbPonderado.CheckedChanged += (s, e) => CambiarModoPredeterminadoPonderacion();

            // Casilla de verificación individual de Arista Ponderada
            chkPonderada.CheckedChanged += (s, e) => ActualizarEstadoControlesInsercion();

            // Lienzo interactivo
            panelCanvas.Paint += PanelCanvas_Paint;
            panelCanvas.Resize += (s, e) => panelCanvas.Invalidate();
            panelCanvas.MouseDown += PanelCanvas_MouseDown;
            panelCanvas.MouseMove += PanelCanvas_MouseMove;
            panelCanvas.MouseUp += PanelCanvas_MouseUp;
            panelCanvas.MouseDoubleClick += PanelCanvas_MouseDoubleClick;

            // Adaptación responsiva del panel lateral
            panelOperaciones.Resize += (s, e) => AjustarControlesResponsivos();

            // Botones de vistas y limpieza
            btnVerMatriz.Click += (s, e) => new FormMatriz(grafo).ShowDialog(this);
            btnVerLista.Click += (s, e) => new FormListaAdyacencia(grafo).ShowDialog(this);
            btnLimpiar.Click += BtnLimpiar_Click;

            // 4.2.2.1 Inserción
            btnAgregarVertice.Click += BtnAgregarVertice_Click;
            btnAgregarArista.Click += BtnAgregarArista_Click;

            // 4.2.2.2 Eliminación
            btnEliminarVertice.Click += BtnEliminarVertice_Click;
            btnEliminarArista.Click += BtnEliminarArista_Click;

            // 4.2.2.3 Adyacencia
            btnVerificarAdyacencia.Click += BtnVerificarAdyacencia_Click;
            btnVerVecinos.Click += BtnVerVecinos_Click;
        }


        private void CambiarEstructuraGrafo()
        {
            if (cmbTipoListaGrafo.SelectedIndex < 0) return;

            IGrafo nuevoGrafo = cmbTipoListaGrafo.SelectedIndex switch
            {
                0 => new GrafoListaSimple(grafo.EsDirigido, grafo.EsPonderado),
                1 => new GrafoLinkedList(grafo.EsDirigido, grafo.EsPonderado),
                _ => new GrafoList(grafo.EsDirigido, grafo.EsPonderado)
            };

            nuevoGrafo.CopiarDesde(grafo);
            grafo = nuevoGrafo;

            RegistrarLog(CategoriasLog.TipoGrafo, $"Estructura cambiada a: {grafo.NombreTipoEstructura} ({grafo.Count} nodos, {grafo.CantidadAristas} aristas).");
            panelCanvas.Invalidate();
        }

        private void CambiarModoGrafo()
        {
            grafo.EsDirigido = rbDirigido.Checked;
            string modoDir = grafo.EsDirigido ? "DIRIGIDO (A -> B)" : "NO DIRIGIDO (A <-> B)";
            RegistrarLog(CategoriasLog.TipoGrafo, $"Modo de dirección cambiado a: {modoDir}.");

            aristaResaltada = null;
            lblResultadoAdyacencia.BackColor = ConfiguracionVisual.ColorResultadoNeutroFondo;
            lblResultadoAdyacencia.ForeColor = ConfiguracionVisual.ColorResultadoNeutroTexto;
            lblResultadoAdyacencia.Text = $"Grafo configurado como {modoDir}.";

            panelCanvas.Invalidate();
        }

        private void CambiarModoPredeterminadoPonderacion()
        {
            grafo.EsPonderado = rbPonderado.Checked;
            chkPonderada.Checked = rbPonderado.Checked;

            string modo = grafo.EsPonderado ? "PONDERADO (por defecto)" : "NO PONDERADO (por defecto)";
            RegistrarLog(CategoriasLog.TipoGrafo, $"Modo de ponderación predeterminado: {modo}.");

            ActualizarEstadoControlesInsercion();
            panelCanvas.Invalidate();
        }

        private void ActualizarEstadoControlesInsercion()
        {
            bool esPond = chkPonderada.Checked;
            numPeso.Enabled = esPond;
            lblPeso.ForeColor = esPond ? Color.Black : Color.Gray;
        }



        private void BtnAgregarVertice_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresa un nombre para el vértice.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            Point ubicacion = ObtenerUbicacionParaNuevoNodo();

            if (grafo.AgregarVertice(nombre, ubicacion.X, ubicacion.Y, out string mensaje))
            {
                RegistrarLog(CategoriasLog.Insercion, mensaje);
                txtNombre.Clear();
                posicionClicSiguienteNodo = null;

                SincronizarComboBoxes();
                panelCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Point ObtenerUbicacionParaNuevoNodo()
        {
            if (posicionClicSiguienteNodo.HasValue)
            {
                return posicionClicSiguienteNodo.Value;
            }

            int margen = ConfiguracionVisual.MargenLienzo * 2;
            int anchoDisponible = Math.Max(100, panelCanvas.Width - (margen * 2));
            int altoDisponible = Math.Max(100, panelCanvas.Height - (margen * 2));

            int pasoX = 80;
            int pasoY = 70;

            int nuevoX = margen + ((grafo.Count * pasoX) % anchoDisponible);
            int fila = (grafo.Count * pasoX) / anchoDisponible;
            int nuevoY = margen + ((fila * pasoY) % altoDisponible);

            return new Point(nuevoX, nuevoY);
        }

        private void BtnAgregarArista_Click(object? sender, EventArgs e)
        {
            string origen = cmbOrigen.Text;
            string destino = cmbDestino.Text;

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Selecciona el nodo origen y destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool esPonderada = chkPonderada.Checked;
            double peso = (double)numPeso.Value;

            if (grafo.AgregarArista(origen, destino, esPonderada, peso, out string mensaje))
            {
                RegistrarLog(CategoriasLog.Insercion, mensaje);
                SincronizarComboBoxes();
                panelCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void BtnEliminarVertice_Click(object? sender, EventArgs e)
        {
            string nombre = cmbEliminarVertice.Text;
            if (string.IsNullOrEmpty(nombre)) return;

            if (grafo.EliminarVertice(nombre, out int huerfanas, out string mensaje))
            {
                RegistrarLog(CategoriasLog.Eliminacion, mensaje);
                if (huerfanas > 0)
                {
                    RegistrarLog(CategoriasLog.Huerfanas, $"🛡️ Se eliminaron automáticamente {huerfanas} aristas huérfanas conectadas a '{nombre}'.");
                }

                if (nodoSeleccionado != null && string.Equals(nodoSeleccionado.Nombre, nombre, StringComparison.OrdinalIgnoreCase)) nodoSeleccionado = null;
                if (nodoResaltadoA != null && string.Equals(nodoResaltadoA.Nombre, nombre, StringComparison.OrdinalIgnoreCase)) nodoResaltadoA = null;
                if (nodoResaltadoB != null && string.Equals(nodoResaltadoB.Nombre, nombre, StringComparison.OrdinalIgnoreCase)) nodoResaltadoB = null;
                aristaResaltada = null;

                SincronizarComboBoxes();
                panelCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminarArista_Click(object? sender, EventArgs e)
        {
            string origen = cmbEliminarAristaOrig.Text;
            string destino = cmbEliminarAristaDest.Text;

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino)) return;

            if (grafo.EliminarArista(origen, destino, out string mensaje))
            {
                RegistrarLog(CategoriasLog.Eliminacion, mensaje);
                aristaResaltada = null;
                SincronizarComboBoxes();
                panelCanvas.Invalidate();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void BtnVerificarAdyacencia_Click(object? sender, EventArgs e)
        {
            string nombreA = cmbAdyA.Text;
            string nombreB = cmbAdyB.Text;

            if (string.IsNullOrEmpty(nombreA) || string.IsNullOrEmpty(nombreB)) return;

            bool adyacentes = grafo.SonAdyacentes(nombreA, nombreB, out Arista? arista, out string mensaje);

            nodoResaltadoA = grafo.BuscarNodo(nombreA);
            nodoResaltadoB = grafo.BuscarNodo(nombreB);
            aristaResaltada = arista;

            if (adyacentes)
            {
                lblResultadoAdyacencia.BackColor = ConfiguracionVisual.ColorResultadoPositivoFondo;
                lblResultadoAdyacencia.ForeColor = ConfiguracionVisual.ColorResultadoPositivoTexto;
                lblResultadoAdyacencia.Text = $"✅ {mensaje}";
                RegistrarLog(CategoriasLog.Adyacencia, mensaje);
            }
            else
            {
                lblResultadoAdyacencia.BackColor = ConfiguracionVisual.ColorResultadoNegativoFondo;
                lblResultadoAdyacencia.ForeColor = ConfiguracionVisual.ColorResultadoNegativoTexto;
                lblResultadoAdyacencia.Text = $"❌ {mensaje}";
                RegistrarLog(CategoriasLog.Adyacencia, mensaje);
            }

            panelCanvas.Invalidate();
        }

        private void BtnVerVecinos_Click(object? sender, EventArgs e)
        {
            string nombre = cmbAdyA.Text;
            if (string.IsNullOrEmpty(nombre)) return;

            List<ElementoAdyacente> vecinos = grafo.ObtenerAdyacentesDetallados(nombre);

            if (vecinos.Count == 0)
            {
                lblResultadoAdyacencia.BackColor = ConfiguracionVisual.ColorResultadoNeutroFondo;
                lblResultadoAdyacencia.ForeColor = ConfiguracionVisual.ColorResultadoNeutroTexto;
                lblResultadoAdyacencia.Text = $"ℹ️ El nodo '{nombre}' no tiene vecinos adyacentes.";
            }
            else
            {
                string listaTexto = string.Join(", ", vecinos.ConvertAll(v =>
                    v.EsPonderada && v.Peso.HasValue
                        ? $"{v.Destino.Nombre} (peso: {v.Peso.Value:0.##})"
                        : $"{v.Destino.Nombre} (no ponderada)"
                ));

                lblResultadoAdyacencia.BackColor = ConfiguracionVisual.ColorResultadoPositivoFondo;
                lblResultadoAdyacencia.ForeColor = ConfiguracionVisual.ColorResultadoPositivoTexto;
                string tipo = grafo.EsDirigido ? "Sucesores (salientes)" : "Vecinos";
                lblResultadoAdyacencia.Text = $"👥 {tipo} de '{nombre}' ({vecinos.Count}):\n{listaTexto}";
                RegistrarLog(CategoriasLog.Vecinos, $"{tipo} de '{nombre}': [{listaTexto}].");
            }
        }



        private void PanelCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Cuadrícula suave
            using (Pen penGrid = new Pen(ConfiguracionVisual.ColorCuadricula, 1))
            {
                for (int x = 0; x < panelCanvas.Width; x += ConfiguracionVisual.EspaciadoCuadricula)
                {
                    g.DrawLine(penGrid, x, 0, x, panelCanvas.Height);
                }
                for (int y = 0; y < panelCanvas.Height; y += ConfiguracionVisual.EspaciadoCuadricula)
                {
                    g.DrawLine(penGrid, 0, y, panelCanvas.Width, y);
                }
            }

            // 2. Indicador visual del estado del grafo
            DibujarInsigniaModo(g);

            // 3. Aristas (Conexiones, Flechas y Distintivos de Peso)
            foreach (Arista a in grafo.Aristas)
            {
                bool esResaltada = a.Equals(aristaResaltada);
                Color color = esResaltada ? ConfiguracionVisual.ColorAristaResaltada : ConfiguracionVisual.ColorAristaNormal;
                float grosor = esResaltada ? ConfiguracionVisual.GrosorAristaResaltada : ConfiguracionVisual.GrosorAristaNormal;

                using (Pen pen = new Pen(color, grosor))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    g.DrawLine(pen, a.Origen.X, a.Origen.Y, a.Destino.X, a.Destino.Y);

                    if (grafo.EsDirigido)
                    {
                        DibujarFlecha(g, pen, a.Origen, a.Destino);
                    }
                }

                // Si esta arista específica es ponderada, dibujar su distintivo numérico
                if (a.EsPonderada && a.Peso.HasValue)
                {
                    DibujarBadgePeso(g, a, esResaltada);
                }
            }

            // 4. Vértices
            foreach (Nodo n in grafo.Nodos)
            {
                bool seleccionado = n.Equals(nodoSeleccionado);
                bool verificado = n.Equals(nodoResaltadoA) || n.Equals(nodoResaltadoB);

                int r = n.Radio;
                int d = r * 2;

                // Sombra
                using (SolidBrush bSombra = new SolidBrush(ConfiguracionVisual.ColorSombra))
                {
                    g.FillEllipse(bSombra, n.X - r + 2, n.Y - r + 3, d, d);
                }

                // Círculo del nodo
                Color color = ConfiguracionVisual.ColorNodoNormal;
                if (seleccionado) color = ConfiguracionVisual.ColorNodoSeleccionado;
                else if (verificado) color = ConfiguracionVisual.ColorNodoResaltado;

                using (SolidBrush bNodo = new SolidBrush(color))
                {
                    g.FillEllipse(bNodo, n.X - r, n.Y - r, d, d);
                }

                using (Pen pBorde = new Pen(Color.White, ConfiguracionVisual.GrosorBordeNodo))
                {
                    g.DrawEllipse(pBorde, n.X - r, n.Y - r, d, d);
                }

                using (SolidBrush bCentro = new SolidBrush(Color.White))
                {
                    g.FillEllipse(bCentro, n.X - ConfiguracionVisual.RadioPuntoCentro, n.Y - ConfiguracionVisual.RadioPuntoCentro, ConfiguracionVisual.DiametroPuntoCentro, ConfiguracionVisual.DiametroPuntoCentro);
                }

                DibujarNombreNodo(g, n, seleccionado || verificado);
            }
        }

        private void DibujarInsigniaModo(Graphics g)
        {
            int cantPond = grafo.Aristas.Count(a => a.EsPonderada);
            int cantNoPond = grafo.Aristas.Count() - cantPond;

            string dir = grafo.EsDirigido ? "Dirigido (→)" : "No Dirigido (↔)";
            string textoModo = $"Estructura: [{grafo.NombreTipoEstructura}]  |  Tipo: {dir}  |  Aristas: {cantPond} Pond., {cantNoPond} No Pond.";

            using (Font f = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold))
            {
                SizeF sz = g.MeasureString(textoModo, f);
                RectangleF rect = new RectangleF(14, 12, sz.Width + 16, sz.Height + 8);

                using (SolidBrush bF = new SolidBrush(Color.FromArgb(240, 248, 250, 252)))
                using (Pen pB = new Pen(Color.FromArgb(203, 213, 225), 1f))
                using (SolidBrush bT = new SolidBrush(Color.FromArgb(51, 65, 85)))
                {
                    g.FillRectangle(bF, rect);
                    g.DrawRectangle(pB, rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString(textoModo, f, bT, rect.X + 8, rect.Y + 4);
                }
            }
        }

        private static void DibujarBadgePeso(Graphics g, Arista a, bool resaltar)
        {
            float mx = (a.Origen.X + a.Destino.X) / 2f;
            float my = (a.Origen.Y + a.Destino.Y) / 2f;

            float dx = a.Destino.X - a.Origen.X;
            float dy = a.Destino.Y - a.Origen.Y;
            float dist = MathF.Sqrt(dx * dx + dy * dy);

            if (dist > 0.001f)
            {
                float nx = -dy / dist;
                float ny = dx / dist;
                mx += nx * 14f;
                my += ny * 14f;
            }

            string textoPeso = a.Peso?.ToString("0.##") ?? "";

            using (Font f = new Font("Segoe UI", 8.25F, FontStyle.Bold))
            {
                SizeF sz = g.MeasureString(textoPeso, f);
                float ancho = Math.Max(22f, sz.Width + 10f);
                float alto = Math.Max(18f, sz.Height + 4f);
                RectangleF rect = new RectangleF(mx - ancho / 2f, my - alto / 2f, ancho, alto);

                Color fondo = resaltar ? ConfiguracionVisual.ColorPesoFondoResaltado : ConfiguracionVisual.ColorPesoFondoNormal;
                Color borde = resaltar ? ConfiguracionVisual.ColorPesoBordeResaltado : ConfiguracionVisual.ColorPesoBordeNormal;
                Color textoColor = resaltar ? ConfiguracionVisual.ColorPesoTextoResaltado : ConfiguracionVisual.ColorPesoTextoNormal;

                using (SolidBrush bF = new SolidBrush(fondo))
                using (Pen pB = new Pen(borde, 1.5f))
                using (SolidBrush bT = new SolidBrush(textoColor))
                {
                    g.FillRectangle(bF, rect);
                    g.DrawRectangle(pB, rect.X, rect.Y, rect.Width, rect.Height);

                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(textoPeso, f, bT, rect, sf);
                }
            }
        }

        private static void DibujarNombreNodo(Graphics g, Nodo n, bool resaltar)
        {
            using (Font f = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                SizeF sz = g.MeasureString(n.Nombre, f);
                float posX = n.X - sz.Width / 2;
                float posY = n.Y + n.Radio + 3;

                RectangleF rect = new RectangleF(posX - 4, posY - 1, sz.Width + 8, sz.Height + 2);
                Color fondo = resaltar ? ConfiguracionVisual.ColorTextoEtiqueta : ConfiguracionVisual.ColorFondoEtiqueta;
                Color txtColor = resaltar ? Color.White : ConfiguracionVisual.ColorTextoEtiqueta;

                using (SolidBrush bF = new SolidBrush(fondo))
                using (Pen pB = new Pen(Color.FromArgb(180, 189, 195, 199), 1f))
                using (SolidBrush bT = new SolidBrush(txtColor))
                {
                    g.FillRectangle(bF, rect);
                    g.DrawRectangle(pB, rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString(n.Nombre, f, bT, posX, posY);
                }
            }
        }

        private static void DibujarFlecha(Graphics g, Pen pen, Nodo origen, Nodo destino)
        {
            double angulo = Math.Atan2(destino.Y - origen.Y, destino.X - origen.X);
            int puntaX = (int)(destino.X - destino.Radio * Math.Cos(angulo));
            int puntaY = (int)(destino.Y - destino.Radio * Math.Sin(angulo));

            Point p1 = new Point(
                (int)(puntaX - ConfiguracionVisual.LargoFlecha * Math.Cos(angulo - ConfiguracionVisual.AnguloFlecha)),
                (int)(puntaY - ConfiguracionVisual.LargoFlecha * Math.Sin(angulo - ConfiguracionVisual.AnguloFlecha)));
            Point p2 = new Point(
                (int)(puntaX - ConfiguracionVisual.LargoFlecha * Math.Cos(angulo + ConfiguracionVisual.AnguloFlecha)),
                (int)(puntaY - ConfiguracionVisual.LargoFlecha * Math.Sin(angulo + ConfiguracionVisual.AnguloFlecha)));

            using (SolidBrush b = new SolidBrush(pen.Color))
            {
                g.FillPolygon(b, new Point[] { new Point(puntaX, puntaY), p1, p2 });
            }
        }



        private void PanelCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Nodo? clickeado = grafo.BuscarNodoPorCoordenadas(e.X, e.Y);
                if (clickeado != null)
                {
                    nodoArrastrado = clickeado;
                    dragOffsetX = clickeado.X - e.X;
                    dragOffsetY = clickeado.Y - e.Y;

                    if (nodoSeleccionado == null || nodoSeleccionado.Equals(clickeado))
                    {
                        nodoSeleccionado = clickeado;
                        cmbOrigen.SelectedItem = clickeado.Nombre;
                        cmbEliminarVertice.SelectedItem = clickeado.Nombre;
                        cmbAdyA.SelectedItem = clickeado.Nombre;
                    }
                    else
                    {
                        cmbDestino.SelectedItem = clickeado.Nombre;
                        cmbAdyB.SelectedItem = clickeado.Nombre;
                        nodoSeleccionado = clickeado;
                    }
                }
                else
                {
                    posicionClicSiguienteNodo = new Point(e.X, e.Y);
                    nodoSeleccionado = null;
                }
                panelCanvas.Invalidate();
            }
        }

        private void PanelCanvas_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (grafo.BuscarNodoPorCoordenadas(e.X, e.Y) == null)
            {
                posicionClicSiguienteNodo = new Point(e.X, e.Y);
                txtNombre.Focus();
                txtNombre.SelectAll();
            }
        }

        private void PanelCanvas_MouseMove(object? sender, MouseEventArgs e)
        {
            lblCoords.Text = $"Posición: (X: {e.X}, Y: {e.Y})";

            if (nodoArrastrado != null && e.Button == MouseButtons.Left)
            {
                int margen = ConfiguracionVisual.MargenLienzo;
                int nx = Math.Max(margen, Math.Min(panelCanvas.Width - margen, e.X + dragOffsetX));
                int ny = Math.Max(margen, Math.Min(panelCanvas.Height - margen, e.Y + dragOffsetY));

                nodoArrastrado.X = nx;
                nodoArrastrado.Y = ny;

                panelCanvas.Invalidate();
            }
        }

        private void PanelCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (nodoArrastrado != null)
            {
                nodoArrastrado = null;
                panelCanvas.Invalidate();
            }
        }



        private void SincronizarComboBoxes()
        {
            IReadOnlyList<Nodo> nodos = grafo.ObtenerTodosLosNodos();

            string? selOrig = cmbOrigen.Text;
            string? selDest = cmbDestino.Text;
            string? selElimN = cmbEliminarVertice.Text;
            string? selElimOrig = cmbEliminarAristaOrig.Text;
            string? selElimDest = cmbEliminarAristaDest.Text;
            string? selAdyA = cmbAdyA.Text;
            string? selAdyB = cmbAdyB.Text;

            cmbOrigen.Items.Clear();
            cmbDestino.Items.Clear();
            cmbEliminarVertice.Items.Clear();
            cmbEliminarAristaOrig.Items.Clear();
            cmbEliminarAristaDest.Items.Clear();
            cmbAdyA.Items.Clear();
            cmbAdyB.Items.Clear();

            foreach (Nodo n in nodos)
            {
                string nom = n.Nombre;
                cmbOrigen.Items.Add(nom);
                cmbDestino.Items.Add(nom);
                cmbEliminarVertice.Items.Add(nom);
                cmbEliminarAristaOrig.Items.Add(nom);
                cmbEliminarAristaDest.Items.Add(nom);
                cmbAdyA.Items.Add(nom);
                cmbAdyB.Items.Add(nom);
            }

            Restablecer(cmbOrigen, selOrig, 0);
            Restablecer(cmbDestino, selDest, nodos.Count > 1 ? 1 : 0);
            Restablecer(cmbEliminarVertice, selElimN, 0);
            Restablecer(cmbEliminarAristaOrig, selElimOrig, 0);
            Restablecer(cmbEliminarAristaDest, selElimDest, nodos.Count > 1 ? 1 : 0);
            Restablecer(cmbAdyA, selAdyA, 0);
            Restablecer(cmbAdyB, selAdyB, nodos.Count > 1 ? 1 : 0);
        }

        private static void Restablecer(ComboBox cb, string? previo, int porDefecto)
        {
            if (cb.Items.Count == 0) return;
            if (!string.IsNullOrEmpty(previo) && cb.Items.Contains(previo))
            {
                cb.SelectedItem = previo;
            }
            else if (porDefecto >= 0 && porDefecto < cb.Items.Count)
            {
                cb.SelectedIndex = porDefecto;
            }
        }

        private void RegistrarLog(string categoria, string texto)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            lstLog.Items.Insert(0, $"[{hora}] [{categoria}] {texto}");
        }

        private void AjustarControlesResponsivos()
        {
            int margenHorizontal = 11;
            int espacioEntreControles = 16;

            txtNombre.Width = Math.Max(100, btnAgregarVertice.Left - margenHorizontal - 12);
            cmbEliminarVertice.Width = Math.Max(100, btnEliminarVertice.Left - margenHorizontal - 12);

            AjustarParHorizontal(grpInsercion, cmbOrigen, cmbDestino, margenHorizontal, espacioEntreControles);
            AjustarParHorizontal(grpEliminacion, cmbEliminarAristaOrig, cmbEliminarAristaDest, margenHorizontal, espacioEntreControles);
            AjustarParHorizontal(grpAdyacencia, cmbAdyA, cmbAdyB, margenHorizontal, espacioEntreControles);
            AjustarParHorizontal(grpAdyacencia, btnVerificarAdyacencia, btnVerVecinos, margenHorizontal, espacioEntreControles);

            int altoDisponibleAdyacencia = panelOperaciones.ClientSize.Height - grpAdyacencia.Top - 12;
            if (altoDisponibleAdyacencia >= 220)
            {
                grpAdyacencia.Height = altoDisponibleAdyacencia;
                lblResultadoAdyacencia.Height = Math.Max(80, grpAdyacencia.ClientSize.Height - lblResultadoAdyacencia.Top - 12);
            }
        }

        private static void AjustarParHorizontal(Control contenedor, Control izquierdo, Control derecho, int margen, int espacio)
        {
            int anchoTotal = contenedor.ClientSize.Width - (margen * 2) - espacio;
            if (anchoTotal <= 80) return;

            int anchoMitad = anchoTotal / 2;
            izquierdo.Left = margen;
            izquierdo.Width = anchoMitad;

            derecho.Left = margen + anchoMitad + espacio;
            derecho.Width = anchoTotal - anchoMitad;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas vaciar el grafo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                grafo.LimpiarGrafo();
                nodoSeleccionado = null;
                aristaResaltada = null;
                nodoResaltadoA = null;
                nodoResaltadoB = null;
                posicionClicSiguienteNodo = null;
                SincronizarComboBoxes();
                panelCanvas.Invalidate();
                RegistrarLog(CategoriasLog.Limpieza, "El grafo ha sido vaciado por completo.");
            }
        }

    }
}
