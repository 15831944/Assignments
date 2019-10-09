using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Sort<T>
    {
        public List<T> data = null;

        public Sort(List<T> l)
        {
            data = l;
        }

        public List<T> GetData(bool acs)
        {
            List<T> ret = data;
            if (!acs)
                ret.Reverse();

            return ret;
        }

        public enum CompareRet
        {
            kGREATER,
            kEQUAL,
            kLESSTHAN
        }

        public static int COMPARE_EQUAL_VAL = 0;

        public delegate CompareRet Compare(T dt1, T dt2);

        public abstract void DoSort(Compare cmp_func);
        public abstract List<T> DoSort(Compare cmp_func, List<T> T);

    }

    class BubbleSort<T> : Sort<T>
    {
        public BubbleSort(List<T> l) : base(l) { }

        public override void DoSort(Compare cmpfunc)
        {
            T curr;
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = i + 1; j < data.Count(); j++)
                {
                    if (cmpfunc(data[i], data[j]) == CompareRet.kGREATER)
                    {
                        curr = data[i];
                        data[i] = data[j];
                        data[j] = curr;
                    }
                }
            }
        }

        public override List<T> DoSort(Compare cmp_func, List<T> T)
        {
            throw new NotImplementedException();
        }
    }

    class QuickSort<T> : Sort<T>
    {
        public QuickSort(List<T> l) : base(l) { }

        public override void DoSort(Compare cmp_func)
        {
            List<T> _left = new List<T>();
            List<T> _right = new List<T>();

            if (data.Count > 1)
            {
                T pivot = data[data.Count - 1];
                data.RemoveAt(data.Count - 1);

                foreach (T each in data)
                {
                    if (cmp_func(each, pivot) == CompareRet.kGREATER)
                    {
                        _right.Add(each);
                    }
                    else
                    {
                        _left.Add(each);
                    }
                }
                data = MergeList(DoSort(cmp_func, _left), pivot, DoSort(cmp_func, _right));
            }
        }

        private static List<T> MergeList(List<T> left, T pivot, List<T> right)
        {
            left.Add(pivot);
            left.AddRange(right);
            return left;
        }

        public override List<T> DoSort(Compare cmp_func, List<T> T)
        {
            throw new NotImplementedException();
        }
    }
}
