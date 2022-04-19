using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    /// <summary>
    /// Список в котором элементы имеют числовой вид (или типо того)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomCountList<T> where T : struct, IComparable<T>
    {
        private Node<T> head;
        public CustomCountList() { head = null; }
        public CustomCountList(T a)
        {
            head = new Node<T>(a);
        }
        /// <summary>
        /// Сумма всех элементов в методе
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public decimal SummaOfAllElements()
        {
            if (head == null)
            {
                return 0;
            }
            if (head.NextNode == null)
            {
                decimal v;
                if (Decimal.TryParse(head.InfField.ToString(), out v))
                    return v;
                else throw new ArgumentException($"Тип {(typeof(T).FullName)} не приводится к численному типу"); ;
            }
            var headCopy = head;
            decimal result = 0;
            while (headCopy.NextNode != null)
            {
                decimal v1;
                if (Decimal.TryParse(headCopy.InfField.ToString(), out v1))
                    result += v1;
                else
                    throw new ArgumentException($"Тип {(typeof(T).FullName)} не приводится к численному типу");

                headCopy = headCopy.NextNode;
            }
            decimal v2;
            if (Decimal.TryParse(headCopy.InfField.ToString(), out v2))
                result += v2;
            else
                throw new ArgumentException($"Тип {(typeof(T).FullName)} не приводится к численному типу");

            return result;
        }
        public void Add(T a)
        {
            var newNode = new Node<T>(a);
            if (head == null)
            {
                head = newNode;
                return;
            }
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                headCopy = headCopy.NextNode;
            }
            headCopy.NextNode = newNode;

        }
    }
}
