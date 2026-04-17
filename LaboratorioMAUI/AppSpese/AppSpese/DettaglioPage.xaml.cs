using AppSpese.Models;
using System;
using System.IO;

namespace AppSpese;

public partial class DettaglioPage : ContentPage
{
    public DettaglioPage(string path)
    {
        InitializeComponent();
        LoadData(path);
    }

    public void LoadData(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            EdiSpese.Text = "Percorso non valido";
            return;
        }

        if (!File.Exists(path))
        {
            EdiSpese.Text = "File non trovato";
            return;
        }

        string[] righe = File.ReadAllLines(path);
        string output = string.Empty;
        double totale = 0;


        foreach (string r in righe)
        {
            if (Spesa.FromCsv(r))
            {
                string[] parti = r.Split(';');

                output += $"Descrizione:{parti[0]}\n";
                output += $"Iimporto:{parti[1]}\n";
                output += "------------------\n";

                if (double.TryParse(parti[1], out double imp) && int.TryParse(parti[2], out int qta))
                {
                    totale += imp * qta;
                }
            }
        }

        if (string.IsNullOrEmpty(output))
            output = "Nessuna spesa valida";
        else
            output += $"totale: {totale}";

        EdiSpese.Text = output;
        lblMese.Text = Path.GetFileNameWithoutExtension(path);
    }

    public async void OnBtnBClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

