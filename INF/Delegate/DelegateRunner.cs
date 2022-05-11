using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inf107_2_.Delegate
{
    public class DelegateRunner
    {
        //создаём тип делегата, который не принимает входящих параметров и не возвращает результат 
        public delegate void Message();

        public delegate int SingleCalc(int x);

        public int PlusOne(int y)
        {
            return y + 1;
        }

        public int ModFive(int z)
        {
            return z % 5;
        }

        public delegate void GetOp(char op);
        public void Run()
        {
            //экземпляр делегата 
            Message msgHello = WriteHello;
            //написать имя делегата и круглые скобки
            msgHello();
            // через Invoke
            msgHello.Invoke();
            //анонимные методы
            SingleCalc sc = delegate (int timur)
              {
                  return timur - 15;
              };
            SingleCalc anonPlusOne = delegate (int x) { return x + 1; };
            anonPlusOne(4);
            //лямбда-выражения
            SingleCalc lamPlusOne = (int x) => { return x + 1; };
            Message lamHello = () => { Console.WriteLine("Hello!!!"); };
            //встроенный делегат Function
            var d5 = new Func<int, int>(PlusOne);
            var d55 = new Func<int, string, string>(
                (int x, string s) =>
                {
                    x = x + 3;
                    s = s + x.ToString();
                    return s;
                });
            var d555 = new Func<string>(() => DateTime.Now.ToShortDateString());
            //способ создания 1
            SingleCalc d1;//null
            d1 = PlusOne;
            //способ создания 2
            var d11 = new SingleCalc(PlusOne);

            //вызов способ 1
            int a = 5;
            a = d1(a); //a = d1(5) => a = PlusOne(5);

            //вызов способ 2
            a = d1.Invoke(a);
            //меняем значение
            d1 = ModFive;
            a = d1(a);

        }
        //функция, которая по входящему параметру и возвращаемому значению соответствует типу делегата message
        public void WriteHello()
        {
            Console.WriteLine("Hello");
        }

        public void GettingOp(char op)
        {

        }
    }
}
