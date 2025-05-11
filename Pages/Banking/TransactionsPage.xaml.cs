using System.Collections.ObjectModel;
using ecommerce_app.Models;
namespace ecommerce_app.Pages.Banking
{
    public partial class TransactionsPage : ContentPage
    {
        public ObservableCollection<TransactionItem> Transactions { get; set; }

        public TransactionsPage()
        {
            InitializeComponent();

            Transactions = new ObservableCollection<TransactionItem>
            {
                new TransactionItem { Icon = "shopping.png", Category = "Groceries", TransactionCount = 3, Amount = "$120.00" },
                new TransactionItem { Icon = "truck.png", Category = "Transport", TransactionCount = 5, Amount = "$45.00" },
                new TransactionItem { Icon = "multimedia.png", Category = "Entertainment", TransactionCount = 2, Amount = "$80.00" },
                new TransactionItem { Icon = "utility.png", Category = "Utilities", TransactionCount = 4, Amount = "$200.00" },
            };

            BindingContext = this;
        }
        
    }

}
