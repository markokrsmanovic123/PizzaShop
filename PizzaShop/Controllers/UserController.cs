﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Helpers;
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

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Neispravni kredencijali");

            return View("Login", user);
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
                    return View("Sucess");
                }
                else
                {
                    ModelState.AddModelError("", "Korisnicko ime " + userVM.Username + " je zauzeto");
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
            if (Request.Cookies["User"] != null)
            {
                Response.Cookies.Delete("User");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            User user = new User();
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie != null)
            {
                user = JsonConvert.DeserializeObject<User>(userCookie)!;
            }

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
                ModelState.AddModelError("", "Korisnicko ime nije ispravno!");
                return View("Profile", model);
            }

            if (user.Password == EncryptionHelper.Encrypt(model.CurrentPassword))
            {
                _userRepository.UpdatePassword(user, model.NewPassword);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Password nije ispravan");
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