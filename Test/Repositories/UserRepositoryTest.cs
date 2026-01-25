using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace Test.Repositories
{
    public class UserRepositoryTest
    {
        private readonly UserImpl _userRepository;

        public UserRepositoryTest()
        {
            var dbContext = GetDatabaseContext().GetAwaiter().GetResult();
            _userRepository = new UserImpl(dbContext);
        }

        private async Task<ApiDBContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApiDBContext>()
                .UseSqlite("Data Source=UnitTestDB.db")
                .Options;
            var _apiDBContext = new ApiDBContext(options);
            _apiDBContext.Database.EnsureCreated();

            if (!await _apiDBContext.Users.AnyAsync())
            {
                _apiDBContext.Users.Add(
                    new WebApi.Models.User()
                    {
                        Name = $"amine",
                        Email = $"amine@mail.com"
                    });

                await _apiDBContext.SaveChangesAsync();
            }
            return _apiDBContext;
        }

        // Create
        // POST: UserRepository/CreateUser
        // Returns: True if the user was created successfully, otherwise false.
        [Fact]
        public async Task UserRepository_CreateUser_ReturnsTrue_WhenSuccessful()
        {
            // Arrange
            var user = A.Fake<User>();

            // Act
            var result = await _userRepository.CreateUser(user);

            // Assert
            result.Should().BeTrue();

        }

        // Update
        // PUT: UserRepository/UpdateUser
        // Returns: True if the user was updated successfully, otherwise false.
        [Theory]
        [InlineData(1)]
        public async Task UserRepository_UpdateUser_ReturnsTrue_WhenSuccessful(int id)
        {
            // Arrange
            var user = await _userRepository.GetUserById(id);
            user!.Name = "Updated Name";
            // Act
            var result = await _userRepository.UpdateUser(user);
            // Assert
            result.Should().BeTrue();
            
        }

        // Delete
        // DELETE: UserRepository/DeleteUser
        // Returns: True if the user was deleted successfully, otherwise false.
        [Theory]
        [InlineData(1)]
        public async Task UserRepository_DeleteUser_ReturnsTrue_WhenSuccessful(int userId)
        {
            // Act
            var result = await _userRepository.DeleteUser(userId);
            // Assert
            result.Should().BeTrue();
        }

        // Get By Id
        // GET: UserRepository/GetUserById
        // Returns: The user with the specified ID, or null if not found.
        [Theory]
        [InlineData(2)]
        public async Task UserRepository_GetUserById_ReturnsUser_WhenSuccessful(int userId)
        {
            // Act
            var result = await _userRepository.GetUserById(userId);
            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(userId);
        }

        // Get All
        // GET: UserRepository/GetAllUsers
        // Returns: A collection of all users.
        [Fact]
        public async Task UserRepository_GetAllUsers_ReturnsUsers_WhenSuccessful()
        {
            // Act
            var result = await _userRepository.GetAllUsers();
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<User>>();
            result.Should().NotBeEmpty();

        }
    }

}
