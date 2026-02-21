using FakeItEasy;
using FluentAssertions;
using Test.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace Test.Services
{
    public class UserServicesTest
    {

        // Create
        // POST: UserService/CreateUser
        // Returns: True if the user was created successfully, otherwise false.
        [Fact]
        public async Task UserService_CreateUser_ReturnTrueAsync()
        {
            var user = A.Fake<User>();

            var client = CustomFakeHttpClient.FakeHttpClient<bool>(true);
            var userService = new UserService(client);
            var result = await userService.CreateUser(user);
            client.Dispose();

            result.Should().BeTrue();
        }

        // Read all
        // GET: UserService/GetAllUsers
        // Returns: A list of all users.
        [Fact]
        public async Task UserService_GetAllUsers_ReturnUsersAsync()
        {
            var users = A.Fake<List<User>>();
            users.Add(new User() { Id = 1, Email = "mail@m.c", Name = "Jalal" });
            var client = CustomFakeHttpClient.FakeHttpClient<List<User>>(users);
            var userService = new UserService(client);

            var result = await userService.GetAllUsers();
            client.Dispose();

            result.Should().BeEquivalentTo(users);
            result.Should().NotBeEmpty();
            result.Should().AllBeOfType<User>();
        }

        // Read by id
        [Theory]
        [InlineData(1)]
        public async Task UserService_GetUserById_ReturnUserAsync(int id)
        {
            var user = A.Fake<User>();
            user.Id = 1;
            user.Email = "mail@m.c";
            user.Name = "Jalal";

            var client = CustomFakeHttpClient.FakeHttpClient<User>(user);
            var userService = new UserService(client);
            var result = await userService.GetUserById(1);
            client.Dispose();

            result.Should().BeEquivalentTo(user);
            result.Should().NotBeNull();
            result.Should().BeOfType<User>();
        }

        // Update
        [Fact]
        public async Task UserService_UpdateUser_ReturnTrueAsync()
        {
            var user = A.Fake<User>();
            user.Id = 1;
            user.Email = "mail@m.c";
            user.Name = "Jalal";

            var client = CustomFakeHttpClient.FakeHttpClient<bool>(true);
            var userService = new UserService(client);
            var result = await userService.UpdateUser(user);
            client.Dispose();

            result.Should().BeTrue();
        }

        // Delete
        [Fact]
        public async Task UserService_DeleteUser_ReturnTrueAsync()
        {
            var client = CustomFakeHttpClient.FakeHttpClient<bool>(true);
            var userService = new UserService(client);
            var result = await userService.DeleteUser(1);
            client.Dispose();

            result.Should().BeTrue();
        }
    }
}
