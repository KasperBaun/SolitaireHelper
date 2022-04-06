using SolitaireHelper.Models;
using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace SolitaireHelper.Views
{
    public partial class NewGamePage : ContentPage
    {

        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
    }
}