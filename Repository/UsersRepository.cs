using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{

    public class UsersRepository : IUsersRepository
    {
        ShopContext _shopContext;
        public UsersRepository(ShopContext shopContext)
        {
            this._shopContext = shopContext;
        }
        public async Task<User> getUserById(int ind)
        {
            return await  _shopContext.Users.FirstOrDefaultAsync(x=>x.UserId==ind);
        }

        public async Task<User> registerUser(User user)
        {
            await _shopContext.Users.AddAsync(user);
            await _shopContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> loginUser(UserLog userToLog)
        {
            return await _shopContext.Users.FirstOrDefaultAsync
                (x => x.UserMail == userToLog.UserMail && x.Password == userToLog.password);
        }
        public async Task<User> updateUser(User userToUpdate, int id)
        {
            //await _shopContext.Users.ExecuteUpdateAsync(userToUpdate, id);
            _shopContext.Users.Update(userToUpdate);
            await _shopContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
