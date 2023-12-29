using Microsoft.EntityFrameworkCore;
using PizzaShop.Helpers;
using PizzaShop.ViewModels;

namespace PizzaShop.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            user.Password = EncryptionHelper.Encrypt(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByUsername(string username) 
        {
            return _context.Users.FirstOrDefault(u => u.Username == username)!;
        }

        public User GetUserById(int userId) 
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId)!;
        }

        public User GetUsersWithPizzasByUserId(int userId) 
        {
            return _context.Users
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.OrderDetails)
                    .ThenInclude(od => od.Pizza)
                    .FirstOrDefault(u => u.UserId == userId)!;
        }

        public void UpdatePassword(User user, string newPassword) 
        {
            user.Password = EncryptionHelper.Encrypt(newPassword);

            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}
