using System;

namespace Hello_world_
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 byte or 8 bit
            bool is_correct = true;
            bool is_not_correct = false;

            // 1 byte or 8 bit
            byte up_to_255 = 255;

            // 2 byte or 16 bit
            short up_to_32767 = 32767;
            ushort up_to_65635 = 65000;

            // 4 byte or 32 bit
            // from -2^31 to 2^31-1
            int color_code;
            int age = 32;

            uint up_to_4294967295;

            // 8 byte or 64 bit
            long up_to_OMG = 2 ^ 63;
            ulong up_to_OMG2 = 2 ^ 64;

            // 4 byte or 32 bit
            //-3.4^38 to 3.4^38
            float float_;

            //8 byte or 64 bit
            double double_float;

            // 16 byte or 128 bit
            decimal for_economic;

            // char ang string
            // 2 byte
            char my_char;
            string my_string;

            //time 
            DateTime current_date;

            // arifmetic operation

            int number_of_apples = 30;
            int children_ate_apples = 15;
            int apples_total = number_of_apples - children_ate_apples;
            // * and / and + and %

            //strings 

            string message = "Hello";
            string message2 = " World!";
            string.Equals(message, message2, StringComparison.OrdinalIgnoreCase);
            string message3 = message + message2;

            int number = 10 / 3; // number = 3
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(message3);

            int[] my_numbers = new int[5];
            int size = my_numbers.Length;

            foreach (int value in my_numbers) { }
        }
    }
}
