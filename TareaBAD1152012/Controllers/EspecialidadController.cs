using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class EspecialidadController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Especialidad/

        public ActionResult Index()
        {
            return View(_db.EspecialidadSet.ToList());
        }

        //
        // GET: /Especialidad/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Especialidad/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Especialidad/Create

        [HttpPost]
        public ActionResult Create(Especialidad especialidadToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)

                    return View(especialidadToCreate);

                _db.AddToEspecialidadSet(especialidadToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Especialidad/Edit/5
 
        public ActionResult Edit(String id)
        {

            var especialidadToEdit = (from m in _db.EspecialidadSet

                                      where m.ID_ESPECIALIDAD == id

                                      select m).First();

            return View(especialidadToEdit);
        }

        //
        // POST: /Especialidad/Edit/5

        [HttpPost]
        public ActionResult Edit(String id, Especialidad especialidadToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalEsp = (from m in _db.EspecialidadSet

                                    where m.ID_ESPECIALIDAD == especialidadToEdit.ID_ESPECIALIDAD

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalEsp);

                _db.ApplyCurrentValues(originalEsp.EntityKey.EntitySetName, especialidadToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Especialidad/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Especialidad/Delete/5

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
