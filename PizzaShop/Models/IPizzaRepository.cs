namespace PizzaShop.Models
{
    public interface IPizzaRepository
    {

        Pizza GetPizzaById(int PieId);

        IEnumerable<Pizza> Pizzas { get; }
    }
}
