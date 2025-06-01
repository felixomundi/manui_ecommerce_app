
using System.Text.Json;
using ecommerce_app.Models;
namespace ecommerce_app.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("users");
            if (!response.IsSuccessStatusCode)
            {
                // Log error or throw
                return new List<User>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return users ?? new List<User>();
        }
    }
}
