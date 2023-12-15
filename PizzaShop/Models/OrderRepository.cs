namespace PizzaShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext context, IShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    PizzaId = item.Pizza.Id,
                    Price = item.Pizza.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
