using Etrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.UW
{
    public interface IUnitOfWork
    {
        IBasketDetailRep _basketDetailRep { get; }
        IBasketMasterRep _basketMasterRep { get; }
        ICategoriesRep _categoriesRep { get; }
        ICityRep _cityRep { get; }
        ICountyRep _countyRep { get; }
        IProductsRep _productsRep { get; }
        IOrdersRep _ordersRep { get; }
        IUsersRep _usersRep { get; }
        
        void Commit();

    }
}

