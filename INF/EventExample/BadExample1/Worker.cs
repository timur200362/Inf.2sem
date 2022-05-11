using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.BadExample1
{
    public class Worker
    {
        public string Name;
        public Manager Manager;
        public FinDepartment Fd;
        public Worker(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Выйти в отпуск
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isAdm"></param>
        public void GoVacation(DateTime from, DateTime to, bool isAdm)
        {
            if (Manager != null)
            {
                Manager.SetReplace(this,from,to);
            }
            if (Fd != null)
            {
                Fd.CalcSalary(this, from, to, isAdm);
            }
        }
    }
}
