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
    public class ClientController : BasicController
    {
        // GET: Client
        public ActionResult Index()
        {
            SessionInitialize();
            ClientCAD clientCAD = new ClientCAD(session);
            ClientCEN clientCEN = new ClientCEN(clientCAD);
            IList<ClientEN> listaEN = clientCEN.ReadAll(0, -1);
            IEnumerable<ClientViewModel> cvm = new ClientAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(cvm);
        }

        // GET: Client/Details/5
        public ActionResult Details(string email)
        {
            ClientEN clientEN = new ClientCEN().ReadOID(email);
            ClientViewModel cvm = new ClientAssembler().ConvertENToModelUI(clientEN);

            return View(cvm);
        }

        // GET: Client/Create
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

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            try
            {
                // TODO: Add insert logic here
                ClientCEN clientCEN = new ClientCEN();


                clientCEN.New_(client.Telefono, client.Photo, client.Pass, client.IdPais, client.Email, client.Lang, client.Name,client.Premium);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(string email)
        {

            IList<CountryEN> listaPaises = new CountryCEN().ReadAll(0, -1);
            IList<SelectListItem> countryitems = new List<SelectListItem>();

            foreach (CountryEN country in listaPaises)
            {
                countryitems.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            }

            ViewData["idPais"] = countryitems;

            ClientViewModel client = null;
            SessionInitialize();
            ClientEN clientEN = new ClientCAD(session).ReadOIDDefault(email);
            client = new ClientAssembler().ConvertENToModelUI(clientEN);
            SessionClose();

            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(string email, ClientViewModel client)
        {
            try
            {
                ClientCEN cen = new ClientCEN();
                cen.Modify(email, client.Telefono, client.Photo, client.Pass, client.Lang, client.Name,client.Premium);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(string email)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                ClientCAD clientCAD = new ClientCAD(session);
                ClientCEN clientCEN = new ClientCEN(clientCAD);
                ClientEN clientEN = clientCEN.ReadOID(email);
                ClientViewModel client = new ClientAssembler().ConvertENToModelUI(clientEN);
                SessionClose();

                return View(client);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(string email, ClientViewModel client)
        {
            try
            {
                // TODO: Add delete logic here
                new ClientCEN().Destroy(email);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
