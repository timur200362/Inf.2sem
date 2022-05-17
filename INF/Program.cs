using System;
using Inf107_2_.Tree;
using Inf107_2_.Delegate;
using Inf107_2_.KR2_2sem_;
using Inf107_2_.KR2_2sem_.Event;

namespace Inf107_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //проверка поворотов
            //BinarySearchTree<int> tree = new BinarySearchTree<int>();
            //tree.Add(56, 6); tree.Add(43, 3); tree.Add(43, 2); tree.Add(43, 8); tree.Add(47, 7); tree.Add(11, 5); tree.Add(89, 11); tree.Add(56, 12);
            //tree.ShowSymmetric();
            //AVLTree avl = new AVLTree(tree.Head());
            //avl.BigRightTurn(ref avl.root);
            //avl.ShowSymmetric();
            //Console.ReadKey();

            ////проверка дерева выражений
            BinaryTreeNode<char> head = new BinaryTreeNode<char>('*', 5, null);
            head.LeftChild = new BinaryTreeNode<char>('+', 1, null); head.RightChild = new BinaryTreeNode<char>('5', 1, null);
            BinaryTreeNode<char> left = head.LeftChild;
            left.LeftChild = new BinaryTreeNode<char>('7', 1, null); left.RightChild = new BinaryTreeNode<char>('5', 1, null);
            ExpressionTree exp = new ExpressionTree(head);
            double res = exp.Calc();
            Console.WriteLine(res);
            Console.ReadKey();

            //Задание с деревом
            //TreeRunner tr = new TreeRunner();
            //tr.Run();

            //Задание с Linq
            //Linq1 linq = new Linq1();
            //linq.Run();

            //Задание с Event
            //EventRunner event1 = new EventRunner();
            //event1.Run();
        }
    }
}
