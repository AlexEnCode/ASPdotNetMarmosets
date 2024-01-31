using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPdotNetMarmosets.Models
{
    public class Marmosets
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string? Nom { get; set; }


        [Display(Name = "Age")]
        public int Age { get; set; }


        [Display(Name = "Poids")]
        public int Poids { get; set; }

        [Display(Name = "Taille")]
        public int Taille { get; set; }
    }
}