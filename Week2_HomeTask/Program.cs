using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_HomeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Учебная программа-калькулятор");
            Calculate();
            Console.ReadLine();
        }

        static string GetUserOperationInput(string userInput)
        {
            Console.WriteLine(userInput);
            string operation = Console.ReadLine();
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                return operation;
            else
                return GetUserOperationInput("Введите одну из четырёх операций: +, -, *, /.");
        }

        static double GetUserOperandInput(string userInput)
        {
            Console.WriteLine(userInput);
            string op = Console.ReadLine();
            try
            {
                return double.Parse(op);
            }
            catch (FormatException)
            {
                Console.WriteLine("Можно ввести любые цифры, и никак иначе!");
                return GetUserOperandInput(userInput);
            }
        }

        static void Calculate()
        {
            double result = 0;

            double value1 = GetUserOperandInput("Введите первый операнд, отделяя целую и дробную часть запятой: ");
            string op = GetUserOperationInput("Введите символ операции: ");
            double value2 = GetUserOperandInput("Введите второй операнд, отделяя целую и дробную часть запятой: ");

            switch (op)
            {
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 + value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "/":
                    result = value1 / value2;
                    break;
            }
            Console.WriteLine("Результат вычислений " + value1 + " " + op + " " + value2 + " равен " + result);
        }
    }
}
