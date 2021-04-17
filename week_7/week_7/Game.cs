using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace week_7
{
    class Game
    {
        Player player;

        int number_of_question;

        int bank;

        public Question[] questions;
        int InputAnswer()
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
        int InputOption()
        {
            string line = Console.ReadLine();
            try
            {
                int answer = int.Parse(line);
                if (answer == 1 || answer == 2)
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("Можно вводить только номер варианта!");
                    return InputAnswer();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Можно вводить только номер варианта!");
                return InputAnswer();
            }
        }
        string InputYesOrNo()
        {
            string line = Console.ReadLine();

            string answer = line;
            if (string.Equals(answer, "да", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(answer, "нет", StringComparison.OrdinalIgnoreCase))
            {
                return answer;
            }
            else
            {
                Console.WriteLine("Можно вводить только да или нет!");
                return InputYesOrNo();
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

            Console.WriteLine("Выбери один из вариантов и введи нужный номер в консоль: ");
            Thread.Sleep(1000);
            Console.WriteLine("1. Начать новую игру");
            Thread.Sleep(1000);
            Console.WriteLine("2. Загрузить сохранённую игру");
            Console.WriteLine();

            int option = InputOption();
            
            if (option == 2) 
            {
                FileInfo file = new FileInfo("data.txt");
                if (file.Exists)
                {
                    LoadGame();
                    Console.WriteLine();
                    Console.WriteLine("Игра успешно загружена!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Сохранённой игры нет!");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Console.WriteLine("Начинаем новую игру!");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    option = 1;
                }
            }
            if (option == 1) {
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
                number_of_question = 0;
            }
            for (int i = number_of_question; i < 3; i++)
            {
                Question question = questions[i];
                Thread.Sleep(3000);
                Console.WriteLine(question.text_question);
                Console.WriteLine();
                Console.WriteLine("Варианты ответа: ");
                foreach (Answer answer in question.answers)
                {
                    Console.WriteLine(answer.answer);
                }
                Console.WriteLine();
                Console.WriteLine("Введи номер правильного ответа: ");
                int player_answer = this.InputAnswer();
                Console.WriteLine();
                if (question.answers[player_answer - 1] is CorrectAnswer)
                {
                    Console.Write("И твой ответ... ");
                    Thread.Sleep(5000);
                    Console.WriteLine("Правильный!");
                    Console.WriteLine();
                    if (number_of_question != 0)
                    {
                        this.bank *= 2;
                    }
                    number_of_question++;
                    if (number_of_question != 3)
                    {
                        Console.WriteLine("Продолжишь играть? (Введи да или нет)");
                        string answer = InputYesOrNo();
                        Console.WriteLine();
                        if (string.Equals(answer, "да", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Хорошо, продолжаем!");
                        }
                        else if (string.Equals(answer, "нет", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Хочешь ли ты забрать выигрыш и закончить игру? (введи да или нет)");
                            answer = InputYesOrNo();
                            Console.WriteLine();
                            if (string.Equals(answer, "да", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Поздравляю, ты выиграл " + this.bank + " долларов!");
                                Thread.Sleep(1000);
                                Console.WriteLine("Игра окончена!");
                                Thread.Sleep(3000);
                                return;
                            }
                            else if (string.Equals(answer, "нет", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Хочешь ли ты сохранить игру? (введи да или нет)");
                                answer = InputYesOrNo();
                                Console.WriteLine();
                                if (string.Equals(answer, "да", StringComparison.OrdinalIgnoreCase))
                                {
                                    SaveGame(player.name, number_of_question);
                                    Console.WriteLine("Игра успешно сохранена!");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Пока, " + player.name + "!");
                                    Thread.Sleep(3000);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Игра окончена.");
                                }

                            }
                                
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
        void SaveGame(string name, int number_of_question)
        {
            FileInfo file = new FileInfo("data.txt");
            if (file.Exists)
            {
                file.Delete();
            }

            FileStream data = file.OpenWrite();
            StreamWriter writer = new StreamWriter(data, Encoding.Unicode);

            writer.WriteLine(name);
            writer.WriteLine(number_of_question);
            writer.Close();
        }
        void LoadGame()
        {
            FileInfo file = new FileInfo("data.txt");

            FileStream data = file.OpenRead();
            StreamReader reader = new StreamReader(data, Encoding.Unicode);

            player = new Player(reader.ReadLine());
            number_of_question = int.Parse(reader.ReadLine());
            bank = (int)(100 * Math.Pow(2, number_of_question));

            reader.Dispose();
        }
    }
}
