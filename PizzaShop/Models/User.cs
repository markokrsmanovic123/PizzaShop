using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Korisnicko ime je neispravno")]
        [Display(Name = "Korisnicko ime")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Sifra je neispravna")]
        [Display(Name = "Sifra")]
        [StringLength(20, ErrorMessage = "Sifra je predugacka (maksimalno 20 karaktera)")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Potvrdi sifru")]
        [Compare("Password", ErrorMessage = "Uneta sifra se ne poklapa!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ime je neispravno")]
        [Display(Name = "Ime")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je neispravno")]
        [Display(Name = "Prezime")]
        [StringLength(20, ErrorMessage = "Prezime je predugacko (maksimalno 20 karaktera)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adresa je neispravna")]
        [Display(Name = "Adresa")]
        [StringLength(60, ErrorMessage = "Adresa je predugacka (maksimalno 60 karaktera)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Uneto ime grada je neispravno")]
        [Display(Name = "Grad")]
        [StringLength(50, ErrorMessage = "Ime je predugacko (maksimalno 50 karaktera)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Uneto ime drzave je neispravno")]
        [Display(Name = "Drzava")]
        [StringLength(50, ErrorMessage = "Ime je predugacko (maksimalno 50 karaktera)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezan!")]
        [Display(Name = "Broj telefona")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Broj telefona nije validan!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email adresa")]
        [StringLength(50, ErrorMessage = "Email adresa je predugacka (maksimalno 50 karaktera)")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public List<Order> Orders { get; set; }

    }
}
