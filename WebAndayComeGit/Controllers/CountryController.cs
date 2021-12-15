using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAndayCome.Assembler;
using WebAndayCome.Models;

namespace WebAndayCome.Controllers
{
    public class CountryController : BasicController
    {
        // GET: Country
        public ActionResult Index()
        {
            SessionInitialize();
            CountryCAD countryCAD = new CountryCAD(session);
            IList<CountryEN> listaEN = new CountryCEN(countryCAD).ReadAll(0, -1);
            IEnumerable<CountriesViewModels> countriesViewModel = new CountriesAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(countriesViewModel);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                // TODO: Add insert logic here
                SessionInitialize();
                CountryCAD countryCAD = new CountryCAD(session);
                CountryCEN cen = new CountryCEN(countryCAD);
                CountryEN countryEN = cen.ReadOID(id);
                CountriesViewModels countries = new CountriesAssembler().ConvertENToModelUI(countryEN);
                SessionClose();

//return View(ruta);
                return RedirectToAction("../Routes/PorCiudad/"+countries.Ciudad);
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
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

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
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

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
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
