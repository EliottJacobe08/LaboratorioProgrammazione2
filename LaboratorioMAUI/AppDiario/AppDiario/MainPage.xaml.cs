using AppDiario.Models;

namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        //windw R (impostato a sciola percorso (Path)) --> cercare App --> LocalState
        string _percorsoFile = Path.Combine(FileSystem.AppDataDirectory, "note.txt");

        public MainPage()
        {
            InitializeComponent();
        }
        public async void OnSalvaClicked(object sender, EventArgs e) {
            Nota nota = new Nota();
            nota.Titolo = entTitolo.Text;
            nota.Testo = entTesto.Text;

            if (string.IsNullOrEmpty(nota.Titolo)) {
                await DisplayAlert("Error", "inserisci almeno titolo", "OK");
                return;
            }
            string rigaDaScrivere = nota.DaOgettoARiga();

            File.AppendAllText(_percorsoFile, rigaDaScrivere + Environment.NewLine);
            entTesto.Text = "";
            entTitolo.Text = "";
            await DisplayAlert("Fatto", "nota salvata corretamente", "ok");
        }

        public async void OnLeggiClicked(object sender, EventArgs e) {
            if (File.Exists(_percorsoFile))
            {
                string[] righe = File.ReadAllLines(_percorsoFile);
                editDisplay.Text = "";

                foreach (string r in righe)
                {
                    Nota n = Nota.DaRigaAOgetto(r);
                    if (n != null)
                    {
                        editDisplay.Text += "Titolo " + n.Titolo + "\n";
                        editDisplay.Text += "Testo " + n.Testo + "\n";
                    }
                }
            }
            else
            {
                editDisplay.Text = "file vuoto o non esiste";

            }
        }
    }

}
