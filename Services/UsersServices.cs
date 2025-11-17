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


        public User getUserById(int id)
        {
            return _iUsersRepository.getUserById(id);
        }
        public User registerUser(User user)
        {
            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(user.password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return _iUsersRepository.registerUser(user);
        }
        public User loginUser(UserLog userTolog)
        {
            return _iUsersRepository.loginUser(userTolog);
        }
        public User updateUser(User user, int id)
        {
            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(user.password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            return _iUsersRepository.updateUser(user, id);
        }
    }
}
