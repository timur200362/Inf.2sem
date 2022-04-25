using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.MailManagerExample
{
    /// <summary>
    /// Параметры сообщения
    /// </summary>
    internal class NewMailEventArgs:EventArgs
    {
        private string mFrom, mTo, subject;
        public NewMailEventArgs(string mf, string mt, string sbj)
        {
            mFrom = mf;
            mTo = mt;
            subject = sbj;
        }
        /// <summary>
        /// От кого сообщение
        /// </summary>
        public string MailFrom { get { return mFrom; } }//от кого сообщение
        public string MailTo { get { return mTo; } }//кому сообщение
        public string Subject { get { return subject; } }//тема письма

    }
}
