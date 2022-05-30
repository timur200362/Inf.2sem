using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.KR2onPara.Event
{
    public class LawEventArgs:EventArgs
    {
        private DateTime startDate;
        private LawEventArgs(DateTime sd)
        {
            startDate = sd;
        }
        public DateTime StartDate { get { return startDate; } }
    }
}
