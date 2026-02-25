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


            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                var current = _questions[_currentIndex];

                QuestionTextLabel.Text = current.Text;
                QuestionImage.Source = current.ImagePath;
                HintLabel.IsVisible = false;
                HintLabel.Text = current.Hint;

                UpdateScoreLabel();
                _hintUsed = false;
            }
            else
            {
                QuestionTextLabel.Text = "Quiz terminato!";
                QuestionImage.Source = null;
                HintLabel.IsVisible = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_currentIndex >= _questions.Count)
                return;

            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            var current = _questions[_currentIndex];

            if (current.CheckAnswer(userAnswer))
            {
                int earnedPoints = current.Points;

                if (_hintUsed)
                    earnedPoints -= 5; // penalizzazione hint

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
    }
}
