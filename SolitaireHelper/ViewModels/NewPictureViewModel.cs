using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SolitaireHelper.ViewModels
{
    public class NewPictureViewModel : BaseViewModel
    {
        private ImageSource _imageSource;
        public NewPictureViewModel()
        {
            Title = "New Picture";
        }
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                //LoadImage(value);
            }
        }
        public async void LoadImage(ImageSource uri)
        {
            try
            {
                var image = "";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load Image");
            }
        }
    }
}
