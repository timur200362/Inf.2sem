using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.GoodExample
{
    public class GoodExampleRunner
    {
        public void Run()
        {
            //создадим менеджера
            var m1 = new Manager("Первый менеджер");
            //создаем фин отдел
            var fd = new FinDepartment();
            //создаем работника
            var worker1 = new Worker("Первый работник");

            //подписок нет, 
            //вызовем выход в отпуск у работника
            worker1.InitVacation(
                new DateTime(2022, 03, 01),
                new DateTime(2022, 03, 14),
                false);

            //подписываю менеджера на сотрудника,
            //чтобы отслеживать выход в отпуск
            m1.Subscribe(worker1);
            worker1.InitVacation(
                new DateTime(2022, 03, 01),
                new DateTime(2022, 03, 14),
                false);

            //фин отдел подписывается на сотрудника
            fd.Subscribe(worker1);
            worker1.InitVacation(
                new DateTime(2022, 02, 7),
                new DateTime(2022, 02, 20),
                false);

            //создаем второго менеджера
            var m2 = new Manager("Второй менеджер");
            //первый отписывается от работника
            m1.Unsubcribe(worker1);
            //второй менеджер подписывается на работника
            m2.Subscribe(worker1);
            worker1.InitVacation(
                new DateTime(2022, 07, 7),
                new DateTime(2022, 07, 20),
                true);
        }
    }
}
