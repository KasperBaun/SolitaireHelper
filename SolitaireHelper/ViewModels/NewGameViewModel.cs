using SolitaireHelper.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using SolitaireHelperModels;

namespace SolitaireHelper.ViewModels
{
    public class NewGameViewModel : BaseViewModel
    {
        private string date = DateTime.Today.Date.ToShortDateString();
        private string gameType = "7-Kabale";
        public event PropertyChangedEventHandler PropertyChanged;

        public NewGameViewModel()
        {
            Title = "New Game";
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            TakePictureCommand = new Command(OnTakePicture);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private async void OnSave()
        {
            string player = NewGamePage.PlayerName;
            Game game = new Game() { Player = player, Date = date, GameType = gameType, Id = Guid.NewGuid().ToString(), GameIsFinished = false };
            await DataStore.AddGameAsync(game);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnTakePicture(/*object sender, EventArgs e*/)
        {
            await Shell.Current.GoToAsync($"{nameof(CameraPage)}");
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
