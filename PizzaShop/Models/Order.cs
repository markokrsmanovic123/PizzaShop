namespace PizzaShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderPlaced { get; set; }
        public double OrderTotal { get; set; }
        public string PhoneNumber { get; set; }
    }
}
