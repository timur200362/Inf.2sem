﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.EventExample.CustomExample
{
    public class Worker
    {
        private string name;
        public string Name { get { return name; } }
        public Worker(string _name)
        {
            name = _name;
        }
        public Action<Worker, GoVacationParams> GoVacationDelegate;
        public void InitVacation(DateTime from, DateTime to, bool isAdm)
        {
            var param = new GoVacationParams(from, to, isAdm);
            var goVacParamCopy = GoVacationDelegate;
            if (goVacParamCopy != null)
            {
                goVacParamCopy(this, param);
            }
        }
    }
}
