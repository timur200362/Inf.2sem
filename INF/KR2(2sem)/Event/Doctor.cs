using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.KR2_2sem_.Event
{
    public class Doctor
    {
        public string Name { set; get; }
        public void WatchPatient(Patient patient)
        {
            patient.Watched = true;
        }
    }
}
