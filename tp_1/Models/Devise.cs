using System;
namespace tp_1.Models
{
	public class Devise
	{

		public int Id
		{
			get
				{
					return Id;
				}
			set
				{
					Id = value;
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
            Id = id;
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

