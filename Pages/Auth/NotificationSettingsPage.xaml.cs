namespace ecommerce_app.Pages.Auth
{
    public partial class NotificationSettingsPage : ContentPage
    {
        public NotificationSettingsPage()
        {
            InitializeComponent();
        }
        // This will handle toggling the notification switch.
        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            var isToggled = e.Value;
           
        }
    }
}
