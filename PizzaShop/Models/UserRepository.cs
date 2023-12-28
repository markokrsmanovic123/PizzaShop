using PizzaShop.Helpers;

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
    }
}
