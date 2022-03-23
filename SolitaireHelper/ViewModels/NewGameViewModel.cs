using SolitaireHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SolitaireHelper.ViewModels
{
    public class NewGameViewModel : BaseViewModel
    {
        private string player;
        private string date;
        private string gameType;

        public NewGameViewModel()
        {
            Title = "New Game";
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(player)
                && !String.IsNullOrWhiteSpace(date);
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

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Game newItem = new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Player = Player,
                Date = Date,
                GameType = GameType
            };

            await DataStore.AddGameAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
