namespace PizzaShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
        public double Total { get; set; }
    }
}
