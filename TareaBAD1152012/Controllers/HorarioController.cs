using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class HorarioController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Horario/

        public ActionResult Index()
        {
            return View(_db.HorarioSet.ToList());
        }

        //
        // GET: /Horario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Horario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Horario/Create

        [HttpPost]
        public ActionResult Create(Horario horarioToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)

                    return View(horarioToCreate);

                _db.AddToHorarioSet(horarioToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Horario/Edit/5
 
        public ActionResult Edit(int id)
        {
            var horarioToEdit = (from m in _db.HorarioSet

                                      where m.ID_HORARIO == id

                                      select m).First();

            return View(horarioToEdit);
        }

        //
        // POST: /Horario/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Horario horarioToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalHor = (from m in _db.HorarioSet

                                   where m.ID_HORARIO == horarioToEdit.ID_HORARIO

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalHor);

                _db.ApplyCurrentValues(originalHor.EntityKey.EntitySetName, horarioToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Horario/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Horario/Delete/5

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
