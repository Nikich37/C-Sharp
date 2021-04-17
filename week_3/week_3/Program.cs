// Написать алгоритм сложения в столбик двух чисел, введённых с консоли, используя массивы.
using System;

namespace week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int first_number = InputNumber();
            int second_number = InputNumber();

            Console.WriteLine(CalculateAndOutputResult(first_number, second_number));
        }
        /// <summary>
        /// Return number entered in console.
        /// </summary>
        /// <returns></returns>
        static int InputNumber()
        {
            Console.WriteLine("Введите число: ");
            string line = Console.ReadLine();
            try
            {
                return int.Parse(line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Можно вводить только целые!");
                return InputNumber();
            }
        }
        /// <summary>
        /// Parsing number to array of digirs.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int[] ParseNumber(int number)
        {
            // вычисляем порядок числа
            int temp = number;
            int order = 1;
            while (temp/10 > 0)
            {
                order++;
                temp /= 10;
            }

            // загоняем цифры числа в массив
            int[] digits = new int[order];
            temp = number;
            for (int i = order - 1; i >= 0; i--)
            {
                digits[i] = temp % 10;
                temp /= 10;
            }
            return digits;
        }
        /// <summary>
        /// Collect digits in array to number.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        static int CollectNumber(int[] digits)
        {
            int number = 0;
            // Проверка на количество нулей в первых знаках массива
            int number_of_first_zero = 0;
            int j = 0;
            while (digits[j] == 0)
            {
                number_of_first_zero++;
                j++;
            }
            for (int i = 0; i < digits.Length; i++)
            {
                number += (int)(digits[i] * Math.Pow(10, (digits.Length - i - number_of_first_zero)));
            }
            return number;
        }
        static int CalculateAndOutputResult(int first_number, int second_number)
        {
            // Парсим числа
            int[] first_array = ParseNumber(first_number);
            int[] second_array = ParseNumber(second_number);
            
            // В первом массиве оставляем число с большим порядком
            if (first_array.Length < second_array.Length)
            {
                int[] temp = first_array;
                first_array = second_array;
                second_array = first_array;
            }

            int[] result = new int[first_array.Length + 1];
            int j = 0; // единичка в уме при переполнении цифры
            // Складываем 
            for (int i = 0; i < second_array.Length; i++)
            {
                result[result.Length - 1 - i] = first_array[first_array.Length - 1 - i]
                    + second_array[second_array.Length - 1 - i] + j;
                j = 0;
                if (result[result.Length - 1 - i] >= 10)
                {
                    result[result.Length - 1 - i] %= 10;
                    j = 1;
                }
            }
            // Переносим старшие разряды, если они есть
            if (first_array.Length > second_array.Length)
            {
                for (int i = 0; i < first_array.Length - second_array.Length; i++)
                {
                    result[first_array.Length - second_array.Length - i] =
                        first_array[first_array.Length - second_array.Length - 1 - i] + j;
                    j = 0;
                }
            }
            // Проверяем самый первый разряд на переполненность
            if (result[1] >= 10)
            {
                result[1] %= 10;
                result[0] = 1;
            }

            return CollectNumber(result);
        }
    }
}
