using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Inf107_2_.List
{
    public class CustomArrayList<T> : ICustomCollection<T> where T : IComparable<T>
    {
        private T[] array;

        public CustomArrayList()
        {
            array = new T[0];
        }
        public CustomArrayList(T el)
        {
            array = new T[1] { el };
        }
        public CustomArrayList(T[] array)
        {
            this.array = array;
        }

        public void Add(T elem)
        {
            throw new NotImplementedException();
        }

        public void AddRange(T[] elems)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T elem)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)array.GetEnumerator();
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
            throw new NotImplementedException();
        }

        public void Remove(T elem)
        {
            throw new NotImplementedException();
        }
        //Удаляет элемент в массиве
        static void Remove(ref T[] array, T elem)
        {
            if (array.Length == 0 || array == null)
                return;
            int removeCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(elem) == 0)
                {
                    removeCount++;
                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                }
            }
            Array.Resize(ref array, array.Length - removeCount);
        }

        public void RemoveAll(T elem)
        {
            if (array.Length == 0 || array == null)
                return;
            int i = 0;
            while (i < array.Length)
            {
                if (array[i].CompareTo(elem) == 0)
                {

                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    Array.Resize(ref array, array.Length - 1);
                    continue;
                }
                i++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new Exception("Индекс должен быть больше нуля");
            if (array == null || (array.Length - 1) < index)
                throw new Exception("Индекс выходит за пределы списка");
            //Перезаписываю все элементы, начиная с позиции index + 1,
            // на одну ячейку влево
            for (int i = index; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            //уменьшая размер массива
            Array.Resize(ref array, array.Length - 1);
        }

        public void Reverse()
        {
            if (array == null || array.Length == 0 || array.Length == 1)
            {
                return;
            }
            Array.Reverse(array);
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (array == null || array.Length == 0)
            {
                return "Список пуст";
            }

            foreach (var item in array)
            {
                result.Append(item.ToString() + "|");
            }
            return result.ToString();
        }
        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
