using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class HoraCitaController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /HoraCita/

        public ActionResult Index()
        {
            return View(_db.HoraCitaSet.ToList());
        }

        //
        // GET: /HoraCita/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /HoraCita/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /HoraCita/Create

        [HttpPost]
        public ActionResult Create(HoraCita horacitaToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)

                    return View(horacitaToCreate);

                _db.AddToHoraCitaSet(horacitaToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /HoraCita/Edit/5
 
        public ActionResult Edit(int id)
        {
            var horacitaToEdit = (from m in _db.HoraCitaSet

                                      where m.ID_HORA_CITA == id

                                      select m).First();

            return View(horacitaToEdit);
        }

        //
        // POST: /HoraCita/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, HoraCita horacitaToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalHor = (from m in _db.HoraCitaSet

                                   where m.ID_HORA_CITA == horacitaToEdit.ID_HORA_CITA

                                   select m).First();

                if (!ModelState.IsValid)

                    return View(originalHor);

                _db.ApplyCurrentValues(originalHor.EntityKey.EntitySetName, horacitaToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HoraCita/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /HoraCita/Delete/5

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
