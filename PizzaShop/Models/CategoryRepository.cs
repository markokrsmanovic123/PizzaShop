using System.Security.Cryptography.Xml;

namespace PizzaShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories { get; }
        private List<Category> _categories = new List<Category>();

        
        public CategoryRepository() 
        {
            Category c1 = new Category { CategoryId = 1, CategoryName = "Pice sa mesom", CategoryDescription = "Opis za prvu kategoriju" };
            Category c2 = new Category { CategoryId = 2, CategoryName = "Veganske pice", CategoryDescription = "Opis za drugu kategoriju" };
            Category c3 = new Category { CategoryId = 3, CategoryName = "Pice bez glutena", CategoryDescription = "Opis za trecu kategoriju" };
            _categories.Add(c1);
            _categories.Add(c2);
            _categories.Add(c3);
        }
        
        public List<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            foreach (var category in Categories) 
            {
                if (category.CategoryId == categoryId)
                {
                    return category;
                }
                
            }

            return null;
        }
    }
}
