﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class TreeRunner
    {
        public void Run()
        {
            
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Add("0", 5);
            tree.Add("1", 4);
            tree.Add("2", 6);
            tree.Add("3", 8);
            tree.Add("4", 9);
            tree.Add("5", 7);
            tree.BreadthFirstSearch();
            tree.OutputOfTreeNodesWithHeightN(3);
            int countLeaves = tree.CountLeaves();
            Console.WriteLine(countLeaves);
            //Проверка метода Remove
            //var tree = new BinarySearchTree<string>();
            //tree.Add("A",8);
            //tree.Add("B", 3);
            //tree.Add("C", 10);
            //tree.Add("C", 1);
            //tree.Add("C", 5);
            //tree.Add("C", 14);
            //tree.Add("C", 4);
            //tree.Add("C", 6);
            //tree.Add("C", 13);
            //tree.Add("C", 7);
            //tree.RemoveRecursion(6);
            //tree.BreadthFirstSearch();

            //Проверка метода IsExternal
            //var tree2 = new BinarySearchTree<string>();
            //tree2.Add("A",8);
            //tree2.Add("A", 6);
            //tree2.Add("A", 9);
            //tree2.Add("A", 5);
            //tree2.Add("A", 7);
            //tree2.Add("A", 10);
            //Console.WriteLine(tree2.IsExternal(6));

            //var n8 = new TreeNode<int>(8);
            //var n9 = new TreeNode<int>(9);
            //var n5 = new TreeNode<int>(5, new List<TreeNode<int>>() { n8, n9 });
            //var n6 = new TreeNode<int>(6);
            //var n7 = new TreeNode<int>(7);
            //var n2 = new TreeNode<int>(2, new List<TreeNode<int>>() { n5, n6 });
            //var n3 = new TreeNode<int>(3);
            //var n4 = new TreeNode<int>(4, new List<TreeNode<int>>() { n7 });
            //var n1 = new TreeNode<int>(1, new List<TreeNode<int>>() { n2, n3, n4 });
            //TreeUtils<int>.BreadthFirstSearch(n1);
        }
    }
}
