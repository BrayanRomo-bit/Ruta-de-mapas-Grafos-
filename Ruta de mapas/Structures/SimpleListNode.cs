using System;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Singly linked node for the custom SimpleList{T} data structure.
    /// </summary>
    /// <typeparam name="T">Type of the stored element.</typeparam>
    public class SimpleListNode<T>
    {
        public T Value { get; set; }
        public SimpleListNode<T>? Next { get; set; }

        public SimpleListNode(T value, SimpleListNode<T>? next = null)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Next = next;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }
    }
}
