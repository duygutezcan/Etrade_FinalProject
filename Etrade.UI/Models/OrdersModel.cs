using Etrade.Entity.Concretes;

namespace Etrade.UI.Models
{
    public class OrdersModel
    {
        public Orders Orders { get; set; }
        public List<County> Counties { get; set; }
        public List<Users> Users { get; set; }
    }
}
