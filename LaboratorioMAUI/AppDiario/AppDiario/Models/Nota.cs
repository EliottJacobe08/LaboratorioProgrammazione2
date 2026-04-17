using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiario.Models
{
    internal class Nota
    {
		private string _titolo;

		public string Titolo
		{
			get { return _titolo; }
			set {
					if (String.IsNullOrEmpty(value)) {
						_titolo = "Sconosciuto";
					}
					_titolo = value;
				}
		}

		private string _testo;

		public string Testo
		{
			get { return _testo; }
			set { _testo = value; }
		}

		public static Nota DaRigaAOgetto(string riga) {

			string[]parti = riga.Split(',');

			if (parti.Length < 2) {
				return null;
			}

			Nota nota = new Nota();
			nota.Titolo = parti[0];
			nota.Testo = parti[1];
			return nota;
		}
		public string DaOgettoARiga()
		{
			return _titolo+";"+_testo;
		}
	}
}
