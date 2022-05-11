using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Inf107_2_.EventExample.MailManagerExample
{
    internal class MailManager 
    {
        public event EventHandler<NewMailEventArgs> NewMail;
        /// <summary>
        /// Симуляция событий
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sbj"></param>
        public void SimulateNewMail(string from, string to, string sbj)
        {
            var args = new NewMailEventArgs(from, to, sbj);
            OnNewMail(args);
        }
        /// <summary>
        /// Обработка событий
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNewMail(NewMailEventArgs args)
        {
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
            if (temp != null)
            {
                temp.Invoke(this, args);
            }
        }
    }
}
