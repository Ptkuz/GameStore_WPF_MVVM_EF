using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameStore_EF_MVVM.ViewModels;
using GameStore_EF_MVVM.Services;
using GameStore_EF_MVVM.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameStore_EF_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignTime { get; private set; } = true;


        private static IHost? host;
        public static IHost Host => host 
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddServices()
            .AddViewModels()
            .AddDatabase(host.Configuration.GetSection("Database"))
            
            ;


        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;

            var host = Host;

            using (var scope = Services.CreateScope()) 
            {
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            }

                base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (var host = Host) 
            {
                base.OnExit(e);
                await host.StopAsync();
            }
        }
    }
}
