using System.Globalization;

namespace Esempio
{
    public partial class MainPage : ContentPage
    {
        double cambio = 0.92;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnConverterClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(
                InputFranchi.Text,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out double val))
            {
                LblRisultato.Text = "Inserisci un numero valido";
                return;
            }

            double ris = val * cambio;
            LblRisultato.Text = ris.ToString("F2");
        }

        private void OnConverterEFClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(
                InputFranchi.Text,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out double val))
            {
                LblRisultato.Text = "Inserisci un numero valido";
                return;
            }

            double ris = val / cambio;
            LblRisultato.Text = ris.ToString("F2");
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            LblRisultato.Text = null;
            InputFranchi.Text = null;
        }
    }
}
