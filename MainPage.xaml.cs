// using System.Collections.ObjectModel;
// using System.Windows.Input;
// using ecommerce_app.Models;
// using ecommerce_app.ViewModels;

// namespace ecommerce_app
// {
//     public partial class MainPage : ContentPage
//     {
//         public MainPage()
//         {
//             InitializeComponent();
//             BindingContext = new DashboardViewModel(); // Attach the ViewModel here
//         }
//     }

// }


using ecommerce_app.ViewModels;
namespace ecommerce_app
{
    public partial class MainPage : ContentPage
    {
        private readonly DashboardViewModel _viewModel;

        public MainPage(DashboardViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadUsersAsync(); // Load users when page appears
        }
    }
}

