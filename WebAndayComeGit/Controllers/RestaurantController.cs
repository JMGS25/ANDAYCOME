using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.CP.AndayCome;
using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAndayCome.Models;
using WebAndayCome.Assemblers;
using System.IO;

namespace WebAndayCome.Controllers
{
    public class RestaurantController : BasicController
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            SessionInitialize(); //si navegamos entre distintas clases es necesario
            RestaurantCAD restaurantCAD = new RestaurantCAD(session);
            RestaurantCEN restaurantCEN = new RestaurantCEN(restaurantCAD);

            IList<RestaurantEN> listEN = restaurantCEN.ReadAll(0, -1);
            IEnumerable<RestaurantViewModel> listViewModel = new RestaurantAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View(listViewModel);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            RestaurantViewModel res = null;
            SessionInitialize();
            RestaurantEN resEN = new RestaurantCAD(session).ReadOIDDefault(id);
            res = new RestaurantAssembler().ConvertENToModelUI(resEN);
            SessionClose();
            return View(res);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            SessionInitialize();
            try
            {

                
                IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
                IList<SelectListItem> countryitems = new List<SelectListItem>();

                Restaurant_OwnerEN Propietario = new Restaurant_OwnerCEN().ReadOID("ib50@gmail.com"); //pasarle el valor de sesion aqui
                ViewData["propietario"] = Propietario.Email;

                foreach (CountryEN country in listaPaises)
                {
                    countryitems.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
                }

                ViewData["idPais"] = countryitems;
                SessionClose();
                return View();
            }
            catch
            {
                SessionClose();
                return View();
            }
           



        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(RestaurantViewModel res, HttpPostedFileBase file)
        {
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }

            try
            {
                fileName = "/Images/Uploads/" + fileName;
                RestaurantCEN cen = new RestaurantCEN();
                cen.New_(res.Propietario, res.IdPais, res.Menu, res.Photo, fileName, res.Street, res.Capacity); //valores de prueba para restaurantOwner y country

                return RedirectToAction("Detail", new { id = res.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            RestaurantViewModel res = null;
            SessionInitialize();
            RestaurantEN artEN = new RestaurantCAD(session).ReadOIDDefault(id);
            res = new RestaurantAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(res);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(RestaurantViewModel res)
        {
            try
            {
                RestaurantCEN cen = new RestaurantCEN();
                cen.Modify(res.Id, res.Menu, res.Photo, res.Name, res.Street, res.Capacity);

                return RedirectToAction("Details", new { id = res.Id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                int idCategoria = -1;
                SessionInitialize();
                RestaurantCAD resCAD = new RestaurantCAD(session);
                RestaurantCEN cen = new RestaurantCEN(resCAD);
                RestaurantEN resEN = cen.ReadOID(id);
                RestaurantViewModel res = new RestaurantAssembler().ConvertENToModelUI(resEN);
                idCategoria = res.Id;
                SessionClose();

                new RestaurantCEN().Destroy(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Restaurant/Delete/5
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
