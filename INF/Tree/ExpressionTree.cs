using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    /// <summary>
    /// Дерево арифметических выражений
    /// </summary>
    public class ExpressionTree
    {
        private BinaryTreeNode<char> head;
        public ExpressionTree(BinaryTreeNode<char> _head)
        {
            head = _head;
        }
        /// <summary>
        /// Вычисление всего выражения
        /// </summary>
        /// <returns></returns>
        public double Calc()
        {
            var op = GetOperation(head.Value);
            return op(Calc(head.LeftChild), Calc(head.RightChild));
            throw new NotImplementedException();
        }
        public double Calc(BinaryTreeNode<char> node)
        {
            if (node.Value <= '9' && node.Value >= '0')
                return double.Parse(node.Value + "");
            return GetOperation(node.Value)(Calc(node.LeftChild), Calc(node.RightChild));
        }
        /// <summary>
        /// Вычисление одного действия
        /// </summary>
        /// <returns></returns>
        private double Calc(char charOp, double a, double b)
        {
            //получаю действие, соответствующее charOp
            var op = GetOperation(charOp);

            return op(a, b);
        }
        /// <summary>
        /// по символу возвращает действие (бинарную операцию)
        /// </summary>
        /// <returns></returns>
        private BinOper GetOperation(char charOp)
        {
            if (operDict.TryGetValue(charOp, out var op))
                return op;
            else throw new InvalidOperationException(
                $"Операции, соотв-ей символу {charOp} не существует");
        }

        private Dictionary<char, BinOper> operDict =
            new Dictionary<char, BinOper>()
            {
                {'*', (a, b) => a * b },
                {'+',  SumVal},
                {'-', (a, b) => a - b },
                {'/', (a, b) => a / b }
            };

        private static double SumVal(double a, double b)
        {
            return a + b;
        }

    }
    /// <summary>
    /// Тип делегата бинарная операция
    /// </summary>
    /// <param name="a">пар-р 1</param>
    /// <param name="b">пар-р 2</param>
    /// <returns>результат</returns>
    public delegate double BinOper(double a, double b);
}
