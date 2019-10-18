using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm
{
    class Program
    {
        static int[] GetRanDomNumList(int max)
        {
            Random random = new Random();
            int[] int_arr = new int[max];
            for (int i = 0; i < max; i++)
            {
                int_arr[i] = random.Next(10,max);
            }
            return int_arr;
        }
        static List<Address> Create_Address_List()
        {
            List<Address> address_list = new List<Address>();
            Address address = new Address();
            //int[] int_arr = GetRanDomNumList(1000000);
            int[] int_arr = { 19, 20, 8, 15, 1, 3, 13, 7, 11, 17, 16, 10, 5, 9, 14, 18, 2, 4, 12, 6 };
            foreach (var val in int_arr)
                address.addAddress(ref address_list, val);
            return address_list;
        }

        // init Address List
        static List<Address> address_list = Create_Address_List();

        static void Main(string[] args)
        {
            HeapSort<Address> heapsort = new HeapSort<Address>(address_list);
            heapsort.BuildMaxHeap(ref address_list, Address.DoCompare);

            foreach (var val in heapsort.GetData(false))
                Console.Write(val.address + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
