using System.Collections.ObjectModel;
using ecommerce_app.Models;
namespace ecommerce_app.Pages.Auth
{
    public partial class Settings : ContentPage
    {
        // Observable collection to hold the settings items
        public ObservableCollection<SettingItem> SettingsItems { get; set; }

        public Settings()
        {
             InitializeComponent();

            // Initialize the settings items
            SettingsItems = new ObservableCollection<SettingItem>
            {
                new SettingItem { Name = "Edit Profile", Icon = "right_chevron.png" },
                new SettingItem { Name = "Change Password", Icon = "right_chevron.png" },
                new SettingItem { Name = "Privacy Settings", Icon = "right_chevron.png" },
                new SettingItem { Name = "Notifications", Icon = "right_chevron.png" },
                new SettingItem { Name = "Logout", Icon = "right_chevron.png" }
            };

            // Bind the settings items to the CollectionView
            BindingContext = this;
        }

        // Handle item selection from the settings list
        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedItem = e.CurrentSelection[0] as SettingItem;

                if (selectedItem != null)
                {
                    // Example: Navigate to a new page based on the selected setting
                    switch (selectedItem.Name)
                    {
                        case "Edit Profile":
                            await Navigation.PushAsync(new ChangePasswordPage());
                            break;
                        case "Change Password":
                            await Navigation.PushAsync(new ChangePasswordPage());
                            break;
                        case "Logout":
                            // Handle logout logic
                            break;
                        default:
                            break;
                    }
                }

                // Unselect the item after the selection
                ((CollectionView)sender).SelectedItem = null;
            }
        }

       
        
    }
}
