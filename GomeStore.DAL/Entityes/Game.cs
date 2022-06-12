using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GomeStore.DAL.Entityes.Base;


namespace GomeStore.DAL.Entityes
{
    public class Game : NamedEntity
    {
        public virtual Category Category { get; set; } = null!;
    }
}
