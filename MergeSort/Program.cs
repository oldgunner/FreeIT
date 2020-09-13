using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = InitArrayOfRandomValues(15);
            Console.WriteLine($"Unsorted array: {string.Join(", ", arr)}");
            MergeSort(arr);
            Console.WriteLine($"Sorted array: {string.Join(", ", arr)}");

            Console.ReadKey();
        }

        private static void MergeSort(int[] arr)
        {
            var buffer = new int[arr.Length];
            MergeSort(arr, 0, arr.Length - 1, buffer);
        }

        private static void MergeSort(int[] arr, int leftStart, int rightEnd, int[] buffer)
        {
            if (leftStart >= rightEnd)
                return;

            var middle = (leftStart + rightEnd) / 2;
            MergeSort(arr, leftStart, middle, buffer);
            MergeSort(arr, middle + 1, rightEnd, buffer);
            MergeHalves(arr, leftStart, middle, rightEnd, buffer);
        }

        private static void MergeHalves(int[] arr, int leftStart, int middle, int rightEnd, int[] buffer)
        {
            var mergingCurrentIndex = leftStart;
            var leftCurrentIndex = leftStart;
            var rightCurrentIndex = middle + 1;

            while (leftCurrentIndex <= middle && rightCurrentIndex <= rightEnd)
            {
                if (arr[leftCurrentIndex] <= arr[rightCurrentIndex])
                {
                    buffer[mergingCurrentIndex] = arr[leftCurrentIndex];
                    leftCurrentIndex++;
                }
                else
                {
                    buffer[mergingCurrentIndex] = arr[rightCurrentIndex];
                    rightCurrentIndex++;
                }
                mergingCurrentIndex++;
            }
            leftCurrentIndex--;
            rightCurrentIndex--;
            mergingCurrentIndex--;

            var tailOfLeftHalfLength = middle - leftCurrentIndex;
            var tailOfRightHalfLength = rightEnd - rightCurrentIndex;

            if (tailOfLeftHalfLength > 0)
                Array.Copy(arr, leftCurrentIndex + 1, buffer, mergingCurrentIndex + 1, tailOfLeftHalfLength);
            else
                Array.Copy(arr, rightCurrentIndex + 1, buffer, mergingCurrentIndex + 1, tailOfRightHalfLength);

            var size = rightEnd - leftStart + 1;
            Array.Copy(buffer, leftStart, arr, leftStart, size);
        }

        static int[] InitArrayOfRandomValues(int size)
        {
            var array = new int[size];
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(20);

            return array;
        }
    }
}
