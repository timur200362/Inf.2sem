using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.CustomExample
{
    public class Manager
    {
        private string name;
        private string Name { get { return name; } }
        public Manager(string _name)
        {
            name = _name;
        }
        protected void FindReplacement(Worker w,GoVacationParams param)
        {
            //происходит поиск замены
            Console.WriteLine($"Происходит поиск замены для сотрудника"+$"для сотрудника {w.Name}, уходящего в"+$"{param.IsAdm}отпуск"+$"в период с {param.From.ToShortDateString()}"+$"по {param.To.ToShortDateString()}");
        }
        public void Subscribe(Worker w)
        {
            w.GoVacationDelegate += FindReplacement;
        }
        public void Unsubcribe(Worker w)
        {
            w.GoVacationDelegate -= FindReplacement;
        }
    }
}
