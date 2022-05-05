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

            //Проверка метода IsExternal
            //var tree2 = new BinarySearchTree<string>();
            //tree2.Add("A",8);
            //tree2.Add("A", 6);
            //tree2.Add("A", 9);
            //tree2.Add("A", 5);
            //tree2.Add("A", 7);
            //tree2.Add("A", 10);
            //Console.WriteLine(tree2.IsExternal(6));

        }
    }
}
