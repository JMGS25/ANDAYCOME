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
    public class RoutesController : BasicController
    {
        // GET: Routes
        public ActionResult Index()
        {
            SessionInitialize();
            RouteCAD routeCAD = new RouteCAD(session);
            RouteCEN routeCEN = new RouteCEN(routeCAD);
            IList<RouteEN> listaEN = routeCEN.ReadAll(0, -1);
            IEnumerable<RutasViewModel> rutasViewModel = new RutasAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(rutasViewModel);
        }
        public ActionResult PorCiudad( AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum id)
        {
            SessionInitialize();
            RouteCAD routeCAD = new RouteCAD(session);
            RouteCEN routeCEN = new RouteCEN(routeCAD);
            IList<RouteEN> listRouteEn = routeCEN.FilterByCity(id);
            IEnumerable<RutasViewModel> rutasViewModel = new RutasAssembler().ConvertListENToModel(listRouteEn).ToList();

            SessionClose();
            return View(rutasViewModel);
        }

        // GET: Routes/Details/5
        public ActionResult Details(int id)
        {
            RouteEN routeEN = new RouteCEN().ReadOID(id);
            RutasViewModel rvm = new RutasAssembler().ConvertENToModelUI(routeEN);

            return View(rvm);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            try
            {
                IList<RestaurantEN> listaRestaurantes = new RestaurantCEN().ReadAll(0, -1);
                IList<SelectListItem> restaurantesItems = new List<SelectListItem>();

                foreach (RestaurantEN rest in listaRestaurantes)
                {
                    restaurantesItems.Add(new SelectListItem { Text = rest.Name, Value = rest.Id.ToString() });
                }

                IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
                IList<SelectListItem> countryitems = new List<SelectListItem>();

                foreach (CountryEN country in listaPaises)
                {
                    countryitems.Add(new SelectListItem { Text = country.Id.ToString() , Value = country.Id.ToString() });
                }

                ViewData["idPais"] = countryitems;
                ViewData["idRestaurante"] = restaurantesItems;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Routes/Create
        [HttpPost]
        public ActionResult Create(RutasViewModel ruta)
        {
            try
            {
                // TODO: Add insert logic here
                RouteCEN routeCEN = new RouteCEN();

                routeCEN.New_("juanma25092001@gmail.com", ruta.IdPais,ruta.IdRestaurante, ruta.Start_date, ruta.End_date, ruta.Photo, ruta.Description, ruta.Name);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Routes/Edit/5
        public ActionResult Edit(int id)
        {

            IList<RestaurantEN> listaRestaurantes = new RestaurantCEN().ReadAll(0, -1);
            IList<SelectListItem> restaurantesItems = new List<SelectListItem>();

            foreach (RestaurantEN rest in listaRestaurantes)
            {
                restaurantesItems.Add(new SelectListItem { Text = rest.Name, Value = rest.Id.ToString() });
            }

            IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
            IList<SelectListItem> countryitems = new List<SelectListItem>();

            foreach (CountryEN country in listaPaises)
            {
                countryitems.Add(new SelectListItem { Text = country.Id.ToString(), Value = country.Id.ToString() });
            }

            ViewData["idPais"] = countryitems;
            ViewData["idRestaurante"] = restaurantesItems;

            RutasViewModel ruta = null;
            SessionInitialize();
            RouteEN routeEN = new RouteCAD(session).ReadOIDDefault(id);
            ruta = new RutasAssembler().ConvertENToModelUI(routeEN);
            SessionClose();

            return View(ruta);
        }

        // POST: Routes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RutasViewModel ruta)
        {
            try
            {
                RouteCEN cen = new RouteCEN();
                cen.Modify(ruta.Id,ruta.Start_date,ruta.End_date,ruta.Photo,ruta.Description,ruta.Name);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Routes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                RouteCAD routeCAD = new RouteCAD(session);
                RouteCEN cen = new RouteCEN(routeCAD);
                RouteEN routeEN = cen.ReadOID(id);
                RutasViewModel ruta = new RutasAssembler().ConvertENToModelUI(routeEN);
                SessionClose();

                return View(ruta);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Routes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RutasViewModel ruta)
        {
            try
            {
                // TODO: Add delete logic here
                new RouteCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
