using AppQuiz.model;
using AppQuiz.Model;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new();
        private int _currentIndex = 0;
        private int _score = 0;
        private bool _hintUsed = false;

        public MainPage()
        {
            InitializeComponent();

            _questions.Add(new TrueFalse(
                "Il C# è un linguaggio orientato agli oggetti?",
                10,
                true,
                "c_uses.png",
                "È sviluppato da Microsoft."
            ));

            _questions.Add(new TrueFalse(
                "Python è un linguaggio compilato?",
                15,
                false,
                "python.png",
                "È interpretato."
            ));
            _questions.Add(new TrueFalse(
                "HTML è un linguaggio di programmazione?",
                10,
                false,
                "html.png",
                "HTML è un linguaggio di markup."
            ));

            _questions.Add(new TrueFalse(
                "CSS serve per definire lo stile e il layout delle pagine web?",
                10,
                true,
                "css.png",
                "Permette di gestire colori, margini, font e layout."
            ));

            _questions.Add(new TrueFalse(
                "JavaScript viene eseguito solo lato server?",
                15,
                false,
                "js.png",
                "JavaScript può essere eseguito sia lato client che lato server (es. Node.js)."
            ));

            _questions.Add(new OpenQuestion(
                "Quanti anni ha JS",
                67,
                "18",
                "js.png",
                "Non avrai aiuti hahah -5 godo"
                ));

            _questions.Add(new OpenQuestion(
                "Quanta Aura ha Palucci",
                67,
                "Troppa",
                "js.png",
                "Non avrai aiuti hahah -5 godo"
                ));


            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                var current = _questions[_currentIndex];
                if (current is OpenQuestion)
                {
                    Risposta.IsVisible = true;
                    CheckAnswer.IsVisible = true;
                    Vero.IsVisible = false;
                    Falso.IsVisible = false;
                }
                else {
                    Risposta.IsVisible = false;
                    CheckAnswer.IsVisible = false;
                    Vero.IsVisible = true;
                    Falso.IsVisible = true;
                }

                QuestionTextLabel.Text = current.Text;
                QuestionImage.Source = current.ImagePath;
                HintLabel.IsVisible = false;
                HintLabel.Text = current.Hint;
                btnResult.IsVisible = false;

                UpdateScoreLabel();
                _hintUsed = false;
            }
            else
            {
                QuestionTextLabel.Text = "Quiz terminato!";
                QuestionImage.Source = null;
                HintLabel.IsVisible = false;
                btnResult.IsVisible= true;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_currentIndex >= _questions.Count)
                return;

            var current = _questions[_currentIndex];
            var btn = sender as Button;

            bool isCorrect = false;

            if (current is TrueFalse)
            {
                if (btn?.CommandParameter is string param &&
                    bool.TryParse(param, out bool userAnswer))
                {
                    isCorrect = current.CheckAnswer(userAnswer);
                }
            }
            else if (current is OpenQuestion)
            {
                string userAnswer = Risposta.Text ?? "";
                isCorrect = current.CheckAnswer(userAnswer);
            }

            if (isCorrect)
            {
                int earnedPoints = current.Points;

                if (_hintUsed)
                    earnedPoints -= 5;

                _score += earnedPoints;
            }

            _currentIndex++;
            ShowQuestion();
        }

        private void Hint_Clicked(object sender, EventArgs e)
        {
            if (_currentIndex < _questions.Count && !_hintUsed)
            {
                HintLabel.IsVisible = true;
                _hintUsed = true;
            }
        }

        private void Restart_Clicked(object sender, EventArgs e)
        {
            _currentIndex = 0;
            _score = 0;
            _hintUsed = false;
            ShowQuestion();
        }

        private void UpdateScoreLabel()
        {
            string name = string.IsNullOrWhiteSpace(NameEntry.Text)
                ? "Giocatore"
                : NameEntry.Text;

            ScoreLabel.Text = $"{name} - Punteggio: {_score}";
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            onQuizFinished();
        }
        private async void onQuizFinished()
        {
            string name = string.IsNullOrWhiteSpace(NameEntry.Text)
            ? "Giocatore"
            : NameEntry.Text;
            await Navigation.PushAsync(new ResultPage(_score, name));
        }
    }
}
