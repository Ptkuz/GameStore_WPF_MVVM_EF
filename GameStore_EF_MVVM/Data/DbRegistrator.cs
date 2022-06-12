using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GameStore.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace GameStore_EF_MVVM.Data
{
    internal static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<GameStoreDB>(opt => 
            {
                string type = Configuration["Type"];
                switch (type) 
                {
                    case null:
                        throw new InvalidOperationException($"Не определен тип БД ");                      
                    case "MSSQL":
                        opt.UseSqlServer(Configuration.GetConnectionString(type));
                        break;

                    case "SQLite":
                        opt.UseSqlite(Configuration.GetConnectionString(type));
                        break;
                        default:
                        throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                       
                }
            
            })
            .AddTransient<DbInitializer>()
            ;

    }
}
