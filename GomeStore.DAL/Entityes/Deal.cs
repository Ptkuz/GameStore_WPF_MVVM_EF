using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GomeStore.DAL.Entityes.Base;

namespace GomeStore.DAL.Entityes
{
    public class Deal : Entity
    {
        public virtual Game Game { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
        public virtual Buyer Buyer { get; set; } = null!;
    }
}
