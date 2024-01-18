namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {

        Pizza GetPizzaById(int PieId);
        void SavePizza(Pizza pizza);

        void DeletePizza(int pizzaId);

        public List<Pizza> GetUsersPizzas(int userId);
        void UpdatePizza(Pizza pizza);

        IEnumerable<Pizza> Pizzas { get; }
    }
}
