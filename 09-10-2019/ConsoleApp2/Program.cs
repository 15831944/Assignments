using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Tree<T> : Compare<T> where T : IComparable
    {
        public int max;
        public Node<T> root;
        public Tree()
        {
            this.max = 0;
        }
        public void InitRoot()
        {
            this.root.parent = null;
            this.root.isLeaf = true;
        }
        public void Insert(T value)
        {
            Node<T> node = FindSubLeafTree(root, value);
            if (!this.TryInsert(node, value))
                this.Split(node, value);
            if (node.NumberOfElements() == 3)
            {
                Reverse(node.elements, node.NumberOfElements());
            }
        }
        public virtual void Split(Node<T> node, T value){}
        public bool TryInsert(Node<T> node, T value)
        {
            bool result = true;
            if (node.NumberOfElements() == 0 && node.parent == null)
            {
                node.elements = new T[max];
                node.elements[0] = value;
            }
            else if (node.NumberOfElements() < max)
            {
                node.elements[node.NumberOfElements()] = value;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public Node<T> FindSubLeafTree(Node<T> node, T value)
        {
            if (node.IsLeaf())
            {
                return node;
            }
            else
            {
                if (DoCompare(value, node.elements[0]) == Comparet.LESSTHAN)
                {
                    return FindSubLeafTree(node.children[0], value);
                }
                else if (node.NumberOfElements() == 1 || (DoCompare(value, node.elements[0]) == Comparet.GREATER
                    && DoCompare(value, node.elements[1]) == Comparet.LESSTHAN))
                {
                    return FindSubLeafTree(node.children[1], value);
                }
                else if (node.NumberOfElements() == 2 || (DoCompare(value, node.elements[1]) == Comparet.GREATER
                    && DoCompare(value, node.elements[2]) == Comparet.LESSTHAN))
                {
                    return FindSubLeafTree(node.children[2], value);
                }
                else
                {
                    return FindSubLeafTree(node.children[3], value);
                }
            }
        }
        public void Reverse(T[] elements, int numberOfElement)
        {
            T temp;
            for (int i = 0; i < numberOfElement; i++)
            {
                for (int j = i + 1; j < numberOfElement; j++)
                {
                    if (DoCompare(elements[i], elements[j]) == Comparet.GREATER)
                    {
                        temp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = temp;
                    }
                }
            }
            //return Data;
        }
    }
    public class BalancedTree<T> : Tree<T> where T : IComparable
    {
        public BalancedTree()
        {
            this.root = new Node<T>();
            this.max = 3;
            this.InitRoot();
        }
        public override void Split(Node<T> node, T value)
        {
            // TODO
            Node<T> tempnode;

            if (node.parent == null)
            {
                tempnode = new Node<T>();
            }
            else
            {
                tempnode = node.parent;
            }
        }
    }
    public class Node<T> : Compare<T> where T : IComparable
    {
        public bool isLeaf;
        public T[] elements; // element of node
        public Node<T>[] children; // children of node
        public Node<T> parent; // parent node
        public int numberOfElements; // number of elements in node; if node isn't a leaf then number + 1 give the number of children
        public Node()
        {
            parent = null;
        }
        public bool IsLeaf()
        {
            bool result = true;
            if (this.children != null)
            {
                for (int i = 0; i < this.children.Length; i++)
                {
                    if (children[i] != null)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        public int NumberOfElements()
        {
            int count = 0;
            if (elements != null)
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!CompareToZero(elements[i]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
    public class TwoThreeFourNode<T> : Node<T> where T : IComparable
    {
        public TwoThreeFourNode()
        {
            this.elements = new T[2];
            this.children = new TwoThreeFourNode<T>[3];
            InitNode();
        }
        
        public void InitNode()
        {
            //elements = twoTreeNode.elements;
            //children = twoTreeNode.children;
            //parent = twoTreeNode.parent;
            //numberOfElements = twoTreeNode.NumberOfElements();
            children = null;
        }
    }
    public class Program
    {
        static int[] GetRanDomNumList(int max)
        {
            int[] int_arr = new int[max];
            if (max != 0)
            {
                Random random = new Random();
                for (int i = 0; i < max; i++)
                {
                    int_arr[i] = random.Next(10, max);
                }
            }
            else
            {
                int_arr = new int[] { 9, 6, 8, 3 }; // , 2, 4, 7, 10 , 1, 5 
            }
            return int_arr;
        }
        public static List<int> CreateList()
        {
            List<int> list = new List<int>();
            int[] address = GetRanDomNumList(0);
            list.AddRange(address);
            return list;
        }
        // init List
        static List<int> listAddress = CreateList();
        static void Main(string[] args)
        {
            BalancedTree<int> balancedTree = new BalancedTree<int>();
            for (int i = 0; i < listAddress.Count(); i++)
            {
                balancedTree.Insert(listAddress[i]);
            }
            Console.ReadLine();
        }
    }
}
