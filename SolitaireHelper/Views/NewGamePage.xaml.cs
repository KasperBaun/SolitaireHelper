using SolitaireHelper.ViewModels;
using Xamarin.Forms;
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

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an image"
            });

            if(pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}