using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class BalancedTreeNode<T> : Compare<T> where T : IComparable
    {
        public List<T> Data { get; set; }
        //public BalancedTreeNode<T> LeftNode;
        //public BalancedTreeNode<T> RightNode;
        //public BalancedTreeNode<T> CenterNode;

        public BalancedTreeNode(T value)
        {
            Data = new List<T>();
            Data.Add(value);
        }
    }
   
    public class BalancedTree<T> : Compare<T> where T : IComparable
    {
        //public List<T> data;
        public int max = 3; // max storage of node
        public BalancedTreeNode<T> Root;
        public BalancedTreeNode<T> Children;
        public BalancedTree()
        {
            //data = new List<T>();
            Root = null;
            Children = null;
        }

        public void Insert(BalancedTreeNode<T> node, T value)
        {
            BalancedTreeNode<T> Curr = Root;
            if (Curr == null)
            {
                Curr = new BalancedTreeNode<T>(value);
            }
            else
            {
                do
                {
                    for (; IsFull(Curr); )
                    if (IsFull(Curr))
                    {
                        if (DoCompare(value, Curr.Data[0]) == Comparet.LESSTHAN)
                        {
                            Insert(Children.Data[0], value);
                        }
                        else
                        {
                            if (DoCompare(value, Curr.Data[1]) == Comparet.LESSTHAN)
                            {
                                Curr.Data.Add(Curr.Data[1]);
                                Curr.Data.RemoveAt(1);
                                Curr.Data.Insert(1, value);
                            }
                            else
                            {
                                Curr.Data.Add(value);
                            }
                        }
                    }

                } while (true);
            }
            Root = Curr;
        }

        
        public void Split(BalancedTreeNode<T> node)
        {
            // at root
            if (node == Root)
            {
                Children = new BalancedTreeNode<T>(node.Data[0]);
                Children.Data.Add(node.Data[2]);
                Root.Data.Remove(node.Data[0]);
                Root.Data.Remove(node.Data[2]);
            }
            else
            {
                int minSplit = CountSpace(Children.Data) / 2;
                int maxSplit = CountSpace(Children.Data);
            }
        }
        // TODO

        // TODO
        public void Delete()
        {

        }
        // TODO

        // TODO
        public void Find()
        {

        }
        // TODO

        public void Print(BalancedTreeNode<T> binaryTreeNode, String pos)
        {
            //if (binaryTreeNode.Data != null)
            //{
            //    for (int i = 0; i < binaryTreeNode.Data.Count(); i++)
            //    {
            //        //if (i == 0)
            //        //{
            //        //    Console.Write("{0} Node: ", pos);
            //        //}
            //        Console.Write(binaryTreeNode.Data[i] + " ");
            //        //if (i == binaryTreeNode.Data.Count() - 1)
            //        //{
            //        //    Console.WriteLine();
            //        //}
            //    }
            //    if (binaryTreeNode.LeftNode != null)
            //    {
            //        foreach (var item in binaryTreeNode.LeftNode.Data)
            //        {
            //            Console.Write(item + " ");
            //        }
            //    }
            //    if (binaryTreeNode.CenterNode != null)
            //    {
            //        foreach (var item in binaryTreeNode.CenterNode.Data)
            //        {
            //            Console.Write(item + " ");
            //        }
            //    }
            //    if (binaryTreeNode.RightNode != null)
            //    {
            //        foreach (var item in binaryTreeNode.RightNode.Data)
            //        {
            //            Console.Write(item + " ");
            //        }
            //    }
            //}
        }
        public int CountSpace(List<T> list)
        {
            if (list == null)
            {
                return 0;
            }
            return list.Count();
        }

        public bool IsFull(BalancedTreeNode<T> node)
        {
            if (CountSpace(node.Data) == max)
            {
                return true;
            }
            return false;
        }

        public List<T> Reverse(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (DoCompare(list[i], list[j]) == Comparet.GREATER)
                    {
                        T temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        
        public BalancedTreeNode<T> GetParent()
        {
            BalancedTreeNode<T> node = null;
            int i = 0;
            while (Root.Data != null)
            {
                node.Data.Add(Root.Data[i]);
                i++;
            }
            return node;
        }

        //public void Add(BalancedTreeNode<T> node, T value)
        //{
        //    if (Root == null)
        //    {
        //        Root = new BalancedTreeNode<T>(value);
        //        return;
        //    }
        //    else
        //    {
        //        if (CountSpace(Root.Data) < max)
        //        {
        //            if (Root.LeftNode != null && Root.RightNode != null)
        //            {
        //                if (CountSpace(Root.Data) == 2)
        //                {
        //                    Root.Data.Add(value);
        //                    Root.Data = Reverse(Root.Data);
        //                    Root.CenterNode.Data.Add(Root.Data[1]);
        //                    Root.CenterNode.Data = Reverse(Root.CenterNode.Data);
        //                    Root.Data.RemoveAt(1);
        //                    Root.Data = Reverse(Root.Data);
        //                    if (CountSpace(Root.CenterNode.Data) == max)
        //                    {
        //                        // TO-DO
        //                        BalancedTree<T> Tree = new BalancedTree<T>();
        //                        Tree.Root = new BalancedTreeNode<T>(Root.CenterNode.Data[1]);
        //                        Tree.Root.LeftNode = new BalancedTreeNode<T>(Root.Data[0]); // Root.Data[0]
        //                        Tree.Root.RightNode = new BalancedTreeNode<T>(Root.Data[1]); // Root.Data[1]
        //                        Tree.Root.LeftNode.LeftNode = new BalancedTreeNode<T>(Root.LeftNode.Data[0]); // 
        //                        Tree.Root.LeftNode.RightNode = new BalancedTreeNode<T>(Root.CenterNode.Data[0]);
        //                        Tree.Root.RightNode.LeftNode = new BalancedTreeNode<T>(Root.CenterNode.Data[2]);
        //                        Tree.Root.RightNode.RightNode = new BalancedTreeNode<T>(Root.RightNode.Data[0]);
        //                        Root.CenterNode.Data.Clear();
        //                        //balancedTree = Tree;
        //                    }
        //                }
        //                else
        //                {
        //                    if (DoCompare(value, Root.Data[0]) == Comparet.LESSTHAN)
        //                    {
        //                        Add(Root.LeftNode, value);
        //                        //Root.LeftNode.Data.Add(value);
        //                        //Reverse(Root.LeftNode.Data);
        //                        if (Root.LeftNode.Data.Count == max)
        //                        {
        //                            if (Root.CenterNode == null)
        //                            {
        //                                Root.CenterNode = new BalancedTreeNode<T>(Root.LeftNode.Data[2]);
        //                            }
        //                            else
        //                            {
        //                                Root.CenterNode.Data.Add(Root.LeftNode.Data[2]);
        //                            }
        //                            Root.Data.Add(Root.LeftNode.Data[1]);
        //                            Reverse(Root.Data);
        //                            Root.LeftNode.Data.RemoveRange(1, 2);
        //                        }
        //                    }
        //                    else if (DoCompare(value, Root.Data[0]) == Comparet.GREATER)
        //                    {
        //                        Root.RightNode.Data.Add(value);
        //                        Reverse(Root.RightNode.Data);
        //                        if (Root.RightNode.Data.Count == max)
        //                        {
        //                            if (Root.CenterNode == null)
        //                            {
        //                                Root.CenterNode = new BalancedTreeNode<T>(Root.RightNode.Data[2]);
        //                            }
        //                            else
        //                            {
        //                                Root.CenterNode.Data.Add(Root.RightNode.Data[2]);
        //                            }
        //                            Root.Data.Add(Root.RightNode.Data[1]);
        //                            Reverse(Root.Data);
        //                            Root.RightNode.Data.RemoveRange(1, 2);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // Throw Exception
        //                        throw new Exception("Duplicate value");
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Root.Data.Add(value);
        //                Root.Data = Reverse(Root.Data);
        //            }
        //        }
        //        else
        //        {
        //            // 16:21
        //            if (Root.LeftNode == null)
        //            {
        //                Root.LeftNode = new BalancedTreeNode<T>(Root.Data[0]);
        //            }
        //            if (Root.RightNode == null)
        //            {
        //                Root.RightNode = new BalancedTreeNode<T>(Root.Data[2]);
        //            }
        //            T temp = Root.Data[1];
        //            Root.Data.Clear();
        //            Root.Data.Add(temp);
        //            Add(Root, value);
        //        }
        //    }
        //}

        // TODO
    }
}
