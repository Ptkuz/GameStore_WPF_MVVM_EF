using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GomeStore.DAL.Entityes.Base
{
    public abstract class Person : NamedEntity
    {
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
    }
}
