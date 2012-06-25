using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class AntecedentesPersonalesController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /AntecedentesPersonales/

        public ActionResult Index()
        {
            return View(_db.AntecedentesPersonalesSet.ToList());
        }

        //
        // GET: /AntecedentesPersonales/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AntecedentesPersonales/Create

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
        // POST: /AntecedentesPersonales/Create

        [HttpPost]
        public ActionResult Create(AntecedentesPersonales antecedentesToCreate)
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

                    return View(antecedentesToCreate);
                }

                _db.AddToAntecedentesPersonalesSet(antecedentesToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /AntecedentesPersonales/Edit/5
 
        public ActionResult Edit(int id)
        {
            var antecedentesToEdit = (from m in _db.AntecedentesPersonalesSet

                                      where m.ID_ANTECEDENTES == id

                                     select m).First();

            return View(antecedentesToEdit);
        }

        //
        // POST: /AntecedentesPersonales/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, AntecedentesPersonales antecedentesToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalAnt = (from m in _db.AntecedentesPersonalesSet

                                   where m.ID_ANTECEDENTES == antecedentesToEdit.ID_ANTECEDENTES

                                   select m).First();

                if (!ModelState.IsValid)

                    return View(originalAnt);

                _db.ApplyCurrentValues(originalAnt.EntityKey.EntitySetName, antecedentesToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AntecedentesPersonales/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AntecedentesPersonales/Delete/5

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
