using System.Security.Cryptography;
using System.Xml.Linq;

namespace PizzaShop.Models
{
    public class PieRepository : Category, IPieRepository
    {
        public List<Pie> AllPies
        {
            get { return myPies; }
        }

        public Pie GetPieById(int pieId)
        {
            foreach (var pie in myPies) 
            {
                if (pie.PieId == pieId) return pie;
            }

            return null;
        }

        private List<Pie> myPies = new List<Pie>();
        private List<Category> Categories = new List<Category>();


        public PieRepository() 
        {
            Category c1 = new Category {CategoryId = 1, CategoryName = "Pice sa mesom", CategoryDescription = "Opis za prvu kategoriju"};
            Category c2 = new Category {CategoryId = 2, CategoryName = "Veganske pice", CategoryDescription = "Opis za drugu kategoriju"};
            Category c3 = new Category {CategoryId = 3, CategoryName = "Pice bez glutena", CategoryDescription = "Opis za trecu kategoriju"};
            Categories.Add(c1);
            Categories.Add(c2);
            Categories.Add(c3);

            Pie p1 = new Pie { PieId = 1, Name = "Pita sa jabukama", Description = "Mala pita sa jabukama", Price = 1.25, IsPieOfTheWeek = false, InStock = true, Category = c2};
            Pie p2 = new Pie { PieId = 2, Name = "Makovnjaca", Description = "Velika struddla sa makom", Price = 8.35, IsPieOfTheWeek = false, InStock = true, Category = c2 };
            Pie p3 = new Pie { PieId = 3, Name = "Burek", Description = "Mastan burek sa sirom", Price = 6.5, IsPieOfTheWeek = true, InStock = true, Category = c1 };
            Pie p4 = new Pie { PieId = 4, Name = "Cheese Pizza", Description = "Pica sa sirom", Price = 4.2, IsPieOfTheWeek = false, InStock = true, Category = c1 };
            Pie p5 = new Pie { PieId = 5, Name = "Pepperoni Pizza", Description = "Ljuta ko djavo", Price = 5.4, IsPieOfTheWeek = false, InStock = true, Category = c1 };
            Pie p6 = new Pie { PieId = 6, Name = "Veganska Pizza", Description = "Vocna, mocna i socna", Price = 7, IsPieOfTheWeek = false, InStock = true, Category = c2 };
            Pie p7 = new Pie { PieId = 7, Name = "Pizza Bezkalorianna", Description = "Sa podlogom od patlidzana za dusu je hrana", Price = 6.6, IsPieOfTheWeek = true, InStock = true, Category = c3 };
            Pie p8 = new Pie { PieId = 8, Name = "Quattro Formaggi", Description = "Cetiri vrste sira da stomak iskulira", Price = 3.6, IsPieOfTheWeek = true, InStock = true, Category = c1 };
            Pie p9 = new Pie { PieId = 9, Name = "Vesuvio", Description = "Eksplozija ukusa", Price = 5.8, IsPieOfTheWeek = false, InStock = true, Category = c1 };
            Pie p10 = new Pie { PieId = 10, Name = "Quattro Stagioni", Description = "Cetiri godisnja doba na tanjiru", Price = 5.8, IsPieOfTheWeek = false, InStock = true, Category = c1 };

            myPies.Add(p1);
            myPies.Add(p2);
            myPies.Add(p3);
            myPies.Add(p4);
            myPies.Add(p5);
            myPies.Add(p6);
            myPies.Add(p7);
            myPies.Add(p8);
            myPies.Add(p9);
            myPies.Add(p10);
        }
    }
}
