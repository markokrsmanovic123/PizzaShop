using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Korisnicko ime")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Sifra")]
        public string Password { get; set; }
    }
}
