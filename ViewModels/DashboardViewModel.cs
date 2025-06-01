using System.Collections.ObjectModel;
using System.Windows.Input;
using ecommerce_app.Models;
using ecommerce_app.Services;
namespace ecommerce_app.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        public ObservableCollection<Transaction> Transactions { get; }

        public ICommand SendMoneyCommand { get; }
        public ICommand ViewAllCommand { get; }

        private const string SendMoneyRoute = "SendMoneyPage";
        private const string TransactionsPage = "TransactionsPage";
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        public DashboardViewModel(UserService userService)
        {
            _userService = userService;
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
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        public async Task LoadUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;
                Users.Clear();

                var usersFromApi = await _userService.GetUsersAsync();
                foreach (var user in usersFromApi)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading users: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

