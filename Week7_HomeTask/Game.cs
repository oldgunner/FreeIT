﻿﻿using System;
using System.IO;
using System.Text;

namespace Week7_HomeTask
{
    class Game
    {
        public Question[] Questions;
        public Player Player;

        public Game() { }
        public Game(Player player)
        {
            this.Player = player;
        }

        public void AskPlayersName()
        {
            Console.Write($"Введите имя: {Environment.NewLine}");
            Player.Name = Console.ReadLine();
            Console.WriteLine($"Здравствуйте, {Player.Name}! Начнём игру!{Environment.NewLine}");
        }
        public void LoadRules(string filePath)
        {
            FileInfo myFile = new FileInfo(filePath);
            FileStream fileStream = myFile.OpenRead();
            if (!myFile.Exists)
            {
                throw new FileNotFoundException();
            }

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        public void PrepareQuestions()
        {
            Questions = new Question[]
            {
                new Question(1, "2x9","21","37","1","18"),
                new Question(2, "3x8","14","32","22","24"),
                new Question(3, "4x7","68","53","11","28"),
                new Question(4, "5x6","21","23","28","30"),
                new Question(5, "6x12","82","62","91","72"),
                new Question(6, "7x5","48","53","31","35"),
                new Question(7, "8x6","34","43","52","48"),
                new Question(8, "9x3","12","23","26","27"),
                new Question(9, "2x1","1","6","3","2")
            };
        }
        public void MainPhase(Question[] questions, int rightAnswers)
        {
            string continueOrNot = "1";
            for (int i = rightAnswers; i < questions.Length; i++)
            {
                if (continueOrNot == "1")
                {
                    questions[i].PrintQuestion();
                    Console.WriteLine();
                    questions[i].PrintAnswers();
                    Console.WriteLine();
                    Answer userChoice = null;

                    Console.Write("Введите вариант ответа цифрой от 1 до 4: ");
                    var answer = Console.ReadLine();

                    while (answer != "1" && answer != "2" && answer != "3" && answer != "4")
                    {
                        Console.Write("Введите вариант ответа цифрой от 1 до 4: ");
                        answer = Console.ReadLine();
                        Console.WriteLine();
                    }

                    int num = Int32.Parse(answer);
                    userChoice = questions[i].Answers[num - 1];
                    userChoice.CheckAnswers();

                    if (userChoice is CorrectAnswer)
                    {
                        rightAnswers++;
                        Player.IncreaseScore(rightAnswers);
                        continueOrNot = GameInformation(continueOrNot, rightAnswers);

                        if (rightAnswers == questions.Length) //high level - user answered all questions
                        {
                            Player.IncreaseScore(rightAnswers);
                            Console.WriteLine("{0}Вы ответили правильно на все вопросы!{0}", Environment.NewLine);
                            GameOver();
                        }
                    }
                    else
                    {
                        Player.ResetScore();
                        GameOver();
                        break;
                    }
                }
                else
                {
                    GameOver();
                    break;
                }
            }
        }
        public string GameInformation(string continueOrNot, int rightAnswers)
        {
            Console.WriteLine("На данном этапе вы можете забрать " + Player.Score + $" рублей{Environment.NewLine}");
            Console.WriteLine("Продолжим играть?");
            Console.Write("Нажмите 1 для продолжения игры, 2 - для выхода из игры: ");
            continueOrNot = Convert.ToString(Console.ReadLine());
            Console.WriteLine();

            while (continueOrNot != "1" && continueOrNot != "2")
            {
                Console.Write("Нажмите 1 для продолжения игры, 2 - для выхода из игры: ");
                continueOrNot = Convert.ToString(Console.ReadLine());
                Console.WriteLine();
            }

            if (continueOrNot == "2")
            {
                Console.WriteLine("Хотите сохранить игру?");
                Console.Write("Нажмите 1 для сохранения игры, 2 - если игру не сохранять: ");
                string saveOrNotGame = Convert.ToString(Console.ReadLine());
                Console.WriteLine();
                while (saveOrNotGame != "1" && saveOrNotGame != "2")
                {
                    Console.Write("Нажмите 1 для сохранения игры, 2 - если игру не сохранять: ");
                    saveOrNotGame = Convert.ToString(Console.ReadLine());
                    Console.WriteLine();
                }
                if (saveOrNotGame == "1")
                {
                    Save(@".\game.txt", rightAnswers);
                }
            }
            return continueOrNot;
        }
        public void GameOver()
        {
            Console.WriteLine($"{Environment.NewLine}Ваш выигрыш составил " + Player.Score + " рублей! Спасибо за игру!");
        }
        public void Save(string filePath, int index)
        {
            FileInfo myFile = new FileInfo(filePath);
            if (myFile.Exists)
            {
                myFile.Delete();
            }

            FileStream fileStream = myFile.OpenWrite();
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            streamWriter.WriteLine(this.Player.Name);
            streamWriter.WriteLine(this.Player.Score);
            streamWriter.WriteLine(index);
            streamWriter.Dispose();
        }
        public int Load(string filePath)
        {
            int questionNum = 0;
            FileInfo myFile = new FileInfo(filePath);
            FileStream fileStream = myFile.OpenRead();
            if (!myFile.Exists)
            {
                throw new FileNotFoundException();
            }

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                try
                {
                    this.Player.Name = sr.ReadLine();
                    this.Player.Score = int.Parse(sr.ReadLine());
                    questionNum = int.Parse(sr.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return questionNum;
        }

        public void ChoosingGame()
        {
            int rightAnswers = 0;

            Console.WriteLine($"{Environment.NewLine}Вы хотите начать новую игру или открыть сохранённую?");
            Console.Write("Нажмите 1 для создания новой игры, 2 - для загрузки сохранённой игры: ");
            var answer = Convert.ToString(Console.ReadLine());
            Console.WriteLine();

            while (answer != "1" && answer != "2")
            {
                Console.Write("Нажмите 1 для создания новой игры, 2 - для загрузки сохранённой игры: ");
                answer = Convert.ToString(Console.ReadLine());
                Console.WriteLine();
            }

            if (answer == "1")
            {
                AskPlayersName();
                MainPhase(Questions, rightAnswers);
            }
            else
            {
                rightAnswers = Load(@".\game.txt");
                GreetingPlayer(rightAnswers);
                MainPhase(Questions, rightAnswers);
            }
        }

        public void GreetingPlayer(int rightAnswers)
        {
            Console.WriteLine($"{Environment.NewLine}Рады снова видеть вас, {Player.Name}");
            Console.WriteLine($"У вас на счету {Player.Score} рублей.");
            Console.WriteLine($"Вы остановились на вопросе № {rightAnswers}");
        }
    }
}