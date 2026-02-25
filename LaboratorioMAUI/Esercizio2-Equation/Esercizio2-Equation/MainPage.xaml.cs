using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Esercizio2_Equation
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            

        }
        public void ControllaValori()
        {
            if (string.IsNullOrWhiteSpace(EntA.Text) ||
                string.IsNullOrWhiteSpace(EntB.Text) ||
                string.IsNullOrWhiteSpace(EntC.Text))
            {
                LblRisultato.Text = "Errore: tutti i campi devono essere compilati.";
                LblRisultato.TextColor = Colors.Orange;
                return;
            }
            else if (EntA.Text == "0")
            {
                LblRisultato.Text = "l'equazione non sarebbe di II grado";
                return;
            }
            CalcolaValori();
        }
        public void CalcolaValori()
        {
            try {
                double.TryParse(EntA.Text, out  double a);
                double.TryParse(EntA.Text, out double b);
                double.TryParse(EntA.Text, out double c);

                double delta = (Math.Pow(b, 2)) - 4 * a * c;

                if (delta == 0)
                {
                    double Xv = -b / (2 * a);
                    LblRisultato.Text = "delta:"+delta+" "+Xv.ToString();
                    LblRisultato.TextColor = Colors.Green;
                }
                else if (delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    LblRisultato.Text = "delta:" + delta + " " + x1.ToString() + " " + x2.ToString();
                    LblRisultato.TextColor = Colors.Blue;
                }
                else if(delta < 0)
                {
                    LblRisultato.Text = "delta:" + delta + " " + "Nessuna soluzione reale";
                    LblRisultato.TextColor = Colors.Red;
                }
            } catch { 
            
            }

        }
        public void BtnRisultato(object sender, EventArgs e)
        {
            ControllaValori();
        }
    }
}
