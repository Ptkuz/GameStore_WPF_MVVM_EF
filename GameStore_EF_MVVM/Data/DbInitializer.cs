using GameStore.DAL.Entityes;
using GameStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Service;
using System.Threading;
using System.Diagnostics;

namespace GameStore_EF_MVVM.Data
{
    internal class DbInitializer
    {
        private readonly GameStoreDB db;
        private readonly ILogger<DbInitializer> logger;

        public DbInitializer(GameStoreDB Db, ILogger<DbInitializer> logger)
        {
            this.db = Db;
            this.logger = logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация БД...");

            logger.LogInformation("Удаление существующей БД...");
            await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            logger.LogInformation($"Удаление выполнено за {0} мс", timer.ElapsedMilliseconds);


            logger.LogInformation($"Миграция БД...");
            await db.Database.MigrateAsync().ConfigureAwait(false);
            logger.LogInformation($"Миграция выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await db.Games.AnyAsync())
                return;

            await InitializeCategoriesAsync();
            await InitializePublichersAsync();
            await InitializeDevelopersAsync();
            await InitializeGamesAsync();
            await InitializeBuyersAsync();
            await InitializeSellersAsync();
            await InitializeDealsAsync();

            logger.LogInformation($"Инициализация выполнена за {0} с", timer.Elapsed.TotalSeconds);

        }

        private const int categoryCount = 10;
        private Category[] Categories;

        private async Task InitializeCategoriesAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация категорий");
            Categories = new Category[categoryCount];
            for (int i = 0; i < categoryCount; i++) 
            {
                Categories[i] = new Category{Name = $"Категория {i + 1}"};  
            }
            await db.Categories.AddRangeAsync(Categories);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация категорий выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int publishersCount = 10;
        private Publicher[] Publichers;

        private async Task InitializePublichersAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация издателей");
            Publichers = new Publicher[publishersCount];
            for (int i = 0; i < publishersCount; i++)
            {
                Publichers[i] = new Publicher { Name = $"Издатель {i + 1}" };
            }
            await db.Publichers.AddRangeAsync(Publichers);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация издателей выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }


        private const int developersCount = 10;
        private Developer[] Developers;

        private async Task InitializeDevelopersAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация разработчиков");
            var rnd = new Random();

            Developers = new Developer[developersCount];
            for (int i = 0; i < developersCount; i++)
            {
                Developers[i] = new Developer 
                { 
                    Name = $"Разработчик {i + 1}",
                    Publicher = rnd.NextItem(Publichers)
                };
                
            }
            await db.Developers.AddRangeAsync(Developers);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация разработчиков выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }



        private const int gamesCount = 10;
        private Game[] Games;

        private async Task InitializeGamesAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация игр");
            var rnd = new Random();

            Games = Enumerable.Range(1, gamesCount)
                .Select(i=> new Game 
                { 
                    ReleaseDate = Extentions.RandomDate(rnd),
                    Name = $"Игра {i}",
                    Category = rnd.NextItem(Categories)

                })
                .ToArray();

            await db.Games.AddRangeAsync(Games);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация игр выполнена за {0} с", timer.Elapsed.TotalSeconds);

        }

        private const int sellersCount = 10;
        private Seller[] Sellers;

        private async Task InitializeSellersAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация продавцов");
            var rnd = new Random();

            Sellers = new Seller[sellersCount];
            for (int i = 0; i < sellersCount; i++)
            {
                Sellers[i] = new Seller
                {
                    Name = $"Продавец Имя {i + 1}",
                    Surname = $"Продавец Фамилия {i+1}",
                    Patronymic = $"Продавец Отчество {i+1}"

                    
                };

            }
            await db.Sellers.AddRangeAsync(Sellers);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация продавцов выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }


        private const int buyersCount = 10;
        private Buyer[] Buyers;

        private async Task InitializeBuyersAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация покупателей");
            var rnd = new Random();

            Buyers = new Buyer[buyersCount];
            for (int i = 0; i < buyersCount; i++)
            {
                Buyers[i] = new Buyer
                {
                    Name = $"Покупатель Имя {i + 1}",
                    Surname = $"Покупатель Фамилия {i + 1}",
                    Patronymic = $"Покупатель Отчество {i + 1}"


                };

            }
            await db.Sellers.AddRangeAsync(Sellers);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация покупателей выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }


        private const int dealsCount = 1000;
        private Deal[] Deals;
        private async Task InitializeDealsAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация сделок");
            var rnd = new Random();

            for (int i = 0; i<dealsCount; i++) 
            {
                Deals[i] = new Deal 
                {
                    Price = (decimal)rnd.NextDouble(100, 2000),
                    DateTime = DateTime.Now,
                    Game = rnd.NextItem(Games),
                    Seller = rnd.NextItem(Sellers),
                    Buyer = rnd.NextItem(Buyers)
                };
                //Thread.Sleep(1000);
            }

            await db.Deals.AddRangeAsync(Deals);
            await db.SaveChangesAsync();
            logger.LogInformation($"Инициализация сделок выполнена за {0} с", timer.Elapsed.TotalSeconds);

        }
    }
}
