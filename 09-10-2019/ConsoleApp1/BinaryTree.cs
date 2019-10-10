using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class BinaryTree<T> : Compare<T> where T : IComparable
    {
        public List<T> data;
        public int max = 0; // max storage of node
        public BinaryTree<T> LeftTree;
        public BinaryTree<T> RightTree;
        public BinaryTree<T> CenterTree;

        public BinaryTree(int max)
        {
            //Parent = new BinaryTree<T>(value);
            this.max = max;
            data = new List<T>();
        }
        public void Add(ref BinaryTree<T> binaryTree, T value)
        {
            if (binaryTree.LeftTree == null)
            {
                binaryTree.LeftTree = new BinaryTree<T>(max);
            }
            if (binaryTree.RightTree == null)
            {
                binaryTree.RightTree = new BinaryTree<T>(max);
            }
            if (CountSpace(binaryTree.data) == EQUAL_VAL)
            {
                binaryTree.data.Add(value);
            }
            else
            {
                if (CountSpace(binaryTree.LeftTree.data) < max && CountSpace(binaryTree.RightTree.data) < max)
                {
                    if (CountSpace(binaryTree.data) < max - 1)
                    {
                        if (DoCompare(value, binaryTree.data[0]) == Comparet.GREATER || DoCompare(value, binaryTree.data[0]) == Comparet.EQUAL)
                        {
                            binaryTree.data.Add(value);
                        }
                        else
                        {
                            binaryTree.data.Add(binaryTree.data[0]);
                            binaryTree.data.RemoveAt(0);
                            binaryTree.data.Insert(0, value);
                        }
                    }
                    else
                    {
                        if (DoCompare(value, binaryTree.data[1]) == Comparet.GREATER || DoCompare(value, binaryTree.data[1]) == Comparet.EQUAL)
                        {
                            binaryTree.LeftTree.data = new List<T>(max);
                            binaryTree.RightTree.data = new List<T>(max);
                            binaryTree.CenterTree.data = new List<T>(max);
                            if (CountSpace(binaryTree.LeftTree.data) < max)
                            {
                                binaryTree.LeftTree.data.Add(binaryTree.data[0]);
                                binaryTree.RightTree.data.Add(value);
                                T temp = binaryTree.data[1];
                                binaryTree.data.Clear();
                                binaryTree.data.Add(temp);
                            }
                            else
                            {
                                Add(ref binaryTree.LeftTree.LeftTree, value);
                            }
                        }
                        else
                        {
                            if (CountSpace(binaryTree.RightTree.data) < max)
                            {
                                binaryTree.RightTree.data.Add(binaryTree.data[1]);
                                if (DoCompare(value, binaryTree.data[0]) == Comparet.LESSTHAN)
                                {
                                    binaryTree.data.RemoveAt(1);
                                    binaryTree.LeftTree.data.Add(value);
                                }
                                else
                                {
                                    binaryTree.LeftTree.data.Add(binaryTree.data[0]);
                                    binaryTree.data.Clear();
                                    binaryTree.data.Add(value);
                                }
                            }
                            else
                            {
                                Add(ref binaryTree.RightTree, value);
                            }
                        }
                    }
                }
                else
                {
                    if (DoCompare(value, binaryTree.data[binaryTree.data.Count() - 1]) == Comparet.GREATER || DoCompare(value, binaryTree.data[binaryTree.data.Count() - 1]) == Comparet.EQUAL)
                    {
                        Add(ref binaryTree.RightTree, value);
                    }
                    else
                    {
                        Add(ref binaryTree.LeftTree, value);
                    }
                }
            }
        }

        public void Print(BinaryTree<T> binaryTree, String pos)
        {
            if (binaryTree.data != null)
            {
                for (int i = 0; i < binaryTree.data.Count(); i++)
                {
                    if (i == 0)
                    {
                        Console.Write("{0} Node: ", pos);
                    }
                    Console.Write(binaryTree.data[i] + " ");
                    if (i == binaryTree.data.Count() - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            if (binaryTree.LeftTree != null)
            {
                Print(binaryTree.LeftTree, "Left");
            }
            
            if (binaryTree.RightTree != null)
            {
                Print(binaryTree.RightTree, "Right");
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

        public virtual int height(BinaryTree<T> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return 1 + Math.Max(height(tree.LeftTree), height(tree.RightTree));
        }
    }
}
