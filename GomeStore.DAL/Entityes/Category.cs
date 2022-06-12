using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GomeStore.DAL.Entityes.Base;

namespace GomeStore.DAL.Entityes
{
    public class Category : NamedEntity
    {
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
