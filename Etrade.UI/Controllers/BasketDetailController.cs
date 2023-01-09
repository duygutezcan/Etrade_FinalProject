using Etrade.Dal;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.UI.Models;
using Etrade.UW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Linq;

namespace ETrade.Ul.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetail _basketDetail;
        IUnitOfWork _uow;
        BasketDetailModel _basketDetailModel;
        TradeContext _db;
        OrdersModel _ordersModel;
        public BasketDetailController(BasketDetail basketDetail, IUnitOfWork uow, BasketDetailModel basketDetailModel, TradeContext db, OrdersModel ordersModel)
        {
            _basketDetail = basketDetail;
            _uow = uow;
            _basketDetailModel = basketDetailModel;
            _db = db;
            _ordersModel = ordersModel;
        }

        public IActionResult List(int x)
        {
            _basketDetailModel.ProductsDTO = _uow._productsRep.GetProductsSelect();
            _basketDetailModel.basketDetailDTO = _uow._basketDetailRep.BasketDetailDTOs(x);
            return View(_basketDetailModel);
        }
  
        public IActionResult Add(BasketDetailModel m, int id2, int Id)
        {
            Products products = _uow._productsRep.FindWithVar(id2);
            BasketDetail basketDetail = _db.Set<BasketDetail>().Where(x => x.Id == Id && x.ProductId == id2).FirstOrDefault();
            if(basketDetail == null)
            {
                _basketDetail.Amount = m.Amount + 1;
                _basketDetail.ProductId = id2;
                _basketDetail.Id = Id;
                _basketDetail.UnitPrice = products.UnitPrice;
                _uow._basketDetailRep.Add(_basketDetail);
                _uow.Commit();
            }
            else
            {
                basketDetail.Amount += 1;
              
                _uow._basketDetailRep.Update(basketDetail);
                _uow.Commit();
            }

            
            _uow.Commit();


            return RedirectToAction("List", new {x = Id});
        }

        public IActionResult Delete(int Id, int id2)
        {

            _uow._basketDetailRep.Delete(Id, id2);
            _uow.Commit();
            return RedirectToAction("List", new { x = Id });
        }
        public IActionResult List2()
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));     
            var selectedMaster = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == user.Id);
            _basketDetailModel.ProductsDTO = _uow._productsRep.GetProductsSelect();
            _basketDetailModel.basketDetailDTO = _uow._basketDetailRep.BasketDetailDTOs(selectedMaster.Id);
            return View(_basketDetailModel);
        }

        public IActionResult Orders()
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedUser = _uow._usersRep.Find(user.Id);
            _ordersModel.Orders = new Orders();
            _ordersModel.Counties = _uow._countyRep.List();
            ViewBag.id = selectedUser.Id;
            ViewBag.mail=selectedUser.Mail;
            ViewBag.avenue=selectedUser.Avenue;
            ViewBag.street = selectedUser.Street;
            ViewBag.no= selectedUser.No;
            _ordersModel.Orders.UsersId=selectedUser.Id;
            return View(_ordersModel);
        }
        [HttpPost]
        public IActionResult Orders(Orders orders)
        {
            _uow._ordersRep.Add(orders);
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var master= _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == user.Id);
            master.Completed = true;
            _uow.Commit();
            return RedirectToAction("Completed");
        }

        public IActionResult Completed()
        {
            return View();
        }


        public ActionResult Basket()
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));   
            var selectedMaster = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == user.Id);
            ViewBag.Id = selectedMaster.Id;
            return View();
        }

    }
}


