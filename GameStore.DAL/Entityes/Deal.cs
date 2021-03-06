using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes.Base;

namespace GameStore.DAL.Entityes
{
    public class Deal : Entity
    {
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Game Game { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
        public virtual Buyer Buyer { get; set; } = null!;
    }
}
