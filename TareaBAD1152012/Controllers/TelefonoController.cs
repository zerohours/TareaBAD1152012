using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class TelefonoController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Telefono/

        public ActionResult Index()
        {
            return View(_db.TelefonoSet.ToList());
        }

        //
        // GET: /Telefono/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Telefono/Create

        public ActionResult Create()
        {

            var query = _db.PersonaSet.Select(c => new
            {
                ID_PERSONA = c.ID_PERSONA,
                PRIMER_NOMBRE = c.PRIMER_NOMBRE + " " + c.PRIMER_APELLIDO
            });

            ViewBag.ID_PERSONA = new SelectList(query.AsEnumerable(), "ID_PERSONA", "PRIMER_NOMBRE");

            return View();
        } 

        //
        // POST: /Telefono/Create

        [HttpPost]
        public ActionResult Create(Telefono telefonoToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    var query = _db.PersonaSet.Select(c => new
                    {
                        ID_PERSONA = c.ID_PERSONA,
                        PRIMER_NOMBRE = c.PRIMER_NOMBRE + " " + c.PRIMER_APELLIDO
                    });

                    ViewBag.ID_PERSONA = new SelectList(query.AsEnumerable(), "ID_PERSONA", "PRIMER_NOMBRE");

                    return View(telefonoToCreate);
                }

                _db.AddToTelefonoSet(telefonoToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Telefono/Edit/5
 
        public ActionResult Edit(int id)
        {
            var telefonoToEdit = (from m in _db.TelefonoSet

                                   where m.ID_TELEFONO == id

                                   select m).First();

            return View(telefonoToEdit);
        }

        //
        // POST: /Telefono/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Telefono telefonoToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalTel = (from m in _db.TelefonoSet

                                    where m.ID_TELEFONO == telefonoToEdit.ID_TELEFONO

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalTel);

                _db.ApplyCurrentValues(originalTel.EntityKey.EntitySetName, telefonoToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Telefono/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Telefono/Delete/5

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
