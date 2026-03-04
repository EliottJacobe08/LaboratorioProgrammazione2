namespace AppQuiz.Model
{
    internal class TrueFalse : QuestionBase
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalse(string text, int points, bool correctAnswer, string imagePath, string hint)
            : base(text, points, imagePath, hint)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(object answer)
        {
            if (answer is bool userAnswer)
                return userAnswer == CorrectAnswer;

            return false;
        }
    }
}
