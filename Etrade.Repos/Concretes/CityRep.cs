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
    public class CityRep<T> : BaseRepository<City>, ICityRep where T : class
    {
        public CityRep(TradeContext db) : base(db)
        {
        }
    }
}
