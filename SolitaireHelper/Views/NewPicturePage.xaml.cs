using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolitaireHelper.Views
{
    public partial class NewPicturePage : ContentPage
    {
  
        public NewPicturePage()
        {
            BackgroundColor = Color.PowderBlue;
            BindingContext = new NewPictureViewModel();

            var image = new Image
            {
                Source = ""
            };
            image.SetBinding(Image.SourceProperty, "ImageSource");
        }
    }
}

