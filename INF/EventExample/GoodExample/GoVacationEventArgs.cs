using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.GoodExample
{
    public class GoVacationEventArgs:EventArgs
    {
        private DateTime from;
        private DateTime to;
        /// <summary>
        /// является ли отпуск административным(неоплачиваемым)
        /// </summary>
        private bool isAdm;
        public DateTime From { get { return from; } }
        public DateTime To { get { return to; } }
        public string IsAdm { get { return isAdm ? "административный" : "оплачиваемый"; } }
        public GoVacationEventArgs(DateTime _from, DateTime _to, bool _isAdm = false)
        {
            from = _from;
            to = _to;
            isAdm = _isAdm;
        }
    }
}
