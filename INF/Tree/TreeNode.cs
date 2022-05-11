using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class TreeNode<T>
    {
        public T Value;

        List<TreeNode<T>> childrenList;
        public List<TreeNode<T>> ChildNodeList
        {
            get => childrenList;
        }

        public TreeNode(T value)
        {
            this.Value = value;
        }
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            this.Value = value;
            childrenList = children;
        }

        public void AddChild(T value)
        {
            if (childrenList == null)
                childrenList = new List<TreeNode<T>>();
            childrenList.Add(new TreeNode<T>(value));
        }

        public bool HasChild()
        {
            return childrenList?.Any() ?? false;
        }
    }
}
