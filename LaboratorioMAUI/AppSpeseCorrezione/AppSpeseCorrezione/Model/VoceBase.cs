using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpeseCorrezione.Model
{
    public abstract class VoceBase
    {
        private string _descrizione;

		public string Descrizione
		{
			get { return Descrizione; }
			set { Descrizione = value; }
		}
		public abstract string ToRiga();

	}
}
