
using Etrade.Dal;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Etrade.UW;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETRADE.UL.Controllers
{
    public class UserController : Controller
    {
        TradeContext _db;
        IUnitOfWork _uow;

        public UserController(TradeContext db,IUnitOfWork uow)
        {
            _db = db;
            _uow = uow;
        }
        public IActionResult Index()
        {
            var products = _db.Set<Products>().Where(p => p.isHome == true && p.isApproved == true).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.ProductName.Length > 50 ? i.ProductName.Substring(0, 47) + "..." : i.ProductName,
                Description = i.Description.Length > 70 ? i.Description.Substring(0, 70) + "..." : i.Description,
                Price = (double)i.UnitPrice,
                Stock = i.Stock,
                imgUrl = i.imgUrl,
                CategoryId = i.CategoryId
            }).ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            return View(_db.Set<Products>().Where(i => i.Id == id).FirstOrDefault());
        }

        public ActionResult List(int? id)
        {

            var urunler = _db.Set<Products>()
                .Where(i => i.isApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.ProductName.Length > 50 ? i.ProductName.Substring(0, 47) + "..." : i.ProductName,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = (double)i.UnitPrice,
                    Stock = i.Stock,
                    imgUrl = i.imgUrl,
                    CategoryId = i.CategoryId,
                    Categories = new List<Categories>()

                }).AsQueryable();

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler);
        }
  
    }
}
