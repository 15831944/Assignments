using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Compare<T> where T : IComparable
    {
        public static int EQUAL_VAL = 0;
        public enum Comparet
        {
            GREATER,
            LESSTHAN,
            EQUAL
        }
        public static Comparet DoCompare(T t1, T t2)
        {
            if (t1.CompareTo(t2) > EQUAL_VAL)
            {
                return Comparet.GREATER;
            }
            else if (t1.CompareTo(t2) < EQUAL_VAL)
            {
                return Comparet.LESSTHAN;
            }
            return Comparet.EQUAL;
        }

        public static bool CompareToZero(T t1)
        {
            bool result = false;
            if (t1.CompareTo(0) == EQUAL_VAL)
            {
                result = true;
            }
            return result;
        }
        public static bool CompareToNull(T t1)
        {
            bool result = false;
            if (t1 != null)
            {
                result = true;
            }
            return result;
        }
    }
}
