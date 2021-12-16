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
    public class GiveawayController : BasicController
    {
        // GET: Giveaway
        public ActionResult Index()
        {
            SessionInitialize();
            GiveawayCAD giveawayCAD = new GiveawayCAD(session);
            GiveawayCEN giveawayCEN = new GiveawayCEN(giveawayCAD);
            IList<GiveawayEN> listaEN = giveawayCEN.ReadAll(0, -1);
            IEnumerable<GiveawayViewModel> gvm = new GiveawayAssembler().ConvertListENToModel(listaEN).ToList();
            SessionClose();

            return View(gvm);
        }

        // GET: Giveaway/Details/5
        public ActionResult Details(int id)
        {
            GiveawayEN giveawayEN = new GiveawayCEN().ReadOID(id);
            GiveawayViewModel gvm = new GiveawayAssembler().ConvertENToModelUI(giveawayEN);

            return View(gvm);
        }

        // GET: Giveaway/Create
        public ActionResult Create()
        {
            try
            {
                IList<ClientEN> listaClientes = new ClientCEN().ReadAll(0, -1);
                IList<SelectListItem> ClientesItems = new List<SelectListItem>();

                foreach (ClientEN cli in listaClientes)
                {
                    ClientesItems.Add(new SelectListItem { Text = cli.Name, Value = cli.Email });
                }

                ViewData["Clientes"] = ClientesItems;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Giveaway/Create
        [HttpPost]
        public ActionResult Create(GiveawayViewModel ga)
        {
            try
            {
                // TODO: Add insert logic here
                GiveawayCEN giveawayCEN = new GiveawayCEN();


                giveawayCEN.New_(ga.Precio,ga.Premium, ga.Premio);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Giveaway/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                IList<ClientEN> listaClientes = new ClientCEN().ReadAll(0, -1);
                IList<SelectListItem> ClientesItems = new List<SelectListItem>();

                foreach (ClientEN cli in listaClientes)
                {
                    ClientesItems.Add(new SelectListItem { Text = cli.Name, Value = cli.Email });
                }

                ViewData["Clientes"] = ClientesItems;

                GiveawayViewModel ga = null;
                SessionInitialize();
                GiveawayEN giveawayEN = new GiveawayCAD(session).ReadOIDDefault(id);
                ga = new GiveawayAssembler().ConvertENToModelUI(giveawayEN);
                SessionClose();

                return View(ga);
            }
            catch
            {
                return View();
            }
        }

        // POST: Giveaway/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GiveawayViewModel ga)
        {
            try
            {
                // TODO: Add insert logic here
                GiveawayCEN giveawayCEN = new GiveawayCEN();


                giveawayCEN.Modify(id,ga.Precio, ga.Premium, ga.Premio);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Giveaway/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                GiveawayCAD giveawayCAD = new GiveawayCAD(session);
                GiveawayCEN giveawayCEN = new GiveawayCEN(giveawayCAD);
                GiveawayEN giveawayEN = giveawayCEN.ReadOID(id);
                GiveawayViewModel gvm = new GiveawayAssembler().ConvertENToModelUI(giveawayEN);
                SessionClose();

                return View(gvm);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Giveaway/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GiveawayViewModel ga)
        {
            try
            {
                // TODO: Add delete logic here
                new GiveawayCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
