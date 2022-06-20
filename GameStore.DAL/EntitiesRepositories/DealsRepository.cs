using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Context;
using GameStore.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.EntitiesRepositories
{
    internal class DealsRepository : DbRepository<Deal>
    {
        public DealsRepository(GameStoreDB db) : base(db)
        {

        }

        public override IQueryable<Deal> Items =>
            base.Items.Include(item => item.Seller).Include(item => item.Buyer).Include(item => item.Game);
    }
}
