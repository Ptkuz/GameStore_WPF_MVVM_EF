using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using GameStore_EF_MVVM.Models;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<BestSellerInfo> BestSellers { get; } = new ObservableCollection<BestSellerInfo>();


        #region Вычислить статистические данные
        private ICommand computeStatisticCommand;

        public ICommand ComputeStatisticCommand => computeStatisticCommand
            ??= new LambdaCommandAsync(OnComputeStatisticCommandExecutedAsync, CanComputeStatisticCommand);

        private bool CanComputeStatisticCommand(object? arg) => true;


        private async Task OnComputeStatisticCommandExecutedAsync(object? obj)
        {
            await ComputeDealsStatisticAsync();

        }
        private async Task ComputeDealsStatisticAsync()
        {
            var bestsellers_query = dealRepository.Items
                .GroupBy(b => b.Game.Id)
                .Select(deals => new
                {
                    GameId = deals.Key,
                    Count = deals.Count(),
                    Sum = deals.Sum(d => d.Price)
                })
                .OrderByDescending(deals => deals.Count)
                .Take(5)
                .Join(gamesRepository.Items,
                deals => deals.GameId,
                games => games.Id,
                (deal, game) => new BestSellerInfo
                {
                    Game = game,
                    Publicher = game.Developer.Publicher,
                    SellCount = deal.Count,
                    SumCost = deal.Sum
                }
                );



            BestSellers.Clear();
            foreach (var bestseller in await bestsellers_query.ToArrayAsync())
                BestSellers.Add(bestseller);
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
