using System.Security.Cryptography.Xml;

namespace PizzaShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int? categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == categoryId)!;
        }
    }
}
