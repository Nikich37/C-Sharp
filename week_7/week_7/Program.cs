// Игра "Кто хочет стать миллионером?" с наследованием и сохранением и загрузкой прогресса
using System;
using System.Threading;

namespace week_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Game game = new Game();
            game.PrepareQuestions();
            game.StartGame();
        }
    }
}

