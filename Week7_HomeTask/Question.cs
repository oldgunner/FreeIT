﻿using System;

namespace Week7_HomeTask
{
    class Question
    {
        public string question;
        public int questionNum;
        public string answerVariant1;
        public string answerVariant2;
        public string answerVariant3;
        public string correctAnswer;

        public Answer[] Answers = new Answer[4];

        public Question(int questionNum, string question, string answerVariant1, string answerVariant2, string answerVariant3, string correctAnswer)
        {
            this.questionNum = questionNum;
            this.question = question;
            this.answerVariant1 = answerVariant1;
            this.answerVariant2 = answerVariant2;
            this.answerVariant3 = answerVariant3;
            this.correctAnswer = correctAnswer;
        }

        public void PrintQuestion()
        {
            Console.WriteLine("Вопрос №" + questionNum + ": " + question);
        }
        public void PrintAnswers()
        {
            Random rand = new Random();
            int num = rand.Next(1, 4);

            switch (num)
            {
                case 1:
                    Answers[0] = new CorrectAnswer(correctAnswer);
                    Answers[1] = new WrongAnswer(answerVariant1);
                    Answers[2] = new WrongAnswer(answerVariant2);
                    Answers[3] = new WrongAnswer(answerVariant3);

                    for (int i = 0; i < Answers.Length; i++)
                        Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                    break;

                case 2:
                    Answers[0] = new WrongAnswer(answerVariant1);
                    Answers[1] = new CorrectAnswer(correctAnswer);
                    Answers[2] = new WrongAnswer(answerVariant2);
                    Answers[3] = new WrongAnswer(answerVariant3);

                    for (int i = 0; i < Answers.Length; i++)
                        Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                    break;

                case 3:
                    Answers[0] = new WrongAnswer(answerVariant1);
                    Answers[1] = new WrongAnswer(answerVariant2);
                    Answers[2] = new CorrectAnswer(correctAnswer);
                    Answers[3] = new WrongAnswer(answerVariant3);

                    for (int i = 0; i < Answers.Length; i++)
                        Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                    break;

                case 4:
                    Answers[0] = new WrongAnswer(answerVariant1);
                    Answers[1] = new WrongAnswer(answerVariant2);
                    Answers[2] = new WrongAnswer(answerVariant3);
                    Answers[3] = new CorrectAnswer(correctAnswer);

                    for (int i = 0; i < Answers.Length; i++)
                        Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                    break;
            }
        }
    }

}