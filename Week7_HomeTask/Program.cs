using System;

namespace Week7_HomeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            Console.ReadLine();
        }
        public static void StartGame()
        {
            Game game = new Game(new Player());

            game.LoadRules(@".\rules.txt");
            game.PrepareQuestions();
            game.ChoosingGame();
        }
    }    
}