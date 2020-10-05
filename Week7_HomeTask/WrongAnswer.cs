﻿using System;

namespace Week7_HomeTask
{
    class WrongAnswer : Answer
    {
        public WrongAnswer(string text) : base(text)
        {
        }

        public override void CheckAnswers()
        {
            Console.WriteLine("{0}Вы ответили неправильно!{0}", Environment.NewLine);
        }
    }
}