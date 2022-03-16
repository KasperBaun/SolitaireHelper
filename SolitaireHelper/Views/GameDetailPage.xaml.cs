using SolitaireHelper.ViewModels;
using System.ComponentModel;
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