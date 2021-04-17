using System;
using System.Collections.Generic;
using System.Text;

namespace week_6
{
    abstract class Answer
    {
        public Answer(string answer)
        {
            this.answer = answer;
        }
        public string answer;
    }

    class CorrectAnswer : Answer
    {
        public CorrectAnswer(string answer) : base(answer) { }
    }

    class WrongAnswer : Answer
    {
        public WrongAnswer(string answer) : base(answer) { }
    }
}
