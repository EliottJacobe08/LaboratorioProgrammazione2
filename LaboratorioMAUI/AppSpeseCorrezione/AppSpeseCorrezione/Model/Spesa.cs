using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpeseCorrezione.Model
{
    public class Spesa : VoceBase
    {
		private double _importo;

		public double Importo
		{
			get { return _importo; }
			set { _importo = value; }
		}
        public override string ToRiga()
        {
            return this.Descrizione+";"+this.Importo;
        }
		public static Spesa FromRiga(string riga)
		{
			if (string.IsNullOrEmpty(riga)) return null;
			string[] parti = riga.Split(";");

			if (parti.Length < 2) return null;

			if (double.TryParse(parti[1], out double importoValido))
			{
				return new Spesa { Descrizione = parti[0], Importo = importoValido };

			}
			return null;
		}

	}
}
