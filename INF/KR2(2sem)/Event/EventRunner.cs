using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.KR2_2sem_.Event
{
    public class EventRunner
    {
        public void Run()
        {
            Hospital hospital = new Hospital();
            hospital.AddPatient(new Patient { Name = "Аскаров Тимур Русланович" });
            Console.ReadKey();
        }
    }
}
