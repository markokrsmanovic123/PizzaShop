using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;
using System.Diagnostics;


namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Index()
        {
            var pizzasOfTheWeek = _pizzaRepository.Pizzas.Where(p => p.IsPizzaOfTheWeek == true).ToList();

            return View(new HomeViewModel(pizzasOfTheWeek));
        }

        public IActionResult Pretplata()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAction(int? id)
        {
            if (id == 1)
            {
                throw new Exception("File not found");
            }
            if (id == 2)
            {
                return StatusCode(500);
            }

            return View();
        }
    }
}