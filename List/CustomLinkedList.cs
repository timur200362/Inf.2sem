using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    public class CustomLinkedList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        private LinkedNode<T> head;
        public CustomLinkedList()
        {
        }
        public CustomLinkedList(T el)
        {
            head = new LinkedNode<T>(el);
        }
        public CustomLinkedList(T[] array)
        {
            if (array == null || array.Length == 0)
                return;
            head = new LinkedNode<T>(array[0]);
            if (array.Length > 1)
            {
                var headCopy = head;
                for (int i = 1; i < array.Length; i++)
                {
                    //создали новый эл списка
                    var node = new LinkedNode<T>(array[i]);
                    //задаем ссылку на пред. элемент
                    node.PrevNode = headCopy;
                    //задаем ссылку на некст элемент
                    headCopy.NextNode = node;
                    headCopy = headCopy.NextNode;
                }
            }
        }
        public void Add(T elem)
        {
            throw new NotImplementedException();
        }

        public void AddRange(T[] elems)
        {
            if (elems == null || elems.Length == 0)
            {
                return;
            }
            if (head == null)
            {
                head = new LinkedNode<T>(elems[0]);
                var headCopy = head;
                for (int i = 1; i < elems.Length; i++)
                {
                    headCopy.NextNode = new LinkedNode<T>(elems[i]);
                    headCopy = headCopy.NextNode;
                }
                return;
            }
            var headCopy2 = head;
            while (headCopy2.NextNode != null)
            {
                headCopy2 = headCopy2.NextNode;
            }
            for (int i = 0; i < elems.Length; i++)
            {
                headCopy2.NextNode = new LinkedNode<T>(elems[i]);
                headCopy2 = headCopy2.NextNode;
            }
        }

        public void Clear()
        {
            head = null;
        }

        public bool Contains(T elem)
        {
            if (head == null)
                return false;
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                if (headCopy.InfField.CompareTo(elem) == 0)
                    return true;
                headCopy = headCopy.NextNode;
            }
            if (headCopy.InfField.CompareTo(elem) == 0)
                return true;
            return false;

        }


        public int IndexOf(T elem)
        {
            throw new NotImplementedException();
        }

        public void Insert(T elem, int index)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void Remove(T elem)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(T elem)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index <= 0)
                throw new Exception("Позиция должна быть больше единицы");

            if (head == null || Size() < index)
                throw new Exception("Нет данной позиции в списке");

            if (index == 1)
                head = head.NextNode;

            var headCopy = head;
            for (int i = 1; i <= index - 1; i++)
            {
                headCopy = headCopy.NextNode;
            }

            //Если последний элемент
            if (headCopy.NextNode == null)
            {
                headCopy.PrevNode.NextNode = null;
            }
            else
            {
                //Делаем, что предшествующий удаляемому элемент
                //смотрит на следующий за удаляемым
                headCopy.PrevNode.NextNode =
                    headCopy.NextNode;
                //Делаем, что следующий за удаляемым элемент
                //смотрит на предшествующий удаляемому
                headCopy.NextNode.PrevNode =
                    headCopy.PrevNode;
            }

        }
        public void Reverse()
        {
            if (head == null || head.NextNode == null)
                return;
            LinkedNode<T> headReverse = null;
            while (head != null)
            {
                #region Добавляем элемент в перевернутый список
                //Создаем новый узел
                var newNode = new LinkedNode<T>(head.InfField);
                //новый элемент ссылается на 1 элемент перевернутого списка
                newNode.NextNode = headReverse;
                headReverse = newNode;
                #endregion

                #region Удаление элемента из изначального списка
                head = head.NextNode;
                #endregion
            }
            head = headReverse;
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            if (head == null)
                return "Список пуст";
            var sb = new StringBuilder();
            var headCopy = head;
            while (headCopy != null)
            {
                sb.Append(headCopy.InfField.ToString());
                if (headCopy.NextNode != null)
                    sb.Append("<=>");
                headCopy = headCopy.NextNode;
            }
            return sb.ToString();
        }
        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomLinkedListEnumerator<T>(head);
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
