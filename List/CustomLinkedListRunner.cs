using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    public class CustomLinkedListRunner
    {
        public static void Run()
        {
            try
            {
                var ll = new CustomLinkedList<int>();
                ll.WriteToConsole();

                var ll2 = new CustomLinkedList<int>(
                    new int[] { 1, 2, 3, 4, 5, 6 });
                ll2.WriteToConsole();
                ll2.AddRange(new int[] { 2222, 1111, 3333 });
                ll2.WriteToConsole();
                ll2.Reverse();
                ll2.WriteToConsole();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);

            }
        }
    }
}
