using System.Xml.Linq;

namespace AppQuiz;

public partial class ResultPage : ContentPage
{
    int _score = 0;
    string _name;

    //percorso leggere e salvare TXT
    private static readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, "^bestscore"); 
    public ResultPage(int score, string name)
    {

        int _score = score;
        _name = name;
        InitializeComponent();
        SaveBestScore(_score);
        ShowGUI(_score);
    }
    private void ShowGUI(int _score)
    {

        LblScore.Text =_name.ToString()+" "+ _score.ToString();
    }
    private void btnPlayAgain_Clicked(object sender, EventArgs e)
    {
        onPlayAgain();
    }
    private async void onPlayAgain()
    {
        await Navigation.PushAsync(new MainPage());
    }

    private int LoadBestScore(int score)
    {
        if (!File.Exists(_filePath))
            return 0;

        try
        {
            // Legge tutte le righe del file
            string[] righe = File.ReadAllLines(_filePath);
            int best = 0;

            foreach (string riga in righe)
            {
                string[] parti = riga.Split(' ');

                if (parti.Length >= 2 && int.TryParse(parti[1], out int punteggio))
                {
                    if (punteggio > best)
                        best = punteggio;
                }
            }

            return best;
        }
        catch (Exception ex)
        {
            DisplayAlert("Errore", ex.Message, "Ok");
            return 0;
        }
    }
    private void SaveBestScore(int score)
    {
        int best = LoadBestScore(score);
        LblBest.Text = best.ToString();

        if (score > best)
        {
            try
            {
                
                string nuovaRiga = $"{_name} {score} {DateTime.Now:yyyy-MM-dd}";
                File.WriteAllText(_filePath, nuovaRiga);

                LblBest.Text = nuovaRiga;
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", ex.Message, "Error");
            }
        }
    }
}