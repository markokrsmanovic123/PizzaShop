using System.Security.Cryptography;

namespace PizzaShop.Models
{
    public class PieRepository : IPieRepository
    {
        public List<Pie> AllPies { get; set; }

        public Pie GetPieById(int pieId)
        {
            foreach (var pie in myPies) 
            {
                if (pie.PieId == pieId) return pie;
            }

            return null;
        }

        private List<Pie> myPies = new List<Pie>();

        public PieRepository() 
        {
            Pie p1 = new Pie();
            p1.PieId = 1;
            p1.Name = "Pita sa jabukama";
            p1.Description = "Mala pita s jabukama";
            p1.Price = 1.25;

            Pie p2 = new Pie();
            p2.PieId = 2;
            p2.Name = "Makovnjaca";
            p2.Description = "Velika strudla s makom";
            p2.Price = 8.35;

            Pie p3 = new Pie();
            p3.PieId = 3;
            p3.Name = "Burek";
            p3.Description = "Mastan burek sa sirom";
            p3.Price = 6.5;

            myPies.Add(p1);
            myPies.Add(p2);
            myPies.Add(p3);
        }
    }
}
