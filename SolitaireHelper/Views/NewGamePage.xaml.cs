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
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an image"
            });

            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}