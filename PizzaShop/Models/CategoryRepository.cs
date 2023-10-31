namespace PizzaShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories { get; }

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
