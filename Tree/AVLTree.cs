using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class AVLTree
    {
        private BinaryTreeNode<int> root;
        public AVLTree(BinaryTreeNode<int> _root)
        {
            root = _root;
        }

        /// <summary>
        /// Малый левый поворот
        /// </summary>
        /// <param name="r"></param>
        public void SmallLeftTurn(BinaryTreeNode<int> r)
        {
            if (r.RightChild == null)
                throw new Exception("Малый левый поворот невозможен");
            var newRoot = r.RightChild;
            r.RightChild = r.RightChild.LeftChild;
            newRoot.LeftChild = r;
            r = newRoot;
        }
    }
}
