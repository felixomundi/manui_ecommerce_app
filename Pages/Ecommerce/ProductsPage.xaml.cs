using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace ecommerce_app.Pages.Ecommerce
{
    public partial class ProductsPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductsPage()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Running Shoes", Price = "$49.99", ImageUrl = "https://unsplash.com/photos/train-travels-through-chicagos-urban-canyon-2RZTcCE-1LQ" },
                new Product { Name = "Smart Watch", Price = "$99.99", ImageUrl = "https://unsplash.com/photos/train-travels-through-chicagos-urban-canyon-2RZTcCE-1LQ" },
                new Product { Name = "Wireless Earbuds", Price = "$29.99", ImageUrl = "https://unsplash.com/photos/train-travels-through-chicagos-urban-canyon-2RZTcCE-1LQ" },
                new Product { Name = "Backpack", Price = "$39.99", ImageUrl = "https://unsplash.com/photos/train-travels-through-chicagos-urban-canyon-2RZTcCE-1LQ" },
                new Product { Name = "Fitness Tracker", Price = "$59.99", ImageUrl = "https://unsplash.com/photos/train-travels-through-chicagos-urban-canyon-2RZTcCE-1LQ" },
            };

            BindingContext = this;
        }

        public class Product
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
