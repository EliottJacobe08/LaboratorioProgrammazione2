namespace AppQuiz;

public partial class ResultPage : ContentPage
{
    int _score = 0;
    public ResultPage(int score)
	{
        int _score = score;
        InitializeComponent();
		ShowGUI(_score);
	}
	private void ShowGUI(int _score)
	{
       
        LblScore.Text = _score.ToString();

	}
    private void btnPlayAgain_Clicked(object sender, EventArgs e)
    {
        onPlayAgain();
    }
    private async void onPlayAgain()
    {
        await Navigation.PushAsync(new MainPage());
    }
}