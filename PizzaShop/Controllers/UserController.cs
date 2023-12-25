using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;

namespace PizzaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignIn(User user)
        {
            return View(user);
        }

        public IActionResult Register(User user)
        {
            
            if (ModelState.IsValid)
            {
                var isExist = _userRepository.IsExist(user.Username);

                if (!isExist)
                {
                    _userRepository.CreateUser(user);

                    return View("Sucess");
                }
                else
                {
                    ModelState.AddModelError("", "Korisnicko ime " +  user.Username + " je zauzeto");
                    return View("Index", user);
                }
            }
            else
            {
                return View("Index", user);
            }
        }
    }
}
