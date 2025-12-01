using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repository
{

    public class UsersRepository : IUsersRepository
    {
        ShopContext ShopContext_;
        public UsersRepository( ShopContext shopContext )
        {
            this.ShopContext_ = shopContext;
        }
        public async Task<User> getUserById(int ind)
        {
            return await  ShopContext_.Users.FirstOrDefaultAsync(x=>x.UserId==ind);
        }

        public async Task<User> registerUser(User user)
        {
            await ShopContext_.Users.AddAsync(user);
            await ShopContext_.SaveChangesAsync();
            return user;
        }

        public async Task<User> loginUser(UserLog userToLog)
        {
            return await ShopContext_.Users.FirstOrDefaultAsync
                (x => x.UserMail == userToLog.userName && x.Password == userToLog.password);
        }
        public async Task<User> updateUser(User userToUpdate, int id)
        {
            //await ShopContext_.Users.ExecuteUpdateAsync(userToUpdate, id);
            ShopContext_.Users.Update(userToUpdate);
            await ShopContext_.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
