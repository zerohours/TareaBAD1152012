using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class ArchivoController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Archivo/

        public ActionResult Index()
        {
            return View(_db.ArchivoSet.ToList());
        }

        //
        // GET: /Archivo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Archivo/Create

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
        // POST: /Archivo/Create

        [HttpPost]
        public ActionResult Create(Archivo archivoToCreate)
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

                    return View(archivoToCreate);
                }

                _db.AddToArchivoSet(archivoToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Archivo/Edit/5
 
        public ActionResult Edit(int id)
        {
            var archivoToEdit = (from m in _db.ArchivoSet

                                  where m.COD_EMPLEADO == id

                                  select m).First();

            return View(archivoToEdit);
        }

        //
        // POST: /Archivo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Archivo archivoToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalArch = (from m in _db.ArchivoSet

                                   where m.COD_EMPLEADO == archivoToEdit.COD_EMPLEADO

                                   select m).First();

                if (!ModelState.IsValid)

                    return View(originalArch);

                _db.ApplyCurrentValues(originalArch.EntityKey.EntitySetName, archivoToEdit);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Archivo/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Archivo/Delete/5

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
