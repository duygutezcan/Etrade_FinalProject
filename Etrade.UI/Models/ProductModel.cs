using Etrade.Entity.Concretes;

namespace Etrade.UI.Models
{
    public class ProductModel
    {
        public Products Products { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string imgUrl { get; set; }
        public int CategoryId { get; set; }
        public List<Categories> Categories { get; set; }
        public string Head { get; set; }
        public string Txt { get; set; }
        public string Cls { get; set; }
        public bool IncProducts { get; set; }
        public string IncMessage { get; set; }
    }
}

