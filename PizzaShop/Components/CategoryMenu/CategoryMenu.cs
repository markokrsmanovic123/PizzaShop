using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PizzaShop.Models;

namespace PizzaShop.Components.CategoryMenu
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.Name).ToList();
            
            var userCookie = HttpContext!.Request.Cookies["User"];

            if (userCookie == null)
            {
                var categoryToRemove = categories.Single(c => c.Name == "Pizze korisnika");
                categories.Remove(categoryToRemove);
            }

            return View(categories);
        }
    }
}