using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;
using AndayComeGenNHibernate.CP.AndayCome;
using AndayComeGenNHibernate.EN.AndayCome;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAndayCome.Assembler;
using WebAndayCome.Models;

namespace WebAndayCome.Controllers
{
    public class BookingController : BasicController
    {
        // GET: Booking
        public ActionResult Index()
        {
            SessionInitialize();
            BookingCAD bookingCAD = new BookingCAD(session);
            BookingCEN bookingCEN = new BookingCEN(bookingCAD);
            IList<BookingEN> listaEN = bookingCEN.ReadAll(0, -1);
            IEnumerable<BookingViewModel> bookingViewModel = new BookingAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(bookingViewModel);
        }
         public ActionResult MisReservas(string email)
         {
             SessionInitialize();
             BookingCAD bookingCAD = new BookingCAD(session);
             BookingCEN bookingCEN = new BookingCEN(bookingCAD);
             IList<BookingEN> listaEN = bookingCEN.FilterByClient(email);
             IEnumerable<BookingViewModel> bookingViewModel = new BookingAssembler().ConvertListENToModel(listaEN).ToList();
             SessionClose();

             return View(bookingViewModel);
         }
        
         public ActionResult ComprobarReservas(string id)
         {
            
            SessionInitialize();
            BookingCAD bookingCAD = new BookingCAD(session);
             BookingCEN bookingCEN = new BookingCEN(bookingCAD);
             IList<BookingEN> listaEN = bookingCEN.FilterByRestaurant(id);
             IEnumerable<BookingViewModel> bookingViewModel = new BookingAssembler().ConvertListENToModel(listaEN).ToList();
             SessionClose();

             return View(bookingViewModel);
         }

        // GET: Routes/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            BookingEN bookingEN = new BookingCAD(session).ReadOID(id);
            BookingViewModel bvm = new BookingAssembler().ConvertENToModelUI(bookingEN);
            SessionClose();
            return View(bvm);
        }

        // GET: Booking/Create
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

                IList<RouteEN> listaRutas = new RouteCEN().ReadAll(0, -1);
                IList<SelectListItem> rutasItems = new List<SelectListItem>();

                foreach (RouteEN ruta in listaRutas)
                {
                    rutasItems.Add(new SelectListItem { Text = ruta.Name, Value = ruta.Id.ToString() });
                }

                IList<ClientEN> listaClientes = new ClientCEN().ReadAll(0, -1);
                IList<SelectListItem> clientesItems = new List<SelectListItem>();

                foreach (ClientEN cli in listaClientes)
                {
                    clientesItems.Add(new SelectListItem { Text = cli.Name, Value = cli.Email });
                }


                ViewData["idCliente"] = clientesItems;
                ViewData["idRuta"] = rutasItems;
                ViewData["idRestaurante"] = restaurantesItems;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create(BookingViewModel booking)
        {
            try
            {
                // TODO: Add insert logic here
                BookingCEN bookingCEN = new BookingCEN();
                BookingCP book = new BookingCP();
                //Corregir crear 
                //cambiar metood new para q acepte lista de id restaurante y lista id cliente
                //book.New_(booking.IdRestaurante, booking.IdCliente, booking.Date, booking.Hour, booking.Guest);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {

            IList<RestaurantEN> listaRestaurantes = new RestaurantCEN().ReadAll(0, -1);
            IList<SelectListItem> restaurantesItems = new List<SelectListItem>();

            foreach (RestaurantEN rest in listaRestaurantes)
            {
                restaurantesItems.Add(new SelectListItem { Text = rest.Name, Value = rest.Id.ToString() });
            }

            IList<RouteEN> listaRutas = new RouteCEN().ReadAll(0, -1);
            IList<SelectListItem> rutasItems = new List<SelectListItem>();

            foreach (RouteEN ruta in listaRutas)
            {
                rutasItems.Add(new SelectListItem { Text = ruta.Name, Value = ruta.Id.ToString() });
            }

            IList<ClientEN> listaClientes = new ClientCEN().ReadAll(0, -1);
            IList<SelectListItem> clientesItems = new List<SelectListItem>();

            foreach (ClientEN cli in listaClientes)
            {
                clientesItems.Add(new SelectListItem { Text = cli.Name, Value = cli.Email });
            }


            ViewData["idCliente"] = clientesItems;
            ViewData["idRuta"] = rutasItems;
            ViewData["idRestaurante"] = restaurantesItems;

            BookingViewModel book = null;
            SessionInitialize();
            BookingEN bookEN = new BookingCAD(session).ReadOIDDefault(id);
            book = new BookingAssembler().ConvertENToModelUI(bookEN);
            SessionClose();

            return View(book);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookingViewModel booking)
        {
            try
            {
                BookingCEN bookingCEN = new BookingCEN();
                bookingCEN.Modify(id, booking.Date, booking.Hour, booking.Guest);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                BookingCAD bookingCAD = new BookingCAD(session);
                BookingCEN bookingCEN = new BookingCEN(bookingCAD);
                BookingEN bookingEN = bookingCEN.ReadOID(id);
                BookingViewModel book = new BookingAssembler().ConvertENToModelUI(bookingEN);
                SessionClose();

                return View(book);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookingViewModel book)
        {
            try
            {
                // TODO: Add delete logic here
                new BookingCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
