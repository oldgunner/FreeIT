using System;
using System.Text;

namespace Week6HT
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Player player = new Player();
            int rightAnswers = 0;
            string continueOrNot = "1";

            game.StartGame();
            game.PrepareQuestions(game);
            game.AskPlayersName(player);
            game.MainPhase(game.Questions, continueOrNot, rightAnswers, player);

            Console.ReadLine();
        }
    }

    class Game
    {
        public Question[] Questions;
        public Answer[] Answers;

        public void StartGame()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Кто хочет стать миллионером!!!");
            Console.WriteLine("Правила игры\n");
            Console.WriteLine("1. 1 вопрос - 4 варианта ответа - 1 правильный ответ.");
            Console.WriteLine("2. Первый вопрос стоит 100 рублей, следующие - удваивают сумму.");
            Console.WriteLine("3. Есть возможность забрать деньги или играть дальше.\n");
        }
        public Game PrepareQuestions(Game game)
        {
            game.Questions = new Question[]
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
            return game;
        }
        public Player AskPlayersName(Player player)
        {
            Console.Write("Введите имя: \n");
            var name = Console.ReadLine();
            Console.WriteLine("\nЗдравствуйте, {0}\n", name);
            player.Name = name;
            Console.WriteLine($"Начнём игру, {player.Name}\n");
            return player;
        }
        public void MainPhase(Question[] questions, string continueOrNot, int rightAnswers, Player player)
        {
            for (int i = 0; i < questions.Length; i++)
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

                    //if (Int32.Parse(answer) != 1 || Int32.Parse(answer) != 2 || Int32.Parse(answer) != 3 || Int32.Parse(answer) != 4)
                    //{
                    //    Console.Write("Введите вариант ответа цифрой: ");
                    //    answer = Console.ReadLine();
                    //}

                    int num = Int32.Parse(answer);

                    if (questions[i].correctAnswerNum == answer)
                    {

                        userChoice = questions[i].Answers[num - 1];
                        userChoice.CheckAnswers();

                        rightAnswers++;
                        if (rightAnswers == 1) //if right answers number is 1, user will get 100 BYN
                        {
                            player.Score += 100;
                            GameInformation(player, out continueOrNot);
                        }
                        else if (rightAnswers > 1 && rightAnswers < questions.Length) //if right answers number is more than 1 and less than questions in array, user will get x2 BYN
                        {
                            player.Score *= 2;
                            GameInformation(player, out continueOrNot);
                        }

                        else if (rightAnswers == questions.Length) //high level - user answered all questions
                        {
                            player.Score *= 2;
                            Console.WriteLine("\nВы ответили правильно на все вопросы!\n");
                            GameOver(player);
                        }
                    }
                    else
                    {
                        userChoice = questions[i].Answers[num - 1];
                        userChoice.CheckAnswers();

                        player.Score = 0;
                        GameOver(player);
                        break;
                    }
                }
                else
                {
                    GameOver(player);
                    break;
                }
            }
        }
        public void GameInformation(Player player, out string continueOrNot)
        {
            continueOrNot = "1";            
            Console.WriteLine("На данном этапе вы можете забрать " + player.Score + " рублей\n");
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
        }
        public void GameOver(Player player)
        {
            Console.WriteLine("\nВаш выигрыш составил " + player.Score + " рублей! Спасибо за игру!");
        }
    }

    class Player
    {
        public string Name;
        public int Score;

        public Player() { }

        public Player(string name, int score = 0)
        {
            this.Name = name;
        }
    }

    class Question
    {
        public string question;
        public string answerVariant1;
        public string answerVariant2;
        public string answerVariant3;
        public string correctAnswer;
        public string correctAnswerNum;
        public Answer[] Answers = new Answer[4];

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
            int num = rand.Next(1, 4);

            switch (num)
            {
                case 1:
                Answers[0] = new CorrectAnswer(correctAnswer);
                Answers[1] = new WrongAnswer(answerVariant1);
                Answers[2] = new WrongAnswer(answerVariant2);
                Answers[3] = new WrongAnswer(answerVariant3);
                correctAnswerNum = "1";
                for (int i = 0; i < Answers.Length; i++)
                    Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                break;

                case 2:
                Answers[0] = new WrongAnswer(answerVariant1);
                Answers[1] = new CorrectAnswer(correctAnswer);
                Answers[2] = new WrongAnswer(answerVariant2);
                Answers[3] = new WrongAnswer(answerVariant3);
                correctAnswerNum = "2";
                for (int i = 0; i < Answers.Length; i++)
                    Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                break;

                case 3:
                Answers[0] = new WrongAnswer(answerVariant1);
                Answers[1] = new WrongAnswer(answerVariant2);
                Answers[2] = new CorrectAnswer(correctAnswer);
                Answers[3] = new WrongAnswer(answerVariant3);
                correctAnswerNum = "3";
                for (int i = 0; i < Answers.Length; i++)
                    Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                break;

                case 4:
                Answers[0] = new WrongAnswer(answerVariant1);
                Answers[1] = new WrongAnswer(answerVariant2);
                Answers[2] = new WrongAnswer(answerVariant3);
                Answers[3] = new CorrectAnswer(correctAnswer);
                correctAnswerNum = "4";
                for (int i = 0; i < Answers.Length; i++)
                    Console.WriteLine($"{i + 1}. {Answers[i].answerText}");
                break;
            }
        }
    }

    abstract class Answer
    {
        public string answerText;
        public Answer(string text)
        {
            this.answerText = text;
        }

        public abstract void CheckAnswers();
    }

    class CorrectAnswer : Answer
    {
        public CorrectAnswer(string text) : base(text)
        {
        }

        public override void CheckAnswers()
        {
            Console.WriteLine("\nВы ответили правильно!\n");
        }
    }

    class WrongAnswer : Answer
    {
        public WrongAnswer(string text) : base(text)
        {
        }

        public override void CheckAnswers()
        {
            Console.WriteLine("\nВы ответили неправильно!\n");
        }
    }
}