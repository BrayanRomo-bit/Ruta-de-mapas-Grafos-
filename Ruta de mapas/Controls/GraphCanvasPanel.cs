using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Double-buffered panel for smooth, flicker-free graph rendering.
    /// </summary>
    public class GraphCanvasPanel : Panel
    {
        public GraphCanvasPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }
    }
}
