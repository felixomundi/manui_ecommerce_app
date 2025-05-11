
using ecommerce_app.Models;
using System.Collections.ObjectModel;
using ecommerce_app.Pages.Auth;
namespace ecommerce_app.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ObservableCollection<SettingsOption> SettingsOptions { get; } = new();

        public SettingsViewModel()
        {
            SettingsOptions.Add(new SettingsOption
            {
                Title = "Change Password",
                NavigateCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ChangePasswordPage)))
            });

            SettingsOptions.Add(new SettingsOption
            {
                Title = "Notification Settings",
                NavigateCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(NotificationSettingsPage)))
            });

            SettingsOptions.Add(new SettingsOption
            {
                Title = "Privacy",
                NavigateCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(PrivacyPage)))
            });
        }
    }
}
