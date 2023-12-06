using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Runtime.CompilerServices;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public PizzaController (IPizzaRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(int? categoryId)
        {
            IEnumerable<Pizza> pizzas;
            string? category = "Sve Pice";

            if (categoryId > 0)
            {
                pizzas = _repository.Pizzas.Where(p => p.Category.Id == categoryId).OrderBy(p => p.Id).ToList();
                category = _categoryRepository.GetCategoryById(categoryId).Name;
            }
            else 
            {
                pizzas = _repository.Pizzas.OrderBy(p => p.Id);
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
    }
}
