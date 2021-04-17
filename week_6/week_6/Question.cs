using System;
using System.Collections.Generic;
using System.Text;

namespace week_6
{
    class Question
    {
        public Question(string text_question, string answer1, string answer2, string answer3,
            string answer4, int correct_answer)
        {
            this.text_question = text_question;
            this.correct_answer = correct_answer;
            string[] answers_strings = new string[4];
            answers_strings[0] = answer1;
            answers_strings[1] = answer2;
            answers_strings[2] = answer3;
            answers_strings[3] = answer4;
            for (int i = 0; i < answers.Length; i++)
            {
                if (i == correct_answer - 1)
                {
                    answers[i] = new CorrectAnswer(answers_strings[i]);
                }
                else
                {
                    answers[i] = new WrongAnswer(answers_strings[i]);
                }
            }
            
            
        }
        public string text_question;
        public Answer[] answers = new Answer[4];
        public int correct_answer;
    }
}
