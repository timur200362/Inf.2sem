using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.HashTable
{
    public class HashTableRunner
    {
        public void Run()
        {
            //буду использовать функцию x mod 11
            var ht = new HashTable<int>(11);
            Console.WriteLine(ht.ToString());
            var x = 12;
            ht.Insert(GetHash(x), x);
            Console.WriteLine(ht.ToString());
            ht.Insert(GetHash(23), 23);
            ht.Insert(GetHash(4), 4);
            ht.Insert(GetHash(15), 15);
            ht.Insert(GetHash(2), 2);
            Console.WriteLine(ht.ToString());

        }

        private int GetHash(int x) => (x % 11);
    }
}
