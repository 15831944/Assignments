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
        }
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
                Array.Resize<T>(ref node.elements, node.NumberOfElements() + 1);
                node.elements[node.NumberOfElements()] = value;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public virtual void Split(Node<T> node, T value) { }
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
            //// TODO
            Node<T> newNode = new Node<T>();
            newNode.elements = new T[] { };
            newNode.children = new Node<T>[3];
            Node<T> n1 = new Node<T>();
            Node<T> n2 = new Node<T>();
            n1.elements = new T[2];
            n2.elements = new T[2];
            T[] elements = { node.elements[0], node.elements[1], node.elements[2] };
            elements = SortArray(elements);
            if (node.parent == null)
            {
                
                n1.elements[0] = elements[0];
                n2.elements[0] = elements[2];
                n1.parent = newNode;
                n2.parent = newNode;
                newNode.elements = new T[1];
                newNode.elements[0] = elements[1];
                newNode.children[0] = n1;
                newNode.children[2] = n2;
                if (DoCompare(value, elements[1]) == Comparet.GREATER)
                {
                    n2.elements[1] = value;
                    Reverse(n2.elements, n2.NumberOfElements());
                }
                else if (DoCompare(value, elements[1]) == Comparet.LESSTHAN)
                {
                    n1.elements[1] = value;
                    Reverse(n1.elements, n1.NumberOfElements());
                }
                this.root = newNode;
            }
            else
            {
                newNode = node.parent;
                n1.parent = newNode;
                n2.parent = newNode;
                Array.Resize(ref newNode.elements, newNode.NumberOfElements() + 1);
                newNode.elements[newNode.NumberOfElements()] = elements[1]; // root 
                n1.elements[0] = elements[0]; // left
                n2.elements[0] = elements[2]; // center
                Reverse(n1.elements, n1.NumberOfElements());
                Reverse(n2.elements, n1.NumberOfElements());
                Reverse(newNode.elements, newNode.NumberOfElements());
            }

            if (newNode.NumberOfElements() == 0)
            {
                newNode.children[0] = n1;
                newNode.children[1] = n2;
                this.root = newNode;
            }
            else if (newNode.NumberOfElements() == 2)
            {
                if (DoCompare(value, newNode.elements[0]) == Comparet.LESSTHAN && DoCompare(value, newNode.elements[1]) == Comparet.LESSTHAN)
                {
                    // add new value to left
                    newNode.children[0] = n1;
                    newNode.children[1] = n2;
                }
                else if (DoCompare(value, newNode.elements[0]) == Comparet.GREATER && DoCompare(value, newNode.elements[1]) == Comparet.GREATER)
                {
                    // add new value to right
                    newNode.children[1] = n2;
                    newNode.children[2] = n1;
                }
                else
                {
                    Array.Resize(ref newNode.elements, newNode.NumberOfElements() + 1);
                    newNode.elements[newNode.elements.Length] = value;
                    Reverse(newNode.elements, newNode.NumberOfElements());
                    //newNode.children[]
                }
                this.root = newNode;
                //if (DoCompare(RightNode.elements[0], newNode.elements[0]) == Comparet.LESSTHAN && DoCompare(RightNode.elements[0], newNode.elements[1]) == Comparet.LESSTHAN)
                //{
                //    newNode.children = new Node<T>[4];
                //    newNode.children[3] = newNode.children[2];
                //    newNode.children[2] = newNode.children[1];
                //    newNode.children[0] = LeftNode;
                //    newNode.children[1] = RightNode;
                //}
                //else if (DoCompare(LeftNode.elements[1], newNode.elements[0]) == Comparet.GREATER && DoCompare(LeftNode.elements[1], newNode.elements[1]) == Comparet.GREATER)
                //{
                //    newNode.children = new Node<T>[4];
                //    newNode.children[2] = LeftNode;
                //    newNode.children[3] = RightNode;
                //}
                //else
                //{
                //    newNode.children = new Node<T>[4];
                //    newNode.children[3] = newNode.children[2];
                //    newNode.children[1] = LeftNode;
                //    newNode.children[2] = RightNode;
                //}
            }

            // if it is not a leaf check
            if (node.IsLeaf() == false)
            {
                //node.children[0].parent = LeftNode;
                //node.children[1].parent = LeftNode;
                //node.children[2].parent = LeftNode;

                //node.children[3].parent = RightNode;
                //node.children[4].parent = RightNode;

                //LeftNode.children[0] = node.children[0];
                //LeftNode.children[1] = node.children[1];
                //LeftNode.children[2] = node.children[2];

                //RightNode.children[0] = node.children[3];
                //RightNode.children[1] = node.children[4];
            }

            if (newNode.NumberOfElements() == 3)
            {
                this.Split(newNode, elements[1]);
            }
            else if (newNode.NumberOfElements() < this.max)
            {
                newNode.elements = new T[1];
                newNode.elements[newNode.NumberOfElements()] = elements[1];
                newNode.elements = SortArray(newNode.elements);
            }

            /*  */
            //Node<T> LeftNode = new Node<T>();
            //LeftNode.elements = new T[2];
            //Node<T> RightNode = new Node<T>();
            //RightNode.elements = new T[1];
            //Node<T> CenterNode = new Node<T>();
            //CenterNode.elements = new T[1];
            //elements = SortArray(elements);
            //T middle;
            //LeftNode.elements[0] = elements[0];
            //LeftNode.elements[1] = elements[1];
            //RightNode.elements[0] = elements[3];
            //middle = elements[2];
            //LeftNode.parent = newNode;
            //RightNode.parent = newNode;
            //newNode.elements = new T[] { };
            //if (newNode.NumberOfElements() == 0)
            //{

            //    newNode.children[0] = LeftNode;
            //    newNode.children[1] = RightNode;
            //    this.root = newNode;
            //}
            /*  */
            //else if (newNode.NumberOfElements() == 1)
            //{
            //    if (DoCompare(RightNode.elements[0], newNode.elements[0]) == Comparet.LESSTHAN)
            //    {
            //        newNode.children = new Node<T>[3];
            //        newNode.children[2] = newNode.children[1];
            //        newNode.children[0] = LeftNode;
            //        newNode.children[1] = RightNode;
            //    }
            //    else
            //    {
            //        newNode.children = new Node<T>[3];
            //        newNode.children[1] = LeftNode;
            //        newNode.children[2] = RightNode;
            //    }
            //}
            //else if (newNode.NumberOfElements() == 2)
            //{
            //    if (DoCompare(RightNode.elements[0], newNode.elements[0]) == Comparet.LESSTHAN && DoCompare(RightNode.elements[0], newNode.elements[1]) == Comparet.LESSTHAN)
            //    {
            //        newNode.children = new Node<T>[4];
            //        newNode.children[3] = newNode.children[2];
            //        newNode.children[2] = newNode.children[1];
            //        newNode.children[0] = LeftNode;
            //        newNode.children[1] = RightNode;
            //    }
            //    else if (DoCompare(LeftNode.elements[1], newNode.elements[0]) == Comparet.GREATER && DoCompare(LeftNode.elements[1], newNode.elements[1]) == Comparet.GREATER)
            //    {
            //        newNode.children = new Node<T>[4];
            //        newNode.children[2] = LeftNode;
            //        newNode.children[3] = RightNode;
            //    }
            //    else
            //    {
            //        newNode.children = new Node<T>[4];
            //        newNode.children[3] = newNode.children[2];
            //        newNode.children[1] = LeftNode;
            //        newNode.children[2] = RightNode;
            //    }
            //}
            //else if (newNode.NumberOfElements() == 3)
            //{
            //    if (DoCompare(RightNode.elements[0], newNode.elements[0]) == Comparet.LESSTHAN)
            //    {
            //        newNode.children = new Node<T>[5];
            //        newNode.children[4] = newNode.children[3];
            //        newNode.children[3] = newNode.children[2];
            //        newNode.children[2] = newNode.children[1];
            //        newNode.children[1] = RightNode;
            //        newNode.children[0] = LeftNode;
            //    }

            //    else if (DoCompare(LeftNode.elements[0], newNode.elements[0]) == Comparet.GREATER && DoCompare(RightNode.elements[0], newNode.elements[1]) == Comparet.LESSTHAN)
            //    {
            //        newNode.children = new Node<T>[5];
            //        newNode.children[4] = newNode.children[3];
            //        newNode.children[3] = newNode.children[2];
            //        newNode.children[2] = RightNode;
            //        newNode.children[1] = LeftNode;
            //    }

            //    else if (DoCompare(LeftNode.elements[0], newNode.elements[1]) == Comparet.GREATER && DoCompare(RightNode.elements[0], newNode.elements[2]) == Comparet.LESSTHAN)
            //    {
            //        newNode.children = new Node<T>[5];
            //        newNode.children[4] = newNode.children[3];
            //        newNode.children[3] = RightNode;
            //        newNode.children[2] = LeftNode;
            //    }
            //    else
            //    {
            //        newNode.children = new Node<T>[5];
            //        newNode.children[3] = LeftNode;
            //        newNode.children[4] = RightNode;
            //    }
            //}

            //if it is not a leaf check
            //if (node.IsLeaf() == false)
            //{
            //    node.children[0].parent = LeftNode;
            //    node.children[1].parent = LeftNode;
            //    node.children[2].parent = LeftNode;

            //    node.children[3].parent = RightNode;
            //    node.children[4].parent = RightNode;

            //    LeftNode.children[0] = node.children[0];
            //    LeftNode.children[1] = node.children[1];
            //    LeftNode.children[2] = node.children[2];

            //    RightNode.children[0] = node.children[3];
            //    RightNode.children[1] = node.children[4];
            //}

            //if (newNode.NumberOfElements() == 3)
            //{
            //    this.Split(newNode, middle);
            //}

            //else if (newNode.NumberOfElements() < this.max)
            //{
            //    newNode.elements = new T[1];
            //    newNode.elements[newNode.NumberOfElements()] = middle;
            //    newNode.elements = SortArray(newNode.elements);
            //}

            this.root = newNode;
        }

        public T[] SortArray(T[] arr)
        {
            T temp;
            T[] data = new T[] { };
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int j = i + 1; j < arr.Count(); j++)
                {
                    if (DoCompare(arr[i], arr[j]) == Comparet.GREATER)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            data = arr;
            return data;
        }

        private static T[] MergeList(T[] left, T pivot, T[] right)
        {
            left[left.Length] = pivot;
            right.Concat(left);
            return left;
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
                int_arr = new int[] { 9, 6, 8, 3, 2, 4 }; // , 7, 10 , 1, 5 
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
