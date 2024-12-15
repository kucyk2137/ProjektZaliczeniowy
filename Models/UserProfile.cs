using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(50)]
        public string Imię { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50)]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [MaxLength(100)]
        public string Adres { get; set; }
        [Required(ErrorMessage ="Kod pocztowy jest wymagany")]
        [MaxLength(10)]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Niepoprawny format numeru telefonu")]
        public string PhoneNumber { get; set; }

        public virtual IdentityUser? Użytkownik { get; set; }
    }
}
