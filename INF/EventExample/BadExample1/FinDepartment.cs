using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.BadExample1
{
    public class FinDepartment
    {
        public void CalcSalary(Worker w, DateTime from, DateTime to, bool isAdm)
        {
            Console.WriteLine($"Считаю отпускные для {w.Name}");
        }
    }
}
