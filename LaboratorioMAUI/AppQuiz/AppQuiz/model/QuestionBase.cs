namespace AppQuiz.Model
{
    internal abstract class QuestionBase
    {
        public string Text { get; set; }
        public int Points { get; set; }
        public string ImagePath { get; set; }
        public string Hint { get; set; }

        public QuestionBase(string text, int points, string imagePath, string hint)
        {
            Text = text;
            Points = points < 0 ? 0 : points;
            ImagePath = imagePath;
            Hint = hint;
        }

        public abstract bool CheckAnswer(bool answer);
    }
}
