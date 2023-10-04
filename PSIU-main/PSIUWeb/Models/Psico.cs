using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{
    public enum  Level
    {
        Graduação,
        Mestrado,
        Doutorado,
        Phd,
        Mestre,
        Licenciado,
        Outros
    }

    public class Psico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento requerida.")]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Experiência no  mercado requerida.")]
        [Display(Name = "Anos de Experiência")]
        public int  Exper { get; set; }

        [Required(ErrorMessage = "Nível de Graduação requerida")]
        [Display(Name = "Nível")]
        public Level  Level { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
    }
}