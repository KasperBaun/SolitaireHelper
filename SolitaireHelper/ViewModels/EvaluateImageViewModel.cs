using System;
using System.Diagnostics;
using Xamarin.Forms;
using SolitaireHelper.Services;

namespace SolitaireHelper.ViewModels
{
    [QueryProperty(nameof(Photo), nameof(Photo))]
    public class EvaluateImageViewModel : BaseViewModel
    {
        private ImageStore ImageStore { get; set; }
        private ImageSource photo;
        public ImageSource Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
                LoadPhoto(value);
            }
        }

        public async void LoadPhoto(ImageSource photo)
        {
            try
            {
                // Fetch photo
                var image = await ImageStore.GetImageAsync(photo);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Image");
            }
        }
    }
}