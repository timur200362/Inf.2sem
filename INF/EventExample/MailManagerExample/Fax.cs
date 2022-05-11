using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.MailManagerExample
{
    internal sealed class Fax
    {
        /// <summary>
        /// Подписаться на событие новое сообщение MailManager-a
        /// </summary>
        /// <param name="mm"></param>
        public void Subscribe(MailManager mm)
        {
            mm.NewMail += PrintMail;
        }
        /// <summary>
        /// Отписаться на событие новое сообщение MailManager-a
        /// </summary>
        /// <param name="mm"></param>
        public void UnSubscribe(MailManager mm)
        {
            mm.NewMail -= PrintMail;
        }
        public void PrintMail(object sender, NewMailEventArgs e)
        {
            Console.WriteLine($"Печатаю письмо от {e.MailFrom}"+$"для {e.MailTo} с темой {e.Subject}");
        }
    }
}
