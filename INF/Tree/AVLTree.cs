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
        //public AVLTree()
        //{
        //}
        public BinarySearchTree<int> tree;
        /// <summary>
        /// Малый левый поворот
        /// </summary>
        /// <param name="r"></param>
        //public void SmallLeftTurn()
        //{
        //    BinaryTreeNode<int> r = tree.Head;
        //    SmallLeftTurn(ref r);
        //    tree.Head = r;
        //}
        public void SmallLeftTurn(ref BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;
            r.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = r;
            r = newRoot;
        }
        //public void SmallRightTurn()
        //{
        //    BinaryTreeNode<int> r = tree.Head;
        //    SmallRightTurn(ref r);
        //    tree.Head = r;
        //}
        public void SmallRightTurn(ref BinaryTreeNode<int> r)
        {
            if (r.LeftChild == null)
                throw new Exception("Малый правый поворот невозможен");
            var newRoot = r.LeftChild;
            r.LeftChild = newRoot.RightChild;
            newRoot.RightChild = r;
            r = newRoot;
        }
        //public void BigLeftTurn()
        //{
        //    BinaryTreeNode<int> r = tree.Head;
        //    BigLeftTurn(ref r);
        //    tree.Head = r;
        //}
        public void BigLeftTurn(ref BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Большой левый поворот невозможен");
            SmallRightTurn(ref r.RightChild);
            SmallLeftTurn(ref r);
        }
        //public void BigRightTurn()
        //{
        //    BinaryTreeNode<int> r = tree.Head;
        //    BigRightTurn(ref r);
        //    tree.Head = r;
        //}
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
        //public void ShowSymmetricDiff()
        //{
        //    ShowSymmetricDiff(tree.Head, 0);
        //}
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
        //public void ShowSymmetricDiff(BinaryTreeNode<int> node, int level)
        //{
        //    if (node != null)
        //    {
        //        ShowSymmetricDiff(node.LeftChild, level + 1);
        //        for (int i = 0; i < 8 * level; i++) Console.Write(" ");
        //        Console.WriteLine(diff(node));
        //        //Console.WriteLine(node.Key);
        //        ShowSymmetricDiff(node.RightChild, level + 1);
        //    }
        //}
        //public void Add(int item, int key)
        //{
        //    tree.Add(item, key);
        //    bool no_stop = true;
        //    BinaryTreeNode<int> r = tree.Head;
        //    while (no_stop)
        //    {
        //        no_stop = Balance(ref r);
        //        r = tree.Head;
        //    }
        //    tree.Head = r;
        //}
        //bool Balance(ref BinaryTreeNode<int> r)
        //{
        //    if (r == null) return false;
        //    BinaryTreeNode<int> node = r;
        //    int diff_root = diff(node);
        //    int diff_right = diff(node.RightChild);
        //    if (diff_root == -2)
        //    {
        //        Console.WriteLine(diff_root + " " + diff_right);
        //        if (diff_right == -1 || diff_right == 0)
        //        {
        //            SmallLeftTurn(ref r);
        //            Console.WriteLine("small_left_");
        //            return true;
        //        }
        //        int diff_right_left = diff(node.RightChild.LeftChild);
        //        if (diff_right == 1 && (diff_right_left == -1 || diff_right_left == 0 || diff_right_left == 1))
        //        {
        //            BigLeftTurn(ref r);
        //            return true;
        //        }
        //    }

        //    int diff_left = diff(node.LeftChild);
        //    //Console.WriteLine(diff_root + " " + diff_left);
        //    if (diff_root == 2)
        //    {
        //        if (diff_left == 1 || diff_left == 0)
        //        {
        //            SmallRightTurn(ref r);
        //            return true;
        //        }
        //        int diff_left_right = diff(node.LeftChild.RightChild);
        //        //Console.WriteLine(diff_root + " " + diff_left+" "+ diff_left_right);
        //        if (diff_left == -1 && (diff_left_right == 1 || diff_left_right == 0 || diff_left_right == -1))
        //        {
        //            BigRightTurn(ref r);
        //            return true;
        //        }
        //    }
        //    return Balance(ref r.LeftChild) || Balance(ref r.RightChild);
        //}
        //int diff(BinaryTreeNode<int> node)
        //{
        //    if (node == null) return 0;
        //    return Height(node.LeftChild) - Height(node.RightChild);
        //}
        //int Height(BinaryTreeNode<int> node)
        //{
        //    int max_height = 0;
        //    if (node != null)
        //    {
        //        max_height = 1;
        //        if (node.LeftChild != null)
        //            Height(node.LeftChild, 2, ref max_height);
        //        if (node.RightChild != null)
        //            Height(node.RightChild, 2, ref max_height);
        //    }
        //    return max_height;
        //}
        //void Height(BinaryTreeNode<int> node, int level, ref int max_height)
        //{
        //    if (level > max_height) max_height = level;
        //    if (node.LeftChild != null)
        //        Height(node.LeftChild, level + 1, ref max_height);
        //    if (node.RightChild != null)
        //        Height(node.RightChild, level + 1, ref max_height);
        //}
    }
}
