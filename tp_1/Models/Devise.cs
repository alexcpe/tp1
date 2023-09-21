using System;
namespace tp_1.Models
{
	public class Devise
	{
		private int id;
		public int Id
		{
			get
				{
					return id;
				}
			set
				{
					id = value;
				}
		}
		private string? nomDevise;

        public string? NomDevise
		{
			get
				{
					return nomDevise;
				}
			set
				{
					nomDevise = value;
				}
		}

		private double taux;

        public Devise(int id, string? nomDevise, double taux)
        {
            id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public double Taux
		{
            get
				{
					return taux;
				}
            set
				{
					taux = value;
				}
        }

    }
}

