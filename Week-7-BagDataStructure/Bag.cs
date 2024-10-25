using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7_BagDataStructure
{
    public class Bag<T>
    {
        private LinkedList<T> list;
        private int size;

        public Bag()
        {
            list = new LinkedList<T>();
            size = 0;
        }

        public void Add(T element)
        {
            list.Add(element);
            size++;
        }

        public int Size()
        {
            return size;
        }

        public BagIterator<T> Iterator()
        {
            return new BagIterator<T>(list.Head, size);
        }
    }
}
