using Etrade.Core;
using Etrade.Dal;
using Etrade.Entity.Concretes;
using Etrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Repos.Concretes
{
    public class CountyRep<T> : BaseRepository<County>, ICountyRep where T : class
    {
        public CountyRep(TradeContext db) : base(db)
        {
        }
    }
}
