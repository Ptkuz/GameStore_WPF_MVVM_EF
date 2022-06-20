using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entityes;
using GameStore.DAL.Entityes.Base;


namespace GameStore.DAL.Entityes
{
    public class Game : NamedEntity
    {
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual Developer Developer { get; set; } = null!;

    }
}
