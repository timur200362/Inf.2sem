using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.GoodExample
{
    public class Manager
    {
        private string name;
        public string Name { get { return name; } }

        public Manager(string _name)
        {
            name = _name;
        }
        /// <summary>
        /// Найти замену 
        /// </summary>
        protected void FindReplacement(object w,
            GoVacationEventArgs param)
        {
            if (w is Worker)
            {
                var worker = (Worker)w;
                //происходит поиск замены
                Console.WriteLine($"Присходит поиск замены " +
                    $"менеджером {Name} " +
                    $"для сотрудника {worker.Name}, уходящего в " +
                    $"{param.IsAdm} отпуск" +
                    $"в период с {param.From.ToShortDateString()}" +
                    $" по {param.To.ToShortDateString()}");
            }
        }
        /// <summary>
        /// Подписка на событие выход в отпуск работника
        /// </summary>
        public void Subscribe(Worker w)
        {
            w.GoVacationDelegate += FindReplacement;
        }
        /// <summary>
        /// Отписка от события выход в отпуск работника
        /// </summary>
        public void Unsubcribe(Worker w)
        {
            w.GoVacationDelegate -= FindReplacement;
        }
    }
}
