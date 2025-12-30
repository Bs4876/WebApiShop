using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class UserIntegrationTests : IClassFixture<DataBaseFixture>
    {
        private readonly UsersRepository _usersRepository;
        private readonly DataBaseFixture _fixture;

        public UserIntegrationTests(DataBaseFixture fixture)
        {
            _fixture = fixture;
            _usersRepository = new UsersRepository(_fixture.Context);
        }

        [Fact]
        public async Task RegisterUser_SavesUserToDatabase()
        {
            // Arrange
            var user = new User
            {
                FirstName = "Jane",
                LastName = "Doe",
                UserMail = "JaneD",
                Password = "SecurePassword"
            };

            // Act
            var result = await _usersRepository.registerUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserMail, result.UserMail);

            var savedUser = await _fixture.Context.Users.FirstOrDefaultAsync(x => x.UserId == result.UserId);
            Assert.NotNull(savedUser);
            Assert.Equal(user.UserMail, savedUser.UserMail);
        }

        [Fact]
        public async Task GetUserById_ReturnsUserWhenExists()
        {
            // Arrange
            var user = new User
            {
                FirstName = "Existing",
                LastName = "User",
                UserMail = "ExistingUser",
                Password = "Password123"
            };

            await _usersRepository.registerUser(user);

            // Act
            var fetchedUser = await _usersRepository.getUserById(user.UserId);

            // Assert
            Assert.NotNull(fetchedUser);
            Assert.Equal(user.UserId, fetchedUser.UserId);
            Assert.Equal(user.UserMail, fetchedUser.UserMail);
        }

        [Fact]
        public async Task LoginUser_ReturnsUserWhenValidCredentials()
        {
            // Arrange
            var user = new User
            {
                FirstName = "Login",
                LastName = "User",
                UserMail = "LoginUser",
                Password = "UserPassword"
            };

            await _usersRepository.registerUser(user);

            var userToLog = new UserLog
            {
                UserMail = user.UserMail,
                password = user.Password
            };

            // Act
            var loggedUser = await _usersRepository.loginUser(userToLog);

            // Assert
            Assert.NotNull(loggedUser);
            Assert.Equal(user.UserMail, loggedUser.UserMail);
        }

        [Fact]
        public async Task UpdateUser_UpdatesUserInDatabase()
        {
            // Arrange
            var user = new User { FirstName = "UserToUpdate", LastName = "UserLastName", UserMail = "ToUpdate", Password = "OldPassword" };
            var registeredUser = await _usersRepository.registerUser(user);

            registeredUser.FirstName = "UpdatedFirstName";
            registeredUser.LastName = "UpdatedLastName";

            // Act
            var updatedUser = await _usersRepository.updateUser(registeredUser, registeredUser.UserId);

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal("UpdatedFirstName", updatedUser.FirstName);
            Assert.Equal("UpdatedLastName", updatedUser.LastName);

            var fetchedUser = await _usersRepository.getUserById(registeredUser.UserId);
            Assert.Equal("UpdatedFirstName", fetchedUser.FirstName);
            Assert.Equal("UpdatedLastName", fetchedUser.LastName);
        }
    }
}
