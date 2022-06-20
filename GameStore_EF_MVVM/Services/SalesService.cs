using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore_EF_MVVM.Services.Interfaces;
using GameStore.Interfaces;
using GameStore.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

namespace GameStore_EF_MVVM.Services
{
    internal class SalesService : ISalesService
    {
        private readonly IRepository<Game> games;
        private readonly IRepository<Deal> deals;

        public IEnumerable<Deal> Deals => deals.Items;

        public SalesService(IRepository<Game> games, IRepository<Deal> deals) 
        {
            this.games = games;
            this.deals = deals;
        }


        public async Task<Deal> MakeADeal(string gameName, Seller seller, Buyer buyer, decimal price) 
        { 
            var game = await games.Items.FirstOrDefaultAsync(x => x.Name == gameName).ConfigureAwait(false);
            if (game is null) return null;

            var deal = new Deal()
            {
                DateTime = DateTime.Now,
                Game = game,
                Seller = seller,
                Buyer = buyer,
                Price = price
            };

           return await deals.AddAsync(deal); 

        }
        
    }
}
