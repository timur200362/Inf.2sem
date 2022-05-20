using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.Tree
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;
        /// <summary>
        /// Добавление элемента в дерево по ключу
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        //public BinaryTreeNode<T> Head
        //{
        //    get
        //    {
        //        return root;
        //    }
        //    set
        //    {
        //        root = value;
        //    }
        //}
        public void Add(T value, int key)
        {
            if (root == null)
                root = new BinaryTreeNode<T>(value, key);
            else
            {
                int hight = 0;
                bool isFind = false;
                var rootCopy = root;
                while (isFind == false)
                {
                    if (key == rootCopy.Key)
                    {
                        rootCopy.Value = value;
                        rootCopy.Hight = hight;
                        isFind = true;
                    }
                    else if (key < rootCopy.Key)
                    {
                        if (rootCopy.LeftChild == null)
                        {
                            rootCopy.LeftChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            rootCopy.LeftChild.Hight = hight + 1;
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.LeftChild;
                    }
                    else
                    {
                        if (rootCopy.RightChild == null)
                        {
                            rootCopy.RightChild = new BinaryTreeNode<T>(value, key, rootCopy);
                            rootCopy.RightChild.Hight = hight + 1;
                            isFind = true;
                        }
                        else
                            rootCopy = rootCopy.RightChild;
                    }
                    hight++;
                }
            }
        }
        /// <summary>
        /// Вывод дерева в ширину с использованием цветов
        /// </summary>
        public void BreadthFirstSearch()
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);
                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);
                toVist.RemoveAt(0);
                Console.WriteLine($"Ключ: {current.Key}, Высота:{current.Hight}, Цвет:{(Color)current.Hight}");
            }
        }
        public enum Color
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            NavyBlue,
            Purple
        }
        /// <summary>
        /// Подсчёт кол-ва листьев
        /// </summary>
        /// <returns></returns>
        public int CountLeaves()
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            int count = 0;

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);

                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);

                if (current.LeftChild == null && current.RightChild == null)
                {
                    count++;
                }
                toVist.RemoveAt(0);
            }
            return count;
        }
        /// <summary>
        /// Вывод узлов высотой n
        /// </summary>
        /// <param name="n"></param>
        public void OutputOfTreeNodesWithHeightN(int n)
        {
            List<BinaryTreeNode<T>> toVist = new List<BinaryTreeNode<T>>();

            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist[0];

                if (current.RightChild != null)
                    toVist.Add(current.RightChild);

                if (current.LeftChild != null)
                    toVist.Add(current.LeftChild);

                toVist.RemoveAt(0);

                if (current.Hight == n)
                    Console.WriteLine($"Ключ: {current.Key}, Высота {current.Hight} ");
            }
        }
        /// <summary>
        /// обойти всё дерево, следуя порядку (левое поддерево, вершина, правое поддерево). Элементы по возрастанию
        /// </summary>
        public void InfixTraverse()
        {
            InfixTraverse(root);
        }
        private void InfixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;

            if (root.LeftChild != null)
                InfixTraverse(root.LeftChild);
            Console.Write(root.Key + "->");
            if (root.RightChild != null)
                InfixTraverse(root.RightChild);
        }
        /// <summary>
        /// обойти всё дерево, следуя порядку (вершина, левое поддерево, правое поддерево). Элементы, как в дереве
        /// </summary>
        public void PrefixTraverse()
        {
            PrefixTraverse(root);
        }
        private void PrefixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;
            Console.Write(root.Key + "->");
            if (root.LeftChild != null)
                PrefixTraverse(root.LeftChild);
            if (root.RightChild != null)
                PrefixTraverse(root.RightChild);
        }
        /// <summary>
        /// обойти всё дерево, следуя порядку (левое поддерево, правое поддерево, вершина). Элементы в обратном порядке, как в дереве
        /// </summary>
        public void PostfixTraverse()
        {
            PostfixTraverse(root);
        }
        private void PostfixTraverse(BinaryTreeNode<T> root)
        {
            if (root == null)
                return;
            if (root.LeftChild != null)
                PostfixTraverse(root.LeftChild);
            if (root.RightChild != null)
                PostfixTraverse(root.RightChild);
            Console.Write(root.Key + "->");
        }
        /// <summary>
        /// возвращает значение корня дерева
        /// </summary>
        public T Root()
        {
            return root.Value;
        }
        public BinaryTreeNode<T> Headroot()
        {
            return root;
        }
        /// <summary>
        /// возвращает значение «родителя» для вершины в позиции p
        /// </summary>
        public T Parent(int p)
        {
            throw new Exception();
        }

        /// <summary>
        /// возвращает значение «самого левого сына» для вершины в позиции p.
        /// изначально надо было вернуть позицию
        /// </summary>
        public T LeftMostChild(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// возвращает значение «правого брата» для вершины в позиции p.
        /// изначально надо было вернуть позицию
        /// </summary>
        public T RightSibling(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// возвращает элемент дерева (хранимую информацию) для вершины в позиции p.
        /// </summary>
        public T Element(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// проверяет, является ли p позицией внутренней вершины (не листа)
        /// </summary>
        public bool IsInternal(int p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// проверяет, является ли p позицией листа дерева.
        /// </summary>
        public bool IsExternal(int p)
        {
            BinaryTreeNode<T> node = Find2(p);
            return node != null && node.LeftChild == null && node.RightChild == null;
            //BinaryTreeNode<T> node = Find2(p);
            //if (node != null && node.LeftChild == null && node.RightChild == null)
            //{
            //    return true;
            //}
            //return node != null && node.LeftChild == null && node.RightChild == null;
            //throw new NotImplementedException();
            //BinaryTreeNode<T> node = new BinaryTreeNode<>('C', 5, null);
            //if (root == null)
            //{
            //    throw new Exception("Дерево пустое");
            //}
            //if (root.Key>p)
            //{
            //    if (root.LeftChild == null)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        while(root.LeftChild.LeftChild!=null)
            //    }
            //}
        }

        /// <summary>
        /// проверяет, является ли p позицией корня.
        /// </summary>
        public bool IsRoot(int p)
        {
            throw new Exception();
        }

        /// <summary>
        /// проверяет, является ли key ключом корневого узла.
        /// </summary>
        public bool IsRootByKey(int key)
        {
            throw new Exception();
        }
        public void ShowSymmetric()
        {
            ShowSymmetric(root, 0);
        }
        public void ShowSymmetric(BinaryTreeNode<T> node, int level)
        {
            if (node != null)
            {
                ShowSymmetric(node.LeftChild, level + 1);
                for (int i = 0; i < 8 * level; i++) Console.Write(" ");
                Console.WriteLine(node.Key);
                ShowSymmetric(node.RightChild, level + 1);
            }
        }
        /// <summary>
        /// Поиск элемента в дереве
        /// </summary>
        public bool Find(int key)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException("Дерево пусто");
            }
            var rootCopy = root;
            bool isFind = false;
            while (isFind == false)
            {
                if (rootCopy.Key == key)
                {
                    return true;

                }
                if (key < rootCopy.Key)
                {
                    if (rootCopy.LeftChild == null)
                    {
                        return false;
                    }
                    rootCopy = rootCopy.LeftChild;
                }
                else if (key > rootCopy.Key)
                {
                    if (rootCopy.RightChild == null)
                    {
                        return false;
                    }
                    rootCopy = rootCopy.RightChild;
                }
            }
            return false;
        }
        public BinaryTreeNode<T> Find2(int key)
        {
            if (root == null)
            {
                return null;
                throw new ArgumentOutOfRangeException("Дерево пусто");
            }
            var rootCopy = root;
            bool isFind = false;
            while (isFind == false)
            {
                if (rootCopy.Key == key)
                {
                    return rootCopy;
                }
                if (key < rootCopy.Key)
                {
                    if (rootCopy.LeftChild == null)
                    {
                        return null;
                    }
                    rootCopy = rootCopy.LeftChild;
                }
                else if (key > rootCopy.Key)
                {
                    if (rootCopy.RightChild == null)
                    {
                        return null;
                    }
                    rootCopy = rootCopy.RightChild;
                }
            }
            return null;
        }
        /// <summary>
        /// добавление в дерево значения 
        /// </summary>
        public void Insert(int key, T data)
        {
            throw new Exception();
        }
        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="value">удаляемое значение</param>
        public void RemoveRecursion(int key)
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            Remove(key, root);
        }
        private void Remove(int key, BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                Console.WriteLine($"Элемент {key} в дереве отсутствует");
                return;
            }
            //Проверяем, надо ли искать в левом поддереве
            if (root.Key > key)
            {
                if (root.LeftChild == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.LeftChild);
            }
            else if (root.Key < key)
            {
                if (root.RightChild == null)
                {
                    Console.WriteLine($"Элемент {key} в дереве отсутствует");
                    return;
                }
                else
                    Remove(key, root.RightChild);
            }
            else //root.Key == key - нашли узел, которы надо удалить
            {
                bool? isLeft = root.Parent != null
                    ? root.Parent.Key > root.Key
                    : (bool?)null; //нет родительского элемента - не может быть левыйм или правым
                //Если обоих детей нет, то удаляем текущий узел и 
                //обнуляем ссылку на него у родительского узла
                if (root.LeftChild == null && root.RightChild == null)
                {
                    if (root.Parent != null) //isLeft.HasValue
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = null;
                        else
                            root.Parent.RightChild = null;
                    }
                    else
                        this.root = null;
                }
                //Если одного из детей нет, то значения полей 
                //ребёнка m ставим вместо соответствующих значений 
                //корневого узла, затирая его старые значения, 
                //и освобождаем память, занимаемую узлом m;
                else if (root.LeftChild != null && root.RightChild == null)
                {
                    //левый потомок есть, правого нет
                    if (isLeft.HasValue) //имеется родительский элемент
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = root.LeftChild;
                        else
                            root.Parent.RightChild = root.LeftChild;
                    }
                    else
                        this.root = root.LeftChild;
                }
                else if (root.LeftChild == null && root.RightChild != null)
                {
                    //правый потомок есть, левого нет
                    if (isLeft.HasValue)
                    {
                        if (isLeft.Value)
                            root.Parent.LeftChild = root.RightChild;
                        else
                            root.Parent.RightChild = root.RightChild;
                    }
                    else
                        this.root = root.RightChild;
                }
                //оба потомка имеются
                else
                {
                    //Если левый узел m правого 
                    //поддерева отсутствует(n->right->left)
                    if (root.RightChild.LeftChild == null)
                    {
                        //Копируем из правого узла в удаляемый поля K, V 
                        //и ссылку на правый узел правого потомка.
                        root.Key = root.RightChild.Key;
                        root.Value = root.RightChild.Value;
                        root.RightChild = root.RightChild.RightChild;
                        if (root.RightChild != null)
                            root.RightChild.Parent = root;
                    }
                    else
                    {
                        //Возьмём самый левый узел m, правого поддерева n->right;
                        var mostLeft = root.RightChild;
                        while (mostLeft.LeftChild != null)
                            mostLeft = mostLeft.LeftChild;
                        //Скопируем данные (кроме ссылок на дочерние элементы) из m в n
                        root.Key = mostLeft.Key;
                        root.Value = mostLeft.Value;
                        //удалим узел m.
                        mostLeft.Parent.LeftChild = null;
                    }
                }
            }
        }
        //https://learnc.info/adt/binary_tree_traversal.html вывод деревьев

        /// <summary>
        /// Вывод в ширину
        /// </summary>
        public void PrintDepth()
        {
        }
        /// <summary>
        /// Сбалансировать дерево *
        /// </summary>
        public void Balance()
        {

        }
    }
}