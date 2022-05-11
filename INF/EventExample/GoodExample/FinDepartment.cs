using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.GoodExample
{
    public class FinDepartment
    {

        protected void CalcSalary(object w,
            GoVacationEventArgs param)
        {
            if (w is Worker)
            {
                var worker = (Worker)w;
                Console.WriteLine($"Вычисление отпускных " +
                $"для сотрудника {worker.Name}, уходящего в " +
                $"{param.IsAdm} отпуск" +
                $"в период с {param.From.ToShortDateString()}" +
                $" по {param.To.ToShortDateString()}");
            }
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
