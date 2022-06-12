using GameStore.DAL.Entityes;
using GameStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore_EF_MVVM.Data
{
    internal class DbInitializer
    {
        private readonly GameStoreDB db;
        private readonly ILogger<DbInitializer> logger;

        public DbInitializer(GameStoreDB Db, ILogger<DbInitializer> Logger)
        {
            this.db = Db;
            logger = Logger;
        }

        public async Task InitializeAsync()
        {
            await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            await db.Database.MigrateAsync().ConfigureAwait(false);

            if (await db.Games.AnyAsync())
                return;

        }

        private const int categoryCount = 10;
        private Category[] Categories;

        private async Task InitializeCategoriesAsync()
        {

            Categories = new Category[categoryCount];
            for (int i = 0; i < categoryCount; i++) 
            {
                Categories[i] = new Category{Name = $"Категория {i + 1}"};  
            }
            await db.Categories.AddRangeAsync(Categories);
            await db.SaveChangesAsync();
        }



        private const int gamesCount = 10;
        private Game[] Games;

        private async Task InitializeGamesAsync()
        {
            var rnd = new Random();

            Games = Enumerable.Range(1, gamesCount)
                .Select(i=> new Game 
                { 
                    Name = $"Игра {i}",
                    Category = rnd.NextItem(Categories)

                })
                .ToArray();

            await db.Games.AddRangeAsync(Games);
            await db.SaveChangesAsync();

        }
    }
}
