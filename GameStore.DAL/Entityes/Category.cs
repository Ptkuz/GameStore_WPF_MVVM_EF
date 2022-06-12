using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes.Base;

namespace GameStore.DAL.Entityes
{
    public class Category : NamedEntity
    {
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
