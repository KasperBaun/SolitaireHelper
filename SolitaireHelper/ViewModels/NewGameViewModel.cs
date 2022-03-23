using SolitaireHelper.Models;
using System;
using Xamarin.Forms;


namespace SolitaireHelper.ViewModels
{
    public class NewGameViewModel : BaseViewModel
    {
        private string player = "Kasper";
        private string date = DateTime.Today.Date.ToShortDateString();
        private string gameType = "7-Kabale";
        private Game game;

        public NewGameViewModel()
        {
            Title = "New Game";
            game = new Game() { Player = player, Date = date, GameType = gameType, Id = Guid.NewGuid().ToString() };

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

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
    }
}
