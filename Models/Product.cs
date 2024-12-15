using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa przedmiotu jest wymagana")]
        [Length(1, 100)]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Opis przedmiotu jest wymagany")]
        [StringLength(500)]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Cena przedmiotu jest wymagana")]
        public int Cena { get; set; }

        [NotMapped]
        public IFormFile Zdjęcie { get; set; }

        public string? UserId { get; set; }

        public virtual IdentityUser? Użytkownik { get; set; }
        public string? ImagePath { get; internal set; }
        public virtual UserProfile? UserProfile { get; set; }



    }
}
