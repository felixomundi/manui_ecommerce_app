namespace ecommerce_app.Pages.Auth
{
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        // This will be triggered when the user presses the "Save" button.
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var currentPassword = CurrentPasswordEntry.Text;
            var newPassword = NewPasswordEntry.Text;
            var confirmPassword = ConfirmPasswordEntry.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            if (newPassword != confirmPassword)
            {
                await DisplayAlert("Error", "New password and confirmation do not match", "OK");
                return;
            }

            // Call your service or logic to change the password here
            // Example: await UserService.ChangePassword(currentPassword, newPassword);

            await DisplayAlert("Success", "Password updated successfully", "OK");

            // Optionally navigate back
            await Shell.Current.GoToAsync("..");
        }
    }
}
