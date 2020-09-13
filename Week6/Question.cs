using System;
using System.Collections.Generic;
using System.Text;

namespace Week6
{
    class Game
    {

    }
    class User
    {

    }
    class Score
    {

    }
    class Question
    {
        public string QuestionText;
        public Answer[] Answers;
    }
    abstract class Answer
    {
        public Answer(string answer) =>
            this.AnswersText = answer;

        public string AnswersText;
        public abstract void Choose();
    }

    class CorrectAnswer : Answer
    {
        public CorrectAnswer(string answer) : base(answer) { }

        public override void Choose() =>
            Console.WriteLine("This is a correct answer");
    }
    class WrongAnswer : Answer
    {
        public WrongAnswer(string answer) : base(answer) { }

        public override void Choose() =>
            Console.WriteLine("This is a wrong answer");
    }
}
