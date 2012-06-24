using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class DoctorController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            return View(_db.DoctorSet.ToList());
        }

        //
        // GET: /Doctor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Doctor/Create

        public ActionResult Create()
        {

            var query = _db.PersonaSet.Select(c => new {
                ID_PERSONA = c.ID_PERSONA,
                PRIMER_NOMBRE = c.PRIMER_NOMBRE +" "+ c.PRIMER_APELLIDO
            });

            ViewBag.ID_PERSONA = new SelectList(query.AsEnumerable(), "ID_PERSONA", "PRIMER_NOMBRE");

            return View();
        } 

        //
        // POST: /Doctor/Create

        [HttpPost]
        public ActionResult Create(Doctor doctorToCreate)
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

                    return View(doctorToCreate);
                }

                _db.AddToDoctorSet(doctorToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Doctor/Edit/5
 
        public ActionResult Edit(int id)
        {
            var doctorToEdit = (from m in _db.DoctorSet

                                 where m.JVPM_DOC == id

                                 select m).First();

            return View(doctorToEdit);
        }

        //
        // POST: /Doctor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Doctor doctorToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalDoct = (from m in _db.DoctorSet

                                      where m.JVPM_DOC == doctorToEdit.JVPM_DOC

                                      select m).First();

                if (!ModelState.IsValid)

                    return View(originalDoct);

                _db.ApplyCurrentValues(originalDoct.EntityKey.EntitySetName, doctorToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Doctor/Delete/5
 
        public ActionResult Delete(int id)
        {
            var doctorToDelete = (from m in _db.DoctorSet

                                   where m.JVPM_DOC == id

                                   select m).First();

            return View(doctorToDelete);
        }

        //
        // POST: /Doctor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Doctor doctorToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var doctorDelete = (from m in _db.DoctorSet

                                     where m.JVPM_DOC == id

                                     select m).First();

                _db.DeleteObject(doctorDelete);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
