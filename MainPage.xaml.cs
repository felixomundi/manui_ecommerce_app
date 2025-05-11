using System.Collections.ObjectModel;
using System.Windows.Input;
using ecommerce_app.Models;
using ecommerce_app.ViewModels;

namespace ecommerce_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel(); // Attach the ViewModel here
        }
    }
    
}
