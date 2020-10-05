namespace Week7_HomeTask
{
    abstract class Answer
    {
        public string answerText;
        public Answer(string text)
        {
            this.answerText = text;
        }

        public abstract void CheckAnswers();
    }
    
}