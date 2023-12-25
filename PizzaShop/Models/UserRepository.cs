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
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsExist(string username)
        {
            if(_context.Users.FirstOrDefault(u => u.Username == username) == null)
            {
                return false;
            }
            return true;
        }
    }
}
