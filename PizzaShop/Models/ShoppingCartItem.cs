namespace PizzaShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
