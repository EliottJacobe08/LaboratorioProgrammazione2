using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAPP_Picker.models
{
    internal class Pizza
    {
		private string _Nome;

		public string Nome
		{
			get { return Nome; }
			set { Nome = value; }
		}
		private float _prezzo;

		public float MPrezzo
		{
			get { return _prezzo; }
			set { _prezzo = value; }
		}
		private string _img;

		public string Img
		{
			get { return _img; }
			set { _img = value; }
		}

		private string _ingredienti;

		public string Ingredienti
		{
			get { return _ingredienti; }
			set { _ingredienti = value; }
		}

        public Pizza(string nome, float prezzo,  string img,  string ingredienti)
        {
            Nome = nome;
            _prezzo = prezzo;
            Img = img;
            Ingredienti = ingredienti;
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
            return base.ToString();
        }
    }
}
