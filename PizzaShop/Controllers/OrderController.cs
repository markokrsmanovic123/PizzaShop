using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShop.Models;
using System.Net;

namespace PizzaShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyf;


        public OrderController(IShoppingCart shoppingCart, IOrderRepository orderRepository, IUserRepository userRepository, INotyfService notyf)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userRepository = userRepository;
            _notyf = notyf;
        }

        public IActionResult Checkout()
        {
            var userCookie = Request.Cookies["User"];

            if (userCookie == null)
            {
                return RedirectToAction("Login", "User");
            }

            var user = JsonConvert.DeserializeObject<User>(userCookie!);

            var vm = new Order();

            vm.UserId = user.UserId;
            vm.Address = user.Address;
            vm.City = user.City;
            vm.PhoneNumber = user.PhoneNumber;
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.Email = user.Email;
            vm.Country = user.Country;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Vasa korpa je prazna!");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();

                _notyf.Success("Vasa porudzbina je uspesna!");

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.Message = "Uspesna porudzbina!";
            return View();
        }
    }
}
