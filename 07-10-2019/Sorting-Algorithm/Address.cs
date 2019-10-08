using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm
{
    public class Address
    {
        public int address { get; set; }
        public void addAddress(ref List<Address> list, int add_val)
        {
            list.Add(new Address() { address = add_val });
        }

        public static Sort<Address>.COMPARET DoCompare(Address t1, Address t2)
        {
            if (t1.address.CompareTo(t2.address) > Sort<Address>.EQUAL_VAL)
                return Sort<Address>.COMPARET.GREATER;
            else if (t1.address.CompareTo(t2.address) < Sort<Address>.EQUAL_VAL)
                return Sort<Address>.COMPARET.LESSTHAN;
            else
                return Sort<Address>.COMPARET.EQUAL;
        }
    }
}
