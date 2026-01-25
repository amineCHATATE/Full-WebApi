using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService : IUserService
    {

        // Users/GetUserById, Users/GetAllUsers, Users/Create, Users/Edit/5, Users/Delete/5
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5079");
        }

        public async Task<bool> CreateUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("/Users/Create", user);
            if (response.IsSuccessStatusCode)
                return true;
            
            return false;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Users/Delete/{id}");
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

         public async Task<IEnumerable<User>?> GetAllUsers() => await _httpClient.GetFromJsonAsync<IEnumerable<User>>($"/Users/GetAllUsers/");

        public async Task<User?> GetUserById(int id) => await _httpClient.GetFromJsonAsync<User>($"/Users/GetUserById/{id}");

        public async Task<bool> UpdateUser(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"/Users/Edit/{user.Id}", user);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
