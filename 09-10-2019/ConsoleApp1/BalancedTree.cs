using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class BalancedTree<T> : Compare<T> where T : IComparable
    {
        public BalancedTreeNode<T> Root;
        public BalancedTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BalancedTreeNode<T>(value);
                Root.Parent = Root;
            }
            else
            {
                BalancedTreeNode<T> Curr = Root;
                do
                {
                    for (; Curr.IsFull(); Curr = GetNextChild(Curr, value))
                    {
                        Split(Curr);
                        Curr = Curr.GetParent();
                    }
                    //Children = new List<BalancedTreeNode<T>>();
                    if (!Curr.IsLeaf() && Curr == Root)
                    {
                        Curr = GetNextChild(Curr, value);
                    }
                    else
                    {
                        Curr.InsertItem(value);
                        Curr.Reverse();
                        return;
                    }
                } while (true);
            }
        }

        public void Split(BalancedTreeNode<T> node)
        {
            //BalancedTreeNode<T> newRoot = new BalancedTreeNode<T>(node.Data[1]);
            //BalancedTreeNode<T>[] newNodes = { };
            //if (node.IsFull())
            //{
            //    if (node == Root)
            //    {
            //        if (node.Children != null && node.Children.Count == 2)
            //        {
            //            BalancedTree<T> balancedTree = new BalancedTree<T>();
            //            balancedTree.Root.Data.Add(node.Data[1]);
            //            BalancedTreeNode<T> firstnode = new BalancedTreeNode<T>(node.Data[0]);
            //            balancedTree.Root.Children.Add(firstnode);
            //            BalancedTreeNode<T> secondnode = new BalancedTreeNode<T>(node.Data[1]);
            //            balancedTree.Root.Children.Add(secondnode);
            //        }
            //        else
            //        {
            //            // change node to Root 17:18
            //            BalancedTreeNode<T> newRight = new BalancedTreeNode<T>(Root.Data[2]);
            //            if (Root.Children == null)
            //            {
            //                Root.Children = new List<BalancedTreeNode<T>>();
            //            }
            //            for (int x = 2; x < Root.Children.Count; x++)
            //            {
            //                if (newRight.Children == null)
            //                {
            //                    newRight.Children = new List<BalancedTreeNode<T>>();
            //                }
            //                newRight.Children.Add(Root.Children[x]);
            //            }

            //            for (int x = Root.Children.Count() - 1; x >= 2; x--)
            //            {
            //                Root.Children.RemoveAt(x);
            //            }

            //            for (int x = 2; x > 0; x--)
            //            {
            //                Root.Data.RemoveAt(x);
            //            }

            //            newNodes = new BalancedTreeNode<T>[] { node, newRight };
            //            newRoot.InsertChild(newNodes[0]);
            //            newRoot.InsertChild(newNodes[1]);
            //            Root = newRoot;
            //            Root.Parent = Root; // 17:47 
            //        }
            //    }
            //    else
            //    {
            //        Root.Data.Add(node.Data[1]);
            //        Root.Reverse();
            //        if (Root.IsFull())
            //        {
            //            Split(Root);
            //        }
            //        Root.Children.Add(Root.Children[1]);
            //        Root.Children.RemoveAt(1);
            //        BalancedTreeNode<T> newNode = new BalancedTreeNode<T>(node.Data[2]);
            //        Root.Children.Insert(1, newNode);
            //        node.Data.RemoveRange(1, 2);

            //        Root.Parent = Root; // 17:47 
            //    }
            //}
            
            if (node.IsFull())
            {
                BalancedTreeNode<T> newNode = new BalancedTreeNode<T>(node.Data[1]);
                if (node.Children == null)
                {
                    node.Children = new List<BalancedTreeNode<T>>();
                }
                for (int x = 2; x < node.Children.Count; x++)
                {
                    newNode.Children.Add(node.Children[x]);
                }
                for (int x = node.Children.Count - 1; x >= 2; x--)
                {
                    node.Children.RemoveAt(x);
                }
                for (int x = 1; x < node.Data.Count; x++)
                {
                    node.Data.RemoveAt(1);
                }
                Root.Children.Add(node);
                Root.Children.Add(newNode);
            }
        }

        public BalancedTreeNode<T> GetNextChild(BalancedTreeNode<T> node, T value)
        {
            if (DoCompare(node.Data[0], value) == Comparet.LESSTHAN)
            {
                if (node.Children == null)
                {
                    node.Children = new List<BalancedTreeNode<T>>();
                    BalancedTreeNode<T> newNode = null;
                    node.Children.Add(newNode);
                }
                node = node.Children[1];
            }
            else if (DoCompare(node.Data[0], value) == Comparet.GREATER)
            {
                if (node.Children == null)
                {
                    node.Children = new List<BalancedTreeNode<T>>();
                    BalancedTreeNode<T> newNode = null;
                    node.Children.Add(newNode);
                }
                node = node.Children[0];
            }
            else
            {
                throw new Exception("Duplicate value");
            }
            return node;
        }

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
    }
}
