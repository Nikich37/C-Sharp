// Игра "Кто хочет стать миллионером?" с наследованием
using System;
using System.Threading;

namespace week_6
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

