using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class AVLTree
    {
        public BinaryTreeNode<int> root;
        public AVLTree(BinaryTreeNode<int> _root)
        {
            root = _root;
        }

        /// <summary>
        /// Малый левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallLeftTurn(ref BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;
            r.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = r;
            r = newRoot;
        }
        public void SmallRightTurn(ref BinaryTreeNode<int> r)
        {
            if (r.LeftChild == null)
                throw new Exception("Малый правый поворот невозможен");
            var newRoot = r.LeftChild;
            r.LeftChild = newRoot.RightChild;
            newRoot.RightChild = r;
            r = newRoot;
        }
        public void BigLeftTurn(ref BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Большой левый поворот невозможен");
            SmallRightTurn(ref r.RightChild);
            SmallLeftTurn(ref r);
        }
        public void BigRightTurn(ref BinaryTreeNode<int> r)
        {
            if (r.LeftChild == null)
                throw new Exception("Большой правый поворот невозможен");
            SmallLeftTurn(ref r.LeftChild);
            SmallRightTurn(ref r);
        }
        public void ShowSymmetric()
        {
            ShowSymmetric(root, 0);
        }
        public void ShowSymmetric(BinaryTreeNode<int> node, int level)
        {
            if (node != null)
            {
                ShowSymmetric(node.LeftChild, level + 1);
                for (int i = 0; i < 8 * level; i++) Console.Write(" ");
                Console.WriteLine(node.Key);
                ShowSymmetric(node.RightChild, level + 1);
            }
        }
    }
}
