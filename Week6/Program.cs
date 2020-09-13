using System;

namespace Week6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cat cat = new Cat("Tom", "Black");
            //Animal jerry = new Dog("Jerry");
            //DoJob(jerry);
            //DoJob(cat);
            //Console.WriteLine("Hello World!");
            Question q1 = new Question
            {
                QuestionText = "What is it?",
                Answers = new Answer[4]
            };

            q1.Answers[0] = new WrongAnswer("1");
            q1.Answers[1] = new WrongAnswer("2");
            q1.Answers[2] = new WrongAnswer("3");
            q1.Answers[3] = new CorrectAnswer("4");

            Answer usersChoice = q1.Answers[2];
            usersChoice.Choose();

            if (usersChoice is CorrectAnswer)
            {
                //multiple score by 2
            }
            else
            {
                //exit
            }
        }

        static string DoJob(Animal animal)
        {
            string result = animal.SayYourName();
            return result;
        }
    }
}
