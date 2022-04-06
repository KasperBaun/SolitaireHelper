using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolitaireHelper.Views
{
    public partial class PictureConfirmationPage : ContentPage
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public PictureConfirmationPage()
        {
            InitializeComponent();
            this.BindingContext = new NewGameViewModel();
        }
    }
}

