using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class LaboratoristaController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Laboratorista/

        public ActionResult Index()
        {
            return View(_db.LaboratoristaSet.ToList());
        }

        //
        // GET: /Laboratorista/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Laboratorista/Create

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
        // POST: /Laboratorista/Create

        [HttpPost]
        public ActionResult Create(Laboratorista laboratoristaToCreate)
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

                    return View(laboratoristaToCreate);
                }

                _db.AddToLaboratoristaSet(laboratoristaToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Laboratorista/Edit/5
 
        public ActionResult Edit(int id)
        {
            var laboratoristaToEdit = (from m in _db.LaboratoristaSet

                                 where m.JVPM_LAB == id

                                 select m).First();

            return View(laboratoristaToEdit);
        }

        //
        // POST: /Laboratorista/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Laboratorista laboratoristaToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalLab = (from m in _db.LaboratoristaSet

                                    where m.JVPM_LAB == laboratoristaToEdit.JVPM_LAB

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalLab);

                _db.ApplyCurrentValues(originalLab.EntityKey.EntitySetName, laboratoristaToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Laboratorista/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Laboratorista/Delete/5

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
