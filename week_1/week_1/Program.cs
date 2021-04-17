//Посчитать и вывести в консоль данное выражение
using System;

namespace week_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            float x = (float)((6 * 6 - 1) / 2.0);
            Console.WriteLine("Результат вычисления: " + x);
        }
    }
}
