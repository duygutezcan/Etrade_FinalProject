using Etrade.Dal;
using Etrade.Entity.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class AdminController : Controller
    {
        TradeContext _db;
        public AdminController(TradeContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id, string mail, string img)
        {
            var user = new Users();
            user.Id = id;
            user.Mail = mail;
            ViewBag.mail = mail;
            ViewBag.url = img;
            return View();
        }
    }
}
