using ecommerce_app.ViewModels;

namespace ecommerce_app.Pages.Auth
{
    public partial class UsersPage : ContentPage
    {
        private readonly UsersViewModel _viewModel;

        public UsersPage(UsersViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadUsersAsync();
        }
    }
}
