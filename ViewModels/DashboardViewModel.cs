using System.Collections.ObjectModel;
using System.Windows.Input;
using ecommerce_app.Models;

namespace ecommerce_app.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; }

        public ICommand SendMoneyCommand { get; }
        public ICommand ViewAllCommand { get; }

        private const string SendMoneyRoute = "SendMoneyPage";
        private const string TransactionsPage = "TransactionsPage";

        public DashboardViewModel()
        {
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction { Description = "Starbucks", Amount = "4.50m", IsCredit = false },
                new Transaction { Description = "Paycheck", Amount = "1500.00m", IsCredit = true },
                new Transaction { Description = "Uber", Amount = "15.75m", IsCredit = false },
                new Transaction { Description = "Starbucks Two", Amount = "4.50m", IsCredit = false },
                new Transaction { Description = "Paycheck One", Amount = "1500.00m", IsCredit = true },
                new Transaction { Description = "Uber Two", Amount = "15.75m", IsCredit = false }
            };

            SendMoneyCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(SendMoneyRoute);
            });

            ViewAllCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(TransactionsPage);
            });
        }
    }
}
