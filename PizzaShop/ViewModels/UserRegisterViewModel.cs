using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class UserRegisterViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Korisnicko ime je obavezno")]
        [Display(Name = "Korisnicko ime")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Sifra je obavezna")]
        [Display(Name = "Sifra")]
        [RegularExpression("^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\\-__+.]){1,}).{8,15}$",
                            ErrorMessage = "Sifra mora imati najmanje 1 veliki karakter, 1 mali karakter, broj, specijalni karakter i da bude duzine od 8-15 karaktera")]
        [StringLength(20, ErrorMessage = "Sifra je predugacka (maksimalno 20 karaktera)")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Polje potvrdi sifru je obavezno")]
        [Display(Name = "Potvrdi sifru")]
        [Compare("Password", ErrorMessage = "Uneta sifra se ne poklapa!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [Display(Name = "Ime")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [Display(Name = "Prezime")]
        [StringLength(20, ErrorMessage = "Prezime je predugacko (maksimalno 20 karaktera)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adresa je obavezna")]
        [Display(Name = "Adresa")]
        [StringLength(60, ErrorMessage = "Adresa je predugacka (maksimalno 60 karaktera)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ime grada je obavezno")]
        [Display(Name = "Grad")]
        [StringLength(50, ErrorMessage = "Ime je predugacko (maksimalno 50 karaktera)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Ime drzave je obavezno")]
        [Display(Name = "Drzava")]
        [StringLength(50, ErrorMessage = "Ime je predugacko (maksimalno 50 karaktera)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezan")]
        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Broj telefona nije validan!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adresa")]
        [StringLength(50, ErrorMessage = "Email adresa je predugacka (maksimalno 50 karaktera)")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
