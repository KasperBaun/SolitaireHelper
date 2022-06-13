using System;
using System.Collections.Generic;
using System.Linq;
using SolitaireHelperModels;
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
                new Game { Id = Guid.NewGuid().ToString(), Player = "Kasper", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" },
                new Game { Id = Guid.NewGuid().ToString(), Player = "Reza", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" },
                new Game { Id = Guid.NewGuid().ToString(), Player = "Annika", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" },
                new Game { Id = Guid.NewGuid().ToString(), Player = "Rikke", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" },
                new Game { Id = Guid.NewGuid().ToString(), Player = "Daniel", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" },
                new Game { Id = Guid.NewGuid().ToString(), Player = "Rikke", Date = DateTime.Today.Date.ToShortDateString(), GameType = "7-kabale" }
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