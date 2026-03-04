using AppQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.model
{
    internal class OpenQuestion : QuestionBase
    {
        public string CorrectAnswer { get; set; }
        public OpenQuestion(string text, int points, string correctAnswer, string imagePath, string hint)
            : base(text, points, imagePath, hint)
        {
            CorrectAnswer = correctAnswer;
        }
        public override bool CheckAnswer(object answer)
        {
            if (answer is string userAnswer)
                return userAnswer == CorrectAnswer;

            return false;
        }
    }
}
