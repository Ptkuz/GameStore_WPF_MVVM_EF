using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GameStore.Interfaces;
using GameStore.DAL.Entityes;
using GameStore.DAL.EntitiesRepositories;

namespace GameStore.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<Buyer>, DbRepository<Buyer>>()
            .AddTransient<IRepository<Deal>, DealsRepository>()
            .AddTransient<IRepository<Developer>, DevelopersRepository>()
            .AddTransient<IRepository<Game>, GamesRepository>()
            .AddTransient<IRepository<Publicher>, DbRepository<Publicher>>()
            .AddTransient<IRepository<Seller>, DbRepository<Seller>>()
            ;


    }
}
