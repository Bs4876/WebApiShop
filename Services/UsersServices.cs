using Entities;
using Repository;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        IUsersRepository _usersRepository;
        IPasswordService _passwordService;
        public UsersServices(IUsersRepository usersRepository, IPasswordService passwordService)
        {
            this._usersRepository = usersRepository;
            this._passwordService = passwordService;
        }


        public async Task<User> getUserById(int id)
        {
            return await  _usersRepository.getUserById(id);
        }
        public async Task<User> registerUser(User user)
        {
            CheckPassowrd checkPassowrd = _passwordService.checkStrengthPassword(user.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return await _usersRepository.registerUser(user);
        }
        public async Task<User> loginUser(UserLog userTolog)
        {
            return await _usersRepository.loginUser(userTolog);
        }
        public async Task<User> updateUser(User user, int id)
        {
            CheckPassowrd checkPassowrd = _passwordService.checkStrengthPassword(user.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return await _usersRepository.updateUser(user, id);
        }
    }
}
