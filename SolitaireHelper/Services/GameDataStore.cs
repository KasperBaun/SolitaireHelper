using SolitaireHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolitaireHelper.Services
{
    public class GameDataStore : IDataStore<Game>
    {
        readonly List<Game> games;

        public GameDataStore()
        {
            games = new List<Game>()
            {
                new Game { Id = Guid.NewGuid().ToString(), Text = "First game", Description="This is a game description." },
                new Game { Id = Guid.NewGuid().ToString(), Text = "Second game", Description="This is a game description." },
                new Game { Id = Guid.NewGuid().ToString(), Text = "Third game", Description="This is a game description." },
                new Game { Id = Guid.NewGuid().ToString(), Text = "Fourth game", Description="This is a game description." },
                new Game { Id = Guid.NewGuid().ToString(), Text = "Fifth game", Description="This is a game description." },
                new Game { Id = Guid.NewGuid().ToString(), Text = "Sixth game", Description="This is a game description." }
            };
        }

        public async Task<bool> AddGameAsync(Game game)
        {
            games.Add(game);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            var oldItem = games.Where((Game arg) => arg.Id == game.Id).FirstOrDefault();
            games.Remove(oldItem);
            games.Add(game);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteGameAsync(string id)
        {
            var oldItem = games.Where((Game arg) => arg.Id == id).FirstOrDefault();
            games.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Game> GetGameAsync(string id)
        {
            return await Task.FromResult(games.FirstOrDefault(g => g.Id == id));
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(games);
        }
    }
}