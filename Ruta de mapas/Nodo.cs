using System;

namespace Ruta_de_mapas
{ 
    public class Nodo : IEquatable<Nodo>
    {
        public const int RadioPorDefecto = 20;

        public string Nombre { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radio { get; set; }

        public Nodo(string nombre, int x, int y, int radio = RadioPorDefecto)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            X = x;
            Y = y;
            Radio = radio;
        }
         
        public bool ContienePunto(int px, int py)
        {
            int dx = px - X;
            int dy = py - Y;
            return (dx * dx + dy * dy) <= (Radio * Radio);
        }

        public bool Equals(Nodo? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Nombre, other.Nombre, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Nodo);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Nombre);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
