using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Helpers;
using PizzaShop.Models;
using PizzaShop.TagHelpers;
using PizzaShop.ViewModels;

namespace PizzaShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyf;

        public UserController(IUserRepository userRepository, INotyfService notyf)
        {
            _userRepository = userRepository;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult SignIn(LoginViewModel loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginUser);
            }

            var user = _userRepository.GetUserByUsername(loginUser.Username);

            if (user != null)
            {
                var isPasswordOk = EncryptionHelper.Encrypt(loginUser.Password) == user.Password ? true : false;

                if (isPasswordOk)
                {
                    user.Password = "";
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(1);
                    var serializedUser = JsonConvert.SerializeObject(user);
                    Response.Cookies.Append("User", serializedUser, cookieOptions);

                    _notyf.Custom($"Dobro dosao, {user.Username}!", 10, "#a593c2", "fa fa-check");

                    return RedirectToAction("Index", "Home");
                }
            }

            _notyf.Error("Vasi kredencijali su neispravni!");

            return View("Login", loginUser);
        }

        public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
        {   
            var user = _userRepository.GetUserByUsername(userRegisterViewModel.Username);

            User userVM = new User()
            {
                UserId = userRegisterViewModel.UserId,
                Username = userRegisterViewModel.Username,
                Password = userRegisterViewModel.Password,
                FirstName = userRegisterViewModel.FirstName,
                LastName = userRegisterViewModel.LastName,
                Address = userRegisterViewModel.Address,
                City = userRegisterViewModel.City,
                Country = userRegisterViewModel.Country,
                PhoneNumber = userRegisterViewModel.PhoneNumber,
                Email = userRegisterViewModel.Email,
            };


            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    _userRepository.CreateUser(userVM);

                    _notyf.Success("Uspesno ste se registrovali!");

                    return View("Sucess");
                }
                else
                {
                    _notyf.Error($"Korisnicko ime {userVM.Username} je zauzeto!");

                    return View("Index", userVM);
                }
            }
            else
            {
                return View("Index", userVM);
            }
        }
        public IActionResult Logout()
        {
            if (HttpContext!.User!.Identity!.IsAuthenticated)
            {
                Response.Cookies.Delete("User");
            }

            _notyf.Success("Uspesno ste se izlogovali");

            return RedirectToAction("Index", "Home");
        }

        [TypeFilter(typeof(UserExceptionFilter))]
        public IActionResult Profile()
        {
            User user = new User();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userCookie = HttpContext!.Request.Cookies["User"];
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

            //throw new Exception($"Cookie za korisnika {user.Username} nije pronadjen! Ovaj exception je vestacki izazvan.");

            var vm = new UpdateUserViewModel()
            {
                Id = user.UserId,
                Username = user.Username
            };

            return View(vm);
        }

        public IActionResult ChangePassword(UpdateUserViewModel model)
        {
            var user = _userRepository.GetUserById(model.Id);

            if (model.Username != user.Username)
            {
                return View("Profile", model);
            }

            if (user.Password == EncryptionHelper.Encrypt(model.CurrentPassword))
            {
                _userRepository.UpdatePassword(user, model.NewPassword);

                _notyf.Success("Vasa lozinka je uspesno promenjena!");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                _notyf.Error("Lozinka nije ispravna!");

                return View("Profile", model);
            }
        }

        public IActionResult OrderHistory(User user) 
        {
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

            var usersOrders = _userRepository.GetUsersWithPizzasByUserId(user.UserId);

            return View(usersOrders);
        }
    }
}
