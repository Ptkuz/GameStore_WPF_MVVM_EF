using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Service;

namespace GameStore_EF_MVVM.Infrostructure.DebugServices
{
    internal class DebugGamesRemository : IRepository<Game>
    {


        public DebugGamesRemository()
        {
            var rnd = new Random();
            var games = Enumerable.Range(1, 100)
               .Select(i => new Game
               {
                   Id = i,
                   Name = $"Книга {i}",
                   ReleaseDate = Extentions.RandomDate(rnd),
                  
               }).ToArray();

            var categories = Enumerable.Range(1, 10)
                .Select(i => new Category 
                {
                    Id = i,
                    Name = $"Категория {i}"
                }).ToArray();

            var publicher = Enumerable.Range(1, 10)
              .Select(i => new Publicher
              {
                  Id = i,
                  Name = $"Издатель {i}"
              }).ToArray();

            var developers = Enumerable.Range(1, 10)
               .Select(i => new Developer
               {
                   Id = i,
                   Name = $"Разработчик {i}"
               }).ToArray();

            foreach (var game in games) 
            {
                var category = categories[game.Id % categories.Length];
                category.Games.Add(game);
                game.Category = category;   
            }

            Items = games.AsQueryable();
        }

        public IQueryable<Game> Items { get; }

        public Game Add(Game item)
        {
            throw new NotImplementedException();
        }

        public Task<Game> AddAsync(Game item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Game Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Game item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Game item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
