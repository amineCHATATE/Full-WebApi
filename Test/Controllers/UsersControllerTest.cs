using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Repositories;

namespace Test.Controllers
{
    public class UsersControllerTest
    {
        private readonly IUserInterface _userRepository;
        private readonly UsersController _usersController;

        public UsersControllerTest()
        {
            _userRepository = A.Fake<IUserInterface>();
            _usersController = new UsersController(_userRepository);
        }

        private static User CreateFakeUser() => A.Fake<User>();

        // Create
        // POST: UsersController/Create
        // This method returned Created when successful | BadRequest when failed
        [Fact]
        public async Task UsersController_Create_ReturnsCreated_WhenSuccessful()
        {
            // Arrange
            var user = CreateFakeUser();
            A.CallTo(() => _userRepository.CreateUser(user)).Returns(true);
            // Act
            var result =(CreatedAtActionResult) await _usersController.Create(user);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Should().NotBeNull();

        }

        // Update
        // PUT: UsersController/Update
        // This method returned CreatedAtActionResult when successful | BadRequest when failed
        [Fact]
        public async Task UsersController_Update_ReturnsNoContent_WhenSuccessful()
        {
            // Arrange
            var user = CreateFakeUser();
            A.CallTo(() => _userRepository.UpdateUser(user)).Returns(true);
            // Act
            var result = (CreatedAtActionResult)await _usersController.Edit(user);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Should().NotBeNull();
        }

        // Delete
        // DELETE: UsersController/Delete
        // This method returned NoContentResult when successful | NotFound when user not found
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task UsersController_Delete_ReturnsNoContent_WhenSuccessful(int id)
        {
            // Arrange
            A.CallTo(() => _userRepository.DeleteUser(id)).Returns(true);
            // Act
            var result = (NoContentResult)await _usersController.DeleteAsync(id);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            result.Should().NotBeNull();
        }


        // Read all
        // GET: UsersController/GetAllUsers
        // This method returned Ok when successful | NotFound when no users found
        [Fact]
        public async Task UsersController_GetAllUsers_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var users = new List<User> { CreateFakeUser(), CreateFakeUser() };
            A.CallTo(() => _userRepository.GetAllUsers()).Returns(users);
            // Act
            var result = (OkObjectResult)await _usersController.GetAllUsers();
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(users);
            result.Should().NotBeNull();

        }

        // Read by id
        // GET: UsersController/GetUserById
        // This method returned Ok when successful | NotFound when user not found
        [Theory]
        [InlineData(1)]
        public async Task UsersController_GetUserById_ReturnsOk_WhenSuccessful(int id)
        {
            // Arrange
            var user = CreateFakeUser();
            user.Id = id;
            A.CallTo(() => _userRepository.GetUserById(1)).Returns(user);
            // Act
            var result = (OkObjectResult)await _usersController.GetUserById(1);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(user);
            result.Should().NotBeNull();

        }
    }
    
}
