using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace week_6
{
    class Game
    {
        public Player player;
        public int bank;
        public Question[] questions;
        public int InputAnswer()
        {
            string line = Console.ReadLine();
            try
            {
                int answer = int.Parse(line);
                if (answer == 1 || answer == 2 || answer == 3 || answer == 4)
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("Можно вводить только варианты ответа!");
                    return InputAnswer();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Можно вводить только варианты ответа!");
                return InputAnswer();
            }
        }
        public void PrepareQuestions()
        {
            this.questions = new Question[3];
            this.questions[0] = new Question("Итак, первый вопрос: какая часть света самая высокая?",
                "1. Австралия", "2. Азия", "3. Америка", "4. Европа", 2);
            this.questions[1] = new Question("Перейдём ко второму вопросу: " +
                "О каких минералах говорят «Воды боится, а из воды родится?»",
                "1. Щелочь", "2. Кислота", "3. Сахар", "4. Спирт", 1);
            this.questions[2] = new Question("Финальный вопрос! У какой планеты в Солнечной системе " +
                "всего два естественных спутника?",
                "1. Юпитер", "2. Венера", "3. Земля", "4. Марс", 4);
        }
        public void StartGame()
        {
            Console.WriteLine("Это игра 'Кто хочет стать миллионером?'!");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Для начала, введи своё имя: ");
            this.player = new Player(Console.ReadLine());
            Console.WriteLine("Привет, " + this.player.name + "!");
            Console.WriteLine();

            Thread.Sleep(3000);
            Console.WriteLine("Вот наши правила:");
            Console.WriteLine("1. Тебе задаётся вопрос и даётся четыре варианта ответа. " +
                "Твоя задача ввести номер правильного ответа в консоль!");
            Thread.Sleep(2000);
            Console.WriteLine("2. За правильный ответ на первый вопрос тебе в банк начисляется 100$");
            Thread.Sleep(2000);
            Console.WriteLine("3. За каждый последующий правильный ответ сумма в банке удваивается!");
            Thread.Sleep(2000);
            Console.WriteLine("4. Если ты ответишь неправильно, то твой банк обнулится и игра закончится! ");
            Thread.Sleep(2000);
            Console.WriteLine("5. После каждого правильного ответа ты можешь либо продолжить игру, либо закончить " +
                "и забрать деньги из банка!");
            Thread.Sleep(2000);
            Console.WriteLine("Удачи");

            Console.WriteLine();
            Console.WriteLine();

            this.bank = 100;
            int number_of_question = 1;
            foreach (Question question in questions)
            {
                Thread.Sleep(3000);
                Console.WriteLine(question.text_question);
                Console.WriteLine();
                Console.WriteLine("Варианты ответа: ");
                foreach (Answer answer in question.answers)
                {
                    Console.WriteLine(answer.answer);
                }
                Console.WriteLine();
                Console.WriteLine("Введите номер правильного ответа: ");
                int player_answer = this.InputAnswer();
                Console.WriteLine();
                if (question.answers[player_answer - 1] is CorrectAnswer)
                {
                    Console.Write("И твой ответ... ");
                    Thread.Sleep(5000);
                    Console.WriteLine("Правильный!");
                    Console.WriteLine();
                    if (number_of_question != 1)
                    {
                        this.bank *= 2;
                    }
                    number_of_question++;
                    if (number_of_question != 4)
                    {
                        Console.WriteLine("Продолжишь играть? (Введи да или нет)");
                        string answer = Console.ReadLine();
                        Console.WriteLine();
                        if (string.Equals(answer, "да", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Хорошо, продолжаем!");
                        }
                        else if (string.Equals(answer, "нет", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Поздравляю, ты выиграл " + this.bank + " долларов!");
                            Thread.Sleep(1000);
                            Console.WriteLine("Игра окончена!");
                            Thread.Sleep(3000);
                            return;
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    this.bank = 0;
                    Console.Write("И твой ответ... ");
                    Thread.Sleep(5000);
                    Console.WriteLine("Неправильный!");
                    Thread.Sleep(3000);
                    Console.WriteLine("К сожалению, ты проиграл и ничего не выиграл... ");
                    Thread.Sleep(1000);
                    Console.WriteLine("Игра окончена! Пока, " + this.player.name + ".");
                    Thread.Sleep(3000);
                    return;

                }
            }
            Console.WriteLine();
            Console.WriteLine("Ты ответил на все вопросы!");
            Thread.Sleep(3000);
            Console.WriteLine("Твой выигрыш составляет: " + this.bank + " долларов!");
            Thread.Sleep(3000);
            Console.WriteLine("Игра окончена! Пока, " + this.player.name + "!");
            Thread.Sleep(3000);
        }
    }
}
