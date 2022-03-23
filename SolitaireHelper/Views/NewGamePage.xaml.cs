using SolitaireHelper.Models;
using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System;
using System.IO;

namespace SolitaireHelper.Views
{
    public partial class NewGamePage : ContentPage
    {
        public Game game { get; set; }
        protected string PhotoPath { get; set; }

        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
        async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
                Console.WriteLine($"CapturePhotoAsync THREW: {fnsEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
                Console.WriteLine($"CapturePhotoAsync THREW: {pEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // Cancelled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // Save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }


        private async void BtnOpenCamera_Clicked(object sender, EventArgs e)
        {
            await TakePhotoAsync();
            PhotoImage.Source = ImageSource.FromFile(PhotoPath);
        }
    }
}