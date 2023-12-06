namespace PizzaShop.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int? categoryId);
    }
}
