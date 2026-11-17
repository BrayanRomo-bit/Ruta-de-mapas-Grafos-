using System;
using System.Drawing;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Visual configuration constants and styles for graph rendering and UI feedback.
    /// </summary>
    public static class VisualConfig
    {
        public const int GridSpacing = 40;
        public const float NormalEdgeWidth = 2.5f;
        public const float HighlightedEdgeWidth = 4.5f;
        public const float VertexBorderWidth = 2.5f;
        public const int CanvasMargin = 25;

        public const int ArrowLength = 12;
        public const double ArrowAngle = Math.PI / 6;

        public const int CenterDotRadius = 3;
        public const int CenterDotDiameter = 6;

        public static readonly Color GridColor = Color.FromArgb(242, 244, 247);
        public static readonly Color NormalEdgeColor = Color.FromArgb(120, 144, 156);
        public static readonly Color HighlightedEdgeColor = Color.FromArgb(0, 184, 148);

        public static readonly Color NormalVertexColor = Color.FromArgb(9, 132, 227);
        public static readonly Color SelectedVertexColor = Color.FromArgb(214, 48, 49);
        public static readonly Color HighlightedVertexColor = Color.FromArgb(0, 184, 148);

        public static readonly Color ShadowColor = Color.FromArgb(35, 0, 0, 0);
        public static readonly Color LabelBackgroundColor = Color.FromArgb(236, 240, 241);
        public static readonly Color LabelTextColor = Color.FromArgb(45, 52, 54);

        // Styles for weight badges on weighted edges
        public static readonly Color NormalWeightBackgroundColor = Color.FromArgb(255, 255, 255);
        public static readonly Color NormalWeightBorderColor = Color.FromArgb(217, 119, 6);
        public static readonly Color NormalWeightTextColor = Color.FromArgb(146, 64, 14);

        public static readonly Color HighlightedWeightBackgroundColor = Color.FromArgb(212, 239, 223);
        public static readonly Color HighlightedWeightBorderColor = Color.FromArgb(0, 184, 148);
        public static readonly Color HighlightedWeightTextColor = Color.FromArgb(20, 90, 50);

        // Adjacency check result states
        public static readonly Color PositiveResultBackgroundColor = Color.FromArgb(212, 239, 223);
        public static readonly Color PositiveResultTextColor = Color.FromArgb(20, 90, 50);
        public static readonly Color NegativeResultBackgroundColor = Color.FromArgb(250, 219, 216);
        public static readonly Color NegativeResultTextColor = Color.FromArgb(120, 40, 31);
        public static readonly Color NeutralResultBackgroundColor = Color.FromArgb(238, 242, 245);
        public static readonly Color NeutralResultTextColor = Color.FromArgb(45, 52, 54);

        // Traversals (BFS / DFS): origin vertex marker and visit-order badges
        public static readonly Color OriginRingColor = Color.FromArgb(243, 156, 18);
        public static readonly Color TraversalBadgeColor = Color.FromArgb(45, 52, 54);
        public static readonly Color TraversalBadgeTextColor = Color.White;
    }
}