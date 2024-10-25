using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_7_BagDataStructure
{
    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void Add(T element)
        {
            Node<T> newNode = new Node<T>(element);
            newNode.Next = head;
            head = newNode;
        }

        public Node<T> Head
        {
            get { return head; }
        }
    }
}
