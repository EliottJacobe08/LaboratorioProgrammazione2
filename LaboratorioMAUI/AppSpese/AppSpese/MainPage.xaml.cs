using System;
using System.IO;
using System.Threading.Tasks;
using AppSpese.Models;

namespace AppSpese
{
    public partial class MainPage : ContentPage
    {
        string _path = Path.Combine(FileSystem.AppDataDirectory, "Liste.txt");

        public MainPage()
        {
            InitializeComponent();
            CaricaListe();


        }

        void CaricaListe()
        {
            if (File.Exists(_path))
                EntNomeLista.Text = EntNomeLista.Text;
            else
                EntNomeLista.Text = string.Empty;
        }

        private async void OnBtnSalvaClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text) || string.IsNullOrEmpty(EntDescrizione.Text))
            {
                await DisplayAlert("Valori vuoti", "uno o piu dei campi sono vuoti", "OK");
                return;
            }

            if (!double.TryParse(EntImporto.Text, out double imp))
            {
                await DisplayAlert("Errore", "importo non valido", "OK");
                return;
            }
            if(!int.TryParse(Entqty.Text, out int qty)) {
                if (!(qty < 1))
                {
                    await DisplayAlert("Errore", "quantità non valida", "OK");
                    return;
                }
                else
                {
                    await DisplayAlert("Errore", "quantità minore 1", "OK");
                    return;
                }
            }

            string filePath = Path.Combine(FileSystem.AppDataDirectory, EntNomeLista.Text + ".txt");

            Spesa s = new Spesa
            {
                Descrizione = EntDescrizione.Text,
                Importo = imp,
                Quantita = qty
            };

            try
            {
                File.AppendAllText(filePath, s.ToRiga() + Environment.NewLine);

                if (!File.Exists(_path))
                    File.WriteAllText(_path, filePath + Environment.NewLine);
                else
                {
                    string contenuto = File.ReadAllText(_path);
                    if (!contenuto.Contains(filePath))
                        File.AppendAllText(_path, filePath + Environment.NewLine);
                }

                CaricaListe();

                EntDescrizione.Text = string.Empty;
                EntImporto.Text = string.Empty;

                await DisplayAlert("OK", "Salvato", "OK");
            }
            catch
            {
                await DisplayAlert("Errore", "errore salvataggio", "OK");
            }
        }

        private async void OnVediClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text))
                return;

            string filePath = Path.Combine(FileSystem.AppDataDirectory, EntNomeLista.Text + ".txt");

            await Navigation.PushAsync(new DettaglioPage(filePath));
        }
    }
}
