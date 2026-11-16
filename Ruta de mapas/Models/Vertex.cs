using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Represents a vertex (node) in a graph with a unique name and 2D canvas coordinates.
    /// </summary>
    public class Vertex : IEquatable<Vertex>
    {
        public const int DefaultRadius = 20;

        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Vertex(string name, int x = 0, int y = 0, int radius = DefaultRadius)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            X = x;
            Y = y;
            Radius = radius;
        }

        public bool ContainsPoint(int pointX, int pointY)
        {
            int deltaX = pointX - X;
            int deltaY = pointY - Y;
            return (deltaX * deltaX + deltaY * deltaY) <= (Radius * Radius);
        }

        public bool Equals(Vertex? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Vertex);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
