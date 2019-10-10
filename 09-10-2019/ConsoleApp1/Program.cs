using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
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
                //int_arr = new int[] { 9, 3, 1, 5, 4, 7 };//4, 7, 10, 14, 17 };
                int_arr = new int[] { 9, 6, 8, 3, 2 }; //, 2, 4
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
            BinaryTree<int> addressTree = new BinaryTree<int>(3);
            for(int i = 0; i < listAddress.Count(); i++)
            {
                addressTree.Add(ref addressTree, listAddress[i]);
            }
            addressTree.Print(addressTree, "Parent");

            //Console.WriteLine("Height: " + addressTree.height(addressTree).ToString());
            Console.ReadLine();
        }
    }
}
