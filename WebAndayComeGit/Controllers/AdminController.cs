using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.EN.AndayCome;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAndayCome.Assembler;
using WebAndayCome.Models;

namespace WebAndayCome.Controllers
{
    public class AdminController : BasicController
    {
        // GET: Routes
        public ActionResult Index()
        {
            SessionInitialize();
            AdminCAD adminCAD = new AdminCAD(session);
            AdminCEN adminCEN = new AdminCEN(adminCAD);
            IList<AdminEN> listaEN = adminCEN.ReadAll(0, -1);
            IEnumerable<AdminViewModel> adminViewModel = new AdminAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(adminViewModel);
        }

        // GET: Routes/Details/5
        public ActionResult Details(string email)
        {
            AdminEN adminEN = new AdminCEN().ReadOID(email);
            AdminViewModel avm = new AdminAssembler().ConvertENToModelUI(adminEN);

            return View(avm);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            try
            {
                    

                IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
                IList<SelectListItem> countryitems = new List<SelectListItem>();

                foreach (CountryEN country in listaPaises)
                {
                    countryitems.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
                }

                ViewData["idPais"] = countryitems;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Routes/Create
        [HttpPost]
        public ActionResult Create(AdminViewModel admin)
        {
            try
            {
                // TODO: Add insert logic here
                AdminCEN adminCEN = new AdminCEN();


                adminCEN.New_(admin.Telefono, admin.Photo, admin.Pass, admin.IdPais,admin.Email, admin.Lang, admin.Name);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(string email)
        {


            IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
            IList<SelectListItem> countryitems = new List<SelectListItem>();

            foreach (CountryEN country in listaPaises)
            {
                countryitems.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            }

            ViewData["idPais"] = countryitems;

            AdminViewModel admin = null;
            SessionInitialize();
            AdminEN adminEN = new AdminCAD(session).ReadOIDDefault(email);
            admin = new AdminAssembler().ConvertENToModelUI(adminEN);
            SessionClose();

            return View(admin);
        }

        // POST: Routes/Edit/5
        [HttpPost]
        public ActionResult Edit(string email, AdminViewModel admin)
        {
            try
            {
                AdminCEN cen = new AdminCEN();
                cen.Modify(email, admin.Telefono, admin.Photo, admin.Pass, admin.Lang, admin.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(string email)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                AdminCAD adminCAD= new AdminCAD(session);
                AdminCEN cen = new AdminCEN(adminCAD);
                AdminEN adminEN = cen.ReadOID(email);
                AdminViewModel admin = new AdminAssembler().ConvertENToModelUI(adminEN);
                SessionClose();

                return View(admin);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Routes/Delete/5
        [HttpPost]
        public ActionResult Delete(string email, AdminViewModel admin)
        {
            try
            {
                // TODO: Add delete logic here
                new AdminCEN().Destroy(email);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
