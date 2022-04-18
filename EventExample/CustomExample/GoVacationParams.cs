using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.CustomExample
{
    /// <summary>
    /// Параметры отпуска
    /// </summary>
    public class GoVacationParams
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
        public GoVacationParams(DateTime _from, DateTime _to, bool _isAdm = false)
        {
            from = _from;
            to = _to;
            isAdm = _isAdm;
        }
    }
}
