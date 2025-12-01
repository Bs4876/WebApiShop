using Entities;

namespace Services
{
    public interface IUsersServices
    {
        Task<User> getUserById(int id);
        Task<User> loginUser(UserLog userTolog);
        Task<User> registerUser(User user);
        Task<User> updateUser(User user, int id);
    }
}