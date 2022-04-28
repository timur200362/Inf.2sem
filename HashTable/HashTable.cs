using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inf107_2_.List;

namespace Inf107_2_.HashTable
{
    /// <summary>
    /// Хеш-таблица на основе связных списков
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class HashTable<TValue> : IAssocArray<int, TValue>
    {
        private List<TValue>[] array;

        public HashTable(int maxKeyValue)
        {
            array = new List<TValue>[maxKeyValue];
        }

        public void Insert(int key, TValue value)
        {
            if (array[key] == null)
                array[key] = new List<TValue>();
            array[key].Add(value);
        }

        public bool Find(int key, TValue value)
        {
            return array[key].Contains(value);
        }

        public void Remove(int key, TValue value)
        {
            array[key].Remove(value);
        }
        public void Clear()
        {
            foreach (var list in array)
                list.Clear();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var filledLists = array.Where(x => x != null);
            foreach (var l in filledLists)
                foreach (var el in l)
                    sb.Append(el.ToString() + " ");
            return sb.ToString();
        }
    }
}
