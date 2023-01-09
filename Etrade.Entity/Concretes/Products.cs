using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entity.Concretes
{
    public class Products : BaseDescription
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        public ICollection<BasketDetail> BasketDetails { get; set; }

        public int Stock { get; set; }
        public bool isApproved { get; set; }

        public bool isHome { get; set; }
        public string imgUrl { get; set; }
    }
}
