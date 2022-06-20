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
    internal class DevelopersRepository : DbRepository<Developer>
    {
        public DevelopersRepository(GameStoreDB db) : base(db)
        {

        }

        public override IQueryable<Developer> Items =>
            base.Items.Include(item => item.Publicher);
    }
}
