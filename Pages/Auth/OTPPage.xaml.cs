using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace ecommerce_app.Pages.Auth
{
    public partial class OTPPage : ContentPage
    {
        private readonly string _email;
        private readonly HttpClient _httpClient = new();

        public OTPPage(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void OnVerifyOtpClicked(object sender, EventArgs e)
        {
            var otp = OtpEntry.Text?.Trim();
            if (string.IsNullOrEmpty(otp))
            {
                OtpStatusLabel.Text = "Please enter the OTP.";
                OtpStatusLabel.IsVisible = true;
                return;
            }

            if (otp.Length != 6)
            {
                OtpStatusLabel.Text = "OTP must be 6 characters long.";
                OtpStatusLabel.IsVisible = true;
                return;
            }

            var payload = new { email = _email, otp };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("http://192.168.0.100:3011/api/v1/users/verify-otp", content);
                var body = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "OTP verified!", "OK");
                    // Navigate to the main app page or dashboard
                }
                else
                {
                    var error = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
                    var message = error != null && error.TryGetValue("message", out var msg) ? msg : "OTP verification failed.";
                    OtpStatusLabel.Text = message;
                    OtpStatusLabel.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                OtpStatusLabel.Text = $"Network error: {ex.Message}";
                OtpStatusLabel.IsVisible = true;
            }
        }
    }
}