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
    public class CommentController : BasicController
    {
        // GET: Comment
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

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            CommentViewModel com = null;
            SessionInitialize();
            ComentariosEN comentariosEN = new ComentariosCAD(session).ReadOIDDefault(id);
            com = new CommentAssembler().ConvertENToModelUI(comentariosEN);
            SessionClose();
            return View(com);

        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentViewModel comment)
        {
            try
            {
                // TODO: Add insert logic here
                ComentariosCEN comentariosCEN = new ComentariosCEN();

                comentariosCEN.New_(comment.Content,comment.Client,comment.Date);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            CommentViewModel com = null;
            SessionInitialize();
            ComentariosEN artEN = new ComentariosCAD(session).ReadOIDDefault(id);
            com = new CommentAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(com);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(CommentViewModel com)
        {
            try
            {
                ComentariosCEN cen = new ComentariosCEN();
                cen.Modify(com.Id,com.Content,com.Date);

                return RedirectToAction("Details", new { id = com.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            ComentariosCAD ComentariosCAD = new ComentariosCAD(session);
            ComentariosCEN cen = new ComentariosCEN(ComentariosCAD);
            ComentariosEN ComentariosEN = cen.ReadOID(id);
            CommentViewModel comment = new CommentAssembler().ConvertENToModelUI(ComentariosEN);
            SessionClose();

            return View(comment);
         
        }

        // POST: Comment/Delete/5
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
