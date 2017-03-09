using MVCtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {
        private Models.ShopDBEntities db = new Models.ShopDBEntities();
        public ActionResult Index()
        {
            var Items = db.Planets;
            return View(Items);
        }
        public ActionResult PlanetPage(int item_id)
        {
            var Item = db.Planets.FirstOrDefault(x => x.Id == item_id);
            if(Item == null)
            {
                return Content("<h1>Page is not found</h1>");
            }
            return View(Item);
        }
        [HttpGet]
        public ActionResult Form(int item_id = 0)
        {
            ViewBag.Item = item_id;
            return PartialView();
        }
        public string FormOptions(int item_id = 0)
        {
            var Items = db.Planets;
            string str = "";
            foreach (var item in Items)
            {
                if (item_id == item.Id)
                {
                    str += "<option value=" + item.Id + " selected>" + item.Title + "</options>";
                }
                else
                {
                    str += "<option value=" + item.Id + ">" + item.Title + "</options>";
                }
            }
            return str;
             

        }
        [HttpPost]
        public string Form(string Name, string Tel, int Planet)
        {
            Order order = new Order
            {
                UserName = Name,
                UserTel = Tel,
                PlanetId = Planet,
                Status = "Created"
            };
            db.Orders.Add(order);
            db.SaveChanges();
            return "Your order on planet " + db.Planets.FirstOrDefault(x => x.Id == Planet).Title + " has been accepted!";
        }
      
    }
}