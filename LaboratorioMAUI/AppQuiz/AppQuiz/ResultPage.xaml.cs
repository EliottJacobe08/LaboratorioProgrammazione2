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
        if (!File.Exists(_filePath)) return 0;

        try
        {
            //leggere contenuto file
            string content = File.ReadAllText(_filePath);
            int best;
            if (int.TryParse(content, out best))
            {
                return best;
            }
            else
            {
                DisplayAlert("Errore", "il file del punteggio", "Cancel");
                return 0;
            }

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
                File.WriteAllText(_filePath,_name.ToString()+" "+score.ToString() + " "+ DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime now = DateTime.Now;
                LblBest.Text = score.ToString();




            }
            catch (Exception ex)
            {
                DisplayAlert("errore", ex.Message, "Error");
            }
        }


    }
}