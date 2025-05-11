namespace ecommerce_app.Pages.Banking
{
    public partial class TransactionsPage : ContentPage
    {
        public TransactionsPage()
        {
            InitializeComponent();
            BindingContext = new TransactionsViewModel();
        }
    }
}
