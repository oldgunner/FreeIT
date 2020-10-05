using System;

namespace Week7_HomeTask
{
    class CorrectAnswer : Answer
    {
        public CorrectAnswer(string text) : base(text)
        {
        }

        public override void CheckAnswers()
        {
            Console.WriteLine("{0}Вы ответили правильно!", Environment.NewLine);
        }
    }

}