using System.ComponentModel.DataAnnotations;

namespace PizzaShop.ViewModels
{
    public class PizzaCustomViewModel
    {
        [Required(ErrorMessage = "Ime pizze je obavezno!")]
        [Display(Name ="Ime pizze")]
        [StringLength(20, ErrorMessage = "Ime je predugacko (maksimalno 20 karaktera)")]
        public string PizzaName { get; set; }

        [Required(ErrorMessage = "Testo je obavezno!")]
        [Display(Name = "Testo")]
        public bool Dough { get; set; }

        [Display(Name = "Pelat")]
        public bool Sauce { get; set; }

        [Display(Name = "Sunka")]
        public bool Ham {  get; set; }

        [Display(Name = "Kobasica")]
        public bool Pepperoni {  get; set; }

        [Display(Name = "Mocarela")]
        public bool Mozzarella { get; set; }

        [Display(Name = "Parmezan")]
        public bool Parmigiano { get; set; }

        [Display(Name = "Pekorino")]
        public bool Pecorino { get; set; }

        [Display(Name = "Sampinjoni")]
        public bool Mushrooms { get; set; }

        [Display(Name = "Masline")]
        public bool Olives { get; set; }

        [Display(Name = "Feferone")]
        public bool Peppers { get; set; }

    }
}
