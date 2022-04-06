using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolitaireHelper.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}