using SolitaireHelper.Models;
using SolitaireHelper.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolitaireHelper.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private Game _selectedGame;

        public ObservableCollection<Game> Games { get; }
        public Command LoadGamesCommand { get; }
        public Command AddGameCommand { get; }
        public Command<Game> GameTapped { get; }

        public HistoryViewModel()
        {
            Title = "History";
            Games = new ObservableCollection<Game>();
            LoadGamesCommand = new Command(async () => await ExecuteLoadGamesCommand());

            GameTapped = new Command<Game>(OnGameSelected);
        }

        async Task ExecuteLoadGamesCommand()
        {
            IsBusy = true;

            try
            {
                Games.Clear();
                var games = await DataStore.GetGamesAsync(true);
                foreach (var game in games)
                {
                    Games.Add(game);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedGame = null;
        }

        public Game SelectedGame
        {
            get => _selectedGame;
            set
            {
                SetProperty(ref _selectedGame, value);
                OnGameSelected(value);
            }
        }

        async void OnGameSelected(Game game)
        {
            if (game == null)
                return;

            // This will push the GameDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(GameDetailPage)}?{nameof(GameDetailViewModel.GameId)}={game.Id}");
        }
    }
}