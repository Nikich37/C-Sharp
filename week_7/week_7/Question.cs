using System;
using System.Collections.Generic;
using System.Text;

namespace week_7
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

        string text_question_;
        public string text_question
        {
            private set
            {
                this.text_question_ = value;
            }
            get
            {
                return this.text_question_;
            }
        }

        Answer[] answers_ = new Answer[4];
        public Answer[] answers
        {
            set
            {
                this.answers = value;
            }
            get
            {
                return answers_;
            }
        }

        int correct_answer_;
        public int correct_answer
        {
            private set
            {
                this.correct_answer_ = value;
            }
            get
            {
                return correct_answer_;
            }
        }
    }
}
