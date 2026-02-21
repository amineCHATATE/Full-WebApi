using WebApi.Models;

namespace WebApi.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User?> GetUserById(int id);
        public Task<bool> DeleteUser(int id);
        public Task<bool> UpdateUser(User user);        
        public Task<bool> CreateUser(User user);

    }
}
