using Etrade.Core;
using Etrade.Dal;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Repos.Concretes
{
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {
        public BasketDetailRep(TradeContext db) : base(db)
        {
        }

        public List<BasketDetailDTO> BasketDetailDTOs(int MasterId)
        {
            return Set().Where(x => x.Id == MasterId).Select(x => new BasketDetailDTO
            {
                ProductName = x.Products.ProductName,
                ProductId = x.ProductId,
                Id = x.Id,
                Amount = x.Amount,
                UnitPrice = x.UnitPrice,
                Total = Decimal.Round((x.UnitPrice * x.Amount),2)
            }).ToList();
        }
    }
}
