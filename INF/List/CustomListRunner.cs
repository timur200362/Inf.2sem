using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.List
{
    public class CustomListRunner
    {
        public static void Run()
        {
            try
            {
                var list = new CustomList<int>();
                list.WriteToConsole();

                list.Add(1);
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.AddToHead(0);
                list.Add(4);
                list.Add(5);
                list.Add(6);
                list.WriteToConsole();

                list.DeleteHead();
                list.WriteToConsole();
                list.DeleteTail();
                list.WriteToConsole();

                list.RemoveAt(5);
                list.WriteToConsole();
                list.RemoveAt(4);
                list.WriteToConsole();
                //list.RemoveAt(1); доделать
                list.WriteToConsole(); // 2 3

                list.DeletePenultimate(); // 3 
                list.WriteToConsole();
                //list.DeletePenultimate(); //Предпоследнего не существует
                //list.WriteToConsole();

                list.AddToHead(2);
                list.AddToHead(1);
                list.Add(4);
                list.Add(5);
                list.Add(5);
                list.WriteToConsole();

                list.Remove(4);
                list.WriteToConsole();
                list.RemoveAll(5);
                list.WriteToConsole();

                list.AddToHead(0); list.AddToHead(0);
                list.WriteToConsole();
                list.RemoveAll(0);
                list.WriteToConsole();
                list.AddNumberBeforeAndAfter(99, 3);
                list.WriteToConsole();
                //Console.WriteLine(list.SummaOfAllElements());

                var list2 = new CustomList<int>();
                list2.Add(1);
                list2.AddNumberBeforeAndAfter(66, 0);
                list2.WriteToConsole();
                list2.Add(2); list2.Add(2); list2.Add(2);
                list2.Add(3); list2.Add(3);
                //Console.WriteLine(list2.SummaOfAllElements());
                list2.WriteToConsole();
                list2.DeleteSimilarElements();
                list2.WriteToConsole();
                list2.DeleteTail(); list2.DeleteTail();
                list2.DeleteSimilarElements();
                list2.Add(1); list2.DeleteSimilarElements();

                list.DeleteTail();
                list.Add(3);
                list.WriteToConsole();
                list.Reverse();
                list.WriteToConsole();
                int k = list.IndexOf(3);
                //list.RemoveAt(1); ДОДЕЛАТЬ
                list.WriteToConsole();
                list.Clear();
                list.Add(1); list.Add(2); list.Add(3); list.Add(4); list.Add(5);
                list.Add(6); list.Add(7); list.Add(8); list.Add(9); list.Add(10);
                list.WriteToConsole();
                list.SwapTwoElements();
                list.WriteToConsole();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Добавление на позицию: "
                    + ex.Message + " " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении методов линейного списка" +
                    "на основе связанного списка "
                    + ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Финальные действия выполняются всегда");
            }
        }
    }
}
