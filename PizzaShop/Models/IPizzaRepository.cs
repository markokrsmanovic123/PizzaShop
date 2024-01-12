namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {

        Pizza GetPizzaById(int PieId);
        void SavePizza(Pizza pizza);

        IEnumerable<Pizza> Pizzas { get; }
    }
}
