using AutoMapper;
using DTOs;
using Entities;
using Repository;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        IUsersRepository _iUsersRepository;
        IPasswordService _iPasswordService;
        IMapper _mapper;

        public UsersServices(IUsersRepository iUsersRepository, IPasswordService iPasswordService, IMapper mapper)
        {
            this._iUsersRepository = iUsersRepository;
            this._iPasswordService = iPasswordService;
            this._mapper = mapper;
        }


        public async Task<UserDTO> getUserById(int id)
        {
           User user= await  _iUsersRepository.getUserById(id);
           return _mapper.Map<User, UserDTO>(user);
           
        }
        public async Task<UserDTO> registerUser(UserToRegisterDTO userToRegister)
        {

            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(userToRegister.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            User user = _mapper.Map<UserToRegisterDTO, User>(userToRegister);
            user= await _iUsersRepository.registerUser(user);
            return _mapper.Map<User, UserDTO>(user);
        }
        public async Task<UserDTO> loginUser(UserLog userTolog)
        {
            User user = await _iUsersRepository.loginUser(userTolog);
            return _mapper.Map<User, UserDTO>(user);
        }
        public async Task<UserDTO> updateUser(UserToRegisterDTO userToUpdate, int id)
        {
            CheckPassowrd checkPassowrd = _iPasswordService.checkStrengthPassword(userToUpdate.Password);
            if (checkPassowrd.strength < 2)
            {
                return null;
            }
            User user = _mapper.Map<UserToRegisterDTO, User>(userToUpdate);
            user.UserId=id;
            user = await _iUsersRepository.updateUser(user, id);
            return _mapper.Map<User, UserDTO>(user);
        }
    }
}
