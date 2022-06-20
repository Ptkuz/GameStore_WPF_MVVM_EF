using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes;

namespace GameStore_EF_MVVM.Models
{
    internal class BestSellerInfo
    {
        public Game Game { get; set; } = null!;
        public Publicher Publicher { get; set; } = null!;
        public int SellCount { get; set; }
        public decimal SumCost { get; set; }
    }
}
