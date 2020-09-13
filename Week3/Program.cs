using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] myArray = new int[5];
            //myArray[0] = -13;
            //myArray[1] = 3;
            //myArray[2] = 23;
            //myArray[3] = 0;
            //myArray[4] = -17;

            //SelectionSort(myArray);

            //FindMaxValue(myArray);
            //ForLoop(myArray);
            //WhileLoop(myArray);
            //DoWhileLoop(myArray);
            //ForeachLoop(myArray);
        }

        static int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int currentMinIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if(arr[j] < arr[currentMinIndex])
                    {
                        currentMinIndex = j;
                    }                    
                }
                int temp = arr[i];
                arr[i] = arr[currentMinIndex];
                arr[currentMinIndex] = temp;
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            return arr;
        }

        static void FindMaxValue(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }
            Console.WriteLine(max);
        }

        static void ForeachLoop(int[] arr)
        {
            foreach (var value in arr)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        static void DoWhileLoop(int[] arr)
        {
            int i = 0;
            do
            {
                Console.Write(arr[i] + " ");
                i++;
            } while (i < arr.Length);
            Console.WriteLine();
        }

        static void WhileLoop(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                Console.Write(arr[i] + " ");
                i++;
            }
            Console.WriteLine();
        }

        static void ForLoop(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
