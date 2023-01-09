using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entity.Concretes
{
    public class BasketDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }  //fiyatlar değişirse görmek için
        public int Amount { get; set; }
      
 
        [ForeignKey("Id")]
        public BasketMaster BasketMaster{ get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
