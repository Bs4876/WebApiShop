using Entities;
using Repository;

namespace Services
{
    public class UsersServices
    {
        UsersRepository repository = new UsersRepository();

        PasswordService passwordService = new PasswordService();
        public User getUserById(int id)
        {
            return repository.getUserById(id);
        }
        public User registerUser(User user)
        {
            CheckPassowrd checkPassowrd = passwordService.checkStrengthPassword(user.password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return repository.registerUser(user);
        }
        public User loginUser(UserLog userTolog)
        {
            return repository.loginUser(userTolog);
        }
        public void updateUser(User user, int id)
        {
            repository.updateUser(user,id);
        }
    }
}
