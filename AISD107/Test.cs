using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD107
{
    public class Test
    {
        public void Massiv()
        {
            Console.WriteLine("Введите размер массива");
            int n = Int32.Parse(Console.ReadLine());
            int[] nums=new int[n];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите номер числа, которое хотите удалить");
            int k = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                //if (nums.Length<k)
                //{
                //    throw new Exception();
                //}
                //else
                //{
                //    nums[i] = 0;
                //}
                if (nums[i] == k)
                {
                    nums[i] = 0;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
