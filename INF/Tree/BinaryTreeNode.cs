using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class BinaryTreeNode<T>
    {
        public T Value;
        public int Key;
        public BinaryTreeNode<T> LeftChild;
        public BinaryTreeNode<T> RightChild;
        public BinaryTreeNode<T> Parent;
        /// <summary>
        /// Высота узла
        /// </summary>
        public int Hight;

        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
            Parent = parent;
        }

        public BinaryTreeNode(T value, int key, BinaryTreeNode<T> leftChild,
                              BinaryTreeNode<T> rightChild, BinaryTreeNode<T> parent = null)
        {
            Value = value;
            Key = key;
            Parent = parent;
            RightChild = rightChild;
            LeftChild = leftChild;
        }
    }
}
