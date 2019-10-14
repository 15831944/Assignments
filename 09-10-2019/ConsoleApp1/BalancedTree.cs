using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class BalancedTreeNode<T> : Compare<T> where T : IComparable
    {
        public List<T> Data { get; set; }
        public BalancedTreeNode<T> LeftNode;
        public BalancedTreeNode<T> RightNode;
        public BalancedTreeNode<T> CenterNode;

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
        public BalancedTree()
        {
            //Parent = new BalancedTree<T>(value);
            //data = new List<T>();
            Root = null;
        }
        public void Add(ref BalancedTree<T> balancedTree, T value)
        {
            if (Root == null)
            {
                Root = new BalancedTreeNode<T>(value);
                return;
            }
            else
            {
                if (CountSpace(Root.Data) < max)
                {
                    if (Root.LeftNode != null && Root.RightNode != null)
                    {
                        if (CountSpace(Root.Data) == 2)
                        {
                            Root.Data.Add(value);
                            Root.Data = Reverse(Root.Data);
                            Root.CenterNode.Data.Add(Root.Data[1]);
                            Root.CenterNode.Data = Reverse(Root.CenterNode.Data);
                            Root.Data.RemoveAt(1);
                            Root.Data = Reverse(Root.Data);
                            if (CountSpace(Root.CenterNode.Data) == max)
                            {
                                // TO-DO
                                BalancedTree<T> Tree = new BalancedTree<T>();
                                Tree.Root = new BalancedTreeNode<T>(Root.CenterNode.Data[1]);
                                Tree.Root.LeftNode = new BalancedTreeNode<T>(Root.Data[0]); // Root.Data[0]
                                Tree.Root.RightNode = new BalancedTreeNode<T>(Root.Data[1]); // Root.Data[1]
                                Tree.Root.LeftNode.LeftNode = new BalancedTreeNode<T>(Root.LeftNode.Data[0]); // 
                                Tree.Root.LeftNode.RightNode = new BalancedTreeNode<T>(Root.CenterNode.Data[0]);
                                Tree.Root.RightNode.LeftNode = new BalancedTreeNode<T>(Root.CenterNode.Data[2]);
                                Tree.Root.RightNode.RightNode = new BalancedTreeNode<T>(Root.RightNode.Data[0]);
                                Root.CenterNode.Data.Clear();
                                balancedTree = Tree;
                            }
                        }
                        else
                        {
                            if (DoCompare(value, Root.Data[0]) == Comparet.LESSTHAN)
                            {
                                Root.LeftNode.Data.Add(value);
                                Reverse(Root.LeftNode.Data);
                                if (Root.LeftNode.Data.Count == max)
                                {
                                    if (Root.CenterNode == null)
                                    {
                                        Root.CenterNode = new BalancedTreeNode<T>(Root.LeftNode.Data[2]);
                                    }
                                    else
                                    {
                                        Root.CenterNode.Data.Add(Root.LeftNode.Data[2]);
                                    }
                                    Root.Data.Add(Root.LeftNode.Data[1]);
                                    Reverse(Root.Data);
                                    Root.LeftNode.Data.RemoveRange(1, 2);
                                }
                            }
                            else if (DoCompare(value, Root.Data[0]) == Comparet.GREATER)
                            {
                                Root.RightNode.Data.Add(value);
                                Reverse(Root.RightNode.Data);
                                if (Root.RightNode.Data.Count == max)
                                {
                                    if (Root.CenterNode == null)
                                    {
                                        Root.CenterNode = new BalancedTreeNode<T>(Root.RightNode.Data[2]);
                                    }
                                    else
                                    {
                                        Root.CenterNode.Data.Add(Root.RightNode.Data[2]);
                                    }
                                    Root.Data.Add(Root.RightNode.Data[1]);
                                    Reverse(Root.Data);
                                    Root.RightNode.Data.RemoveRange(1, 2);
                                }
                            }
                            else
                            {
                                // Throw Exception
                                throw new Exception("Duplicate value");
                            }
                        }
                    }
                    else
                    {
                        Root.Data.Add(value);
                        Root.Data = Reverse(Root.Data);
                    }
                }
                //else
                //{
                //    if (Root.LeftNode != null && Root.LeftNode != null)
                //    {
                //        // TO-DO
                //        Root.Data.Add(value);
                //        Reverse(Root.Data);
                //        if (Root.CenterNode == null)
                //        {
                //            Root.CenterNode = new BalancedTreeNode<T>(Root.Data[1]);
                //        }
                //        else
                //        {
                //            Root.CenterNode.Data.Add(Root.Data[1]);
                //        }
                //        Reverse(Root.CenterNode.Data);
                //    }
                //    else
                //    {
                //        Root.LeftNode = new BalancedTreeNode<T>(Root.Data[0]);
                //        Root.RightNode = new BalancedTreeNode<T>(Root.Data[2]);
                //        List<T> temp = new List<T>();
                //        temp.Add(Root.Data[1]);
                //        Root.Data = temp;
                //        Add(ref balancedTree, value);
                //    } 
                //}
            }
        }

        public void Print(BalancedTree<T> binaryTree, String pos)
        {
            if (binaryTree.Root.Data != null)
            {
                for (int i = 0; i < binaryTree.Root.Data.Count(); i++)
                {
                    //if (i == 0)
                    //{
                    //    Console.Write("{0} Node: ", pos);
                    //}
                    Console.Write(binaryTree.Root.Data[i] + " ");
                    //if (i == binaryTree.Root.Data.Count() - 1)
                    //{
                    //    Console.WriteLine();
                    //}
                }
                if (binaryTree.Root.LeftNode != null)
                {
                    foreach (var item in binaryTree.Root.LeftNode.Data)
                    {
                        Console.Write(item + " ");
                    }
                }
                if (binaryTree.Root.CenterNode != null)
                {
                    foreach (var item in binaryTree.Root.CenterNode.Data)
                    {
                        Console.Write(item + " ");
                    }
                }
                if (binaryTree.Root.RightNode != null)
                {
                    foreach (var item in binaryTree.Root.RightNode.Data)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }

        public int CountSpace(List<T> list)
        {
            if (list == null)
            {
                return 0;
            }
            return list.Count();
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


        public virtual int height(BalancedTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + Math.Max(height(Root.LeftNode), height(Root.RightNode));
        }
    }
}
