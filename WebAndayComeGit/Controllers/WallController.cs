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
    public class WallController : BasicController
    {
        // GET: Wall
        public ActionResult Index()
        {
            SessionInitialize(); //si navegamos entre distintas clases es necesario
            ComentariosCAD comentariosCAD = new ComentariosCAD(session);
            ComentariosCEN comentariosCEN = new ComentariosCEN(comentariosCAD);

            IList<ComentariosEN> listEN = comentariosCEN.ReadAll(0, -1);
            IEnumerable<CommentViewModel> listComment = new CommentAssembler().ConvertListENToModel(listEN).ToList();

            SessionClose();
            return View(listComment);
        }

        // GET: Wall/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wall/Create
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

        // GET: Wall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wall/Edit/5
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

        // GET: Wall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wall/Delete/5
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
