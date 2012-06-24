using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class ExpedienteController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Expediente/

        public ActionResult Index()
        {
            return View(_db.ExpedienteSet.ToList());
        }

        //
        // GET: /Expediente/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Expediente/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Expediente/Create

        [HttpPost]
        public ActionResult Create(Expediente expedienteToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)

                    return View(expedienteToCreate);

                _db.AddToExpedienteSet(expedienteToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Expediente/Edit/5
 
        public ActionResult Edit(int id)
        {
            var expedienteToEdit = (from m in _db.ExpedienteSet

                                      where m.NUM_EXPEDIENTE == id

                                      select m).First();

            return View(expedienteToEdit);
        }

        //
        // POST: /Expediente/Edit/5

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

        //
        // GET: /Expediente/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Expediente/Delete/5

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
