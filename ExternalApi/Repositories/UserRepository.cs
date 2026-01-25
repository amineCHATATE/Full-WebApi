using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository(ApiDBContext _dBContext) : IUserRepository
    {
        public async Task<bool> CreateUser(User user)
        {
            await _dBContext.Users.AddAsync(user);
            var saved = await _dBContext.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var oldUser = await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (oldUser != null)
            {
                _dBContext.Users.Remove(oldUser);

                var saved = await _dBContext.SaveChangesAsync();
                return saved > 0;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers() => await _dBContext.Users.ToListAsync();

        public async Task<User?> GetUserById(int id) => await _dBContext.Users.FindAsync(id);

        public async Task<bool> UpdateUser(User user)
        {
            var oldUser = await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (oldUser != null)
            {
                oldUser.Name = user.Name;
                oldUser.Email = user.Email;
                _dBContext.Update(oldUser);
                var saved = await _dBContext.SaveChangesAsync();
                return saved > 0;
            }
            return false;
        }
    }
}
