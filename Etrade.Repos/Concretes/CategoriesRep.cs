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
    public class CategoriesRep<T> : BaseRepository<Categories>, ICategoriesRep where T : class
    {
        public CategoriesRep(TradeContext db) : base(db)
        {
        }
    }
}
