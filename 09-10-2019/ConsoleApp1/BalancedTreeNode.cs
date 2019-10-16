using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BalancedTreeNode<T> : Compare<T> where T : IComparable
    {
        public List<T> Data { get; set; } // Keys
        public List<BalancedTreeNode<T>> Children { get; set; } // SubTree
        public BalancedTreeNode<T> Parent; // Root
        public int max = 3; // max storage of node
        public BalancedTreeNode(T value)
        {
            Data = new List<T>(); // init Key
            Data.Add(value); // add value to Key
        }
        public void InsertChild(BalancedTreeNode<T> node)
        {
            if (Children == null)
            {
                Children = new List<BalancedTreeNode<T>>();
            }
            for (int x = 0; x < Children.Count; x++)
            {
                if (DoCompare(Children[x].Data[0], node.Data[0]) == Comparet.GREATER)
                {
                    Children.Insert(x, node);
                    return;
                }
            }

            Children.Add(node);
            node.Parent = this;
        }


        public bool IsFull()
        {
            if (CountSpace() == max)
            {
                return true;
            }
            return false;
        }

        public int CountSpace()
        {
            if (Data == null)
            {
                return 0;
            }
            return Data.Count();
        }

        public bool IsLeaf()
        {
            if (Parent == null)
            {
                return false;
            }
            if (Children == null)
            {
                return true;
            }
            else
            {
                if (Children.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public BalancedTreeNode<T> GetParent()
        {
            return Parent;
        }

        public void InsertItem(T value)
        {
            Data.Add(value);
        }

        public List<T> Reverse()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                for (int j = i + 1; j < Data.Count; j++)
                {
                    if (DoCompare(Data[i], Data[j]) == Comparet.GREATER)
                    {
                        T temp = Data[i];
                        Data[i] = Data[j];
                        Data[j] = temp;
                    }
                }
            }
            return Data;
        }
    }
}
