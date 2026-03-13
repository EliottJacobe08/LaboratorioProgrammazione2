using AppQuiz.model;
using AppQuiz.Model;

namespace AppQuiz
{
    
    public partial class MainPage : ContentPage
    {
        private static readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, "domande.txt");
        private List<QuestionBase> _questions = new();
        private int _currentIndex = 0;
        private int _score = 0;
        private bool _hintUsed = false;

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_filePath))
            {
                string[] righe = File.ReadAllLines(_filePath);

                foreach (string riga in righe)
                {
                    string[] dati = riga.Split(';');

                    if (dati[0] == "TF")
                    {
                       if (int.TryParse(dati[2], out int punti) && bool.TryParse(dati[3], out bool risposta))
                        {
                            _questions.Add(new TrueFalse(
                                dati[1],
                                punti,
                                risposta,
                                dati[4],
                                dati[5]
                            ));
                        }
                    } else if (dati[0] == "OPEN")
                    {
                        if (int.TryParse(dati[2], out int punti))
                        {
                            _questions.Add(new OpenQuestion(
                                dati[1],
                                punti,
                                dati[3],
                                dati[4],
                                dati[5]
                                ));
                        }
                    }
                    else { continue; }

                }
            }
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
