using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;

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
            return View(new LoginViewModel());
        }

        public IActionResult SignIn(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            var isExist = _userRepository.IsExist(user.Username);

            if (isExist) 
            {
                var isPasswordOk = _userRepository.IsPasswordOk(user.Password);

                if (isPasswordOk)
                {
                    return RedirectToAction("SignInSuccess");
                }
            }

            ModelState.AddModelError("", "Neispravni kredencijali");

            return View("Login", user);
        }

        public IActionResult SignInSuccess()
        {
            return View();
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
