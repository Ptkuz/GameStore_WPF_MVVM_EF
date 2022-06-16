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



        #region Вычислить статистические данные
        private ICommand computeStatisticCommand;

        public ICommand ComputeStatisticCommand => computeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecutedAsync, CanComputeStatisticCommand);

        private bool CanComputeStatisticCommand(object? arg) => true;


        private async Task OnComputeStatisticCommandExecutedAsync(object? obj)
        {

            var bestsellers_query = dealRepository.Items
                .GroupBy(b => b.Game.Id)
                .Select(deals => new { GameId = deals.Key, Count = deals.Count() })
                .OrderByDescending(deals => deals.Count)
                .Take(5)
                .Join(gamesRepository.Items,
                deals => deals.GameId,
                games => games.Id,
                (deal, game) => new { Game = game, deal.Count }
                );

            var bestsellers = await bestsellers_query.ToDictionaryAsync(deal => deal.Game.Name, deal => deal.Count);

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
