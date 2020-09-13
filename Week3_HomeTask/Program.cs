using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int[] result = ArrayColumnAddition();
            Print(result);
            Console.ReadLine();
        }

        static int[] ArrayColumnAddition()
        {
            int value1 = GetUserInput("Введите первое число:");
            int value2 = GetUserInput("Введите второе число:");
            int[] arrayOfDigits1 = DivisionNumber(value1);
            int[] arrayOfDigits2 = DivisionNumber(value2);
            return ColumnAddition(arrayOfDigits1, arrayOfDigits2);
        }
        static int GetUserInput(string userInput)
        {
            Console.WriteLine(userInput);
            string str = Console.ReadLine();
            try
            {
                return int.Parse(str);
            }
            catch (Exception)
            {
                Console.WriteLine("Нужно ввести положительные целые цифры, и никак иначе!");
                return GetUserInput(userInput);
            }
        }
        static int[] DivisionNumber(int value)
        {
            int[] array = new int[value.ToString().Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value % 10;
                value /= 10;
            }
            return array;
        }
        static int[] ColumnAddition(int[] arrayOfDigits1, int[] arrayOfDigits2)
        {
            var length = (arrayOfDigits1.Length > arrayOfDigits2.Length) ? arrayOfDigits1.Length : arrayOfDigits2.Length;

            int[] array = new int[length + 1];
            array[0] = 0;
            Array.Resize(ref arrayOfDigits1, length + 1);
            Array.Resize(ref arrayOfDigits2, length + 1);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[length--] = arrayOfDigits1[i] + arrayOfDigits2[i];
                for (int j = 0; j <= array.Length - 1; j++)
                {
                    if (array[j] > 9)
                    {
                        array[j] %= 10;
                        array[j + 1] += 1;
                    }
                }
            }

            Array.Reverse(array);

            if (array[0] == 0)
                array = array.Skip(1).ToArray();

            return array;
        }
        static void Print(int[] result)
        {
            Console.Write("Результат сложения введённых чисел равен ");
            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}