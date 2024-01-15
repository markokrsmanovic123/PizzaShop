using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Trenutna sifra")]
        public string CurrentPassword { get; set; }

        [Required]
        [RegularExpression("^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\\-__+.]){1,}).{8,15}$",
                            ErrorMessage = "Nova sifra mora imati najmanje 1 veliki karakter, 1 mali karakter, broj, specijalni karakter i da bude duzine od 8-15 karaktera")]
        [Display(Name = "Nova sifra")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Potvrdi novu sifru")]
        [Compare("NewPassword", ErrorMessage = "Uneta sifra se ne poklapa!")]
        public string ConfirmPassword { get; set; }

    }
}
