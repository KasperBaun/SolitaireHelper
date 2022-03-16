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
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                Text = game.Text;
                Description = game.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Game");
            }
        }
    }
}
