using Etrade.Core;
using Etrade.Dal;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.Repos.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Repos.Concretes
{

    public class ProductsRep<T> : BaseRepository<Products>, IProductsRep where T : class
    {
        public ProductsRep(TradeContext db) : base(db)
        {

        }
        public Products FindWithVar(int Id)
        {
            // lazy loading
            return Set().Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<ProductsDTO> GetProductsSelect()
        {
            return Set().Select(x => new ProductsDTO { Id = x.Id, ProductName = x.ProductName }).ToList();
        }
    }
}
