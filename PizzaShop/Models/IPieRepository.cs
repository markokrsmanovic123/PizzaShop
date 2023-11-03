namespace PizzaShop.Models
{
    public interface IPieRepository
    {
        List<Pie> AllPies { get; }

        Pie GetPieById (int PieId);
    }
}
