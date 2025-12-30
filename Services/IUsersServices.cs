using DTOs;
using Entities;

namespace Services
{
    public interface IUsersServices
    {
        Task<UserDTO> getUserById(int id);
        Task<UserDTO> loginUser(UserLog userTolog);
        Task<UserDTO> registerUser(UserToRegisterDTO userToRegister);
        Task<UserDTO> updateUser(UserToRegisterDTO userToUpdate, int id);
    }
}