using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.CustomExample
{
    public class CustomExampleRunner
    {
        public void Run()
        {
            //Создадим менеджера
            var m1 = new Manager("Первый менеджер");
            //Создаем фин отдел
            var fd = new FinDepartment();
            //создадим работника
            var worker1 = new Worker("Первый работник");
            //подписок нет, вызовем выход в отпуск у работника
            var param1 = new GoVacationParams(new DateTime(2022, 03, 1), new DateTime(2022, 03, 14), false);
            //подписываю менеджера на сотрудника, чтобы отслеживать выход в отпуск
            m1.Subscribe(worker1);
            worker1.InitVacation(
                new DateTime(2022, 03, 01),
                new DateTime(2022, 03, 14),
                false);
            //фин отдел подписывается на сотрудника
            fd.Subscribe(worker1);
            worker1.InitVacation(
                new DateTime(2022, 04, 03),
                new DateTime(2022, 04, 17),
                false);
            //создаем второго менеджера
            var m2 = new Manager("Второй менеджер");
            //первый отписывается от работника
            m1.Unsubcribe(worker1);
        }
    }
}
