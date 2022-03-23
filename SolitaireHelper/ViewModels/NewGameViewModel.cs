using SolitaireHelper.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace SolitaireHelper.ViewModels
{
    public class NewGameViewModel : BaseViewModel
    {
        private string player = "Kasper";
        private string date = DateTime.Today.Date.ToShortDateString();
        private string gameType = "7-Kabale";
        private Game game;
        private string photoPath;

        public NewGameViewModel()
        {
            Title = "New Game";
            game = new Game() { Player = player, Date = date, GameType = gameType, Id = Guid.NewGuid().ToString() };

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            TakePictureCommand = new Command(OnTakePicture);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {photoPath}");
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

        private async Task LoadPhotoAsync(FileResult photo)
        {
            // Cancelled
            if (photo == null)
            {
                photoPath = null;
                return;
            }
            // Save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }

        public string PhotoPath
        {
            get => photoPath;
            set => photoPath = value;
        }


        public string Player
        {
            get => player;
            set => SetProperty(ref player, value);
        }

        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string GameType
        {
            get => gameType;
            set => SetProperty(ref gameType, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command TakePictureCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            await DataStore.AddGameAsync(game);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnTakePicture(/*object sender, EventArgs e*/)
        {
            Console.WriteLine("Virker det?");
            await TakePhotoAsync();

        }


    }
}
