// Написать калькулятор с операциями "+", "-", "?", "/" и обработать всевозможные исключения.
using System;

namespace week_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            double first_number = InputNumber();
            char operation = InputOperation();
            double second_number = InputNumber();

            CalculateAndOutputResult(first_number, operation, second_number);
        }
        static double InputNumber()
        {
            Console.WriteLine("Введите число: ");
            string line = Console.ReadLine();
            try
            {
                return double.Parse(line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Можно вводить только целые и дробные числа!");
                return InputNumber();
            }
        }
        static char InputOperation()
        {
            Console.WriteLine("Введите операцию: ");
            char operation = (char)Console.Read();
            Console.ReadLine();
            if (operation != '+' && operation != '-' && operation != '*' &&
                operation != '/')
            {
                Console.WriteLine("Нужно ввести одну из четырёх операций: '+', '-', '*', '/'");
                return InputOperation();
            }
            else { return operation; }
        }
        static void CalculateAndOutputResult(double first_number, char operation, double second_number)
        {
            double result = 0;
            if (operation == '+') { result = first_number + second_number; }
            else if (operation == '-') { result = first_number - second_number; }
            else if (operation == '*') { result = first_number * second_number; }
            else if (operation == '/') { result = first_number / second_number; }
            else
            {
                Console.WriteLine("Недопустимая операция!");
                return;
            }
            Console.WriteLine("Результат: " + 
                first_number + ' ' + operation + ' ' + second_number + " = " 
                + result);
        }
    }
}
