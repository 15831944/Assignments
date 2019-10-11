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
            if (binaryTree.CenterTree == null)
            {
                binaryTree.CenterTree = new BinaryTree<T>(max);
            }

            if (CountSpace(binaryTree.data) == EQUAL_VAL)
            {
                binaryTree.data.Add(value);
            }
            else
            {
                if (CountSpace(binaryTree.data) < max)
                {
                    if (DoCompare(value, binaryTree.data[CountSpace(binaryTree.data)-1]) == Comparet.GREATER)
                    {
                        binaryTree.CenterTree.data.Add(binaryTree.data[CountSpace(binaryTree.data) - 1]);
                        binaryTree.data.RemoveAt(CountSpace(binaryTree.data) - 1);
                        binaryTree.data.Add(value);
                    }
                    else
                    {
                        if (DoCompare(value, binaryTree.data[0]) == Comparet.GREATER)
                        {
                            //binaryTree.LeftTree.data[CountSpace(binaryTree.LeftTree.data) - 1]
                            binaryTree.CenterTree.data.Add(value);
                            binaryTree.LeftTree.data.RemoveAt(CountSpace(binaryTree.LeftTree.data)-1);
                            binaryTree.LeftTree.data.Add(value);
                        }
                        else
                        {
                            binaryTree.CenterTree.data.Add(binaryTree.data[0]);
                            binaryTree.data.RemoveAt(0);
                            binaryTree.data.Insert(0, value);
                        }
                    }
                }
                else
                {
                    // To the Right Tree
                    if (DoCompare(value, binaryTree.data[binaryTree.data.Count - 1]) == Comparet.GREATER || DoCompare(value, binaryTree.data[binaryTree.data.Count - 1]) == Comparet.EQUAL)
                    {
                        if (CountSpace(binaryTree.LeftTree.data) == 0 && CountSpace(binaryTree.RightTree.data) == 0)
                        {
                            if (CountSpace(binaryTree.data) < max)
                            {
                                binaryTree.data.Add(value);
                            }
                            else
                            {
                                Add(ref binaryTree.LeftTree, binaryTree.data[0]);
                                Add(ref binaryTree.RightTree, value);
                                T temp = binaryTree.data[1];
                                binaryTree.data.Clear();
                                binaryTree.data.Add(temp);
                            }
                        }
                        else
                        {
                            if (CountSpace(binaryTree.RightTree.data) < max)
                            {
                                binaryTree.data.Add(value);
                            }
                            else
                            {
                                Add(ref binaryTree.RightTree, value);
                            }
                        }
                    }
                    // To the Left Tree
                    else
                    {
                        if (CountSpace(binaryTree.LeftTree.data) == 0 && CountSpace(binaryTree.RightTree.data) == 0)
                        {
                            if (CountSpace(binaryTree.data) == 1)
                            {
                                binaryTree.data.Add(binaryTree.data[0]);
                                binaryTree.data.RemoveAt(0);
                                binaryTree.data.Insert(0, value);
                            }
                            else
                            {
                                if (DoCompare(value, binaryTree.data[binaryTree.data.Count - 2]) == Comparet.LESSTHAN)
                                {
                                    // check if lefttree not full
                                    if (CountSpace(binaryTree.LeftTree.data) < max)
                                    {
                                        binaryTree.LeftTree.data.Add(value);
                                    }
                                    else
                                    {
                                        binaryTree.LeftTree.LeftTree.data.Add(value);
                                    }
                                    // check if righttree not full
                                    if (CountSpace(binaryTree.RightTree.data) < max)
                                    {
                                        binaryTree.RightTree.data.Add(binaryTree.data[1]);
                                    }
                                    else
                                    {
                                        binaryTree.RightTree.LeftTree.data.Add(binaryTree.data[1]);
                                    }
                                    binaryTree.data.RemoveRange(1, binaryTree.data.Count - 1);
                                }
                                else
                                {
                                    // check if lefttree not full
                                    if (CountSpace(binaryTree.LeftTree.data) < max)
                                    {
                                        binaryTree.LeftTree.data.Add(binaryTree.data[0]);
                                    }
                                    else
                                    {
                                        binaryTree.LeftTree.LeftTree.data.Add(binaryTree.data[0]);
                                    }
                                    // check if righttree not full
                                    if (CountSpace(binaryTree.RightTree.data) < max)
                                    {
                                        binaryTree.RightTree.data.Add(binaryTree.data[1]);
                                    }
                                    else
                                    {
                                        binaryTree.RightTree.LeftTree.data.Add(binaryTree.data[1]);
                                    }
                                    binaryTree.data.Clear();
                                    binaryTree.data.Add(value);
                                }
                            }
                        }
                        else
                        {
                            if (CountSpace(binaryTree.LeftTree.data) < max - 1)
                            {
                                // Number of ele not exceed 2
                                if (DoCompare(binaryTree.LeftTree.data[0], value) == Comparet.LESSTHAN)
                                {
                                    binaryTree.LeftTree.data.Add(value);
                                }
                                else
                                {
                                    binaryTree.LeftTree.data.Add(binaryTree.LeftTree.data[0]);
                                    binaryTree.LeftTree.data.RemoveAt(0);
                                    binaryTree.LeftTree.data.Insert(0, value);
                                }
                            }
                            else
                            {
                                // Number of ele equal 2
                                if (CountSpace(binaryTree.data) < max)
                                {
                                    if (DoCompare(value, binaryTree.LeftTree.data[0]) == Comparet.LESSTHAN)
                                    {
                                        // take [1] index to the root
                                        if (DoCompare(binaryTree.data[0], binaryTree.LeftTree.data[0]) == Comparet.LESSTHAN)
                                        {
                                            binaryTree.data.Add(binaryTree.LeftTree.data[0]);
                                        }
                                        else
                                        {
                                            binaryTree.data.Add(binaryTree.data[0]);
                                            binaryTree.data.RemoveAt(0);
                                            binaryTree.data.Insert(0, binaryTree.LeftTree.data[0]);
                                            binaryTree.LeftTree.data.RemoveAt(0);
                                            binaryTree.LeftTree.data.Insert(0, value);
                                        }
                                    }
                                    else
                                    {
                                        if (DoCompare(value, binaryTree.LeftTree.data[1]) == Comparet.LESSTHAN)
                                        {
                                            // take [1] index to the root
                                            if (DoCompare(binaryTree.data[0], value) == Comparet.LESSTHAN)
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
                                            // take [1] index to the root
                                            if (DoCompare(binaryTree.data[0], binaryTree.LeftTree.data[1]) == Comparet.LESSTHAN)
                                            {
                                                binaryTree.data.Add(binaryTree.LeftTree.data[1]);
                                            }
                                            else
                                            {
                                                binaryTree.data.Add(binaryTree.data[0]);
                                                binaryTree.data.RemoveAt(0);
                                                binaryTree.data.Insert(0, binaryTree.LeftTree.data[1]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (CountSpace(binaryTree.CenterTree.data) < max)
                                    {
                                        if (DoCompare(binaryTree.CenterTree.data[0], value) == Comparet.GREATER || DoCompare(binaryTree.CenterTree.data[0], value) == Comparet.EQUAL)
                                        {
                                            if (DoCompare(binaryTree.CenterTree.data[1], value) == Comparet.GREATER || DoCompare(binaryTree.CenterTree.data[1], value) == Comparet.EQUAL)
                                            {
                                                binaryTree.CenterTree.data.Add(value);
                                            }
                                            else
                                            {
                                                binaryTree.CenterTree.data.Add(binaryTree.CenterTree.data[1]);
                                                binaryTree.CenterTree.data.RemoveAt(1);
                                                binaryTree.CenterTree.data.Insert(1, value);
                                            }
                                        }
                                        else
                                        {
                                            binaryTree.CenterTree.data.Add(binaryTree.CenterTree.data[1]);
                                            binaryTree.CenterTree.data.RemoveAt(1);
                                            binaryTree.CenterTree.data.Insert(1, binaryTree.CenterTree.data[0]);
                                            binaryTree.CenterTree.data.RemoveAt(0);
                                            binaryTree.CenterTree.data.Insert(0, value);
                                        }
                                    }
                                    else
                                    {
                                        // TO _ DO
                                        //if (DoCompare(binaryTree.CenterTree.data[binaryTree.CenterTree.data.Count - 2], value) == Comparet.GREATER || DoCompare(binaryTree.CenterTree.data[binaryTree.CenterTree.data.Count - 2], value) == Comparet.EQUAL)
                                        //{
                                        //    if (DoCompare(binaryTree.CenterTree.data[binaryTree.CenterTree.data.Count - 1], value) == Comparet.LESSTHAN)
                                        //    {

                                        //    }
                                        //    else
                                        //    {

                                        //    }
                                        //}
                                    }
                                }
                            }
                        }
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

            if (binaryTree.CenterTree != null)
            {
                Print(binaryTree.CenterTree, "Center");
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
