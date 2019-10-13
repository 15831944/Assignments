using System;
using DataStructures;

namespace BinaryTreeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> b = new BinaryTree<int>();

            b.Insert(5);
            b.Insert(4);
            b.Insert(3);
            b.Insert(2);
            b.Insert(1);
            b.Insert(7);
            b.Insert(6);
            b.Insert(8);
            b.Insert(9);
            b.Insert(10);

            //Console.Write("In Order:");
            //foreach( BinaryTreeNode<int> node in b.InOrder())
            //{
            //            Console.Write(node.Data + " ");
            //}

            //Console.WriteLine();
            //Console.Write("Pre Order:");
            //foreach (BinaryTreeNode<int> node in b.PreOrder())
            //{
            //    Console.Write(node.Data + " ");
            //}

            //Console.WriteLine();

            //Console.Write("Post Order:");
            //foreach (BinaryTreeNode<int> node in b.PostOrder())
            //{
            //    Console.Write(node.Data + " ");
            //}
            b.BalanceTree();

            Console.WriteLine();
            Console.Write("Breadth First Traversal:");
            foreach (BinaryTreeNode<int> node in b.BreadthFirstTraversal())
            {
                Console.Write(node.Data + " ");
            }

            b.BalanceTree();
            b.Delete(6, true);

            Console.WriteLine();
            Console.Write("Breadth First Traversal:");
            foreach (BinaryTreeNode<int> node in b.BreadthFirstTraversal())
            {
                Console.Write(node.Data + " ");
            }

            //Console.WriteLine();
            //Console.Write("Depth First Traversal");
            //foreach (BinaryTreeNode<int> node in b.DepthFirstTraversal())
            //{
            //    Console.Write(node.Data + " ");
            //}

            //b.BalanceTree();

            //Console.WriteLine();
            //Console.Write("Breadth First Traversal Again");
            //foreach (BinaryTreeNode<int> node in b.BreadthFirstTraversal())
            //{
            //    Console.Write(node.Data + " ");
            //}

            Console.ReadLine();
        }
    }
}
