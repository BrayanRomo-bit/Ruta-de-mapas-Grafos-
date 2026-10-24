using System;
using System.Drawing;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Constantes y estilos de configuración visual para el renderizado del grafo y la interfaz.
    /// </summary>
    public static class ConfiguracionVisual
    {
        public const int EspaciadoCuadricula = 40;
        public const float GrosorAristaNormal = 2.5f;
        public const float GrosorAristaResaltada = 4.5f;
        public const float GrosorBordeNodo = 2.5f;
        public const int MargenLienzo = 25;

        public const int LargoFlecha = 12;
        public const double AnguloFlecha = Math.PI / 6;

        public const int RadioPuntoCentro = 3;
        public const int DiametroPuntoCentro = 6;

        public static readonly Color ColorCuadricula = Color.FromArgb(242, 244, 247);
        public static readonly Color ColorAristaNormal = Color.FromArgb(120, 144, 156);
        public static readonly Color ColorAristaResaltada = Color.FromArgb(0, 184, 148);

        public static readonly Color ColorNodoNormal = Color.FromArgb(9, 132, 227);
        public static readonly Color ColorNodoSeleccionado = Color.FromArgb(214, 48, 49);
        public static readonly Color ColorNodoResaltado = Color.FromArgb(0, 184, 148);

        public static readonly Color ColorSombra = Color.FromArgb(35, 0, 0, 0);
        public static readonly Color ColorFondoEtiqueta = Color.FromArgb(236, 240, 241);
        public static readonly Color ColorTextoEtiqueta = Color.FromArgb(45, 52, 54);

        // Estilos para distintivos de Peso en aristas ponderadas
        public static readonly Color ColorPesoFondoNormal = Color.FromArgb(255, 255, 255);
        public static readonly Color ColorPesoBordeNormal = Color.FromArgb(217, 119, 6);
        public static readonly Color ColorPesoTextoNormal = Color.FromArgb(146, 64, 14);

        public static readonly Color ColorPesoFondoResaltado = Color.FromArgb(212, 239, 223);
        public static readonly Color ColorPesoBordeResaltado = Color.FromArgb(0, 184, 148);
        public static readonly Color ColorPesoTextoResaltado = Color.FromArgb(20, 90, 50);

        // Mensajes y estados de adyacencia
        public static readonly Color ColorResultadoPositivoFondo = Color.FromArgb(212, 239, 223);
        public static readonly Color ColorResultadoPositivoTexto = Color.FromArgb(20, 90, 50);
        public static readonly Color ColorResultadoNegativoFondo = Color.FromArgb(250, 219, 216);
        public static readonly Color ColorResultadoNegativoTexto = Color.FromArgb(120, 40, 31);
        public static readonly Color ColorResultadoNeutroFondo = Color.FromArgb(238, 242, 245);
        public static readonly Color ColorResultadoNeutroTexto = Color.FromArgb(45, 52, 54);
    }
}
