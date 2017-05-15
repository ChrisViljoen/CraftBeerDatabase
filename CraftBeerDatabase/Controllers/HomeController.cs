using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CraftBeerDatabase.Models;

namespace CraftBeerDatabase.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private BeersDBEntities _db = new BeersDBEntities();
        public ActionResult Index()
        {
            return View(_db.Beers.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {           
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _db.AddBeer(collection["Brewery"], collection["Style"], collection["Name"], collection["Description"], Convert.ToDecimal(collection["ABV"]), Convert.ToInt32(collection["IBU"]));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var beer = (from b in _db.Beers
                        where b.Id == id
                        select b).First();
            return View(beer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _db.EditBeer(id, collection["Brewery"], collection["Style"], collection["Name"], collection["Description"], Convert.ToDecimal(collection["ABV"]), Convert.ToInt32(collection["IBU"]));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var beer = (from b in _db.Beers
                        where b.Id == id
                        select b).First();
            return View(beer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _db.RemoveBeer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}