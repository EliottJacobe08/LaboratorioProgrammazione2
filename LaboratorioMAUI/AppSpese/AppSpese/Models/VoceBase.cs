using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    public abstract class VoceBase
    {
        private string descrizione;

        public string Descrizione
        {
            get { return descrizione; }
            set { descrizione = value; }
        }

        public abstract string ToRiga();
    }
}
