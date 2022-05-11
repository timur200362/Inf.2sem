using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.MailManagerExample
{
    public class MailManagerRunner
    {
        public void Run()
        {
            var mm = new MailManager();
            mm.SimulateNewMail("Тимур","Глеб","");
            var pager = new Pager();
            pager.Subscribe(mm);
            mm.SimulateNewMail("Тимур", "Глеб", "");
            var fax = new Fax();
            fax.Subscribe(mm);
            pager.UnSubscribe(mm);
            mm.SimulateNewMail("Тимур", "Глеб", "");
        }
    }
}
