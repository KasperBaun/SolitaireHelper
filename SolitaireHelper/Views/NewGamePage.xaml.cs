using SolitaireHelper.Models;
using SolitaireHelper.ViewModels;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class NewGamePage : ContentPage
    {
        public Game game { get; set; }

        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
    }
}