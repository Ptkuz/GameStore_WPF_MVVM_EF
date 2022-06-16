using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;


namespace GameStore_EF_MVVM.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellerRepository;
        private readonly IRepository<Deal> dealRepository;


        #region Количество книг
        private int gamesCount;
        public int GamesCount
        {
            get
            {
                return gamesCount;
            }
            set
            {
                Set(ref gamesCount, value);
            }
        }
        #endregion

        #region Вычислить статистические данные
        private ICommand computeStatisticCommand;

        public ICommand ComputeStatisticCommand => computeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecutedAsync, CanComputeStatisticCommand);

        private bool CanComputeStatisticCommand(object? arg) => true;


        private async Task OnComputeStatisticCommandExecutedAsync(object? obj)
        {
            GamesCount = await gamesRepository.Items.CountAsync();

            var deals = dealRepository.Items;

            var bestsellers = await deals.GroupBy(deal => deal.Game)
                  .Select(game_deals => new { Game = game_deals.Key, Count = game_deals.Count() })
                  .OrderByDescending(game => game.Count)
                  .Take(5)
                  .ToArrayAsync();

        }
        #endregion



        public StatisticViewModel
            (
            IRepository<Game> gamesRepository,
            IRepository<Buyer> buyersRepository,
            IRepository<Seller> sellerRepository,
            IRepository<Deal> dealRepository
            )
        {
            this.gamesRepository = gamesRepository;
            this.buyersRepository = buyersRepository;
            this.sellerRepository = sellerRepository;
            this.dealRepository = dealRepository;
        }


    }
}
