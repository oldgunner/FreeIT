using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = InitArrayOfRandomValues(10);
            Console.WriteLine($"Unsorted array: {string.Join(", ", arr)}");
            QuickSort(arr);
            Console.WriteLine($"Sorted array: {string.Join(", ", arr)}");

            Console.ReadKey();
        }

        private static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            var pivotLocation = ChoosePivotLocation(arr, leftStart, rightEnd);
            pivotLocation = OrderItemsAroundPivot(arr, leftStart, pivotLocation, rightEnd);
            QuickSort(arr, leftStart, pivotLocation - 1);
            QuickSort(arr, pivotLocation + 1, rightEnd);

        }

        private static int OrderItemsAroundPivot(int[] arr, int leftStart, int pivotLocation, int rightEnd)
        {
            var pivot = arr[pivotLocation];
            Swap(arr, pivotLocation, rightEnd);
            var leftIndex = leftStart;
            var rightIndex = rightEnd - 1;
            while (leftIndex <= rightIndex)
            {
                if (arr[leftIndex] <= pivot)
                {
                    leftIndex++;
                    continue;
                }

                if (arr[rightIndex] >= pivot)
                {
                    rightIndex--;
                    continue;
                }

                Swap(arr, leftIndex, rightIndex);
            }

            Swap(arr, rightEnd, leftIndex);
            return leftIndex;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static int ChoosePivotLocation(int[] arr, int leftStart, int rightEnd)
        {
            return leftStart + (rightEnd - leftStart) / 2;
        }

        static int[] InitArrayOfRandomValues(int size)
        {
            var array = new int[size];
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(10);

            return array;
        }
    }
}
