using System.Windows.Forms;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Panel con doble búfer activado para renderizado gráfico fluido y sin parpadeo (flickering).
    /// </summary>
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }
    }
}
