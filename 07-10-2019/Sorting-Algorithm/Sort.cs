using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm
{
    public abstract class Sort<T>
    {
        public List<T> data = null;
        public static int EQUAL_VAL = 0;
        public enum COMPARET
        {
            EQUAL,
            GREATER,
            LESSTHAN
        }
        public Sort(List<T> input_list)
        {
            this.data = input_list;
        }

        public delegate COMPARET Compare(T t1, T t2);

        public abstract void DoCompare(Compare cmp_func, int left, int right);

        public abstract void DoSort(Compare cmp_func, int low, int high);

        public List<T> GetData(bool acs)
        {
            List<T> list = data;
            if (acs)
                list.Reverse();
            return list;
        }
    }

    public class QuickSort<T> : Sort<T>
    {
        public QuickSort(List<T> list) : base(list) {}
        public override void DoCompare(Compare cmp_func, int left, int right)
        {
            int i = left;
            int j = right;
            int mid = (left + right) / 2;
            T pivot = data[mid];
            T temp;
            if (left >= right || data == null)
                return;
            while (i <= j)
            {
                while (cmp_func(data[i], pivot) == COMPARET.LESSTHAN)
                    i++;
                while (cmp_func(data[j], pivot) == COMPARET.GREATER)
                    j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
                DoCompare(cmp_func, left, j);
            if (right > i)
                DoCompare(cmp_func, i, right);
        }
        public override void DoSort(Compare cmp_func, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(cmp_func, left, right);

                if (pivot > 1)
                {
                    DoSort(cmp_func, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    DoSort(cmp_func, pivot + 1, right);
                }
            }
        }
        public int Partition(Compare cmp_func, int left, int right)
        {
            int mid = (left + right) / 2;
            T pivot = data[mid];
            while (true)
            {
                while (cmp_func(data[left], pivot) == COMPARET.LESSTHAN)
                {
                    left++;
                }

                while (cmp_func(data[right], pivot) == COMPARET.GREATER)
                {
                    right--;
                }

                if (left < right)
                {
                    if (cmp_func(data[left], data[right]) == COMPARET.EQUAL)
                    {
                        return right;
                    }
                    T temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }

    public class HeapSort<T> : Sort<T>
    {
        int arrSize;
        public HeapSort(List<T> list) : base(list)
        {
            arrSize = list.Count();
            data = list;
        }
        //public HeapSort()
        //{
        //    arrSize = 0;
        //    eleCount = 0;
        //    arr = new int[arrSize];
        //}

        public void BuildMaxHeap(ref List<T> list, Compare cmp_func)
        {
            for (int i = arrSize / 2 - 1; i >= 0; i--)
            {
                Heapify(ref list, arrSize, i, cmp_func);
            }

            for (int i = arrSize - 1; i >= 0; i--)
            {
                T temp = list[0];
                list[0] = list[i];
                list[i] = temp;
                Heapify(ref list, i, 0, cmp_func);
            }
        }

        public void Heapify(ref List<T> list, int n, int i, Compare cmp_func)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && cmp_func(list[left], list[largest]) == Sort<T>.COMPARET.GREATER)
            {
                largest = left;
            }
            if (right < n && cmp_func(list[right], list[largest]) == Sort<T>.COMPARET.GREATER)
            {
                largest = right;
            }
            if (largest != i)
            {
                T temp = list[i];
                list[i] = list[largest];
                list[largest] = temp;
                Heapify(ref list, n, largest, cmp_func);
            }
        }

        //public bool Add(T value)
        //{
        //    if (eleCount == arr.Length)
        //    {
        //        return false;
        //    }

        //    arr[arrSize] = value;
        //    return true;
        //}

        public override void DoCompare(Compare cmp_func, int left, int right)
        {
            throw new NotImplementedException();
        }

        public override void DoSort(Compare cmp_func, int low, int high)
        {
            throw new NotImplementedException();
        }
    }
}
