using SolitaireHelper.ViewModels;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class GameDetailPage : ContentPage
    {
        public GameDetailPage()
        {
            InitializeComponent();
            BindingContext = new GameDetailViewModel();
        }
    }
}