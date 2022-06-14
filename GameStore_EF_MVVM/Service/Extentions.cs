using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore_EF_MVVM.Service
{
    
        public static class Extentions
        {
            public static DateTime RandomDate(Random random)
            {
                DateTime start = new DateTime(2000, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }
        }
    
}
