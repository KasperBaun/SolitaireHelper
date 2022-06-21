using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Essentials;
using System;

namespace SolitaireHelper.Views
{
    public partial class NewGamePage : ContentPage
    {

        private static string playerName;

        public static string PlayerName
        {
            get => playerName;
            set => playerName = value;
        }
        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
        public void GameSaved(object obj, EventArgs args)
        {
            playerName = entry_field.Text;
        }
    }
}