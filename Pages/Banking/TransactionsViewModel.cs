using System.Collections.ObjectModel;
using ecommerce_app.Models;
namespace ecommerce_app.Pages.Banking
{
    public class TransactionsViewModel : BaseViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        public TransactionsViewModel()
        {
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction { Description = "Netflix", Amount = "-9.99m" },
                new Transaction { Description = "Refund", Amount =" 25.00m" },
                new Transaction { Description = "Apple", Amount = "-2.50m" }
            };
        }
    }
}
