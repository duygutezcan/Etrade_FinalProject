using Etrade.Dal;
using Etrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.UW
{
    public class UnitOfWork : IUnitOfWork
    {
        TradeContext _db;
        public UnitOfWork(TradeContext db,IOrdersRep ordersRep, IBasketDetailRep basketDetailRep, IBasketMasterRep basketMasterRep, ICategoriesRep categoriesRep, ICityRep cityRep, ICountyRep countyRep, IProductsRep productsRep, IUsersRep usersRep)
        {
            _db = db;
            _basketDetailRep = basketDetailRep;
            _basketMasterRep = basketMasterRep;
            _categoriesRep = categoriesRep;
            _cityRep = cityRep;
            _countyRep = countyRep;
            _productsRep = productsRep;
            _ordersRep = ordersRep;
            _usersRep = usersRep;
     
        }



        public IBasketDetailRep _basketDetailRep { get; set; }

        public IBasketMasterRep _basketMasterRep { get; set; }

        public ICategoriesRep _categoriesRep { get; set; }

        public ICityRep _cityRep { get; set; }

        public ICountyRep _countyRep { get; set; }

        public IProductsRep _productsRep { get; set; }

        public IUsersRep _usersRep { get; set; }

        public IOrdersRep _ordersRep { get; set; }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
