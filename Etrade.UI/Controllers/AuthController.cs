using Etrade.Dal;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;

namespace Etrade.UI.Controllers
{
    public class AuthController : Controller
    {
        UsersModel _model;
        TradeContext _db;
        public AuthController(TradeContext db, UsersModel model)
        {
            _db = db;
            _model = model;
        }

        public Users CreateUser(Users u)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == u.Mail);
            if (selectedUser == null)
            {
                u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
                u.Error = false;
            }
            else { u.Error = true; }
            return u;

        }
        public UserDTO User_Login(string username, string password)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == username);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            UserDTO user = new UserDTO();
            if (selectedUser != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(password, selectedUser.Password);
                if (verified == true)
                {
                    user.Id = selectedUser.Id;
                    user.Mail = selectedUser.Mail;
                    user.Role = selectedUser.Role;
                    user.Error = false;
                    user.imgUrl = selectedUser.imgUrl;

                }
                else
                {
                    user.Error = true;
                }
            }
            else
            {
                user.Error = true;
            }

            return user;
        }
        public IActionResult Register()
        {
            _model.User = new Users();
            _model.Counties = _db.Set<County>().ToList();
            return View(_model);
        }

        [HttpPost]

        public IActionResult Register(UsersModel? m)
        {
            Users u = new Users();
            m.User = CreateUser(m.User);
            if (m.User.Error == true)
            {

                m.Counties = _db.Set<County>().ToList();
                m.Error = $"{m.User.Mail} mail adresiyle kayıtlı bir kullanıcı mevcut!";
                return View(m);

            }
            else
            {

                m.User.Role = "User";
                _db.Set<Users>().Add(m.User);
                _db.SaveChanges();
                return RedirectToAction("Msg", "Home", new { Msg = $"{m.User.Mail} Kullanıcı başarıyla kayıt edilmiştir." });
            }

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Mail, string Password)
        {
            var usr = User_Login(Mail, Password);
            if (usr.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(usr));
                if (usr.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin", new { id = usr.Id, mail = usr.Mail, img = usr.imgUrl });
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
