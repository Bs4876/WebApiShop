using Entities;
using Moq;
using Repository;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class UserUnitTest
    {
        private readonly Mock<IUsersRepository> _mockRepository;

        public UserUnitTest()
        {
            _mockRepository = new Mock<IUsersRepository>();
        }

        [Fact]
        public async Task GetUserById_ReturnsUserWhenUserExists()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Test", LastName = "User", UserMail = "TestUser", Password = "Password" };
            _mockRepository.Setup(repo => repo.getUserById(1)).ReturnsAsync(user);

            // Act
            var result = await _mockRepository.Object.getUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.UserId);
            Assert.Equal("Test", result.FirstName);
            Assert.Equal("User", result.LastName);
            Assert.Equal("TestUser", result.UserMail);
        }

        [Fact]
        public async Task GetUserById_ReturnsNullWhenUserDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.getUserById(2)).ReturnsAsync((User)null);

            // Act
            var result = await _mockRepository.Object.getUserById(2);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task RegisterUser_ReturnsRegisteredUser()
        {
            // Arrange
            var user = new User { FirstName = "John", LastName = "Doe", UserMail = "JohnD", Password = "Password123" };
            _mockRepository.Setup(repo => repo.registerUser(user)).ReturnsAsync(user);

            // Act
            var result = await _mockRepository.Object.registerUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("JohnD", result.UserMail);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public async Task LoginUser_ReturnsUserWhenCredentialsAreValid()
        {
            // Arrange
            var userToLog = new UserLog { UserMail = "TestUser", password = "Password" };
            var user = new User { UserMail = "TestUser", Password = "Password" };

            _mockRepository.Setup(repo => repo.loginUser(userToLog)).ReturnsAsync(user);

            // Act
            var result = await _mockRepository.Object.loginUser(userToLog);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserMail, result.UserMail);
        }
    }
}