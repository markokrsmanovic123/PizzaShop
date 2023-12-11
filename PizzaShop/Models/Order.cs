﻿namespace PizzaShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = default!;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
