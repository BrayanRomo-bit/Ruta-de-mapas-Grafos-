using System.Collections;
using System.Collections.Generic;

namespace Ruta_de_mapas
{
    /// <summary>
    /// Custom generic singly linked list implementation.
    /// </summary>
    public class SimpleList<T> : IEnumerable<T>
    {
        private SimpleListNode<T>? head;
        private SimpleListNode<T>? tail;
        private int count;

        public SimpleListNode<T>? Head
        {
            get { return head; }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public SimpleList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Appends an element to the end of the singly linked list.
        /// </summary>
        public void Add(T element)
        {
            SimpleListNode<T> newNode = new SimpleListNode<T>(element);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        /// <summary>
        /// Removes the first occurrence of the specified element.
        /// </summary>
        public bool Remove(T element)
        {
            if (head == null) return false;

            if (EqualityComparer<T>.Default.Equals(head.Value, element))
            {
                head = head.Next;
                if (head == null) tail = null;
                count--;
                return true;
            }

            SimpleListNode<T> currentNode = head;
            while (currentNode.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Next.Value, element))
                {
                    if (ReferenceEquals(currentNode.Next, tail))
                    {
                        tail = currentNode;
                    }
                    currentNode.Next = currentNode.Next.Next;
                    count--;
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Determines whether an element is present in the list.
        /// </summary>
        public bool Contains(T element)
        {
            SimpleListNode<T>? currentNode = head;
            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, element))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns the zero-based index of an element in the list, or -1 if not found.
        /// </summary>
        public int IndexOf(T element)
        {
            int index = 0;
            SimpleListNode<T>? currentNode = head;
            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, element))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;
            }
            return -1;
        }

        /// <summary>
        /// Clears all elements from the singly linked list.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Converts the list elements into a standard List{T}.
        /// </summary>
        public List<T> ToList()
        {
            List<T> result = new List<T>(count);
            SimpleListNode<T>? currentNode = head;
            while (currentNode != null)
            {
                result.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SimpleListNode<T>? currentNode = head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
