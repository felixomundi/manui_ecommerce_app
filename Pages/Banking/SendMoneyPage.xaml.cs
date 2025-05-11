namespace ecommerce_app.Pages.Banking
{
    public partial class SendMoneyPage : ContentPage
    {
        public SendMoneyPage()
        {
            InitializeComponent();
            Shell.SetPresentationMode(this, PresentationMode.ModalAnimated);
        }
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(".."); 
        }
    }
}
