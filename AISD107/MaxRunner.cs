using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD107
{
    public class MaxRunner
    {
        public void Run()
        {
            int[] array = new int[] { 4, 5, 6, 3, 10 };
            Maximum maxNumber = new Maximum();
            maxNumber.FindMaxNumberRecursive(array);
        }
    }
}
