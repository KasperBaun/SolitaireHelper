using SolitaireHelper.Views;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SolitaireHelperModels;
using SolitaireHelper.Services;

namespace SolitaireHelper.ViewModels
{
    public class NewGameViewModel : BaseViewModel
    {
        private string date = DateTime.Today.Date.ToShortDateString();
        private string gameType = "7-Kabale";
        private ImageSource imageURI;
        public event PropertyChangedEventHandler PropertyChanged;

        public NewGameViewModel()
        {
            
            Title = "New Game";
            CardDeck CardDeck = new CardDeck();
            CardDeck.PrintDeck();
            //Table Table = new Table(CardDeck.Deck);
            //Table.PrintDeck();
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            TakePictureCommand = new Command(OnTakePicture);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private async void OnSave()
        {
            string player = NewGamePage.PlayerName;
            Game game = new Game() { Player = player, Date = date, GameType = gameType, Id = Guid.NewGuid().ToString() };
            await DataStore.AddGameAsync(game);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnTakePicture(/*object sender, EventArgs e*/)
        {
            //await TakePhotoAsync();
            await Shell.Current.GoToAsync($"{nameof(CameraPage)}");
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {imageURI}");
                //await Shell.Current.GoToAsync("PictureConfirmationPage");

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
                imageURI = null;
                return;
            }
            // Save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            imageURI = newFile;
        }

        public ImageSource PhotoPath
        {
            get => imageURI;
            set
            {
                imageURI = value;
                var args = new PropertyChangedEventArgs(nameof(PhotoPath));
                PropertyChanged?.Invoke(this, args);
            }
        }




        public string Date
        {
            get => date;
            set
            {
                date = value;
                var args = new PropertyChangedEventArgs(nameof(Date));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string GameType
        {
            get => gameType;
            set
            {
                gameType = value;
                var args = new PropertyChangedEventArgs(nameof(GameType));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command TakePictureCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }



    }
}
