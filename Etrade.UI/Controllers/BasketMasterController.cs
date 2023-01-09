using Etrade.DTO;
using Etrade.Entity.Concretes;
using Etrade.UW;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Etrade.UI.Controllers
{
    public class BasketMasterController : Controller
    {
        IUnitOfWork _uow;
        BasketMaster _basketMaster;
        public BasketMasterController(IUnitOfWork uow, BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }
        public IActionResult Create(int id)
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));     //sepete ürün ekleyen kullanıcının Id sini çeker
            var selectedMaster = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == user.Id);
            if (selectedMaster != null)
            {
                return RedirectToAction("Add", "BasketDetail", new { Id = selectedMaster.Id, id2=id });
            }
            else
            {
                _basketMaster.EntityId = user.Id;
                _uow._basketMasterRep.Add(_basketMaster);
                _basketMaster.OrderDate = DateTime.Now;
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new { Id = _basketMaster.Id });
            }
        }
    }
}
