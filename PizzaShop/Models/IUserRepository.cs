namespace PizzaShop.Models
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void UpdatePassword(User user, string password);
        User GetUsersWithPizzasByUserId(int userId);
    }
}
