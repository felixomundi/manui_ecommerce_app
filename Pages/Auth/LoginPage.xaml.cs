using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace ecommerce_app.Pages.Auth
{
    public partial class LoginPage : ContentPage
    {
        private readonly HttpClient _httpClient = new();

        public LoginPage()
        {
            InitializeComponent();
        }
        public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static string TodoItemsUrl = $"{BaseAddress}/api/todoitems/";

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text?.Trim();
            var password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                StatusLabel.Text = "Please enter email and password.";
                StatusLabel.IsVisible = true;
                return;
            }
            var payload = new
            {
                email = email,
                password = password
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            string errorMessage = "Login failed.";

            try
            {
                const string BASE_URL = "http://192.168.0.100:3011";
                var response = await _httpClient.PostAsync($"{BASE_URL}/api/v1/users/login", content);
                var body = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    // Handle response as needed (e.g. parse JWT, navigate, etc.)
                    await DisplayAlert("Success", "Login successful!", "OK");
                    // Example: Navigate to main page
                    await Navigation.PushAsync(new ecommerce_app.Pages.Auth.OTPPage(email));

                }
                else
                {

                    StatusLabel.Text = "Login failed. Check credentials.";
                    StatusLabel.IsVisible = true;
                    var error = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
                    if (error != null && error.TryGetValue("message", out var message))
                    {
                        errorMessage = message;
                    }
                    StatusLabel.Text = errorMessage;
                    StatusLabel.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Error: {ex.Message}";
                StatusLabel.IsVisible = true;
            }
        }
    }
}
