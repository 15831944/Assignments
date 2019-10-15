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
                int_arr = new int[] { 9, 6, 8 }; // , 3, 2, 4, 7, 10, 1, 5 
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
            BalancedTree<int> addressTree = new BalancedTree<int>();
            for(int i = 0; i < listAddress.Count(); i++)
            {
                addressTree.Insert(addressTree.Root, listAddress[i]);
            }

            //addressTree.Print(addressTree.Root, "Parent");

            //Console.WriteLine("Height: " + addressTree.height(addressTree).ToString());
            Console.ReadLine();
        }
    }
}
