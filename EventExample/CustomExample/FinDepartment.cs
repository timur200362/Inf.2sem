using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.CustomExample
{
    public class FinDepartment
    {
        protected void CalcSalary(Worker w, GoVacationParams param)
        {
            Console.WriteLine($"Происходит поиск замены для сотрудника" + $"для сотрудника {w.Name}, уходящего в" + $"{param.IsAdm}отпуск" + $"в период с {param.From.ToShortDateString()}" + $"по {param.To.ToShortDateString()}");
        }
        public void Subscribe(Worker w)
        {
            w.GoVacationDelegate += CalcSalary; 
        }
        public void Unsubscribe(Worker w)
        {
            w.GoVacationDelegate -= CalcSalary;
        }
    }
}
