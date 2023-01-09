using Etrade.Dal;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Etrade.UI.Controllers
{
    public class HomeController : Controller
    {
        TradeContext _db;
        ProductModel _model;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TradeContext db, ProductModel model)
        {
            _logger = logger;
            _db = db;
            _model = model;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Msg(string Msg)
        {
            ViewBag.Msg = Msg;
            return View();
        }
    }
}