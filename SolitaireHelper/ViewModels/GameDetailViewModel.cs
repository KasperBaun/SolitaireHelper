using SolitaireHelper.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolitaireHelper.ViewModels
{
    [QueryProperty(nameof(GameId), nameof(GameId))]
    public class GameDetailViewModel : BaseViewModel
    {
        private string gameId;
        private string player;
        private string date;
        public string Id { get; set; }

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

        public string GameId
        {
            get
            {
                return gameId;
            }
            set
            {
                gameId = value;
                LoadGameId(value);
            }
        }

        public async void LoadGameId(string gameId)
        {
            try
            {
                var game = await DataStore.GetGameAsync(gameId);
                Id = game.Id;
                Player = game.Player;
                Date = game.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Game");
            }
        }
    }
}
