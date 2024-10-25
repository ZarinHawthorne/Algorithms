using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7_BagDataStructure
{
    public class BagIterator<T> : IEnumerator<T>
    {
        private List<T> elements;
        private int position = -1;

        public BagIterator(Node<T> head, int size)
        {
            elements = new List<T>();
            var current = head;
            while (current != null)
            {
                elements.Add(current.Data);
                current = current.Next;
            }

            // Randomize elements
            var random = new Random();
            for (int i = 0; i < elements.Count; i++)
            {
                int j = random.Next(i, elements.Count);
                var temp = elements[i];
                elements[i] = elements[j];
                elements[j] = temp;
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < elements.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public T Current
        {
            get
            {
                if (position < 0 || position >= elements.Count)
                    throw new InvalidOperationException();
                return elements[position];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}
