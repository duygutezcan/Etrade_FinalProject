using Etrade.Dal;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryModel _model;
        TradeContext _db;
        //List<Category> _Category;
        public CategoryController(TradeContext db, CategoryModel model)
        {
            _model = model;
            _db = db;
            //_Category = Category;
        }
        public List<Categories> CreateList()
        {
            return _db.Set<Categories>().ToList();
        }

        public IActionResult List()
        {
            var clist = CreateList();
            return View(clist);
        }
        public IActionResult Create()
        {
            _model.Categories = new Categories();
            _model.Head = "New Entry";
            _model.Txt = "Save";
            _model.Cls = "btn btn-primary";
            // var x = CreateList().Max(x => x.Id) + 1;
            //_model.Categories.Id = CreateList().Max(x => x.Id) + 1;
            //_model.Category = new Category();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            _db.Set<Categories>().Add(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int Id)
        {
            _model.Categories = _db.Set<Categories>().Find(Id);
            _model.Head = "Update";
            _model.Txt = "Save";
            _model.Cls = "btn btn-success";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(CategoryModel model)
        {
            _db.Set<Categories>().Update(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Categories = _db.Set<Categories>().Where(x => x.Id == Id).FirstOrDefault();
            _model.Head = "Delete";
            _model.Txt = "Delete";
            _model.Cls = "btn btn-danger";
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CategoryModel model)
        {

            _db.Set<Categories>().Remove(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Detail(int Id)
        {
            var cat = _db.Set<Categories>().FirstOrDefault();
            return View(cat);
        }
    }
}
