namespace Week7_HomeTask
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player() { }

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
        public void IncreaseScore(int rightAnswers)
        {
            if (rightAnswers == 1)
                Score = 100;
            else
                Score *= 2;

        }
        public void ResetScore()
        {
            Score = 0;
        }
    }    
}