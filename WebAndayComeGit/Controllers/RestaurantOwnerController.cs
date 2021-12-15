using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAndayCome.Controllers
{
    public class RestaurantOwnerController : BasicController
    {
        // GET: RestaurantOwner
        public ActionResult Index()
        {
            Restaurant_OwnerCEN restOwnerCEN = new Restaurant_OwnerCEN();
            List<Restaurant_OwnerEN> lista = restOwnerCEN.ReadAll(0, 2).ToList();
            return View(lista);
        }

        // GET: RestaurantOwner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantOwner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantOwner/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantOwner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantOwner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantOwner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantOwner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
