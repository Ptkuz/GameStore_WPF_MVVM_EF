using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes;

namespace GameStore_EF_MVVM.Services.Interfaces
{
    internal interface ISalesService
    {
        public IEnumerable<Deal> Deals { get; }

        Task<Deal> MakeADeal(string gameName, Seller seller, Buyer buyer, decimal price);
    }
}
