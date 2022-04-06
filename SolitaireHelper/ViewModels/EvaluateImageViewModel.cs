using System;
using System.Diagnostics;
using Xamarin.Forms;
using SolitaireHelper.Services;

namespace SolitaireHelper.ViewModels
{
    [QueryProperty(nameof(Source), nameof(Source))]
    public class EvaluateImageViewModel : BaseViewModel
    {
        private ImageStore ImageStore { get; set; }
        public Image Photo { get; set; } = new Image() { Source = "template.png" };


        public string Source
        {
            get
            {
                return Source;
            }
            set
            {
                Source = value;
                LoadPhoto(value);
            }
        }

        public async void LoadPhoto(string path)
        {
            try
            {
                // Fetch photo
                Photo = await ImageStore.GetImageAsync(path);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Image");
            }
        }
    }
}