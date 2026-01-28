namespace ConvertitoreFranchi
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnConverterClicked(object sender, EventArgs e)
        {
            double val;
            double ris;
            double cambio = 0.92;
            double.TryParse(InputFranchi.Text, out val);

            ris = (double)val * cambio;

            LblRisultato.Text = ris.ToString();




        }
    }

}
