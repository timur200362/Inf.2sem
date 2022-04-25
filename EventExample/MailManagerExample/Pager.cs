using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.MailManagerExample
{
    /// <summary>
    /// Пейджер-подписчик события новое-сообщение MailManager-a
    /// </summary>
    internal sealed class Pager
    {
        private void Show(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Печать сообщения от {e.MailFrom}" + $"для {e.MailTo} с темой {e.Subject}");
        }
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += Show;
        }
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= Show;
        }
    }
}
