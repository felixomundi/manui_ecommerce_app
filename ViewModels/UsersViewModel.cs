using System.Collections.ObjectModel;
using System.Diagnostics;
using ecommerce_app.Models;
using ecommerce_app.Services;
namespace ecommerce_app.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ObservableCollection<User> Users { get; } = new();

        public UsersViewModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task LoadUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Users.Clear();

                var users = await _userService.GetUsersAsync();
                foreach (var user in users)
                    Users.Add(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to load users.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
