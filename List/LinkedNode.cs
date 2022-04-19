using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    /// <summary>
    /// Элемент двунаправленного связного списка
    /// </summary>
    public class LinkedNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// информ поле
        /// </summary>
        public T InfField;
        /// <summary>
        /// Следующий элемент
        /// </summary>
        public LinkedNode<T> NextNode;
        /// <summary>
        /// предыдущий элемент
        /// </summary>
        public LinkedNode<T> PrevNode;
        public LinkedNode(T inf)
        {
            InfField = inf;
        }

    }
}
