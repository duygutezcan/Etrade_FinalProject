using Etrade.Dal;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductModel _model;
        TradeContext _db;

        public ProductController(TradeContext db, ProductModel model)
        {
            _model = model;
            _db = db;

        }
        public List<Products> CreateList()
        {
            return _db.Set<Products>().ToList();
        }

        public IActionResult List()
        {
            var urunler = _db.Set<Products>()
       .Where(i => i.isApproved)
       .Select(i => new Products()
       {
           Id = i.Id,
           ProductName = i.ProductName.Length > 50 ? i.ProductName.Substring(0, 30) + "..." : i.ProductName,
           Description = i.Description.Length > 50 ? i.Description.Substring(0, 30) + "..." : i.Description,
           UnitPrice = i.UnitPrice,
           Stock = i.Stock,
           imgUrl = i.imgUrl.Length > 50 ? i.imgUrl.Substring(0, 30) + "..." : i.imgUrl,
           CategoryId = i.CategoryId,
           isApproved = i.isApproved,
           isHome = i.isHome,

       }).ToList();
            return View(urunler);
        }
        public IActionResult Create()
        {
            _model.Products = new Products();
            _model.Head = "New Entry";
            _model.Txt = "Save";
            _model.Cls = "btn btn-primary";
            // var x = CreateList().Max(x => x.Id) + 1;
            //_model.Categories.Id = CreateList().Max(x => x.Id) + 1;
            //_model.Category = new Category();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            _db.Set<Products>().Add(model.Products);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int Id)
        {
            _model.Products = _db.Set<Products>().Find(Id);
            _model.Head = "Update";
            _model.Txt = "Save";
            _model.Cls = "btn btn-success";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            _db.Set<Products>().Update(model.Products);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Products = _db.Set<Products>().Where(x => x.Id == Id).FirstOrDefault();
            _model.Head = "Delete";
            _model.Txt = "Delete";
            _model.Cls = "btn btn-danger";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(ProductModel model)
        {

            _db.Set<Products>().Remove(model.Products);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Detail(int Id)
        {
            var cat = _db.Set<Products>().FirstOrDefault();
            return View(cat);
        }
    }
}
