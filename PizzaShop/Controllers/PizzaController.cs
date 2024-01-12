using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public PizzaController(IPizzaRepository repository, ICategoryRepository categoryRepository, 
            IUserRepository userRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public ViewResult List(int? categoryId)
        {
            IEnumerable<Pizza> pizzas;
            string? category = "Sve Pice";
            int? specialCategoryId = _repository.Pizzas.FirstOrDefault(x => x.Category.Name == "Pizze korisnika")!.Category.Id;

            if (categoryId > 0)
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.Id == categoryId).OrderBy(p => p.Id).ToList();
                category = _categoryRepository.GetCategoryById(categoryId).Name;
            }
            else
            {
                pizzas = _repository.Pizzas.OrderBy(p => p.Id).Where(p => p.Category.Id != specialCategoryId);
            }

            if (category == "Pizze korisnika")
            {
                return View("UserPizzas", new PizzaListViewModel(pizzas, category));
            }


            return View(new PizzaListViewModel(pizzas, category));
        }

        public ViewResult Details(int id)
        {
            Pizza p = _repository.GetPizzaById(id);

            return View(p);
        }

        public IActionResult Index()
        {
            ViewBag.Uslov = false;
            ViewBag.Message = "Ovo je server-side poruka.";
            ViewBag.Message2 = "Ovo je druga poruka";
            return View();
        }

        public IActionResult CustomPizza()
        {
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                var user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

            var vm = new PizzaCustomViewModel();
            return View(vm);
        }

        public IActionResult CreateCustomPizza(PizzaCustomViewModel customPizza)
        {
            List<string> ingredients = new List<string>();

            var properties = typeof(PizzaCustomViewModel).GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    var value = (bool)property.GetValue(customPizza)!;

                    if (value)
                    {
                        var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;

                        var nameOfAttr = displayAttribute?.Name;

                        ingredients.Add(nameOfAttr ?? property.Name);
                    }
                }
            }

            var userCookie = Request.Cookies["User"];
            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            var pizza = new Pizza()
            {
                Name = customPizza.PizzaName,
                Category = _categoryRepository.GetAllCategories().FirstOrDefault(c => c.Name == "Pizze korisnika")!,
                ShortDescription = string.Join(", ", ingredients),
                LongDescription = string.Join(", ", ingredients),
                Price = 14.99m,
                IsPizzaOfTheWeek = false,
                InStock = true,
                ImageThumbnailUrl = String.Empty,
                ImageUrl = String.Empty,
                UserID = user!.UserId
            };

            _repository.SavePizza(pizza);

            return RedirectToAction("Profile", "User");
        }
    }
}
