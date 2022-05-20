using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD107
{
    public class Maximum
    {
        public int FindMaxNumberRecursive(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"Массив нулл");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Массив пуст");
            }

            return FindMaxNumber(array, 0);
        }
        private int FindMaxNumber(int[] array, int position, int currentMaxNumber = 0)
        {
            if (position == 0)
            {
                currentMaxNumber = array[0];
            }

            if (position == array.Length)
            {
                return currentMaxNumber;
            }
            else
            {
                currentMaxNumber = Math.Max(currentMaxNumber, array[position]);
                return FindMaxNumber(array, position + 1, currentMaxNumber);
            }
        }
    }
}
