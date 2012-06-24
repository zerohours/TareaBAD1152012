using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class PacienteController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Paciente/

        public ActionResult Index()
        {
            return View(_db.PacienteSet.ToList());
        }

        //
        // GET: /Paciente/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Paciente/Create

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
        // POST: /Paciente/Create

        [HttpPost]
        public ActionResult Create(Paciente pacienteToCreate)
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

                    return View(pacienteToCreate);
                }

                _db.AddToPacienteSet(pacienteToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Paciente/Edit/5
 
        public ActionResult Edit(int id)
        {
            var pacienteToEdit = (from m in _db.PacienteSet

                                where m.COD_PAC == id

                                select m).First();

            return View(pacienteToEdit);
        }

        //
        // POST: /Paciente/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Paciente pacienteToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalPac = (from m in _db.DoctorSet

                                    where m.JVPM_DOC == pacienteToEdit.COD_PAC

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalPac);

                _db.ApplyCurrentValues(originalPac.EntityKey.EntitySetName, pacienteToEdit);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Paciente/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Paciente/Delete/5

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
