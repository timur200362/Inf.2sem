using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    public class CustomList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        private Node<T> head;

        public CustomList() { }
        public CustomList(T a)
        {
            head = new Node<T>(a);
        }
        /// <summary>
        /// Добавление по  умолчанию в конец
        /// </summary>
        /// <param name="a"></param>
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
        public void AddRange(T[] elems)
        {
            throw new NotImplementedException();
        }
        public void AddToHead(T a)
        {
            var newNode = new Node<T>(a);
            newNode.NextNode = head;
            head = newNode;
        }
        /// <summary>
        /// Добавление на позицию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index"></param>
        public void Insert(T a, int index)
        {
            if (index == 1)
            {
                AddToHead(a);
                return;
            }
            var headCopy = head;
            for (int i = 1; i <= index - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException("Cписок короче, чем заданная длинна");
                headCopy = headCopy.NextNode;
            }
            var newNode = new Node<T>(a);
            //если добовляем не в конец, то новому элементу записываем хвост
            if (headCopy.NextNode != null)
            {
                newNode.NextNode = headCopy.NextNode;
            }
            headCopy.NextNode = newNode;
        }
        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new StringBuilder();
            if (head == null)
            {
                return "Список пуст";
            }
            while (headCopy != null)
            {
                result.Append(headCopy.InfField.ToString() + " ");
                headCopy = headCopy.NextNode;
            }
            return result.ToString();
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }
        public void DeleteHead()
        {
            if (head.NextNode == null)
            {
                head = null;
            }
            head = head.NextNode;
        }
        public void DeleteTail()
        {
            if (head.NextNode == null)
            {
                head = null;
            }
            var headcopy = head;

            while (headcopy.NextNode.NextNode != null)
            {
                headcopy = headcopy.NextNode;
            }
            headcopy.NextNode = null;
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
            for (int i = 1; i <= index - 2; i++)
            {
                headCopy = headCopy.NextNode;
            }
            if (headCopy.NextNode.NextNode == null)
            {
                headCopy.NextNode = null;
            }
            else
                headCopy.NextNode = headCopy.NextNode.NextNode;
        }
        public int Size()
        {
            int k = 1;
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                headCopy = headCopy.NextNode;
                k++;
            }
            return k;
        }
        /// <summary>
        /// Удаление предпоследнего элемента
        /// </summary>
        public void DeletePenultimate()
        {
            if ((Size() - 1) == 0)
            {
                throw new ArgumentOutOfRangeException("Предпоследнего элемента не существует!");
            }
            RemoveAt(Size() - 1);
        }
        public void Remove(T k) 
        {
            var headCopy = head;
            int lenght = Size();
            for (int i = 1; i <= lenght; i++)
            {
                if (headCopy.InfField.CompareTo(k) == 0)
                {
                    RemoveAt(i);
                    return;
                }
                headCopy = headCopy.NextNode;
            }
            throw new ArgumentOutOfRangeException("Элемент не найден");
        }

        public void RemoveAll(T k)
        {
            while (head.InfField.CompareTo(k) == 0)
            {
                DeleteHead();
            }
            var headCopy = head;
            while (headCopy.NextNode != null)
            {

                if (headCopy.NextNode.InfField.CompareTo(k) == 0)
                {
                    if (headCopy.NextNode.NextNode == null)
                    {
                        headCopy.NextNode = null;
                        break;
                    }
                    else
                    {
                        headCopy.NextNode = headCopy.NextNode.NextNode;
                        continue;
                    }

                }
                headCopy = headCopy.NextNode;

            }
        }
        public void Clear()
        {
            head = null;
        }
        public void Reverse()
        {
            if (head == null || head.NextNode == null)
            {
                return;
            }
            Node<T> headReverse = null;
            while (head != null)
            {
                #region Добавляем элемент в перевернутый список
                //Создаем новый узел
                var newNode = new Node<T>(head.InfField);
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

        public void AddNumberBeforeAndAfter(T number, T elementK)
        {
            if (head.InfField.CompareTo(elementK) == 0)
            {
                AddToHead(number);
                Insert(number, 3);
                return;
            }
            var headCopy = head;
            int length = Size();
            for (int i = 1; i <= length; i++)
            {
                if (headCopy.NextNode != null)
                {
                    if (headCopy.NextNode.InfField.CompareTo(elementK) == 0)
                    {
                        Insert(number, i + 1);
                        Insert(number, i + 3);
                        return;
                    }
                    headCopy = headCopy.NextNode;
                }
            }
            Console.WriteLine("Элемент не найден!");

        }
        public void DeleteSimilarElements()
        {
            if ((head == null) || (head.NextNode == null))
            {
                return;
            }
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                if (headCopy.InfField.CompareTo(headCopy.NextNode.InfField) == 0)
                {
                    if (headCopy.NextNode.NextNode != null)
                    {
                        headCopy.NextNode = headCopy.NextNode.NextNode;
                    }
                    else
                        headCopy.NextNode = null;
                }
                else
                    headCopy = headCopy.NextNode;
            }

        }
        public void SwapTwoElements()
        {
            //финалочка
            var tempNode = head.NextNode.NextNode;
            var headCopy = head;
            head = head.NextNode;
            head.NextNode = headCopy;
            while (tempNode != null && tempNode.NextNode != null)
            {
                headCopy.NextNode = tempNode.NextNode;
                headCopy = tempNode;
                var tempNext = tempNode.NextNode.NextNode;
                tempNode.NextNode.NextNode = tempNode;
                tempNode = tempNext;
            }
            headCopy.NextNode = tempNode;

            //Попытка2, через создание нового узла
            //if (head == null || head.NextNode == null)
            //    return;
            //Node<T> headSwap = new Node<T>(head.NextNode.InfField);
            //headSwap.NextNode = new Node<T>(head.InfField);
            //head = head.NextNode.NextNode;
            //var headSwapCopy = headSwap.NextNode;
            //while (head!=null)
            //{
            //    if (head.NextNode != null)
            //    {
            //        headSwapCopy.NextNode = new Node<T>(head.NextNode.InfField);
            //        headSwapCopy.NextNode.NextNode = new Node<T>(head.InfField);
            //        head = head.NextNode.NextNode;
            //        headSwapCopy = headSwapCopy.NextNode.NextNode;
            //    }
            //    else
            //    {
            //        headSwapCopy.NextNode = new Node<T>(head.InfField);
            //        head = null;
            //    }   
            //}
            //head = headSwap;

            //попытка1
            //var tempCopy = new Node<T>(headCopy.NextNode.InfField) { NextNode = headCopy.NextNode.NextNode };
            //headCopy.NextNode.NextNode = headCopy;
            //headCopy.NextNode = tempCopy.NextNode;
            //if (headCopy.NextNode != null)
            //{
            //    headCopy = headCopy.NextNode;
            //}
        }
        /// <inheritdoc"/>
        public bool isEmpty()
        {
            return head == null;
        }
        public bool Contains(T el)
        {
            if (head == null)
                return false;
            var headCopy = head;
            while (headCopy.NextNode != null)
            {
                if (headCopy.InfField.CompareTo(el) == 0)
                    return true;
                headCopy = headCopy.NextNode;
            }
            if (headCopy.InfField.CompareTo(el) == 0)
                return true;
            return false;
        }
        /// <summary>
        /// Индекс элемента (отсчет с 1)
        /// </summary>
        /// <param name="el"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int IndexOf(T el)
        {
            if (head == null)
                throw new ArgumentOutOfRangeException("Список пуст");
            var headCopy = head;
            int index = 1;
            while (headCopy.NextNode != null)
            {
                if (headCopy.InfField.CompareTo(el) == 0)
                {
                    return index;
                }
                else
                {
                    index++;
                    headCopy = headCopy.NextNode;
                }
            }
            if (headCopy.InfField.CompareTo(el) == 0)
                return index;
            throw new ArgumentException("Элемент не найден");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator<T>(head);
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
