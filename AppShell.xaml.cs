namespace ecommerce_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SendMoneyPage", typeof(Pages.Banking.SendMoneyPage));
            Routing.RegisterRoute("TransactionsPage", typeof(Pages.Banking.TransactionsPage));
        }
    }
}
