using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameStore.DAL.Entityes;

namespace GameStore.DAL.Context
{
    public class GameStoreDB : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Developer> Developers { get; set; } = null!;
        public DbSet<Publicher> Publichers { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<Deal> Deals { get; set; } = null!;

        public GameStoreDB(DbContextOptions<GameStoreDB> options) : base(options)
        {
             
        
        }
    }
}
 