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
    internal class BuyersViewModel : ViewModel
    {
        private readonly IRepository<Buyer> buyersRepository;

        public BuyersViewModel(IRepository<Buyer> buyersRepository)
        {
            this.buyersRepository = buyersRepository;
        }
    }
}
