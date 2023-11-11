namespace PizzaShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public IEnumerable<Pie> PieList { get; set; }
    }
}
