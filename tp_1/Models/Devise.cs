using System.ComponentModel.DataAnnotations;

namespace tp_1.Models;

public class Devise
{
    public Devise(int id, string? nomDevise, double taux)
    {
        Id = id;
        NomDevise = nomDevise;
        Taux = taux;
    }

    public int Id { get; set; }

    [Required] public string? NomDevise { get; set; }

    public double Taux { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Devise other) return Id == other.Id && NomDevise == other.NomDevise && Taux == other.Taux;
        return false;
    }
}