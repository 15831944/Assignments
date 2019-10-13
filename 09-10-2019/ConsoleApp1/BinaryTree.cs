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
            if (binaryTree == null)
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
                binaryTree.data.Add(value);
            }
            else
            {

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
