using Etrade.DTO;

namespace Etrade.UI.Models
{
    public class BasketDetailModel
    {
        public List<ProductsDTO> ProductsDTO { get; set; }
        public List<BasketDetailDTO> basketDetailDTO { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitId { get; set; }
        public int Amount { get; set; }
    }
}
