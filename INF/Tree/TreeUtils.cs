using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public static class TreeUtils<T>
    {
        public static void BreadthFirstSearch(TreeNode<T> root)
        {
            List<TreeNode<T>> toVist = new List<TreeNode<T>>();
            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist.First();
                toVist.RemoveAt(0);
                if (current.HasChild())
                    toVist.AddRange(current.ChildNodeList);
                Console.WriteLine(current.Value.ToString());
            }
        }
        public static int GetHeight(BinaryTreeNode<T> root)
        {
            if (root == null)
                return 0;
            else return 1 + Math.Max(
                GetHeight(root.LeftChild),
                GetHeight(root.RightChild));
        }
    }
}
