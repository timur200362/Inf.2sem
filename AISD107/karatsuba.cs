using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD107
{
    public class Karatsuba
    {
        public double Calc(int a, int b)
        {
            var result = calc(a, b);
            return result;
        }
        /// <summary>
        /// Неоптимальный метод нахождения длины интового числа
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private int IntLength(int a)
        {
            int i = 1;
            while (a / 10 != 0)
            {

                i++;
                a /= 10;
            }
            return i;
        }
        private int calc(int a, int b)
        {
            if (b == 0 || a == 0) return 0;
            if (a == 1) return b;
            if (b == 1) return a;
            if (a < 10 || b < 10) return a * b;

            //пока будет работать только для равных длин

            int aLength = IntLength(a);
            int bLength = IntLength(b);
            int halfLength = Math.Min(aLength, bLength) / 2;

            int a1 = a / (int)Math.Pow(10, halfLength);
            int a2 = a % (int)Math.Pow(10, aLength - halfLength);
            int b1 = b / (int)Math.Pow(10, halfLength);
            int b2 = b % (int)Math.Pow(10, bLength - halfLength);

            int ac = calc(a1, b1);
            int bd = calc(a2, b2);

            var sumFirst = a1 + a2;
            var sumSecond = b1 + b2;
            int bigsum = calc(sumFirst, sumSecond);

            var middle = bigsum - ac - bd;
            int numeralResult = ac * (int)Math.Pow(10, halfLength * 2) +
                middle * (int)Math.Pow(10, halfLength) + bd;

            return numeralResult;
        }
    }
}
