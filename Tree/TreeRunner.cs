using System;
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
            var tree = new BinarySearchTree<string>();
            tree.Add("A",8);
            tree.Add("B", 3);
            tree.Add("C", 10);
            tree.Add("C", 1);
            tree.Add("C", 5);
            tree.Add("C", 14);
            tree.Add("C", 4);
            tree.Add("C", 6);
            tree.Add("C", 13);
            tree.Add("C", 7);
            tree.RemoveRecursion(6);
            tree.BreadthFirstSearch();
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
