using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AppSpese.Models
{
    public class Spesa : VoceBase
    {
        public double Importo { get; set; }
        public int Quantita { get; set; }

        public override string ToRiga()
        {
            return Descrizione+";"+Importo+";"+Quantita;
        }
        public static bool FromCsv(string riga)
        {
            if (string.IsNullOrEmpty(riga))
                return false;

            string[] parti = riga.Split(';');

            if (parti.Length != 3)
                return false;

            if (!double.TryParse(parti[1], out double importo))
                return false;

            if (!int.TryParse(parti[2], out int qty))
                return false;

            Spesa spesa = new Spesa
            {
                Descrizione = parti[0],
                Importo = importo,
                Quantita = qty
            };
            return true;
        }


    }
}
