using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Inf107_2_.Threadclass
{
    public class ThreadArr
    {
        public static void Run()
        {
            int[] arr=new int[10] {1,2,3,4,5,6,7,8,9,10};
            Thread thread1 = new Thread(Poww1);
            Thread thread2 = new Thread(Poww2);
            Thread thread3 = new Thread(Poww3);
        }
        public static void Poww1()
        {

        }
        public static void Poww2()
        {

        }
        public static void Poww3()
        {

        }
    }
}
