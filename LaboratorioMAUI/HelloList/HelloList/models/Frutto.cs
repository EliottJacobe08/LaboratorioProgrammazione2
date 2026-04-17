using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloList.models
{
    internal class Frutto
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}
		private string _provenienza;

		public string Provenienza
		{
			get { return _provenienza; }
			set { _provenienza = value; }
		}

        public Frutto(string nome , string provenienza)
        {
			Nome = nome;
			Provenienza = provenienza;
		}

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Nome + ";" + Provenienza;
        }
    }
}
