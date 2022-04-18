using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.BadExample1
{
    public class Manager
    {
        public string Name;
        public Manager(string name)
        {
            Name = name;
        }
        public void SetReplace(Worker w, DateTime from, DateTime to)
        {
            Console.WriteLine($"Тут я нахожу замену работнику {w.Name}");
        }
    }
}
