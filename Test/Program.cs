using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            ShowRules();
            InputName();
            Play();
        }

        static void Play()
        {
            int rightAnswers = 0, money = 0;

            //Here you can add questions manually
            Question[] questions = new Question[]
            {
                new Question("2x9","21","37","1","18"),
                new Question("3x8","14","32","22","24"),
                new Question("4x7","68","53","11","28"),
                new Question("5x6","21","23","28","30"),
                new Question("6x12","82","62","91","72"),
                new Question("7x5","48","53","31","35"),
                new Question("8x6","34","43","52","48"),
                new Question("9x3","12","23","26","27"),
                new Question("2x1","1","6","3","2")
            };

            //main loop
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].PrintQuestion();
                questions[i].PrintAnswers();

                Console.Write("Введите вариант ответа цифрой: ");
                var answer = Console.ReadLine();
               
                if (questions[i].CheckAnswers(answer))
                {
                    rightAnswers++;
                    if (rightAnswers == 1) //if right answers number is 1, user will get 100 BYN
                    {
                        money += 100;
                        Console.WriteLine("Вы ответили правильно!");
                        string continueOrNot = "1";
                        Console.WriteLine("Сыграем ещё раз?");
                        Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
                        continueOrNot = Convert.ToString(Console.ReadLine());
                        while (continueOrNot != "1" && continueOrNot != "2")
                        {
                            Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
                            continueOrNot = Convert.ToString(Console.ReadLine());
                        }
                        if (continueOrNot == "2")
                        {
                            GameOver(money);
                            break;
                        }
                    }
                    else if (rightAnswers > 1 && rightAnswers < questions.Length) //if right answers number is more than 1 and less than questions in array, user will get x2 BYN
                    {
                        money *= 2;
                        Console.WriteLine("Вы ответили правильно!");
                        string continueOrNot = "1";
                        Console.WriteLine("Сыграем ещё раз?");
                        Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
                        continueOrNot = Convert.ToString(Console.ReadLine());
                        while (continueOrNot != "1" && continueOrNot != "2")
                        {
                            Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
                            continueOrNot = Convert.ToString(Console.ReadLine());
                        }
                        if (continueOrNot == "2")
                        {
                            GameOver(money);
                            break;
                        }
                    }

                    else if (rightAnswers == questions.Length) //high level - user answered all questions
                    {
                        money *= 2;
                        Console.WriteLine("Вы ответили правильно на все вопросы!");
                        GameOver(money);
                    }
                }
                else
                {
                    money = 0;
                    GameOver(money);
                    break;
                }
            }
        }
        static void PrintChoice(int money)
        {
            Console.WriteLine("Вы ответили правильно!");
            string continueOrNot = "1";
            Console.WriteLine("Сыграем ещё раз?");
            Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
            continueOrNot = Convert.ToString(Console.ReadLine());
            while (continueOrNot != "1" && continueOrNot != "2")
            {
                Console.WriteLine("Нажмите 1 для продолжения игры, 2 - для выхода из игры.");
                continueOrNot = Convert.ToString(Console.ReadLine());
            }
            if (continueOrNot == "2")
                GameOver(money);
        }
        static void GameOver(int money)
        {
            Console.WriteLine("Ваш выигрыш составил " + money + " рублей! Спасибо за игру!");
        }
        static void InputName()
        {
            Console.Write("Введите имя: \n");
            var name = Console.ReadLine();
            Console.WriteLine("Здравствуйте, {0}\n", name);
            Console.WriteLine("Начнём игру!\n");
        }
        static void ShowRules()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Кто хочет стать миллионером!!!");
            Console.WriteLine("Правила игры\n");
            Console.WriteLine("1. 1 вопрос - 4 варианта ответа - 1 правильный ответ.");
            Console.WriteLine("2. Первый вопрос стоит 100 рублей, следующие - удваивают сумму.");
            Console.WriteLine("3. Есть возможность забрать деньги или играть дальше.\n");
        }
    }
    class Question
    {
        string question;
        string answerVariant1;
        string answerVariant2;
        string answerVariant3;
        string correctAnswer;
        string correctAnswerNum;

        public Question(string question, string answerVariant1, string answerVariant2, string answerVariant3, string correctAnswer)
        {
            this.question = question;
            this.answerVariant1 = answerVariant1;
            this.answerVariant2 = answerVariant2;
            this.answerVariant3 = answerVariant3;
            this.correctAnswer = correctAnswer;
        }
        public void PrintQuestion()
        {
            Console.WriteLine("Вопрос: " + question);
        }
        public void PrintAnswers()
        {
            Random rand = new Random();
            int i = rand.Next(1, 12);
            if (i == 1)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", correctAnswer, answerVariant1, answerVariant2, answerVariant3); correctAnswerNum = "1"; }
            if (i == 2)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", correctAnswer, answerVariant1, answerVariant2, answerVariant3); correctAnswerNum = "1"; }
            if (i == 3)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", correctAnswer, answerVariant1, answerVariant2, answerVariant3); correctAnswerNum = "1"; }
            if (i == 4)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, correctAnswer, answerVariant2, answerVariant3); correctAnswerNum = "2"; }
            if (i == 5)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, correctAnswer, answerVariant2, answerVariant3); correctAnswerNum = "2"; }
            if (i == 6)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, correctAnswer, answerVariant2, answerVariant3); correctAnswerNum = "2"; }
            if (i == 7)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, correctAnswer, answerVariant3); correctAnswerNum = "3"; }
            if (i == 8)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, correctAnswer, answerVariant3); correctAnswerNum = "3"; }
            if (i == 9)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, correctAnswer, answerVariant3); correctAnswerNum = "3"; }
            if (i == 10)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, answerVariant3, correctAnswer); correctAnswerNum = "4"; }
            if (i == 11)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, answerVariant3, correctAnswer); correctAnswerNum = "4"; }
            if (i == 12)
            { Console.WriteLine("1. {0}		2. {1}		3. {2}		4. {3}", answerVariant1, answerVariant2, answerVariant3, correctAnswer); correctAnswerNum = "4"; }
        }
        public bool CheckAnswers(string answer)
        {
            if (answer == correctAnswerNum)
            {
                return true;
            }
            return false;
        }
    }
}