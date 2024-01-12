using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Models
{
    public class PizzaRepository : IPizzaRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public PizzaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Pizza GetPizzaById(int id)
        {
            return _applicationDbContext.Pizzas.Include(p => p.Category).FirstOrDefault(p => p.Id == id)!;
        }

        public IEnumerable<Pizza> Pizzas
        {
            get
            {
                return _applicationDbContext.Pizzas.Include(p => p.Category);
            }
        }

        public void SavePizza(Pizza pizza)
        {
            _applicationDbContext.Pizzas.Add(pizza);
            _applicationDbContext.SaveChanges();
        }



    }
}
