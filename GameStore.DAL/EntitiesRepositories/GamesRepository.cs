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
    internal class GamesRepository : DbRepository<Game>
    {
        public GamesRepository(GameStoreDB db) : base(db)
        { 
        
        }

        public override IQueryable<Game> Items => 
            base.Items.Include(item => item.Category).Include(item => item.Publicher);
    }
}
