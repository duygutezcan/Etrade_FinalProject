using Etrade.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entity.Concretes
{
    public class BasketMaster : IBaseTable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int EntityId { get; set; }
        public bool Completed { get; set; }      //sepet tamalandığında boş sepet getirmek için
        public ICollection<BasketDetail> BasketDetails { get; set; }
        [ForeignKey("EntityId")]             // EntityId Users daki Id ile eşleşiyor
        public Users Users { get; set; }
    }
}
