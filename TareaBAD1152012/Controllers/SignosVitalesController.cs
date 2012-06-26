using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class SignosVitalesController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /SignosVitales/

        public ActionResult Index()
        {
            return View(_db.SignosVitalesSet.ToList());
        }

        //
        // GET: /SignosVitales/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SignosVitales/Create

        public ActionResult Create()
        {

            var query = _db.ExpedienteSet.Select(c => new
            {
                NUM_EXPEDIENTE = c.NUM_EXPEDIENTE,
                PRIMER_NOMBRE = c.PACIENTE.PERSONA.PRIMER_NOMBRE + " " + c.PACIENTE.PERSONA.PRIMER_APELLIDO
            });

            ViewBag.NUM_EXPEDIENTE = new SelectList(query.AsEnumerable(), "NUM_EXPEDIENTE", "PRIMER_NOMBRE");

            return View();
        } 

        //
        // POST: /SignosVitales/Create

        [HttpPost]
        public ActionResult Create(SignosVitales signosToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {

                    var query = _db.ExpedienteSet.Select(c => new
                    {
                        NUM_EXPEDIENTE = c.NUM_EXPEDIENTE,
                        PRIMER_NOMBRE = c.PACIENTE.PERSONA.PRIMER_NOMBRE + " " + c.PACIENTE.PERSONA.PRIMER_APELLIDO
                    });

                    ViewBag.NUM_EXPEDIENTE = new SelectList(query.AsEnumerable(), "NUM_EXPEDIENTE", "PRIMER_NOMBRE");

                    return View(signosToCreate);
                }

                _db.AddToSignosVitalesSet(signosToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /SignosVitales/Edit/5
 
        public ActionResult Edit(int id)
        {
            var signosToEdit = (from m in _db.SignosVitalesSet

                                 where m.ID_SIGNOSV == id

                                 select m).First();

            return View(signosToEdit);
        }

        //
        // POST: /SignosVitales/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, SignosVitales signosToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalSig = (from m in _db.SignosVitalesSet

                                      where m.ID_SIGNOSV == signosToEdit.ID_SIGNOSV

                                      select m).First();

                if (!ModelState.IsValid)

                    return View(originalSig);

                _db.ApplyCurrentValues(originalSig.EntityKey.EntitySetName, signosToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SignosVitales/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SignosVitales/Delete/5

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
