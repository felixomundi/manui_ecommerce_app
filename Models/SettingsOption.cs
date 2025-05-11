using System.Windows.Input;
namespace ecommerce_app.Models
{
    public class SettingsOption
    {
        public string Title { get; set; } = string.Empty;
        public ICommand? NavigateCommand { get; set; }
    }

}
