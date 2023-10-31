namespace PizzaShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories { get; }

        public Category GetCategoryById(int id)
        {
            return Categories.FirstOrDefault(); //default
        }
    }
}
