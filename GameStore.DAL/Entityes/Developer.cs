using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes.Base;

namespace GameStore.DAL.Entityes
{
    public class Developer : NamedEntity
    {
        public virtual Publicher Publicher { get; set; } = null!;
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
