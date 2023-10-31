namespace PizzaShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        Category GetCategoryById(int id);
    }
}
