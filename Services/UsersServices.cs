using Entities;
using Repository;

namespace Services
{
    public class UsersServices : IUsersRepository,IUsersServices
    {
        IUsersRepository _iUsersRepository;
        IPasswordService _iPasswordService;
        public UsersServices(IUsersRepository iUsersRepository, IPasswordService iPasswordService)
        {
            this._iUsersRepository = iUsersRepository;
            this._iPasswordService = iPasswordService;
        }


        public async Task<User> getUserById(int id)
        {
            return await  _iUsersRepository.getUserById(id);
        }
        public async Task<User> registerUser(User user)
        {
            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(user.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return await _iUsersRepository.registerUser(user);
        }
        public async Task<User> loginUser(UserLog userTolog)
        {
            return await _iUsersRepository.loginUser(userTolog);
        }
        public async Task<User> updateUser(User user, int id)
        {
            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(user.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return await _iUsersRepository.updateUser(user, id);
        }
    }
}
