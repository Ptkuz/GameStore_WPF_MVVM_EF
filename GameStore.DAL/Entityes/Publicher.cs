using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes.Base;

namespace GameStore.DAL.Entityes
{
    public class Publicher : NamedEntity
    {

        public List<Developer> Developers { get; set; } = new List<Developer>();
    }
}
