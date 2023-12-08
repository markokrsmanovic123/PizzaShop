using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using PizzaShop.ViewModels;

namespace PizzaShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IPizzaRepository _pizzaRepository;

        public ShoppingCartController(IShoppingCart shoppingCart, IPizzaRepository pizzaRepository)
        {
            _shoppingCart = shoppingCart;
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pizzaId)
        {
            var selectedPizza = _pizzaRepository.GetPizzaById(pizzaId);

            if (selectedPizza != null)
            {
                _shoppingCart.AddToCart(selectedPizza);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pizzaId)
        {
            var selectedPizza = _pizzaRepository.GetPizzaById(pizzaId);

            if (selectedPizza != null)
            {
                _shoppingCart.RemoveFromCart(selectedPizza);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();

            return RedirectToAction("Index");
        }
    }
}
