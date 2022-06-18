using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Services.Interfaces;

namespace GameStore_EF_MVVM.Services
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>services
            .AddTransient<ISalesService, SalesService>()
            .AddTransient<IUserDialog, UserDialogService>()
            ;
       
    }
}
