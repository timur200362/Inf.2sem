using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    public class Node<T> where T : IComparable<T>
    {
        public T InfField { get; set; }
        public Node<T> NextNode { get; set; }
        public Node(T a)
        {
            InfField = a;
        }

    }
}
