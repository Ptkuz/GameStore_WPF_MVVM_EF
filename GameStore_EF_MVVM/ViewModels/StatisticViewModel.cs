using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes;
using GameStore.Interfaces;
using MathCore.WPF.ViewModels;

namespace GameStore_EF_MVVM.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Buyer> buyersRepository;
        private readonly IRepository<Seller> sellerRepository;

        public StatisticViewModel(IRepository<Game> gamesRepository, IRepository<Buyer> buyersRepository, IRepository<Seller> sellerRepository)
        {
            this.gamesRepository = gamesRepository;
            this.buyersRepository = buyersRepository;
            this.sellerRepository = sellerRepository;
        }
    }
}
