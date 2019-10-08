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
            //int[] int_arr = GetRanDomNumList(1000);
            int[] int_arr = { 9, 3, 1, 5, 4, 7, 10, 14, 17 };
            foreach (var val in int_arr)
                address.addAddress(ref address_list, val);
            return address_list;
        }

        // init Address List
        static List<Address> address_list = Create_Address_List();

        static void Main(string[] args)
        {
            /* Quick Sort */
            //Sort<Address> sort = new QuickSort<Address>(address_list);
            //sort.DoSort(Address.DoCompare, 0, address_list.Count() - 1);
            /* END: Quick Sort */

            /* Heap Sort */
            Sort<Address> sort = new HeapSort<Address>(address_list);
            
            /* END: Heap Sort */

            //foreach (var val in sort.GetData(false))
            //    Console.Write(val.address + " ");
            //Console.WriteLine();
            Console.ReadKey();
        }
    }
}
